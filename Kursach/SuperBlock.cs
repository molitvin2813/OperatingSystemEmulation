using System;
using System.Runtime.Serialization;

namespace Kursach
{
    [Serializable]
    public class SuperBlock : ISerializable
    {
        //тип файловой системы
        public string s_type;
        //кол-во логических блоков данных
        public int s_fsize;
        //размер лог-го блока данных
        public int s_bsize;

        public SuperBlock() {}

        public SuperBlock(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.s_type = (string)sInfo.GetValue("s_type", typeof(string));
            this.s_fsize = (int)sInfo.GetValue("s_fsize", typeof(int));
            this.s_bsize = (int)sInfo.GetValue("s_bsize", typeof(int));
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("s_type", this.s_type);
            sInfo.AddValue("s_fsize", this.s_fsize);
            sInfo.AddValue("s_bsize", this.s_bsize);
        }
    }
}
