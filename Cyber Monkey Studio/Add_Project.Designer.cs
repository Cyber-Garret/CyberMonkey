namespace Cyber_Monkey_Studio
{
    partial class Add_Project
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Project));
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richProjectDesc = new System.Windows.Forms.RichTextBox();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBarInAdd = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Проекта";
            // 
            // txtProjectID
            // 
            this.txtProjectID.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtProjectID.Location = new System.Drawing.Point(0, 13);
            this.txtProjectID.Name = "txtProjectID";
            this.txtProjectID.Size = new System.Drawing.Size(484, 20);
            this.txtProjectID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Описание для проекта";
            // 
            // richProjectDesc
            // 
            this.richProjectDesc.AccessibleDescription = "";
            this.richProjectDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richProjectDesc.Location = new System.Drawing.Point(0, 46);
            this.richProjectDesc.Name = "richProjectDesc";
            this.richProjectDesc.Size = new System.Drawing.Size(484, 215);
            this.richProjectDesc.TabIndex = 3;
            this.richProjectDesc.Text = "";
            // 
            // btnAddProject
            // 
            this.btnAddProject.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddProject.Location = new System.Drawing.Point(0, 216);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(484, 23);
            this.btnAddProject.TabIndex = 4;
            this.btnAddProject.Text = "Push me in local storage";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.BtnAddProject_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarInAdd});
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(484, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusBarInAdd
            // 
            this.StatusBarInAdd.Name = "StatusBarInAdd";
            this.StatusBarInAdd.Size = new System.Drawing.Size(0, 17);
            // 
            // Add_Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richProjectDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProjectID);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Add_Project";
            this.Text = "Manage Project";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjectID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarInAdd;
        public System.Windows.Forms.RichTextBox richProjectDesc;
    }
}