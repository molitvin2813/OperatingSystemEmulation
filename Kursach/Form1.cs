using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;


namespace Kursach
{
   
    public partial class EnterForm : Form
    {

        
        public EnterForm()
        {
           
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void format()
        {
            try
            {
                SerializableObject obj = new SerializableObject();
                MySerializer serializer = new MySerializer();
                obj = serializer.DeserializeObject("Users.txt");
                Main.users = obj.Users;

                string log = Login.Text;
                string pas1 = Main.GetHashString(Password.Text);
                int er = -1;
                int uid = 0;

               foreach (User p in Main.users)
                {
                    if ((p.Login == log) && (p.Password == pas1) && (0 == p.UID))
                    {
                        er = 1;
                        uid = p.UID;
                        Main.currentuser = uid;
                    }
                }
                if (er == 1)
                {
                    if (open() != false)
                    {
                        formating();
                        //Main.Show();
                        this.Hide();

                    }
                    else MessageBox.Show("Файлы не найдены!");

                }
                else MessageBox.Show("Вы не можете форматировать диск!");
            }
            catch (FileNotFoundException e1)
            {
                MessageBox.Show("Файлы не найдены!");
            }
        }

        public void formating1(object sender, EventArgs e)
        {
            formating();
        }

        public Boolean open()
        {
            Main.roots.Clear();
            Main.inodes.Clear();
            Main.bitcard.Clear();
            try
            {
                //открываем суперблок
                BinaryFormatter Formatter = new BinaryFormatter();
                FileStream File = new FileStream("SuperBlock.txt", FileMode.Open);
                Main.Super1 = (SuperBlock)Formatter.Deserialize(File);
                File.Close();

                //открываем иноды
                SerializableObject1 obj1 = new SerializableObject1();
                MySerializer1 serializer1 = new MySerializer1();
                obj1.Inodes = Main.inodes;
                obj1 = serializer1.DeserializeObject1("Inodes.txt");
                Main.inodes = obj1.Inodes;

                //открываем битовую карту
                SerializableObject2 obj2 = new SerializableObject2();
                MySerializer2 serializer2 = new MySerializer2();
                obj2.Bitcard = Main.bitcard;
                obj2 = serializer2.DeserializeObject2("Bitcard.txt");
                Main.bitcard = obj2.Bitcard;

                //достаем пользователей
                SerializableObject obj = new SerializableObject();
                obj.Users = Main.users;
                MySerializer serializer = new MySerializer();
                obj = serializer.DeserializeObject("Users.txt");
                Main.users = obj.Users;

                //открываем рут он же корень
                SerializableObject5 obj5 = new SerializableObject5();
                MySerializer5 serializer5 = new MySerializer5();
                obj5.Roots = Main.roots;
                obj5 = serializer5.DeserializeObject5("Roots.txt");
                Main.roots = obj5.Roots;
                return true;
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Система повреждена! Обратитесь к администратору!", "Аларма");
                return false;
            }
        }

        private void Enter_programm(object sender, EventArgs e)
        {
            SerializableObject obj = new SerializableObject();
            MySerializer serializer = new MySerializer();
         
            obj = serializer.DeserializeObject("Users.txt");

            Main.users = obj.Users;

            string log = Login.Text;
            string pas1 = Main.GetHashString(Password.Text);

            int er = -1;
            int uid;

            foreach (User p in Main.users)
            {
                if ((p.Login == log) && (p.Password == pas1))
                {
                    er = 1;
                    uid = p.UID;
                    Main.currentuser = uid;

                }
            }
            if (er == 1)
            {
                if (open() != false)
                {
                    this.Hide();
                    Main.vhod = 1;
                }
                else MessageBox.Show("Файлы не найдены.");

            }
            else MessageBox.Show("Вход не выполнен.");
        }

        public void formating()
        {
            //чистим списки
            Main.users.Clear();
            Main.roots.Clear();
            Main.inodes.Clear();
            Main.bitcard.Clear();
            BinaryFormatter Formatter = new BinaryFormatter();

            //форматируем суперблок
            Main.Super1.s_type = "S5FS";
            Main.Super1.s_fsize = 36864;
            Main.Super1.s_bsize = 4096;
            FileStream File = new FileStream(@"SuperBlock.txt", FileMode.Create);
            Formatter.Serialize(File, Main.Super1);
            File.Close();

            //форматируем Inode, Bitcard
            bool[] lis = { true, true, true, true };
            DateTime Time_create = DateTime.Now;
            DateTime Time_modify = DateTime.Now;
            for (int i = 0; i < Main.Super1.s_fsize; i++)
            {
                Inode TestInode1 = new Inode(i, -1, lis, -1, Time_create, Time_modify, new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }, false, false);
                Main.inodes.Add(TestInode1);
                Main.bitcard.Add(false);
            }
            SerializableObject1 obj1 = new SerializableObject1();
            obj1.Inodes = Main.inodes;
            MySerializer1 serializer1 = new MySerializer1();
            serializer1.SerializeObject1(@"Inodes.txt", obj1);
            SerializableObject2 obj2 = new SerializableObject2();
            obj2.Bitcard = Main.bitcard;
            MySerializer2 serializer2 = new MySerializer2();
            serializer2.SerializeObject2(@"Bitcard.txt", obj2);

            //форматируем пользователей   
            User TestUser = new User(0, "admin", Main.GetHashString("admin"),1);
            Main.users.Add(TestUser);
            string log = "**********";
            string pas = Main.GetHashString("**********");
            for (int i = 1; i <= 49; i++)
            {
                User TestUser1 = new User(i, log, pas,0);
                Main.users.Add(TestUser1);

            }
            SerializableObject obj = new SerializableObject();
            obj.Users = Main.users;
            MySerializer serializer = new MySerializer();
            serializer.SerializeObject(@"Users.txt", obj);

            //Заполнение места для информации
            File = new FileStream("Data.txt", FileMode.Create);
            File.Seek(Main.Super1.s_fsize * Main.Super1.s_bsize, SeekOrigin.Begin);
            byte[] ar = new byte[3];
            File.Write(ar, 0, 3);
            File.Close();

            //заполнение корневого каталога
            string name1 = "^^^^^^^^";
            for (int i = 0; i < Main.Super1.s_fsize; i++)
            {
                Root Root1 = new Root(i, name1);
                Main.roots.Add(Root1);
            }
            SerializableObject5 obj5 = new SerializableObject5();
            obj5.Roots = Main.roots;
            MySerializer5 serializer5 = new MySerializer5();
            serializer5.SerializeObject5(@"Roots.txt", obj5);

            MessageBox.Show("Форматирование завершено.");
        }

      
    }
}
