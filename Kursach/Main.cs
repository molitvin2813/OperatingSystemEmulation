using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Main : Form
    {
        public  static List<User> users = new List<User>();
        public static List<Inode> inodes = new List<Inode>();
        public static List<Boolean> bitcard = new List<Boolean>();
        public static List<Root> roots = new List<Root>();
        public static SuperBlock Super1 = new SuperBlock();
        public static byte[] MassivByte;
        private static bool flash_file;
        private static bool flash_user;
        public static int inod;
        public static int flag_operation;
        public static int currentuser;
        public static int currDirIno = -1;
        public static String currDir = "/";
        public static String currFile = "";
        public static FileStream File;


        public static int vhod = 0;

        List<string> historyDirectory = new List<string>();
        AddForm add = new AddForm();
        EnterForm enter = new EnterForm();
        EditForm edit = new EditForm();
        EditUserForm editUser = new EditUserForm();
        int hist = 0;
        public static int currIno;
        private string chooseFile;
        int lastnode;
        public Main()
        {
            InitializeComponent();
            directory.Text = currDir;
            historyDirectory.Add(currDir);
        }

       

        private void listfile(object sender, EventArgs e)
        {
            ListViewItem item;
            listView1.Items.Clear();
            foreach (Root root in roots)
            {
                if (root.nameFile != ("^^^^^^^^"))
                {
                    string name, size, create, modify, use = "", lis, is_dir;
                    int p = root.idFile;


                    name = root.nameFile;
                    foreach (Inode inode in inodes)
                    {
                        if (inode.IDnode == p)
                        {

                            size = Convert.ToString(inode.File_size);

                            create = Convert.ToString(inode.Time_create);

                            modify = Convert.ToString(inode.Time_modify);

                            is_dir = inode.isDirectory ? "Каталог" : "Обычный файл";

                            foreach (User user in users)
                            {
                                if (user.UID == inode.UID)
                                {

                                    use = user.Login;
                                    break;
                                }
                            }
                            string lisstr = "";

                            if ((inode.UID != currentuser) && (currentuser != 0) && users[currentuser].isAdmin == 1)
                            {
                                if (inode.lis[1]==false)
                                    lisstr += "**";
                                else
                                {
                                    if (inode.lis[0] == true)
                                        lisstr += "r";
                                    else lisstr += "-";
                                    if (inode.lis[1] == true)
                                        lisstr += "w";
                                    else lisstr += "-";
                                }
                                if (inode.lis[2] == true)
                                    lisstr += "r";
                                else lisstr += "-";
                                if (inode.lis[3] == true)
                                    lisstr += "w";
                                else lisstr += "-";
                            }
                            else if ((inode.UID != currentuser) && (currentuser == 0) )
                            {
                                if (inode.lis[0] == true)
                                    lisstr += "r";
                                else lisstr += "-";
                                if (inode.lis[1] == true)
                                    lisstr += "w";
                                else lisstr += "-";
                                if (inode.lis[2] == true)
                                    lisstr += "r";
                                else lisstr += "-";
                                if (inode.lis[3] == true)
                                    lisstr += "w";
                                else lisstr += "-";
                            }
                            if ((inode.UID == currentuser))
                            {
                                if(users[currentuser].isAdmin == 1)
                                {
                                    if (inode.lis[0] == true)
                                        lisstr += "r";
                                    else lisstr += "-";
                                    if (inode.lis[1] == true)
                                        lisstr += "w";
                                    else lisstr += "-";
                                }
                               else
                                {
                                    lisstr += "**";
                                }
                                if (inode.lis[2] == true)
                                    lisstr += "r";
                                else lisstr += "-";
                                if (inode.lis[3] == true)
                                    lisstr += "w";
                                else lisstr += "-";
                            }
                            lis = lisstr;
                            if (name.Length < 7)
                            {
                                item = new ListViewItem(name);
                                if(is_dir== "Обычный файл")
                                    item.SubItems.Add(size);
                                else
                                    item.SubItems.Add("");
                                item.SubItems.Add(create);
                                item.SubItems.Add(modify);
                                item.SubItems.Add(lis);
                                item.SubItems.Add(use);
                                item.SubItems.Add(is_dir);
                               
                            }
                                
                            else
                            {
                                if (name.Length == 7)
                                {
                                    item = new ListViewItem(name);
                                    if (is_dir == "Обычный файл")
                                        item.SubItems.Add(size);
                                    else
                                        item.SubItems.Add("");
                                    item.SubItems.Add(create);
                                    item.SubItems.Add(modify);
                                    item.SubItems.Add(lis);
                                    item.SubItems.Add(use);
                                    item.SubItems.Add(is_dir);
                                    
                                }
                                else
                                {
                                    item = new ListViewItem(name);
                                    if (is_dir == "Обычный файл")
                                        item.SubItems.Add(size);
                                    else
                                        item.SubItems.Add("");
                                    item.SubItems.Add(create);
                                    item.SubItems.Add(modify);
                                    item.SubItems.Add(lis);
                                    item.SubItems.Add(use);
                                    item.SubItems.Add(is_dir);
                                    
                                }
                                    
                            }
                            
                            listView1.Items.Add(item);
                            break;

                        }
                    }

                }

            }
        }

        public static string GetHashString(string s)
        {
            //переводим строку в байт-массив   
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования   
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах   
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива   
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            enter.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(vhod==1)
                add.Show();
        }

        private void exit(object sender, EventArgs e)
        {
            if (vhod == 1)
            {
                BinaryFormatter Formatter = new BinaryFormatter();
                FileStream File = new FileStream("SuperBlock.txt", FileMode.Create);
                Formatter.Serialize(File, Super1);      //сериализация
                File.Close();

                //форматируем Inode, Bitcard
                SerializableObject1 obj1 = new SerializableObject1();
                obj1.Inodes = inodes;
                MySerializer1 serializer1 = new MySerializer1();
                serializer1.SerializeObject1("Inodes.txt", obj1);

                SerializableObject2 obj2 = new SerializableObject2();
                obj2.Bitcard = bitcard;
                MySerializer2 serializer2 = new MySerializer2();
                serializer2.SerializeObject2("Bitcard.txt", obj2);

                if (currDir == "/")
                {
                    //заполнение рута
                    SerializableObject5 obj5 = new SerializableObject5();
                    obj5.Roots = roots;
                    MySerializer5 serializer5 = new MySerializer5();
                    serializer5.SerializeObject5("Roots.txt", obj5);
                }
                else
                    save_file_binary(currDirIno, serializeDirectory(roots));

                //форматируем пользователей.    
                SerializableObject obj = new SerializableObject();
                obj.Users = users;
                MySerializer serializer = new MySerializer();
                serializer.SerializeObject("Users.txt", obj);
            }
            Environment.Exit(0);
        }
        public static void save_file_binary(int nodeNumber, byte[] buf)
        {
            MassivByte = buf;
            File = new FileStream("Data.txt", FileMode.Open);
            inodes[nodeNumber].File_size = buf.Length;
            inodes[nodeNumber].Time_modify = DateTime.Now;
            //Textfile.Text = "";

            //смотрим, сколько нужно всего кластеров
            int WaitCountClasters = 0;
            if (MassivByte.Length % Super1.s_bsize == 0)
                WaitCountClasters = MassivByte.Length / Super1.s_bsize;
            else
                WaitCountClasters = MassivByte.Length / Super1.s_bsize + 1;

            //если < 10 - ищем свободный инод
            if (WaitCountClasters <= 10)
            {
                int er = 0;
                for (int j = 0; j < 10; j++)
                {
                    if (inodes[nodeNumber].block[j] != -1)
                        er++;
                }
                if (WaitCountClasters == er)
                {
                    int LengthMassive = MassivByte.Length;
                    int position = 0;
                    int clasterSize = Super1.s_bsize;
                    for (int p = 0; p < er; p++)
                    {
                        File.Seek(inodes[nodeNumber].block[p] * Super1.s_bsize, SeekOrigin.Begin);
                        if (Super1.s_bsize < LengthMassive)
                        {
                            File.Write(MassivByte, 0, Super1.s_bsize);
                            LengthMassive -= Super1.s_bsize;
                            position += Super1.s_bsize;
                        }
                        else
                        {
                            File.Write(MassivByte, position, LengthMassive);
                        }
                    }
                }

                if ((WaitCountClasters <= er) || (WaitCountClasters >= er))
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (inodes[nodeNumber].block[j] != -1)
                            bitcard[inodes[nodeNumber].block[j]] = false;
                        inodes[nodeNumber].block[j] = -1;
                        er++;
                    }
                    int Last = -1, i = 0;
                    int LengthMassive = MassivByte.Length;
                    int position = 0;
                    int bit = -1;
                    int clasterSize = Super1.s_bsize;

                    for (i = 0; i < bitcard.Count; i++)
                    {
                        if (bitcard[i] == false)
                        {
                            bit = i;
                            bitcard[i] = true;
                            break;
                        }
                    }

                    inodes[nodeNumber].block[0] = bit;
                    Last = i;

                    WaitCountClasters--;

                    File.Seek(i * Super1.s_bsize, SeekOrigin.Begin);
                    if (Super1.s_bsize < LengthMassive)
                    {
                        File.Write(MassivByte, 0, Super1.s_bsize);
                        LengthMassive -= Super1.s_bsize;
                        position += Super1.s_bsize;
                    }
                    else
                    {
                        File.Write(MassivByte, 0, LengthMassive);
                    }

                    if (WaitCountClasters > 0)
                    {
                        int p = 1;
                        for (i = 0; (i < bitcard.Count && WaitCountClasters != 0); i++)
                        {
                            if (bitcard[i] == false)
                            {
                                bitcard[i] = true;
                                inodes[nodeNumber].block[p] = i;
                                p++;
                                Last = i;
                                WaitCountClasters--;
                                File.Seek((i) * Super1.s_bsize, SeekOrigin.Begin);
                                if (Super1.s_bsize < LengthMassive)
                                {
                                    File.Write(MassivByte, position, Super1.s_bsize);
                                    LengthMassive -= Super1.s_bsize;
                                    position += Super1.s_bsize;
                                }
                                else
                                {
                                    File.Write(MassivByte, position, LengthMassive);
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
        public static byte[] serializeDirectory(List<Root> directory)
        {
            byte[] encMsg = null;
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter br = new BinaryFormatter();
                br.Serialize(ms, directory);
                encMsg = ms.ToArray();
            }

            return encMsg;
        }

        private List<Root> deserializeDirectory(byte[] buf)
        {
            List<Root> obj = null;
            using (MemoryStream ms = new MemoryStream(buf))
            {
                IFormatter br = new BinaryFormatter();
                obj = (br.Deserialize(ms) as List<Root>);
            }

            return obj;
        }

        private void delete_file(object sender, EventArgs e)
        {
            if (vhod == 1)
            {
                string add;
                ListViewItem item = listView1.SelectedItems[0]; //Получаем один выделенный item
                add = (item.SubItems[0].Text);

                int inod = findFile(add);
                foreach (Inode inode in inodes)
                {
                    if (inode.IDnode == inod && inode.File_size > 0 && inode.isDirectory == true)
                    {
                        MessageBox.Show("Директория должна быть пустой перед удалением.");
                        return;
                    }
                }

                if (inod != -1)
                {

                    if (inodes[findFile(add)].UID == currentuser)
                    {
                        if (inodes[findFile(add)].lis[1] == true)
                        {
                            int w = deleteinf(add);
                            add = String.Empty;
                        }
                        else MessageBox.Show("Недостаточно прав для удаления файла.");
                    }
                    else
                    {
                        if (inodes[findFile(add)].lis[3] == true)
                        {
                            int w = deleteinf(add);
                            add = String.Empty;
                        }
                        else MessageBox.Show("Недостаточно прав для удаления файла.");
                    }
                }
                else MessageBox.Show("Введите корректное имя файла.");
                saveState();
                listfile(sender, e);
            }
        }

        private void saveState()
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
        }
        public static int findFile(string filename)
        {
            foreach (Root root in roots)
            {
                if (root.nameFile == filename)
                {
                    return root.idFile;
                }
            }
            return -1;
        }

        private int deleteinf(string namefile)
        {

            if (namefile == "" || namefile.Length > 8)
            {
                MessageBox.Show("Файл не найден.");
                return -1;
            }

            else
            {
                int InodNumber = -1;
                foreach (Root root in roots)
                {
                    if (root.nameFile == namefile)
                    {

                        InodNumber = root.idFile;
                        root.nameFile = "^^^^^^^^";
                        break;
                    }
                }
                if (InodNumber != -1)
                {

                    foreach (Inode fr in inodes)
                    {
                        if (fr.IDnode == InodNumber)
                        {
                            fr.File_size = -1;
                            fr.lis = new Boolean[] { true, true, true, true };
                            fr.flag = false;
                            fr.UID = -1;
                            fr.Time_create = DateTime.Now;
                            fr.Time_modify = DateTime.Now;
                            fr.block = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                            break;
                        }
                    }
                    
                    return 0;

                }
                else
                {
                    MessageBox.Show("Такого файла не существует!");
                    return -1;
                }

            }

        }

        private void changeDirectory_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0]; //Получаем один выделенный item
            historyDirectory.Add(item.SubItems[0].Text);
            hist++;
            changeDirectory(string.Join("/", historyDirectory.ToArray()));
            
            add.Label = currDir;
            listfile(sender, e);
            directory.Text = string.Join("/", historyDirectory.ToArray());
        }

        private void changeDirectory(string path)
        {
            if (currDirIno == -1)
            {
                //заполнение рута
                SerializableObject5 obj5 = new SerializableObject5();
                obj5.Roots = roots;
                MySerializer5 serializer5 = new MySerializer5();
                serializer5.SerializeObject5("Roots.txt", obj5);
            }
            else
                save_file_binary(currDirIno, serializeDirectory(roots));

            //открываем рут он же корень
            SerializableObject5 obj = new SerializableObject5();
            MySerializer5 serializer = new MySerializer5();
            obj.Roots = roots;
            obj = serializer.DeserializeObject5("Roots.txt");
            roots = obj.Roots;

            if (path == "/")
            {
                currDir = "/";
                return;
            }

            String[] filenames = path.Trim('/').Split('/');
            if (filenames.Length > 0)
            {
                int err = openDirectory(filenames[0]);

                if (err == -9)
                {
                    changeDirectory(currDir);
                    return;
                }

                if (filenames.Length > 1)
                {
                    for (int i = 1; i < filenames.Length; i++)
                    {
                        save_file_binary(currDirIno, serializeDirectory(roots));
                        err = openDirectory(filenames[i]);

                        if (err == -9)
                        {
                            changeDirectory(currDir);
                            return;
                        }
                    }
                }
            }

            currDir = path;

        }


        private int openDirectory(string filename)
        {
            int fsize = openfile(filename);

            if (fsize == -9)
                return fsize;

            if (fsize > 0)
            {
                roots = deserializeDirectory(MassivByte);
            }
            else
                roots.Clear();

            currDirIno = currIno;

            return 0;
        }

        public int openfile(string filename)
        {
            int inodNumber = findFile(filename);  // ищем инод, связаный с файлом
            currIno = inodNumber;
            if (inodNumber != -1)                // если нашли
            {

                File = new FileStream("Data.txt", FileMode.Open);
                if (inodes[inodNumber].File_size <= Super1.s_bsize)// попробовать сделать размеры 
                    MassivByte = new byte[Super1.s_bsize];
                else
                    if (inodes[inodNumber].File_size % Super1.s_bsize == 0)
                    MassivByte = new byte[inodes[inodNumber].File_size];
                else MassivByte = new byte[(inodes[inodNumber].File_size / Super1.s_bsize) * Super1.s_bsize + Super1.s_bsize];

                //берем номер первого кластера////////////////////////////////

                int i = 0;  // смещение в массиве байтов

                int p = 0;
                while (inodes[inodNumber].block[p] != -1)
                {
                    readfile(ref inodes[inodNumber].block[p], ref i);
                    p++;


                }
                File.Close();
                return inodes[inodNumber].File_size;
            }
            else            // если не нашли инод связанный с фалом
            {
                MessageBox.Show("Файла не существует.");
                return -9;
            }
        }

        //  Считать информацию одного кластера
        private void readfile(ref int fistClater, ref int i)
        {
            File.Seek((fistClater) * Super1.s_bsize, SeekOrigin.Begin);
            File.Read(MassivByte, i, Super1.s_bsize);
            i += Super1.s_bsize;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (vhod == 1)
            {
                if (hist != 0)
                {
                    historyDirectory.RemoveAt(hist);
                    hist--;
                    changeDirectory(string.Join("/", historyDirectory.ToArray()));
                }

                else
                    MessageBox.Show("Вы в корневом катологе");
                add.Label = currDir;
                listfile(sender, e);
                directory.Text = string.Join("/", historyDirectory.ToArray());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            currFile = listView1.SelectedItems[0].Text;
            edit.Label = currFile;
            inod = findFile(currFile);
            if (users[currentuser].UID==0)
            {
                int gettext = openfile(currFile);
                edit.TextBox = "";
                string p = Encoding.Default.GetString(MassivByte);
                for (int i = 0; i < openfile(currFile); i++)
                    edit.TextBox += p[i];
                edit.Show();
                return;
            }
            if (inodes[inod].UID == currentuser)
            {
                if (inodes[inod].lis[3] == true)
                {
                    int gettext = openfile(currFile);
                    edit.TextBox = "";
                    string p = Encoding.Default.GetString(MassivByte);
                    for (int i = 0; i < openfile(currFile); i++)
                        edit.TextBox += p[i];
                    edit.Show();
                }
                else
                {
                    MessageBox.Show("Недостаточно прав для редактироваия файла.");
                    return;
                }


            }

            else if (inodes[inod].UID != currentuser && users[currentuser].isAdmin == 1)
            {
                if (inodes[inod].lis[1] == true)
                {


                    int gettext = openfile(currFile);
                    edit.TextBox = "";
                    string p = Encoding.Default.GetString(MassivByte);
                    for (int i = 0; i < openfile(currFile); i++)
                        edit.TextBox += p[i];

                    edit.Show();
                }
                else
                {
                    MessageBox.Show("Недостаточно прав для редактироваия файла.");
                    return;
                }
            }
            else if (inodes[inod].UID != currentuser && users[currentuser].isAdmin ==0)
                {
                    MessageBox.Show("Недостаточно прав для редактироваия файла.");
                    return;
                }
                    
            
            
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
            if (inodes[findFile(listView1.SelectedItems[0].Text)].isDirectory)
                changeDirectory_Click(sender, e);
            else
                btnEdit_Click(sender, e);      
        }


        private void directory_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(directory.Text) && !String.IsNullOrWhiteSpace(directory.Text))
                {
                    string[] words = directory.Text.Split(new char[] { '/' });
                    hist = 0;
                    historyDirectory.Clear();
                    historyDirectory.Add("/");
                    foreach (string s in words)
                    {
                        if (!String.IsNullOrEmpty(s))
                        {
                            historyDirectory.Add(s);
                            hist++;
                        }

                    }

                    int inod = findFile(historyDirectory[hist]);
                    if (inodes[findFile(historyDirectory[hist])].isDirectory)
                    {

                        changeDirectory(directory.Text);
                        add.Label = currDir;
                        listfile(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Введено имя файла,а не каталога");
                        string[] words2 = currDir.Split(new char[] { '/' });
                        hist = 0;
                        historyDirectory.Clear();
                        historyDirectory.Add("/");
                        foreach (string s in words)
                        {
                            if (!String.IsNullOrEmpty(s))
                            {
                                historyDirectory.Add(s);
                                hist++;
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите имя  каталога корректно.");
                    return;
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            editUser.Show();
        }

        int filesize;
        string f;
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            if (vhod == 1)
            {
                if (!inodes[findFile(listView1.SelectedItems[0].Text)].isDirectory)
                {
                    chooseFile = listView1.SelectedItems[0].Text;
                    lastnode = findFile(chooseFile);
                    filesize = openfile(chooseFile);
                    f = Encoding.UTF8.GetString(MassivByte);
                    delete_file(sender, e);
                    btnReplace.Enabled = true;
                }
                else
                    MessageBox.Show("Выберите ФАЙЛ, а не каталог");
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (vhod == 1)
            {
                int InodNumber = copy_copy(f, filesize, chooseFile, inodes[lastnode].lis, inodes[lastnode].isDirectory);
                Root TestRoot = new Root(InodNumber, chooseFile);
                roots.Add(TestRoot);
                MessageBox.Show("Файл добавлен.");

                saveState();
                listfile(sender, e);
                btnReplace.Enabled = false;
            }
        }

        private int copy_copy(string p, int filesize, string newname, bool[] lis, bool isDirectory)
        {
            string tmp = "";
            for (int i = 0; i < filesize; i++)
                tmp += p[i];
            int s = createfile(isDirectory, tmp, lis);
        
            if (s != -1)
            {
                return s;
            }
            else return -1;
        }

        private int createfile(bool isDirectory, String TextFail, bool[] lis1)
        {
            MassivByte = Encoding.Default.GetBytes(TextFail);
            File = new FileStream("Data.txt", FileMode.Open);
            int i, InodNumber = -1;
            int Last = -1;
           

            //смотрим, сколько нужно всего кластеров
            int WaitCountClasters = 0;
            if (MassivByte.Length % Super1.s_bsize == 0)
                WaitCountClasters = MassivByte.Length / Super1.s_bsize;
            else
                WaitCountClasters = MassivByte.Length / Super1.s_bsize + 1;

            //WaitCountClasters = 5;
            //int m = WaitCountClasters;
            int m = WaitCountClasters;
            //если < 10 - ищем свободный инод
            if (WaitCountClasters <= 10)
            {
                foreach (Inode freeinode in inodes)
                {
                    if (freeinode.flag == false)
                    {
                        InodNumber = freeinode.IDnode;
                        freeinode.File_size = TextFail.Length;
                        freeinode.flag = true;
                        freeinode.UID = currentuser;
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
                    File.Close();
                    MessageBox.Show("Нет свободных инодов.");
                    return -1;
                }

                Last = -1;
                int LengthMassive = MassivByte.Length;
                int position = 0;
                int bit = -1;
                int clasterSize = Super1.s_bsize;

                for (i = 0; i < bitcard.Count; i++)
                {
                    if (bitcard[i] == false)
                    {
                        bit = i;
                        bitcard[i] = true;
                        break;
                    }
                }

                inodes[InodNumber].block[0] = bit;
                Last = i;

                WaitCountClasters--;

                File.Seek(i * Super1.s_bsize, SeekOrigin.Begin);
                if (Super1.s_bsize < LengthMassive)
                {
                    File.Write(MassivByte, 0, Super1.s_bsize);
                    LengthMassive -= Super1.s_bsize;
                    position += Super1.s_bsize;
                }
                else
                {
                    File.Write(MassivByte, 0, LengthMassive);
                }

                if (Last == -1)
                {
                    File.Close();
                    MessageBox.Show("Недостаточно места для записи файла.");
                    return -1;
                }

                if (WaitCountClasters > 0)
                {
                    int p = 1;
                    for (i = 0; (i < bitcard.Count && WaitCountClasters != 0); i++)
                    {
                        if (bitcard[i] == false)
                        {
                            bitcard[i] = true;
                            inodes[InodNumber].block[p] = i;
                            p++;
                            Last = i;
                            WaitCountClasters--;
                            File.Seek((i) * Super1.s_bsize, SeekOrigin.Begin);
                            if (Super1.s_bsize < LengthMassive)
                            {
                                File.Write(MassivByte, position, Super1.s_bsize);
                                LengthMassive -= Super1.s_bsize;
                                position += Super1.s_bsize;
                            }
                            else
                            {
                                File.Write(MassivByte, position, LengthMassive);
                            }
                        }
                    }
                }
                File.Close();
                return InodNumber;
            }
            else
            {
                File.Close();
                return -1;
            }
        }

    }
}
