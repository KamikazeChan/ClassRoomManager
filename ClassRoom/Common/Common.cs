using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.ComponentModel;

namespace ClassRoom.Common
{
    class CommonClass
    {
        public CommonClass(){}

        public static TicketInfo UserTicket { get; set; }

        //public static Dictionary<string, List<DictionaryEntry>> EnumDataCollection = new Dictionary<string, List<DictionaryEntry>>();
        /// <summary>
        /// 根据枚举获取数据
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns>key value</returns>
        public static List<DictionaryEntry> ListTypeForEnum(Type enumType)
        {
            //if (EnumDataCollection.ContainsKey(enumType.FullName))
            //{ return EnumDataCollection[enumType.FullName].ToList(); }

            FieldInfo[] fis = enumType.GetFields();

            List<DictionaryEntry> list = new List<DictionaryEntry>();
            foreach (FieldInfo fi in fis)
            {
                if (fi.FieldType.IsEnum)
                {
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string name = (attributes.Length > 0) ? attributes[0].Description : fi.Name;
                    DictionaryEntry de = new DictionaryEntry(name, ((int)Enum.Parse(enumType, fi.Name)));

                    list.Add(de);
                }
            }
            //EnumDataCollection.Add(enumType.FullName, list);
            return list.ToList();
        }
    }
}
