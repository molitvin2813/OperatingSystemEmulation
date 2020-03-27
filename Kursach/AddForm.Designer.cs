namespace Kursach
{
    partial class AddForm
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
            this.r1 = new System.Windows.Forms.CheckBox();
            this.w1 = new System.Windows.Forms.CheckBox();
            this.r2 = new System.Windows.Forms.CheckBox();
            this.w2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dir = new System.Windows.Forms.Label();
            this.isDir = new System.Windows.Forms.CheckBox();
            this.Textfile = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // r1
            // 
            this.r1.AutoSize = true;
            this.r1.Location = new System.Drawing.Point(38, 85);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(29, 17);
            this.r1.TabIndex = 0;
            this.r1.Text = "r";
            this.r1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.r1.UseVisualStyleBackColor = true;
            // 
            // w1
            // 
            this.w1.AutoSize = true;
            this.w1.Location = new System.Drawing.Point(38, 129);
            this.w1.Name = "w1";
            this.w1.Size = new System.Drawing.Size(34, 17);
            this.w1.TabIndex = 1;
            this.w1.Text = "w";
            this.w1.UseVisualStyleBackColor = true;
            // 
            // r2
            // 
            this.r2.AutoSize = true;
            this.r2.Location = new System.Drawing.Point(139, 85);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(29, 17);
            this.r2.TabIndex = 2;
            this.r2.Text = "r";
            this.r2.UseVisualStyleBackColor = true;
            // 
            // w2
            // 
            this.w2.AutoSize = true;
            this.w2.Location = new System.Drawing.Point(139, 129);
            this.w2.Name = "w2";
            this.w2.Size = new System.Drawing.Size(34, 17);
            this.w2.TabIndex = 3;
            this.w2.Text = "w";
            this.w2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Админ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Другие";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F);
            this.label3.Location = new System.Drawing.Point(90, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Права";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F);
            this.label4.Location = new System.Drawing.Point(104, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Имя";
            // 
            // nameFile
            // 
            this.nameFile.Location = new System.Drawing.Point(38, 192);
            this.nameFile.Name = "nameFile";
            this.nameFile.Size = new System.Drawing.Size(181, 20);
            this.nameFile.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F);
            this.label5.Location = new System.Drawing.Point(271, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Текущий Каталог : ";
            // 
            // dir
            // 
            this.dir.AutoSize = true;
            this.dir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F);
            this.dir.Location = new System.Drawing.Point(433, 25);
            this.dir.Name = "dir";
            this.dir.Size = new System.Drawing.Size(156, 17);
            this.dir.TabIndex = 10;
            this.dir.Text = "Текущая дериктория: ";
            // 
            // isDir
            // 
            this.isDir.AutoSize = true;
            this.isDir.Location = new System.Drawing.Point(80, 243);
            this.isDir.Name = "isDir";
            this.isDir.Size = new System.Drawing.Size(67, 17);
            this.isDir.TabIndex = 12;
            this.isDir.Text = "Каталог";
            this.isDir.UseVisualStyleBackColor = true;
            this.isDir.Click += new System.EventHandler(this.isDir_Click);
            // 
            // Textfile
            // 
            this.Textfile.Location = new System.Drawing.Point(274, 73);
            this.Textfile.Multiline = true;
            this.Textfile.Name = "Textfile";
            this.Textfile.Size = new System.Drawing.Size(489, 363);
            this.Textfile.TabIndex = 13;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(38, 334);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(181, 28);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(38, 383);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(181, 28);
            this.btnEnd.TabIndex = 15;
            this.btnEnd.Text = "Завершить";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 448);
            this.ControlBox = false;
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.Textfile);
            this.Controls.Add(this.isDir);
            this.Controls.Add(this.dir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nameFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.w2);
            this.Controls.Add(this.r2);
            this.Controls.Add(this.w1);
            this.Controls.Add(this.r1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.ShowIcon = false;
            this.Text = "Добавление Файла/Каталога";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox r1;
        private System.Windows.Forms.CheckBox w1;
        private System.Windows.Forms.CheckBox r2;
        private System.Windows.Forms.CheckBox w2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label dir;
        private System.Windows.Forms.CheckBox isDir;
        private System.Windows.Forms.TextBox Textfile;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEnd;
    }
}