namespace Kursach
{
    partial class EditForm
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
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Textfile = new System.Windows.Forms.TextBox();
            this.currFile = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.newName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.w2 = new System.Windows.Forms.CheckBox();
            this.r2 = new System.Windows.Forms.CheckBox();
            this.w1 = new System.Windows.Forms.CheckBox();
            this.r1 = new System.Windows.Forms.CheckBox();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(27, 378);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(181, 28);
            this.btnEnd.TabIndex = 30;
            this.btnEnd.Text = "Завершить";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(27, 315);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(181, 28);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "Редактировать";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.editFile);
            // 
            // Textfile
            // 
            this.Textfile.Location = new System.Drawing.Point(263, 68);
            this.Textfile.Multiline = true;
            this.Textfile.Name = "Textfile";
            this.Textfile.Size = new System.Drawing.Size(489, 363);
            this.Textfile.TabIndex = 28;
            // 
            // currFile
            // 
            this.currFile.AutoSize = true;
            this.currFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F);
            this.currFile.Location = new System.Drawing.Point(422, 20);
            this.currFile.Name = "currFile";
            this.currFile.Size = new System.Drawing.Size(156, 17);
            this.currFile.TabIndex = 26;
            this.currFile.Text = "Текущая дериктория: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F);
            this.label5.Location = new System.Drawing.Point(260, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Текущий Файл: ";
            // 
            // newName
            // 
            this.newName.Location = new System.Drawing.Point(27, 187);
            this.newName.Name = "newName";
            this.newName.Size = new System.Drawing.Size(181, 20);
            this.newName.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F);
            this.label4.Location = new System.Drawing.Point(47, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Задайте новое имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F);
            this.label3.Location = new System.Drawing.Point(79, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Права";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Другие";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Админ";
            // 
            // w2
            // 
            this.w2.AutoSize = true;
            this.w2.Location = new System.Drawing.Point(128, 124);
            this.w2.Name = "w2";
            this.w2.Size = new System.Drawing.Size(34, 17);
            this.w2.TabIndex = 19;
            this.w2.Text = "w";
            this.w2.UseVisualStyleBackColor = true;
            // 
            // r2
            // 
            this.r2.AutoSize = true;
            this.r2.Location = new System.Drawing.Point(128, 80);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(29, 17);
            this.r2.TabIndex = 18;
            this.r2.Text = "r";
            this.r2.UseVisualStyleBackColor = true;
            // 
            // w1
            // 
            this.w1.AutoSize = true;
            this.w1.Location = new System.Drawing.Point(27, 124);
            this.w1.Name = "w1";
            this.w1.Size = new System.Drawing.Size(34, 17);
            this.w1.TabIndex = 17;
            this.w1.Text = "w";
            this.w1.UseVisualStyleBackColor = true;
            // 
            // r1
            // 
            this.r1.AutoSize = true;
            this.r1.Location = new System.Drawing.Point(27, 80);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(29, 17);
            this.r1.TabIndex = 16;
            this.r1.Text = "r";
            this.r1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.r1.UseVisualStyleBackColor = true;
            // 
            // btnChangeName
            // 
            this.btnChangeName.Location = new System.Drawing.Point(27, 281);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(181, 28);
            this.btnChangeName.TabIndex = 31;
            this.btnChangeName.Text = "Переименовать";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(27, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 28);
            this.button2.TabIndex = 32;
            this.button2.Text = "Изменить права";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.changeRights);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 446);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnChangeName);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.Textfile);
            this.Controls.Add(this.currFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.newName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.w2);
            this.Controls.Add(this.r2);
            this.Controls.Add(this.w1);
            this.Controls.Add(this.r1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.Text = "Редактирование Файла";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox Textfile;
        private System.Windows.Forms.Label currFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox newName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox w2;
        private System.Windows.Forms.CheckBox r2;
        private System.Windows.Forms.CheckBox w1;
        private System.Windows.Forms.CheckBox r1;
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.Button button2;
    }
}