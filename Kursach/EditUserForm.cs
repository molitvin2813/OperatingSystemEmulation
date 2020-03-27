using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class EditUserForm : Form
    {
        public EditUserForm()
        {
            InitializeComponent();
        }

        private void adduser(object sender, EventArgs e)
        {

            int p1 = 0;
            foreach (User p in Main.users)
            {
                if ((p.Login == "**********") && (p.Password == Main.GetHashString("**********")))
                {
                    p1 += 1;

                }
            }
            if (p1 == 50) { MessageBox.Show("Невозможно добавить больше 50 позьзователей."); }
            else
            {
                string log = Login.Text;
                string pas = Password.Text;
                if ((log != "") && (pas != "") && (log.Length <= 8) && (pas.Length <= 8))
                {
                    foreach (User p in Main.users)
                    {
                        if (p.Login == log)
                        {
                            p1 = 1;

                        }
                    }
                    if (p1 == 1)
                    {
                        MessageBox.Show("Такой пользователь уже существует.");
                    }
                    else
                    {
                        {
                            foreach (User p in Main.users)
                            {
                                if ((p.Login == "**********") && (p.Password == Main.GetHashString("**********")))
                                {
                                    p.Login = log;
                                    p.Password = Main.GetHashString(pas);
                                    p.isAdmin = Convert.ToInt32(isAdmin.Checked);
                                    Login.Text = String.Empty;
                                    Password.Text = String.Empty;
                                    MessageBox.Show("Пользователь добавлен.");
                                    break;
                                }
                            }
                        }

                    }

                }
                else
                    MessageBox.Show("Логин и пароль должны содержать от 1 до 8 символов.");
            }
            listuser(sender,e);
        }

        
        private void listuser(object sender, EventArgs e)
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

            ListViewItem item;
            listView1.Items.Clear();
            foreach (User user in Main.users)
            {
                if (user.Login != "**********")
                {
                    string itog, uid, name, status;
                    string isAdmin=user.isAdmin.ToString();
                    uid = Convert.ToString(user.UID);

                    name = user.Login;
                    item = new ListViewItem(uid);
                    item.SubItems.Add(name);
                    item.SubItems.Add(isAdmin);
                    listView1.Items.Add(item);
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void deleteuser(object sender, EventArgs e)
        {
            int p1 = -1;
            int id = Convert.ToInt32( listView1.SelectedItems[0].Text);

                foreach (User p in Main.users)
                {
                    if (p.UID != 0)
                    {
                        p1 = 0;
                        if (p.UID == id)
                        {
                            foreach (Inode inode in Main.inodes)
                            {
                                if (inode.UID == p.UID)
                                    inode.UID = 0;
                            }
                            Main.users.Remove(p);
                            
                            MessageBox.Show("Пользователь удален.");
                            p1 = 10;
                            User TestUser = new User(p.UID, "**********", Main.GetHashString("**********"),0);
                            Main.users.Add(TestUser);
                            break;
                        }
                    }
                }
                if (p1 == 0) MessageBox.Show("Вы не можете удалить учетную запись администратора.");
                if (p1 == -1) MessageBox.Show("Такого пользователя не существует.");
            listuser(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int p1 = -1;
            int id = Convert.ToInt32(listView1.SelectedItems[0].Text);

            Main.users[id].isAdmin = Convert.ToInt32( isAdmin.Checked);
        }
    }
}
