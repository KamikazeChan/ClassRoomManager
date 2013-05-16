using System;
using System.Data;
using System.Runtime.Serialization;



namespace ClassRoom.Model
{
    [DataContract]
    [KnownType(typeof(DigitalFileInfoEntity))]
	public class DigitalFileInfoEntity 
	{
        internal const string DB_TableName = "DigitalFileInfo";
        
		#region Properties
		
		#region public Guid ID		
        /// <summary>
        /// ID数据字段名
        /// </summary>
        public const string DF_ID = "DigitalFileInfo_ID";	        
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
		
		#region public int ExtensionTypeID		
        /// <summary>
        /// ExtensionTypeID数据字段名
        /// </summary>
        public const string DF_ExtensionTypeID = "DigitalFileInfo_ExtensionTypeID";	        
		private int _ExtensionTypeID = 0;
		/// <summary>
		/// 文件扩展类型    
		/// </summary>
		[DataMember]
		public int ExtensionTypeID
		{
			get { 
                return _ExtensionTypeID; 
                }
			set { _ExtensionTypeID = value;}
		}		
		#endregion
		
		#region public Guid DigitalFileID		
        /// <summary>
        /// DigitalFileID数据字段名
        /// </summary>
        public const string DF_DigitalFileID = "DigitalFileInfo_DigitalFileID";	        
		private Guid _DigitalFileID = Guid.Empty;
		/// <summary>
		/// 文件数据ID    
		/// </summary>
		[DataMember]
		public Guid DigitalFileID
		{
			get { 
                return _DigitalFileID; 
                }
			set { _DigitalFileID = value;}
		}		
		#endregion
		
		#region public string FileTitle		
        /// <summary>
        /// FileTitle数据字段名
        /// </summary>
        public const string DF_FileTitle = "DigitalFileInfo_FileTitle";	        
		private string _FileTitle = string.Empty;
		/// <summary>
		/// 文件名称    
		/// </summary>
		[DataMember]
		public string FileTitle
		{
			get { 
                return _FileTitle; 
                }
			set { _FileTitle = value;}
		}		
		#endregion
		
		#region public DateTime CreateTime		
        /// <summary>
        /// CreateTime数据字段名
        /// </summary>
        public const string DF_CreateTime = "DigitalFileInfo_CreateTime";	        
		private DateTime _CreateTime = Convert.ToDateTime("1900/01/01");
		/// <summary>
		/// 建立时间    
		/// </summary>
		[DataMember]
		public DateTime CreateTime
		{
			get { 
                return _CreateTime; 
                }
			set { _CreateTime = value;}
		}		
		#endregion
		
		#region public int CreateSysUserID		
        /// <summary>
        /// CreateSysUserID数据字段名
        /// </summary>
        public const string DF_CreateSysUserID = "DigitalFileInfo_CreateSysUserID";	        
		private int _CreateSysUserID = 0;
		/// <summary>
		/// 建立人ID    
		/// </summary>
		[DataMember]
		public int CreateSysUserID
		{
			get { 
                return _CreateSysUserID; 
                }
			set { _CreateSysUserID = value;}
		}		
		#endregion
		
		#region public string Description		
        /// <summary>
        /// Description数据字段名
        /// </summary>
        public const string DF_Description = "DigitalFileInfo_Description";	        
		private string _Description = string.Empty;
		/// <summary>
		/// 建立人说明    
		/// </summary>
		[DataMember]
		public string Description
		{
			get { 
                return _Description; 
                }
			set { _Description = value;}
		}		
		#endregion
		
		#endregion     
		
		
        #region Clone

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public DigitalFileInfoEntity Clone()
        {
            DigitalFileInfoEntity entity = new DigitalFileInfoEntity();
            Clone(entity);
            return entity;
        }

        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(DigitalFileInfoEntity entity)
        {
           entity.ID = this.ID;
           entity.ExtensionTypeID = this.ExtensionTypeID;
           entity.DigitalFileID = this.DigitalFileID;
           entity.FileTitle = this.FileTitle;
           entity.CreateTime = this.CreateTime;
           entity.CreateSysUserID = this.CreateSysUserID;
           entity.Description = this.Description;
           
        }
        #endregion
        
        #region Equals
        /// <summary>
        /// 是否相等,仅用于Entity对比
        /// </summary>
        public bool Equals(DigitalFileInfoEntity entity)
        {
           return entity.ExtensionTypeID == this.ExtensionTypeID &&
                  entity.DigitalFileID == this.DigitalFileID &&
                  entity.FileTitle == this.FileTitle &&
                  entity.CreateTime == this.CreateTime &&
                  entity.CreateSysUserID == this.CreateSysUserID &&
                  entity.Description == this.Description;
        }
        #endregion
	}
}
