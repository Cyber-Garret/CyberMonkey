using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Cyber_Monkey_Studio
{
    public partial class MainForm : Form
    {
        string Mykey = "GPC_API_KEY";
        string betaUrl = "http://ua4.jooble.com:4080/GlobalControl";
        string prodUrl = "http://ua4.jooble.com:85/GlobalControl";
        string sqlite_conn = "Data Source=Monkey.db; Version=3;";
        string sql_conn = "Data Source=ua4.jooble.com;Persist Security Info=True;User ID=USER_ID;Password=USER_PASSWORD";

        public MainForm()
        {
            InitializeComponent();
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection c = new SQLiteConnection(sqlite_conn))
            {
                c.Open();
                string sql = "CREATE TABLE IF NOT EXISTS Projects(RowID INTEGER PRIMARY KEY ASC AUTOINCREMENT NOT NULL DEFAULT(1), Project_ID INTEGER, [Desc] TEXT);";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE UNIQUE INDEX IF NOT EXISTS idx_projects_Project_ID ON Projects(Project_ID)";
                    cmd.ExecuteNonQuery();
                }
            }
            UpdateProjectList();
        }

        //Метод для принятия сообщения и отображение в статус баре
        private void WriteToStatusBar(string Message)
        {
            //Пишем сообщение в статус бар
            StatusBar.Text = Message;
        }
        //Метод обновления списка проектов в выпадающем меню
        private void UpdateProjectList()
        {

            //Check whether the Drop Down has existing items. If YES, empty it.
            if (projectBox.Items.Count > 0)
                projectBox.Items.Clear();

            using (SQLiteConnection c = new SQLiteConnection(sqlite_conn))
            {
                c.Open();
                string sql = "select Project_ID from Projects where Project_ID";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                            projectBox.Items.Add(rdr[0].ToString());
                    }
                }
            }
        }
        //Метод для работы с Global Project Control API
        private static void Gpc_exec(string url, string apiKey, string apiAction, string apiProjectIds, string apiValue, out int gpc_message)
        {
            gpc_message = 0;

            var json = new { key = apiKey, action = apiAction, projectIds = apiProjectIds, value = apiValue };
            using (var client = new WebClientEx())
            {
                try {

                    var dataString = JsonConvert.SerializeObject(json);
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    client.UploadString(new Uri(url), "POST", dataString);
                    HttpStatusCode allOk = HttpStatusCode.OK;
                    if (allOk == HttpStatusCode.OK)
                    { 
                        gpc_message = 200;
                    }
                }
                catch(WebException ex)
                {
                    var webResponse = ex.Response as HttpWebResponse;
                    if (webResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        gpc_message = 400;
                    }
                    else if (webResponse.StatusCode == HttpStatusCode.Forbidden)
                    {
                        gpc_message = 403;
                    }
                    else if (webResponse.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        gpc_message = 500;
                    }
                    else
                    {
                        gpc_message = 500;
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string prodAction = "CreateBackup";
                string prodProjects = projectBox.SelectedItem.ToString();
                string prodValue = null;
                Gpc_exec(prodUrl, Mykey, prodAction, prodProjects, prodValue, out int Response);
                if (Response == 200)
                {
                    WriteToStatusBar("[Prod] Все ок");
                }
                else if (Response == 400)
                {
                    WriteToStatusBar("[Prod] Входящие данные невалидные");
                }
                else if (Response == 403)
                {
                    WriteToStatusBar("[Prod] Доступ запрещен");
                }
                else if (Response == 500)
                {
                    WriteToStatusBar("[Prod] Что-то упало");
                }
                else
                {
                    WriteToStatusBar("[Prod] Юзай Debug");
                }
            }
            catch (Exception ex)
            {
                WriteToStatusBar(ex.Message);
                //throw;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection c = new SqlConnection(sql_conn))
                {
                    c.Open();
                    string sql = "SELECT COUNT(*) FROM [Crawler].[dbo].[project_backup] WITH(NOLOCK) WHERE[id_project] = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, c))
                    {
                        cmd.Parameters.AddWithValue("@id", projectBox.SelectedItem);
                        int backupCount = (int)cmd.ExecuteScalar();
                        if (backupCount == 0)
                        {
                            WriteToStatusBar("На проде нет бекапа выбраного проекта.");
                        }
                        else
                        {
                            cmd.CommandText = @"MERGE INTO [CrawlerTest].[dbo].[project_backup] Bpb
                                                USING [Crawler].[dbo].[project_backup] Ppb
                                                ON Bpb.id_project = Ppb.id_project
                                                WHEN MATCHED AND Ppb.[id_project] = @id
                                                THEN UPDATE SET
                                                    [id_project] = Ppb.[id_project],
                                                    [data_zipped] = Ppb.[data_zipped],
                                                    [date] = Ppb.[date]
                                                WHEN NOT MATCHED AND Ppb.[id_project] = @id
                                                THEN INSERT ([id_project], [data_zipped], [date])
                                                VALUES (Ppb.[id_project], Ppb.[data_zipped], Ppb.[date]);";
                            cmd.ExecuteNonQuery();
                            WriteToStatusBar("Бекап успешно скопирован\\обновлен");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                WriteToStatusBar(ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string betaAction = "RestoreFromBackup";
                string betaProjects = projectBox.SelectedItem.ToString();
                string betaValue = null;
                Gpc_exec(betaUrl, Mykey, betaAction, betaProjects, betaValue, out int Response);
                if (Response == 200)
                {
                    WriteToStatusBar("[Beta] Все ок");
                }
                else if (Response == 400)
                {
                    WriteToStatusBar("[Beta] Входящие данные невалидные");
                }
                else if (Response == 403)
                {
                    WriteToStatusBar("[Beta] Доступ запрещен");
                }
                else if (Response == 500)
                {
                    WriteToStatusBar("[Beta] Что-то упало");
                }
                else
                {
                    WriteToStatusBar("[Beta] Юзай Debug");
                }
            }
            catch (Exception ex)
            {

                WriteToStatusBar(ex.Message);
            }
        }

        private void ProjectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection c = new SQLiteConnection(sqlite_conn))
                {
                    c.Open();
                    string sql = "select * from Projects where Project_ID = @id";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        cmd.Parameters.AddWithValue("@id", projectBox.SelectedItem);
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read() == true)
                            {
                                string proID = rdr[1].ToString();
                                string proDesc = rdr[2].ToString();
                                string str = $"Проект: {proID}@Описание:@{proDesc}";
                                txtProjectDesc.Text = str.Replace("@", "" + System.Environment.NewLine);
                            }
                            else
                            {
                                string nodesc = "Для выбранного проекта нет описания.";
                                txtProjectDesc.Text = nodesc;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                WriteToStatusBar(ex.Message);
                throw;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit application?", "", MessageBoxButtons.YesNo) ==
                   DialogResult.No)
            {
                return;
            }
            else
            {
                // The user wants to exit the application. Close everything down.
                Application.Exit();
            }
        }

        private void AddProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Project openForm = new Add_Project();
            //this.Hide();
            openForm.ShowDialog();
            //this.Show();
            UpdateProjectList();

        }
    }
}
