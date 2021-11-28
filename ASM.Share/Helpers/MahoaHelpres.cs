using ASM.Share.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Share.Helpers
{
    public interface IMahoaHelper
    {        
        string Mahoa(string source);
    }
    public class MahoaHelper : IMahoaHelper
    {
        public string Mahoa(string source)
        {
            string hash = "";         
            using (var md5Hash = MD5.Create())
            {
                var sourceBytes = Encoding.UTF8.GetBytes(source);
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
            return hash;
        }
    }
}
