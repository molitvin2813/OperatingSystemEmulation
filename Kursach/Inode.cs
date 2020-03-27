using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    [Serializable]
    public class Inode : ISerializable
    {
        public int IDnode;              //id инода
        public int UID;                 //id пользователя
        public bool[] lis = {};         //права доступа
        public int File_size;           //размер файла
        public DateTime Time_create;    //дата_время создания файла
        public DateTime Time_modify;    //дата_время изменения файла
        public int[] block;             //номера кластеров
        public bool flag;               //просто флаг (свободен/занят)
        public bool isDirectory;

        public Inode(int IDnode1, int UID1, bool[] lis1, int File_size1, DateTime Time_create1,
            DateTime Time_modify1, int[] block1, bool flag1, bool isDirectory)
        {
            IDnode = IDnode1;
            UID = UID1;
            lis = lis1;
            File_size = File_size1;
            Time_create = Time_create1;
            Time_modify = Time_modify1;
            block = block1;
            flag = false;
            this.isDirectory = isDirectory;
        }

        public Inode(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.IDnode = (int)sInfo.GetValue("IDnode", typeof(int));
            this.UID = (int)sInfo.GetValue("UID", typeof(int));
            this.File_size = (int)sInfo.GetValue(" File_size", typeof(int));
            this.lis = (bool[])sInfo.GetValue("lis", typeof(bool[]));
            this.block = (int[])sInfo.GetValue("block", typeof(int[]));
            this.Time_create = (DateTime)sInfo.GetValue("Time_create", typeof(DateTime));
            this.Time_modify = (DateTime)sInfo.GetValue("Time_modify", typeof(DateTime));
            this.flag = (bool)sInfo.GetValue("flag", typeof(bool));
            this.isDirectory = (bool)sInfo.GetValue("isDirectory", typeof(bool));
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("UID", this.UID);
            sInfo.AddValue(" File_size", this.File_size);
            sInfo.AddValue("IDnode", this.IDnode);
            sInfo.AddValue("lis", this.lis);
            sInfo.AddValue("block", this.block);
            sInfo.AddValue("Time_create", this.Time_create);
            sInfo.AddValue("Time_modify", this.Time_modify);
            sInfo.AddValue("flag", this.flag);
            sInfo.AddValue("isDirectory", this.isDirectory);
        }
    }

    [Serializable]
    public class SerializableObject1 : ISerializable
    {
        private List<Inode> inodes;

        public List<Inode> Inodes
        {
            get { return this.inodes; }
            set { this.inodes = value; }
        }

        public SerializableObject1() { }

        public SerializableObject1(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.inodes = (List<Inode>)sInfo.GetValue("Inodes", typeof(List<Inode>));
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("Inodes", this.inodes);
        }
    }

    public class MySerializer1
    {
        public MySerializer1() { }

        public void SerializeObject1(string fileName, SerializableObject1 objToSeriaize)
        {
            FileStream fstream = File.Open(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fstream, objToSeriaize);
            fstream.Close();
        }

        public SerializableObject1 DeserializeObject1(string fileName)
        {
            SerializableObject1 objToSerialize = null;
            FileStream fstream = File.Open(fileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            objToSerialize = (SerializableObject1)binaryFormatter.Deserialize(fstream);
            fstream.Close();
            return objToSerialize;
        }
    }

    //для битовой карты
    [Serializable]
    public class SerializableObject2 : ISerializable
    {
        private List<Boolean> bitcard;

        public List<Boolean> Bitcard
        {
            get { return this.bitcard; }
            set { this.bitcard = value; }
        }

        public SerializableObject2() {}

        public SerializableObject2(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.bitcard = (List<Boolean>)sInfo.GetValue("Bitcard", typeof(List<Boolean>));
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("Bitcard", this.bitcard);
        }
    }

    //для битовой карты
    public class MySerializer2
    {
        public MySerializer2() { }

        public void SerializeObject2(string fileName, SerializableObject2 objToSerialize)
        {
            FileStream fstream = File.Open(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fstream, objToSerialize);
            fstream.Close();
        }

        public SerializableObject2 DeserializeObject2(string fileName)
        {
            SerializableObject2 objToSerialize = null;
            FileStream fstream = File.Open(fileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            objToSerialize = (SerializableObject2)binaryFormatter.Deserialize(fstream);
            fstream.Close();
            return objToSerialize;
        }
    }
}