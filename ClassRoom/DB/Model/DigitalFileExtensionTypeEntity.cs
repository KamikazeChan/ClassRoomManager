using System;
using System.Data;
using System.Runtime.Serialization;

namespace ClassRoom.Model
{
    [DataContract]
    [KnownType(typeof(DigitalFileExtensionTypeEntity))]
	public class DigitalFileExtensionTypeEntity 
	{
        internal const string DB_TableName = "DigitalFileExtensionType";
        
		#region Properties
		
		#region public int ID		
        /// <summary>
        /// ID数据字段名
        /// </summary>
        public const string DF_ID = "DigitalFileExtensionType_ID";	        
		private int _ID = 0;
		/// <summary>
		/// 文件扩展ID    
		/// </summary>
		[DataMember]
		public int ID
		{
			get { 
                return _ID; 
                }
			set { _ID = value;}
		}		
		#endregion
		
		#region public string Name		
        /// <summary>
        /// Name数据字段名
        /// </summary>
        public const string DF_Name = "DigitalFileExtensionType_Name";	        
		private string _Name = string.Empty;
		/// <summary>
		/// 名称    
		/// </summary>
		[DataMember]
		public string Name
		{
			get { 
                return _Name; 
                }
			set { _Name = value;}
		}		
		#endregion
		
		#region public string Description		
        /// <summary>
        /// Description数据字段名
        /// </summary>
        public const string DF_Description = "DigitalFileExtensionType_Description";	        
		private string _Description = string.Empty;
		/// <summary>
		/// 说明    
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
		
		#region public bool IsFiexd		
        /// <summary>
        /// IsFiexd数据字段名
        /// </summary>
        public const string DF_IsFiexd = "DigitalFileExtensionType_IsFiexd";	        
		private bool _IsFiexd = false;
		/// <summary>
		/// 是否标准类型    
		/// </summary>
		[DataMember]
		public bool IsFiexd
		{
			get { 
                return _IsFiexd; 
                }
			set { _IsFiexd = value;}
		}		
		#endregion
		
		#endregion     
		
		
        #region Clone

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public DigitalFileExtensionTypeEntity Clone()
        {
            DigitalFileExtensionTypeEntity entity = new DigitalFileExtensionTypeEntity();
            Clone(entity);
            return entity;
        }

        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(DigitalFileExtensionTypeEntity entity)
        {
           entity.ID = this.ID;
           entity.Name = this.Name;
           entity.Description = this.Description;
           entity.IsFiexd = this.IsFiexd;
           
        }
        #endregion
        
        #region Equals
        /// <summary>
        /// 是否相等,仅用于Entity对比
        /// </summary>
        public bool Equals(DigitalFileExtensionTypeEntity entity)
        {
           return entity.Name == this.Name &&
                  entity.Description == this.Description &&
                  entity.IsFiexd == this.IsFiexd;
        }
        #endregion
	}
}
