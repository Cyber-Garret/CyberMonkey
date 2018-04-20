using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Cyber_Monkey_Studio
{
    public partial class Add_Project : Form
    {
        //Переменная для подключения к SQLite
        string sqlite_conn = ("Data Source=Monkey.db; Version=3;");
        public Add_Project()
        {
            InitializeComponent();
        }

        //Метод для принятия сообщения и отображение в статус баре
        private void WriteToStatusBar(string Message)
        {
            //Пишем сообщение в статус бар
            StatusBarInAdd.Text = Message;
        }

        private void BtnAddProject_Click(object sender, EventArgs e)
        {
            try
            {
                string checkID = txtProjectID.Text;
                string checkDesc = richProjectDesc.Text;

                if (String.IsNullOrEmpty(checkID))
                    {
                        WriteToStatusBar("ID проекта не может быть пустыми.");
                    }
                else if (String.IsNullOrEmpty(checkDesc))
                {
                    WriteToStatusBar("Описание проекта не может быть пустыми.");
                }
                else
                {
                    using (SQLiteConnection c = new SQLiteConnection(sqlite_conn))
                    {
                        c.Open();
                        string sql = "REPLACE INTO Projects (Project_ID, Desc) VALUES (@id,@Desc)";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                        {
                            cmd.Parameters.AddWithValue("@id", txtProjectID.Text);
                            cmd.Parameters.AddWithValue("@Desc", richProjectDesc.Text);
                            cmd.ExecuteNonQuery();
                        }


                    }
                    //sqlite_cmd.ExecuteNonQuery();
                    WriteToStatusBar("Проект " + txtProjectID.Text + " успешно добавлен\\обновлен");
                    //sqlite_conn.Close();
                }

            }
            catch (Exception ex)
            {
                WriteToStatusBar(ex.Message);
            }
        }
    }
}
