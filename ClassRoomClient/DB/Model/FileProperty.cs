using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ClassRoom.Model
{
    [DataContract]
    [KnownType(typeof(FileProperty))]
    public class FileProperty
    {
        #region 客户端上传的文件全名
        private string _FileName = string.Empty;
        [DataMember]
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }
        #endregion

        #region 文件GUID = DigitalFileInfoID
        private Guid _GUID = Guid.Empty;
        [DataMember]
        public Guid GUID
        {
            get { return _GUID; }
            set { _GUID = value; }
        }
        #endregion

        #region 文件长度
        private long _Length = 0;
        [DataMember]
        public long Length
        {
            get { return _Length; }
            set { _Length = value; }
        }
        #endregion

        #region 文件MD5
        private string _MD5 = string.Empty;
        [DataMember]
        public string MD5
        {
            get { return _MD5; }
            set { _MD5 = value; }
        }
        #endregion
        
        #region 文件的描述
        private string _FileDescription = string.Empty;
        [DataMember]
        public string FileDescription
        {
            get { return _FileDescription; }
            set { _FileDescription = value; }
        }
        #endregion
    }
}
