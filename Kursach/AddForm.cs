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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            dir.Text = Main.currDir;
        }

        public string Label
        {
            get {return dir.Text;}
            set { dir.Text = value; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool[] lis1 = { (bool)r1.Checked, (bool)w1.Checked, (bool)r2.Checked, (bool)w2.Checked };
            if(!String.IsNullOrEmpty(nameFile.Text) && !String.IsNullOrWhiteSpace(nameFile.Text))
                newfile(nameFile.Text, (bool)isDir.Checked, Textfile.Text, lis1);
            else
            {
                MessageBox.Show("Введите имя корректно.");
                return;
            }
            Textfile.Text = String.Empty;
            
        }

        public void newfile(String Name, bool isDirectory, String Text, bool[] lis1)
        {

            if (Name.Length > 8)
            {
                MessageBox.Show("Имя файла должно быть от 1 до 8 символов.");
                return;
            }
            else
            {
                int p1 = -1;
                foreach (Root root in Main.roots)
                {
                    if (root.nameFile == Name)
                    {

                        p1 = 1;
                        break;
                    }
                }
                if (p1 == -1)
                {

                    int InodNumber = createfile(isDirectory, Text, lis1);
                    if (InodNumber != -1)
                    {

                        foreach (Root p in Main.roots)
                        {
                            if (p.nameFile == "^^^^^^^^")
                            {
                                Main.roots.Remove(p);
                                break;
                            }
                        }
                        {
                            Root TestRoot = new Root(InodNumber, Name);
                            Main.roots.Add(TestRoot);
                            nameFile.Text = String.Empty;
                            Textfile.Text = String.Empty;
                            r1.Checked = false;
                            r2.Checked = false;
                            w1.Checked = false;
                            w2.Checked = false;
                            MessageBox.Show("Файл создан.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Создано максимальное количество файлов.");
                    }
                }
                else
                {
                    MessageBox.Show("Файл уже существует.");
                }
            }
        }

        private int createfile(bool isDirectory, String TextFail, bool[] lis1)
        {
            Main.MassivByte = Encoding.Default.GetBytes(TextFail);
            Main.File = new FileStream("Data.txt", FileMode.Open);
            int i, InodNumber = -1;
            int Last = -1;
            Textfile.Text = "";

            //смотрим, сколько нужно всего кластеров
            int WaitCountClasters = 0;
            if (Main.MassivByte.Length % Main.Super1.s_bsize == 0)
                WaitCountClasters = Main.MassivByte.Length / Main.Super1.s_bsize;
            else
                WaitCountClasters = Main.MassivByte.Length / Main.Super1.s_bsize + 1;

            int m = WaitCountClasters;

            //если < 10 - ищем свободный инод
            if (WaitCountClasters <= 10)
            {
                foreach (Inode freeinode in Main.inodes)
                {
                    if (freeinode.flag == false)
                    {
                        InodNumber = freeinode.IDnode;
                        freeinode.File_size = TextFail.Length;
                        freeinode.flag = true;
                        freeinode.UID = Main.currentuser;
                        freeinode.Time_create = DateTime.Now;
                        freeinode.Time_modify = DateTime.Now;
                        freeinode.lis = lis1;
                        freeinode.isDirectory = isDirectory;
                        Last = 0;

                        break;
                    }
                }

                if (Last == -1)
                {
                    Main.File.Close();
                    MessageBox.Show("Нет свободных инодов.");
                    return -1;
                }

                Last = -1;
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

                Main.inodes[InodNumber].block[0] = bit;
                Last = i;

                WaitCountClasters--;

                Main.File.Seek(i * Main.Super1.s_bsize, SeekOrigin.Begin);
                if (Main.Super1.s_bsize < LengthMassive)
                {
                    Main.File.Write(Main.MassivByte, 0, Main.Super1.s_bsize);
                    LengthMassive -= Main.Super1.s_bsize;
                    position += Main.Super1.s_bsize;
                }
                else
                {
                    Main.File.Write(Main.MassivByte, 0, LengthMassive);
                }

                if (Last == -1)
                {
                    Main.File.Close();
                    MessageBox.Show("Недостаточно места для записи файла.");
                    return -1;
                }

                if (WaitCountClasters > 0)
                {
                    int p = 1;
                    for (i = 0; (i < Main.bitcard.Count && WaitCountClasters != 0); i++)
                    {
                        if (Main.bitcard[i] == false)
                        {
                            Main.bitcard[i] = true;
                            Main.inodes[InodNumber].block[p] = i;
                            p++;
                            Last = i;
                            WaitCountClasters--;
                            Main.File.Seek((i) * Main.Super1.s_bsize, SeekOrigin.Begin);
                            if (Main.Super1.s_bsize < LengthMassive)
                            {
                                Main.File.Write(Main.MassivByte, position, Main.Super1.s_bsize);
                                LengthMassive -= Main.Super1.s_bsize;
                                position += Main.Super1.s_bsize;
                            }
                            else
                            {
                                Main.File.Write(Main.MassivByte, position, LengthMassive);
                            }
                        }
                    }
                }
                Main.File.Close();
                return InodNumber;
            }
            else
            {
                Main.File.Close();
                return -1;
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

        private void isDir_Click(object sender, EventArgs e)
        {
            if (isDir.Checked)
            {
                Textfile.Text = string.Empty;
                Textfile.ReadOnly = true;
            }
            else
                Textfile.ReadOnly = false;
        }
    } // AddForm
} // Kursach
