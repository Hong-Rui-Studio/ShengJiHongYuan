using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Md5Helpers
{
    public class Md5Config
    {
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encryption(string str) 
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            var buffer =  md5.ComputeHash(bytes);
            return Encoding.UTF8.GetString(buffer);
        }


    }
}
