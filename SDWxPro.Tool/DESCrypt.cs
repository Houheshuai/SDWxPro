﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SDWxPro.Tool
{
    public class DESCrypt
    {
        public DESCrypt() { }
        private static byte[] IV24;
        private static byte[] Key24;

        static DESCrypt()
        {
            Key24 = new byte[] { 
                0x19, 0x4f, 0x24, 0x63, 0xa7, 0x3f, 0x2a, 0x56, 0xf6, 0x4f, 0x24, 0x63, 0xa7, 0x5d, 0x2a, 0x6a, 
                0x5d, 0x9c, 0x4e, 0x41, 0xda, 0x20, 0x37, 0x63
            };
                IV24 = new byte[] { 
                0x60, 0xd0, 0x20, 0x37, 0x67, 0xce, 0x4f, 0x24, 0x63, 0x6b, 210, 0x2a, 0x38, 0xd8, 0x4f, 0x24, 
                0x63, 0xa7, 0xcb, 0x2a, 0x56, 0x5d, 0x7e, 0x4e
            };

        }

        public static string Crypt(string p)
        {
            if (p != "")
            {
                TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(Key24, IV24), CryptoStreamMode.Write);
                StreamWriter writer = new StreamWriter(stream2);
                writer.Write(p);
                writer.Flush();
                stream2.FlushFinalBlock();
                stream.Flush();
                return Convert.ToBase64String(stream.GetBuffer(), 0, Convert.ToInt32(stream.Length)).Replace("/", "@@@XXX").Replace("=", "@@@DDD").Replace("*", "###XXX");
            }
            return "";
        }

        public static string DeCrypt(string p)
        {
            if (p != "")
            {
                p = p.Replace("@@@XXX", "/").Replace("@@@DDD", "=").Replace("###XXX", "*");
                TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
                MemoryStream stream = new MemoryStream(Convert.FromBase64String(p));
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(Key24, IV24), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(stream2);
                return reader.ReadToEnd();
            }
            return "";
        }

 


    }
}
