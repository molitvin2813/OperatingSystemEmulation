namespace Kursach
{
    partial class Main
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateCreate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateModify = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rights = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tupe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button5 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.directory = new System.Windows.Forms.TextBox();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Войти в систему";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Содержимое Каталога";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.listfile);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Добавить Файл/Каталог";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 385);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Выход";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.exit);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.size,
            this.dateCreate,
            this.dateModify,
            this.rights,
            this.author,
            this.tupe});
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(195, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(579, 390);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // name
            // 
            this.name.Text = "Имя";
            this.name.Width = 52;
            // 
            // size
            // 
            this.size.Text = "Размер";
            this.size.Width = 58;
            // 
            // dateCreate
            // 
            this.dateCreate.Text = "Дата Создания";
            this.dateCreate.Width = 112;
            // 
            // dateModify
            // 
            this.dateModify.Text = "Дата Изменения";
            this.dateModify.Width = 120;
            // 
            // rights
            // 
            this.rights.Text = "Права";
            this.rights.Width = 44;
            // 
            // author
            // 
            this.author.Text = "Автор";
            this.author.Width = 69;
            // 
            // tupe
            // 
            this.tupe.Text = "Тип";
            this.tupe.Width = 118;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 190);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(174, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Удалить Файл";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.delete_file);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(195, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(47, 20);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // directory
            // 
            this.directory.Location = new System.Drawing.Point(248, 9);
            this.directory.Name = "directory";
            this.directory.Size = new System.Drawing.Size(526, 20);
            this.directory.TabIndex = 11;
            this.directory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.directory_KeyUp);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(3, 54);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(174, 23);
            this.btnEditUser.TabIndex = 12;
            this.btnEditUser.Text = "Редактировать Пользователей";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(3, 272);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(174, 23);
            this.btnChooseFile.TabIndex = 13;
            this.btnChooseFile.Text = "Выбрать Файл";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(3, 301);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(174, 23);
            this.btnReplace.TabIndex = 14;
            this.btnReplace.Text = "Переместить";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 443);
            this.ControlBox = false;
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.directory);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBack);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Файловая Система";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ColumnHeader dateCreate;
        private System.Windows.Forms.ColumnHeader dateModify;
        private System.Windows.Forms.ColumnHeader rights;
        private System.Windows.Forms.ColumnHeader author;
        private System.Windows.Forms.ColumnHeader tupe;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox directory;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnReplace;
    }
}