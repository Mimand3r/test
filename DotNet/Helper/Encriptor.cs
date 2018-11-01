using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DotNet.Helper
{
    public class Encriptor
    {
        public static string EncodeString(string _string)
        {
            var usernameBytes = Encoding.UTF8.GetBytes(_string);
            return System.Convert.ToBase64String(usernameBytes);
        }

        public static string DecodeKey(string key)
        {
            var bytekey = Convert.FromBase64String(key);
            return Encoding.UTF8.GetString(bytekey);
        }
    }
}
