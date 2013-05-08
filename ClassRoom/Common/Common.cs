using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Data;

namespace ClassRoom.Util
{
    public class Common
    {
        #region 将系统时间转换为Javascript的时间格式
        /// <summary>
        /// 将系统时间转换为Javascript的时间格式
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>Javascript时间字符串</returns>
        public static string CovertToScriptTime(DateTime time)
        {
            return time.ToString("yyyy/MM/dd HH:mm:ss").Replace("/", "-");
        }

        public static string ConverToStringDate(DateTime time)
        {
            return time != Convert.ToDateTime("1900-01-01") && time != Convert.ToDateTime("0001-01-01") ? time.ToString("yyyy/MM/dd").Replace("/", "-") : null;
        }

        public static string ConverToStringDateNull(DateTime? time)
        {
            return time.HasValue ? time.Value.ToString("yyyy/MM/dd").Replace("/", "-") : null;
        }

        public static string ConvertToStringLongDate(DateTime time)
        {
            return time != Convert.ToDateTime("1900-01-01") ? time.ToString() : null;
        }

        #endregion

        #region 将'转化为''
        public static string ReplacePoint(string str)
        {
            if (str == null)
                return null;
            return str.Replace("'", "''").Trim();
        }
        #endregion

        #region 数字保留兩位小數
        public static decimal GetTwoRound(decimal number)
        {
            return Math.Round(number, 2);
        }
        #endregion


        /// <summary>
        /// 是否数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
            }
        }

        /// <summary>
        /// 是否整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(value, @"^[+-]?\d*$");
            }
        }

        /// <summary>
        /// 是否正数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsUnsign(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(value, @"^(0|([1-9]\d*))(\.\d+)?$");
            }
        }

        /// <summary>
        /// //判断YYYY-MM-DD这种格式的日期，基本上把闰年和2月等的情况都考虑进去了 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(value, @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
            }
            
        }

        /// <summary>
        /// 验证邮箱格式是否正确
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmail(string value)
        {
            return Regex.IsMatch(value, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

        }


        /// <summary>
        /// 替换千分符逗号
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceComma(string value)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                result = result.Replace(value,",");
            }
            return result;
        }


        /// <summary>
        /// 选择值转换为bool
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool? DDLValueToBool(string value)
        {
            bool? result = null;
            if (!String.IsNullOrEmpty(value))
            {
                switch (value.ToLower())
                {
                    case "0":
                    case "false":
                        result = false;
                        break;

                    case "1":
                    case "true":
                        result = true;

                        break;
                    default:
                        result = null;
                        break;
                }
            }
            return result;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns>key value</returns>
        public static List<DictionaryEntry> ListTypeForEnum(Type enumType)
        {
           FieldInfo[] fis= enumType.GetFields();

           List<DictionaryEntry> list = new List<DictionaryEntry>();
           foreach (FieldInfo fi in fis)
           {
               if (fi.FieldType.IsEnum)
               {
                   DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                   string name = (attributes.Length > 0) ? attributes[0].Description : fi.Name;
                   DictionaryEntry de = new DictionaryEntry(name, ((int)Enum.Parse(enumType, fi.Name)).ToString());

                   list.Add(de);
               }
           }
            return list;
        }


        /// <summary>
        /// 名称转枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T EnumFromName<T>( string name)
        {
            return (T)Enum.Parse(typeof(T), name, false);
        }

        /// <summary>
        /// 根据图片扩展名获取ImageFormat类型
        /// </summary>
        /// <param name="imageType"></param>
        /// <returns></returns>
        public static System.Drawing.Imaging.ImageFormat GetImageFormat(string strExtension)
        {
            switch (strExtension)
            {
                case ".jpg":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case ".jpeg":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case ".gif":
                    return System.Drawing.Imaging.ImageFormat.Gif;
                case ".bmp":
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                case ".png":
                    return System.Drawing.Imaging.ImageFormat.Png;
                case ".icon":
                    return System.Drawing.Imaging.ImageFormat.Icon;
                case ".tiff":
                    return System.Drawing.Imaging.ImageFormat.Tiff;
                case ".emf":
                    return System.Drawing.Imaging.ImageFormat.Emf;
                case ".exif":
                    return System.Drawing.Imaging.ImageFormat.Exif;
                case ".wmf":
                    return System.Drawing.Imaging.ImageFormat.Wmf;
                default:
                    return System.Drawing.Imaging.ImageFormat.MemoryBmp;
            }
        }


        #region public static string MD5(string path)
        /// <summary>
        /// 获取文件的MD5
        /// </summary>
        /// <param name="path">文件的完整路径</param>
        /// <returns></returns>
        public static string GetFileMD5(string path)
        {
            try
            {
                FileStream get_file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                System.Security.Cryptography.MD5CryptoServiceProvider get_md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash_byte = get_md5.ComputeHash(get_file);
                string resule = System.BitConverter.ToString(hash_byte);
                resule = resule.Replace("-", "");
                return resule;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public static string GetFileMD5ByStream(Stream stream)
        {
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider get_md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash_byte = get_md5.ComputeHash(stream);
                string resule = System.BitConverter.ToString(hash_byte);
                resule = resule.Replace("-", "");
                return resule;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }

        #endregion


        /// <summary>
        /// DataTable转xml string
        /// </summary>
        /// <param name="xmlDS"></param>
        /// <returns></returns>
        public static string ConvertDataTableToXML(DataTable xmlDS)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                if (string.IsNullOrEmpty(xmlDS.TableName))
                {
                    xmlDS.TableName = "Table1";
                }
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.Default);
                xmlDS.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                //UTF8Encoding utf = new UTF8Encoding();
                return Encoding.Default.GetString(arr).Trim();
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        /// <summary>
        /// DataTable转xml string
        /// </summary>
        /// <param name="xmlDS"></param>
        /// <returns></returns>
        public static string ConvertDataSetToXML(DataSet xmlDS)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                if (string.IsNullOrEmpty(xmlDS.Tables[0].TableName))
                {
                    xmlDS.Tables[0].TableName = "Table1";
                }
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.Default);
                xmlDS.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                //UTF8Encoding utf = new UTF8Encoding();
                return Encoding.Default.GetString(arr).Trim();
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        /// <summary>
        /// xml string转DataTable
        /// </summary>
        /// <param name="xmlDS"></param>
        /// <returns></returns>
        public static DataTable ConvertXMLToDataTable(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataTable xmlDS = new DataTable();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        /// <summary>
        /// xml string转DataSet
        /// </summary>
        /// <param name="xmlDS"></param>
        /// <returns></returns>
        public static DataSet ConvertXMLToDataSet(string xmlDatat)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlDatat);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
