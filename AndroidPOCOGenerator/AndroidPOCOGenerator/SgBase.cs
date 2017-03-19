using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

namespace AndroidPOCOGenerator
{
    public sealed class SgBase
    {
        private static readonly SgBase instance = new SgBase();
        static SgBase() { }
        private SgBase() { }

        public static SgBase Instance
        {
            get{ return instance; }
        }

        public string DBType { get; set; }

        public enum DataBases
        {
            MsSql,
            Oracle,
            Sqlite
        }   

        public static string toString(object value)
        {
          
            if (value != DBNull.Value)
            {
                
                return Convert.ToString(value);
            }
            else
            {
                return null;
            }
        }

        public static int toInt(object value)
        {

            if (value != DBNull.Value)
            {

                return Convert.ToInt32(value);
            }
            else
            {
                return 0;
            }
        }

        public static String toLowerCamel(String value)
        {
            StringBuilder ret = new StringBuilder();
            try
            {
                if (value.Contains("_"))
                {
                    String[] s = value.Split('_');
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (i > 0)
                        {
                            ret.Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s[i].ToLower()));
                        }
                        else
                        {
                            ret.Append(s[i].ToLower());
                        }

                    }
                }
                else
                {
                    ret.Append(value);
                }

                return ret.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static String toUpperCamel(String value)
        {
            StringBuilder ret = new StringBuilder();
            try
            {
                if (value.Contains("_"))
                {
                    String[] s = value.Split('_');
                    for (int i = 0; i < s.Length; i++)
                    {

                        ret.Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s[i].ToLower()));

                    }
                }
                else
                {
                    ret.Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value));
                }

                return ret.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool toBoolFalse(object value)
        {
            if (value != DBNull.Value)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(value);
            }
        }

        public static bool toBoolTrue(object value)
        {
            if (value != DBNull.Value)
            {
                return true;
            }
            else
            {
                return Convert.ToBoolean(value);
            }
        }

    }
}
