using LinkClip.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Application.Services
{
    public class MD5PasswordHelper : IMD5PasswordHelper
    {
        public string EncodePasswordMd5(string pass) //Encrypt Using MD5 algorithm 
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }
    }
}
