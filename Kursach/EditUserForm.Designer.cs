namespace Kursach
{
    partial class EditUserForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.idUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.users = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.TextBox();
            this.state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isAdmin = new System.Windows.Forms.CheckBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.changeState = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idUser,
            this.users,
            this.state});
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(223, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(360, 276);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // idUser
            // 
            this.idUser.Text = "ID";
            this.idUser.Width = 35;
            // 
            // users
            // 
            this.users.Text = "Пользователи";
            this.users.Width = 177;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.adduser);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(53, 86);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(110, 20);
            this.Login.TabIndex = 8;
            // 
            // state
            // 
            this.state.Text = "Статус";
            this.state.Width = 144;
            // 
            // isAdmin
            // 
            this.isAdmin.AutoSize = true;
            this.isAdmin.Location = new System.Drawing.Point(53, 148);
            this.isAdmin.Name = "isAdmin";
            this.isAdmin.Size = new System.Drawing.Size(105, 17);
            this.isAdmin.TabIndex = 10;
            this.isAdmin.Text = "Администратор";
            this.isAdmin.UseVisualStyleBackColor = true;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(53, 122);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(110, 20);
            this.Password.TabIndex = 11;
            this.Password.UseSystemPasswordChar = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(53, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 29);
            this.button2.TabIndex = 12;
            this.button2.Text = "Обновить Список";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.listuser);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(53, 339);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 29);
            this.button3.TabIndex = 13;
            this.button3.Text = "Завершить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(53, 218);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 29);
            this.button4.TabIndex = 14;
            this.button4.Text = "Удалить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.deleteuser);
            // 
            // changeState
            // 
            this.changeState.Location = new System.Drawing.Point(53, 253);
            this.changeState.Name = "changeState";
            this.changeState.Size = new System.Drawing.Size(110, 29);
            this.changeState.TabIndex = 15;
            this.changeState.Text = "Изменить";
            this.changeState.UseVisualStyleBackColor = true;
            this.changeState.Click += new System.EventHandler(this.button5_Click);
            // 
            // EditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 444);
            this.Controls.Add(this.changeState);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.isAdmin);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "EditUserForm";
            this.Text = "EditUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader idUser;
        private System.Windows.Forms.ColumnHeader users;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.ColumnHeader state;
        private System.Windows.Forms.CheckBox isAdmin;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button changeState;
    }
}