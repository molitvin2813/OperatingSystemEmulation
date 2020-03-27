using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kursach
{
    [Serializable]
    public class Root : ISerializable
    {
        public bool isDirectory;
        public int idFile;
        public string nameFile;

        public Root(int idFile1, string nameFile1)
        {
            idFile = idFile1;
            nameFile = nameFile1;
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("idFile", this.idFile);
            sInfo.AddValue("nameFile", this.nameFile);
        }

        public Root(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.idFile = (int)sInfo.GetValue("idFile", typeof(int));
            this.nameFile = (string)sInfo.GetValue("nameFile", typeof(string));
        }
    }

    [Serializable]
    public class SerializableObject5 : ISerializable
    {
        private List<Root> roots;

        public List<Root> Roots
        {
            get { return this.roots; }
            set { this.roots = value; }
        }

        public SerializableObject5() { }

        public SerializableObject5(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.roots = (List<Root>)sInfo.GetValue("Roots", typeof(List<Root>));
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("Roots", this.roots);
        }
    }

    public class MySerializer5
    {
        public MySerializer5() { }

        public void SerializeObject5(string fileName, SerializableObject5 objToSerialize)
        {
            FileStream fstream = File.Open(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fstream, objToSerialize);
            fstream.Close();
        }

        public SerializableObject5 DeserializeObject5(string fileName)
        {
            SerializableObject5 objToSerialize = null;
            FileStream fstream = File.Open(fileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            objToSerialize = (SerializableObject5)binaryFormatter.Deserialize(fstream);
            fstream.Close();
            return objToSerialize;
        }
    }
}
