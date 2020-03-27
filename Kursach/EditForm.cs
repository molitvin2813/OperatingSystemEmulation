using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class EditForm : Form
    {
        public FileStream File;
        public EditForm()
        {
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        public string Label
        {
            get { return currFile.Text; }
            set { currFile.Text = value; }
        }
        public string TextBox
        {
            get { return Textfile.Text; }
            set { Textfile.Text = value; }
        }

        private void renameFile(object sender, EventArgs e)
        {
            if ((Main.findFile(newName.Text) != -1) || (newName.Text == ""))
            {
                MessageBox.Show("Введите имя корректно.");
            }
            else
            {
                if (Main.findFile(newName.Text) != -1)
                {

                    if (Main.inodes[Main.findFile(newName.Text)].UID == Main.currentuser)
                    {
                        if (Main.inodes[Main.findFile(newName.Text)].lis[1] == true)
                        {
                            foreach (Root root in Main.roots)
                            {
                                if (root.nameFile == newName.Text)
                                {
                                    root.nameFile = newName.Text;
                                    newName.Text = String.Empty;
                                    MessageBox.Show("Файл успешно переименован.");
                                    break;
                                }
                            }
                        }
                        else MessageBox.Show("Недостаточно прав для переименования.");
                    }
                    else
                    {
                        if (Main.inodes[Main.findFile(newName.Text)].lis[3] == true)
                        {
                            foreach (Root root in Main.roots)
                            {
                                if (root.nameFile == newName.Text)
                                {
                                    root.nameFile = newName.Text;
                                    newName.Text = String.Empty;
                                   
                                    MessageBox.Show("Файл успешно переименован.");
                                    break;
                                }
                            }
                        }
                        else MessageBox.Show("Недостаточно прав для переименования.");
                    }
                }
                else MessageBox.Show("Такого файла не существует.");
            }
        }

        private void changeRights(object sender, EventArgs e)
        {
            if ((Main.currFile.Length > 8) || (Main.currFile == ""))
            {
                MessageBox.Show("Введите корректное имя.");
            }
            if (Main.findFile(Main.currFile) != -1)
            {
                int inod = Main.findFile(Main.currFile);
                if ((Main.inodes[inod].UID == Main.currentuser) || ((Main.currentuser == 0) && (Main.inodes[inod].lis[3] == true)))
                {
                    Main.inodes[inod].lis[0] = (bool)r1.Checked;
                    Main.inodes[inod].lis[1] = (bool)w1.Checked;
                    Main.inodes[inod].lis[2] = (bool)r2.Checked;
                    Main.inodes[inod].lis[3] = (bool)w2.Checked;
                }
                else MessageBox.Show("Недостаточно прав для изменения прав доступа.");
            }
            else
                MessageBox.Show("Такого файла не существует.");
            r1.Checked = false;
            r2.Checked = false;
            w1.Checked = false;
            w2.Checked = false;
        }

        // Редактирование файла
        private void editFile(object sender, EventArgs e)
        {
            int ino = Main.findFile(Main.currFile);

            foreach (Inode inode in Main.inodes)
            {
                if (inode.IDnode == ino && inode.isDirectory)
                {
                    MessageBox.Show("Выберете обычный файл, а не директорию!");
                    return;
                }
            }

            Main.inod = Main.findFile(Main.currFile);
            if (Main.inod != -1)
            {
                if (Main.inodes[Main.inod].UID == Main.currentuser)
                {
                    if (Main.inodes[Main.inod].lis[1] == true)
                    {
                        save_file(Main.inod, Textfile.Text);

                        int gettext = openfile(Main.currFile);
                        Textfile.Text = "";
                        string p = Encoding.Default.GetString(Main.MassivByte);
                        for (int i = 0; i < openfile(Main.currFile); i++)
                            Textfile.Text += p[i];
                    }
                    else MessageBox.Show("Недостаточно прав для редактироваия файла.");
                }

                else
                {
                    if (Main.inodes[Main.inod].lis[3] == true)
                    {
                        save_file(Main.inod, Textfile.Text);

                        int gettext = openfile(Main.currFile);
                        Textfile.Text = "";
                        string p = Encoding.Default.GetString(Main.MassivByte);
                        for (int i = 0; i < openfile(Main.currFile); i++)
                            Textfile.Text += p[i];
                    }
                    else MessageBox.Show("Недостаточно прав для редактироваия файла.");
                }
            }
            else
                MessageBox.Show("Введите корректное имя файла.");

           
        }

        public int openfile(string filename)
        {
            int inodNumber = Main.findFile(filename);  // ищем инод, связаный с файлом
            Main.currIno = inodNumber;
            if (inodNumber != -1)                // если нашли
            {

                Main.File = new FileStream("Data.txt", FileMode.Open);
                if (Main.inodes[inodNumber].File_size <= Main.Super1.s_bsize)// попробовать сделать размеры 
                    Main.MassivByte = new byte[Main.Super1.s_bsize];
                else
                    if (Main.inodes[inodNumber].File_size % Main.Super1.s_bsize == 0)
                    Main.MassivByte = new byte[Main.inodes[inodNumber].File_size];
                else Main.MassivByte = new byte[(Main.inodes[inodNumber].File_size / Main.Super1.s_bsize) * Main.Super1.s_bsize + Main.Super1.s_bsize];

                //берем номер первого кластера

                int i = 0;  // смещение в массиве байтов

                int p = 0;
                while (Main.inodes[inodNumber].block[p] != -1)
                {
                    //readfile(ref inodes[inodNumber].block[p], ref i);
                    Main.File.Seek((Main.inodes[inodNumber].block[p]) * Main.Super1.s_bsize, SeekOrigin.Begin);
                    Main.File.Read(Main.MassivByte, i, Main.Super1.s_bsize);
                    i += Main.Super1.s_bsize;
                    p++;


                }
                Main.File.Close();
                return Main.inodes[inodNumber].File_size;
            }
            else            // если не нашли инод связанный с фалом
            {
                MessageBox.Show("Файла не существует.");
                return -9;
            }
        }

        // Сохранить файл
        private void save_file(int nodeNumber, String TextFail)
        {
            Main.MassivByte = Encoding.Default.GetBytes(TextFail);
            File = new FileStream("Data.txt", FileMode.Open);
            Main.inodes[nodeNumber].File_size = TextFail.Length;
            Main.inodes[nodeNumber].Time_modify = DateTime.Now;
            Textfile.Text = "";

            //смотрим, сколько нужно всего кластеров
            int WaitCountClasters = 0;
            if (Main.MassivByte.Length % Main.Super1.s_bsize == 0)
                WaitCountClasters = Main.MassivByte.Length / Main.Super1.s_bsize;
            else
                WaitCountClasters = Main.MassivByte.Length / Main.Super1.s_bsize + 1;

            //если < 10 - ищем свободный инод
            if (WaitCountClasters <= 10)
            {
                int er = 0;
                for (int j = 0; j < 10; j++)
                {
                    if (Main.inodes[nodeNumber].block[j] != -1)
                        er++;
                }
                if (WaitCountClasters == er)
                {
                    int LengthMassive = Main.MassivByte.Length;
                    int position = 0;
                    int clasterSize = Main.Super1.s_bsize;
                    for (int p = 0; p < er; p++)
                    {
                        File.Seek(Main.inodes[nodeNumber].block[p] * Main.Super1.s_bsize, SeekOrigin.Begin);
                        if (Main.Super1.s_bsize < LengthMassive)
                        {
                            File.Write(Main.MassivByte, 0, Main.Super1.s_bsize);
                            LengthMassive -= Main.Super1.s_bsize;
                            position += Main.Super1.s_bsize;
                        }
                        else
                        {
                            File.Write(Main.MassivByte, position, LengthMassive);
                        }
                    }
                }

                if ((WaitCountClasters <= er) || (WaitCountClasters >= er))
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (Main.inodes[nodeNumber].block[j] != -1)
                            Main.bitcard[Main.inodes[nodeNumber].block[j]] = false;
                        Main.inodes[nodeNumber].block[j] = -1;
                        er++;
                    }
                    int Last = -1, i = 0;
                    int LengthMassive = Main.MassivByte.Length;
                    int position = 0;
                    int bit = -1;
                    int clasterSize = Main.Super1.s_bsize;

                    for (i = 0; i < Main.bitcard.Count; i++)
                    {
                        if (Main.bitcard[i] == false)
                        {
                            bit = i;
                            Main.bitcard[i] = true;
                            break;
                        }
                    }

                    Main.inodes[nodeNumber].block[0] = bit;
                    Last = i;

                    WaitCountClasters--;

                    File.Seek(i * Main.Super1.s_bsize, SeekOrigin.Begin);
                    if (Main.Super1.s_bsize < LengthMassive)
                    {
                        File.Write(Main.MassivByte, 0, Main.Super1.s_bsize);
                        LengthMassive -= Main.Super1.s_bsize;
                        position += Main.Super1.s_bsize;
                    }
                    else
                    {
                        File.Write(Main.MassivByte, 0, LengthMassive);
                    }

                    if (WaitCountClasters > 0)
                    {
                        int p = 1;
                        for (i = 0; (i < Main.bitcard.Count && WaitCountClasters != 0); i++)
                        {
                            if (Main.bitcard[i] == false)
                            {
                                Main.bitcard[i] = true;
                                Main.inodes[nodeNumber].block[p] = i;
                                p++;
                                Last = i;
                                WaitCountClasters--;
                                File.Seek((i) * Main.Super1.s_bsize, SeekOrigin.Begin);
                                if (Main.Super1.s_bsize < LengthMassive)
                                {
                                    File.Write(Main.MassivByte, position, Main.Super1.s_bsize);
                                    LengthMassive -= Main.Super1.s_bsize;
                                    position += Main.Super1.s_bsize;
                                }
                                else
                                {
                                    File.Write(Main.MassivByte, position, LengthMassive);
                                }
                            }
                        }
                    }
                }
                File.Close();
            }
            else
            {
                File.Close();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream File = new FileStream("SuperBlock.txt", FileMode.Create);
            Formatter.Serialize(File, Main.Super1);      //сериализация
            File.Close();

            //форматируем Inode, Bitcard
            SerializableObject1 obj1 = new SerializableObject1();
            obj1.Inodes = Main.inodes;
            MySerializer1 serializer1 = new MySerializer1();
            serializer1.SerializeObject1("Inodes.txt", obj1);

            SerializableObject2 obj2 = new SerializableObject2();
            obj2.Bitcard = Main.bitcard;
            MySerializer2 serializer2 = new MySerializer2();
            serializer2.SerializeObject2("Bitcard.txt", obj2);

            if (Main.currDir == "/")
            {
                //заполнение рута
                SerializableObject5 obj5 = new SerializableObject5();
                obj5.Roots = Main.roots;
                MySerializer5 serializer5 = new MySerializer5();
                serializer5.SerializeObject5("Roots.txt", obj5);
            }
            else
                Main.save_file_binary(Main.currDirIno, Main.serializeDirectory(Main.roots));

            //форматируем пользователей.    
            SerializableObject obj = new SerializableObject();
            obj.Users = Main.users;
            MySerializer serializer = new MySerializer();
            serializer.SerializeObject("Users.txt", obj);

            this.Hide();
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(newName.Text) && String.IsNullOrWhiteSpace(newName.Text))
            {
                MessageBox.Show("Введите имя корректно.");
                return;
            }

            if (Main.inodes[Main.findFile(Main.currFile)].UID == Main.currentuser)
            {
                if (Main.inodes[Main.findFile(Main.currFile)].lis[1] == true)
                {
                    foreach (Root root in Main.roots)
                    {
                        if (root.nameFile == Main.currFile)
                        {
                            root.nameFile = newName.Text;
                            currFile.Text = newName.Text;
                            Main.currFile = newName.Text;
                            MessageBox.Show("Файл успешно переименован.");
                            break;
                        }
                    }
                }
                else MessageBox.Show("Недостаточно прав для переименования.");
            }
            else
            {
                if (Main.inodes[Main.findFile(Main.currFile)].lis[3] == true)
                {
                    foreach (Root root in Main.roots)
                    {
                        if (root.nameFile == Main.currFile)
                        {
                            root.nameFile = newName.Text;
                            currFile.Text = newName.Text;
                            Main.currFile = newName.Text;
                            MessageBox.Show("Файл успешно переименован.");
                            break;
                        }
                    }
                }
                else MessageBox.Show("Недостаточно прав для переименования.");
            } 
        }
    }
}
