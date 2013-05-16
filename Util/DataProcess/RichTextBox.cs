using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;
using System.IO;
using System;

namespace Util.DataProcess
{
    public static class RichTextBoxEx
    {
        public static string RTF(this RichTextBox richTextBox)
        {
            string rtf = string.Empty;
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            using (MemoryStream ms = new MemoryStream())
            {
                textRange.Save(ms, System.Windows.DataFormats.Rtf);
                ms.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(ms);
                rtf = sr.ReadToEnd();
            }

            return rtf;
        }

        public static void LoadFromRTF(this RichTextBox richTextBox, string rtf)
        {
            if (!string.IsNullOrEmpty(rtf))
            {

                TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (StreamWriter sw = new StreamWriter(ms))
                    {
                        sw.Write(rtf);
                        sw.Flush();
                        ms.Seek(0, SeekOrigin.Begin);
                        textRange.Load(ms, DataFormats.Rtf);
                    }
                }
            }
        }

    }
}
