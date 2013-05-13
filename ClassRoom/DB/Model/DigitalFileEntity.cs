using System;
using System.Data;
using System.Runtime.Serialization;


namespace ClassRoom.Model
{
    [DataContract]
    [KnownType(typeof(DigitalFileEntity))]
	public class DigitalFileEntity
	{
        internal const string DB_TableName = "DigitalFile";
        
		#region Properties
		
		#region public Guid ID		
        /// <summary>
        /// ID数据字段名
        /// </summary>
        public const string DF_ID = "DigitalFile_ID";	        
		private Guid _ID = Guid.Empty;
		/// <summary>
		/// 文件ID    
		/// </summary>
		[DataMember]
		public Guid ID
		{
			get { 
                return _ID; 
                }
			set { _ID = value;}
		}		
		#endregion
		
		#region public string MD5		
        /// <summary>
        /// MD5数据字段名
        /// </summary>
        public const string DF_MD5 = "DigitalFile_MD5";	        
		private string _MD5 = string.Empty;
		/// <summary>
		/// 文件校验码    
		/// </summary>
		[DataMember]
		public string MD5
		{
			get { 
                return _MD5; 
                }
			set { _MD5 = value;}
		}		
		#endregion
		
		#region public long FileLength		
        /// <summary>
        /// FileLength数据字段名
        /// </summary>
        public const string DF_FileLength = "DigitalFile_FileLength";	        
		private long _FileLength = 0;
		/// <summary>
		/// 文件长度    
		/// </summary>
		[DataMember]
		public long FileLength
		{
			get { 
                return _FileLength; 
                }
			set { _FileLength = value;}
		}		
		#endregion
		
		#region public string FileFolder		
        /// <summary>
        /// FileFolder数据字段名
        /// </summary>
        public const string DF_FileFolder = "DigitalFile_FileFolder";	        
		private string _FileFolder = string.Empty;
		/// <summary>
		/// 文件目录    
		/// </summary>
		[DataMember]
		public string FileFolder
		{
			get { 
                return _FileFolder; 
                }
			set { _FileFolder = value;}
		}		
		#endregion
		
		#endregion     
		
		
        #region Clone

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public DigitalFileEntity Clone()
        {
            DigitalFileEntity entity = new DigitalFileEntity();
            Clone(entity);
            return entity;
        }

        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(DigitalFileEntity entity)
        {
           entity.ID = this.ID;
           entity.MD5 = this.MD5;
           entity.FileLength = this.FileLength;
           entity.FileFolder = this.FileFolder;
           
        }
        #endregion
        
        #region Equals
        /// <summary>
        /// 是否相等,仅用于Entity对比
        /// </summary>
        public bool Equals(DigitalFileEntity entity)
        {
           return entity.MD5 == this.MD5 &&
                  entity.FileLength == this.FileLength &&
                  entity.FileFolder == this.FileFolder;
        }
        #endregion
	}
}
