﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SDWxPro.Tool
{
    /// <summary>
    /// MD5加密操作类
    /// </summary>
    public class ChangePwd
    {
        /// <summary>
        /// 本项目的MD5加密方式
        /// </summary>
        /// <param name="Str">明文密码</param>
        /// <returns>本项目加密MD5值</returns>
        public static string MD5Text(string Str)
        {
            return ChanageMD5(MD5.MDString(Str).ToLower());
        }

        /// <summary>
        /// 更改首位两个字符串(加密MD5的值)
        /// </summary>
        /// <param name="Str">MD5值</param>
        /// <returns>已加密MD5值</returns>
        public static string ChanageMD5(string Str)
        {
            //获取首位字符
            string TStr = Str.Substring(0, 1);
            //判断字符串是否大于2,返回值
            if (Str.Length > 1)
            {
                string WStr = Str.Substring(Str.Length - 1, 1);
                return ChangeStr(TStr) + Str.Substring(1, Str.Length - 1) + ChangeStr(WStr);
            }
            else
            {
                return ChangeStr(TStr);
            }
        }

        /// <summary>
        /// 解密MD5
        /// </summary>
        /// <param name="Str">MD5 字符串</param>
        /// <returns>返回正确的MD5加密值(解密MD5值)</returns>
        public static string RevertMD5(string Str)
        {
            //获取首位字符
            string TStr = Str.Substring(0, 1);
            //判断字符串是否大于2,返回值
            if (Str.Length > 1)
            {
                string WStr = Str.Substring(Str.Length - 1, 1);
                return RevertStr(TStr) + Str.Substring(1, Str.Length - 1) + RevertStr(WStr);
            }
            else
            {
                return RevertStr(TStr);
            }
        }

        /// <summary>
        /// 打乱字符顺序
        /// </summary>
        /// <param name="Str">要打乱的字符串</param>
        /// <returns>打乱后的字符串</returns>
        public static string ChangeStr(string Str)
        {
            string Ret = Str;
            switch (Str.ToLower())
            {
                case "a": Ret = "b"; break;
                case "b": Ret = "c"; break;
                case "c": Ret = "d"; break;
                case "d": Ret = "e"; break;
                case "e": Ret = "f"; break;
                case "f": Ret = "g"; break;
                case "g": Ret = "h"; break;
                case "h": Ret = "i"; break;
                case "i": Ret = "j"; break;
                case "j": Ret = "k"; break;
                case "k": Ret = "l"; break;
                case "l": Ret = "m"; break;
                case "m": Ret = "n"; break;
                case "n": Ret = "o"; break;
                case "o": Ret = "p"; break;
                case "p": Ret = "q"; break;
                case "q": Ret = "r"; break;
                case "r": Ret = "s"; break;
                case "s": Ret = "t"; break;
                case "t": Ret = "u"; break;
                case "u": Ret = "v"; break;
                case "v": Ret = "w"; break;
                case "w": Ret = "x"; break;
                case "x": Ret = "y"; break;
                case "y": Ret = "z"; break;
                case "z": Ret = "a"; break;

                case "0": Ret = "1"; break;
                case "1": Ret = "2"; break;
                case "2": Ret = "3"; break;
                case "3": Ret = "4"; break;
                case "4": Ret = "5"; break;
                case "5": Ret = "6"; break;
                case "6": Ret = "7"; break;
                case "7": Ret = "8"; break;
                case "8": Ret = "9"; break;
                case "9": Ret = "0"; break;
            }
            return Ret;
        }

        /// <summary>
        /// 还原字符串顺序
        /// </summary>
        /// <param name="Str">要还原的字符串</param>
        /// <returns>还原后的字符串</returns>
        public static string RevertStr(string Str)
        {
            string Ret = Str;
            switch (Str.ToLower())
            {
                case "a": Ret = "z"; break;
                case "b": Ret = "a"; break;
                case "c": Ret = "b"; break;
                case "d": Ret = "c"; break;
                case "e": Ret = "d"; break;
                case "f": Ret = "e"; break;
                case "g": Ret = "f"; break;
                case "h": Ret = "g"; break;
                case "i": Ret = "h"; break;
                case "j": Ret = "i"; break;
                case "k": Ret = "j"; break;
                case "l": Ret = "k"; break;
                case "m": Ret = "l"; break;
                case "n": Ret = "m"; break;
                case "o": Ret = "n"; break;
                case "p": Ret = "o"; break;
                case "q": Ret = "p"; break;
                case "r": Ret = "q"; break;
                case "s": Ret = "r"; break;
                case "t": Ret = "s"; break;
                case "u": Ret = "t"; break;
                case "v": Ret = "u"; break;
                case "w": Ret = "v"; break;
                case "x": Ret = "w"; break;
                case "y": Ret = "x"; break;
                case "z": Ret = "y"; break;

                case "0": Ret = "9"; break;
                case "1": Ret = "0"; break;
                case "2": Ret = "1"; break;
                case "3": Ret = "2"; break;
                case "4": Ret = "3"; break;
                case "5": Ret = "4"; break;
                case "6": Ret = "5"; break;
                case "7": Ret = "6"; break;
                case "8": Ret = "7"; break;
                case "9": Ret = "8"; break;
            }
            return Ret;
        }

        /// <summary>
        /// MD5加密算法类
        /// MD5.MDString("111111");
        /// </summary>
        public class MD5
        {
            //static state variables 
            private static UInt32 A;
            private static UInt32 B;
            private static UInt32 C;
            private static UInt32 D;

            //number of bits to rotate in tranforming 
            private const int S11 = 7;
            private const int S12 = 12;
            private const int S13 = 17;
            private const int S14 = 22;
            private const int S21 = 5;
            private const int S22 = 9;
            private const int S23 = 14;
            private const int S24 = 20;
            private const int S31 = 4;
            private const int S32 = 11;
            private const int S33 = 16;
            private const int S34 = 23;
            private const int S41 = 6;
            private const int S42 = 10;
            private const int S43 = 15;
            private const int S44 = 21;


            /**/
            /* F, G, H and I are basic MD5 functions. 
             * 四个非线性函数: 
             * 
             * F(X,Y,Z) =(X&Y)|((~X)&Z) 
             * G(X,Y,Z) =(X&Z)|(Y&(~Z)) 
             * H(X,Y,Z) =X^Y^Z 
             * I(X,Y,Z)=Y^(X|(~Z)) 
             * 
             * （&与，|或，~非，^异或） 
             */
            private static UInt32 F(UInt32 x, UInt32 y, UInt32 z)
            {
                return (x & y) | ((~x) & z);
            }
            private static UInt32 G(UInt32 x, UInt32 y, UInt32 z)
            {
                return (x & z) | (y & (~z));
            }
            private static UInt32 H(UInt32 x, UInt32 y, UInt32 z)
            {
                return x ^ y ^ z;
            }
            private static UInt32 I(UInt32 x, UInt32 y, UInt32 z)
            {
                return y ^ (x | (~z));
            }

            /**/
            /* FF, GG, HH, and II transformations for rounds 1, 2, 3, and 4. 
             * Rotation is separate from addition to prevent recomputation. 
             */
            private static void FF(ref UInt32 a, UInt32 b, UInt32 c, UInt32 d, UInt32 mj, int s, UInt32 ti)
            {
                a = a + F(b, c, d) + mj + ti;
                a = a << s | a >> (32 - s);
                a += b;
            }
            private static void GG(ref UInt32 a, UInt32 b, UInt32 c, UInt32 d, UInt32 mj, int s, UInt32 ti)
            {
                a = a + G(b, c, d) + mj + ti;
                a = a << s | a >> (32 - s);
                a += b;
            }
            private static void HH(ref UInt32 a, UInt32 b, UInt32 c, UInt32 d, UInt32 mj, int s, UInt32 ti)
            {
                a = a + H(b, c, d) + mj + ti;
                a = a << s | a >> (32 - s);
                a += b;
            }
            private static void II(ref UInt32 a, UInt32 b, UInt32 c, UInt32 d, UInt32 mj, int s, UInt32 ti)
            {
                a = a + I(b, c, d) + mj + ti;
                a = a << s | a >> (32 - s);
                a += b;
            }

            private static void MD5_Init()
            {
                A = 0x67452301;  //in memory, this is 0x01234567 
                B = 0xefcdab89;  //in memory, this is 0x89abcdef 
                C = 0x98badcfe;  //in memory, this is 0xfedcba98 
                D = 0x10325476;  //in memory, this is 0x76543210 
            }

            private static UInt32[] MD5_Append(byte[] input)
            {
                int zeros = 0;
                int ones = 1;
                int size = 0;
                int n = input.Length;
                int m = n % 64;
                if (m < 56)
                {
                    zeros = 55 - m;
                    size = n - m + 64;
                }
                else if (m == 56)
                {
                    zeros = 0;
                    ones = 0;
                    size = n + 8;
                }
                else
                {
                    zeros = 63 - m + 56;
                    size = n + 64 - m + 64;
                }

                ArrayList bs = new ArrayList(input);
                if (ones == 1)
                {
                    bs.Add((byte)0x80); // 0x80 = 000000 
                }
                for (int i = 0; i < zeros; i++)
                {
                    bs.Add((byte)0);
                }

                UInt64 N = (UInt64)n * 8;
                byte h1 = (byte)(N & 0xFF);
                byte h2 = (byte)((N >> 8) & 0xFF);
                byte h3 = (byte)((N >> 16) & 0xFF);
                byte h4 = (byte)((N >> 24) & 0xFF);
                byte h5 = (byte)((N >> 32) & 0xFF);
                byte h6 = (byte)((N >> 40) & 0xFF);
                byte h7 = (byte)((N >> 48) & 0xFF);
                byte h8 = (byte)(N >> 56);
                bs.Add(h1);
                bs.Add(h2);
                bs.Add(h3);
                bs.Add(h4);
                bs.Add(h5);
                bs.Add(h6);
                bs.Add(h7);
                bs.Add(h8);
                byte[] ts = (byte[])bs.ToArray(typeof(byte));

                /**/
                /* Decodes input (byte[]) into output (UInt32[]). Assumes len is 
         * a multiple of 4. 
         */
                UInt32[] output = new UInt32[size / 4];
                for (Int64 i = 0, j = 0; i < size; j++, i += 4)
                {

                    output[j] = (UInt32)(ts[i] | ts[i + 1] << 8 | ts[i + 2] << 16 | ts[i + 3] << 24);
                }
                return output;
            }
            private static UInt32[] MD5_Trasform(UInt32[] x)
            {

                UInt32 a, b, c, d;

                for (int k = 0; k < x.Length; k += 16)
                {
                    a = A;
                    b = B;
                    c = C;
                    d = D;

                    /**/
                    /* Round 1 */
                    FF(ref a, b, c, d, x[k + 0], S11, 0xd76aa478); /**//* 1 */
                    FF(ref d, a, b, c, x[k + 1], S12, 0xe8c7b756); /**//* 2 */
                    FF(ref c, d, a, b, x[k + 2], S13, 0x242070db); /**//* 3 */
                    FF(ref b, c, d, a, x[k + 3], S14, 0xc1bdceee); /**//* 4 */
                    FF(ref a, b, c, d, x[k + 4], S11, 0xf57c0faf); /**//* 5 */
                    FF(ref d, a, b, c, x[k + 5], S12, 0x4787c62a); /**//* 6 */
                    FF(ref c, d, a, b, x[k + 6], S13, 0xa8304613); /**//* 7 */
                    FF(ref b, c, d, a, x[k + 7], S14, 0xfd469501); /**//* 8 */
                    FF(ref a, b, c, d, x[k + 8], S11, 0x698098d8); /**//* 9 */
                    FF(ref d, a, b, c, x[k + 9], S12, 0x8b44f7af); /**//* 10 */
                    FF(ref c, d, a, b, x[k + 10], S13, 0xffff5bb1); /**//* 11 */
                    FF(ref b, c, d, a, x[k + 11], S14, 0x895cd7be); /**//* 12 */
                    FF(ref a, b, c, d, x[k + 12], S11, 0x6b901122); /**//* 13 */
                    FF(ref d, a, b, c, x[k + 13], S12, 0xfd987193); /**//* 14 */
                    FF(ref c, d, a, b, x[k + 14], S13, 0xa679438e); /**//* 15 */
                    FF(ref b, c, d, a, x[k + 15], S14, 0x49b40821); /**//* 16 */

                    /**/
                    /* Round 2 */
                    GG(ref a, b, c, d, x[k + 1], S21, 0xf61e2562); /**//* 17 */
                    GG(ref d, a, b, c, x[k + 6], S22, 0xc040b340); /**//* 18 */
                    GG(ref c, d, a, b, x[k + 11], S23, 0x265e5a51); /**//* 19 */
                    GG(ref b, c, d, a, x[k + 0], S24, 0xe9b6c7aa); /**//* 20 */
                    GG(ref a, b, c, d, x[k + 5], S21, 0xd62f105d); /**//* 21 */
                    GG(ref d, a, b, c, x[k + 10], S22, 0x2441453); /**//* 22 */
                    GG(ref c, d, a, b, x[k + 15], S23, 0xd8a1e681); /**//* 23 */
                    GG(ref b, c, d, a, x[k + 4], S24, 0xe7d3fbc8); /**//* 24 */
                    GG(ref a, b, c, d, x[k + 9], S21, 0x21e1cde6); /**//* 25 */
                    GG(ref d, a, b, c, x[k + 14], S22, 0xc33707d6); /**//* 26 */
                    GG(ref c, d, a, b, x[k + 3], S23, 0xf4d50d87); /**//* 27 */
                    GG(ref b, c, d, a, x[k + 8], S24, 0x455a14ed); /**//* 28 */
                    GG(ref a, b, c, d, x[k + 13], S21, 0xa9e3e905); /**//* 29 */
                    GG(ref d, a, b, c, x[k + 2], S22, 0xfcefa3f8); /**//* 30 */
                    GG(ref c, d, a, b, x[k + 7], S23, 0x676f02d9); /**//* 31 */
                    GG(ref b, c, d, a, x[k + 12], S24, 0x8d2a4c8a); /**//* 32 */

                    /**/
                    /* Round 3 */
                    HH(ref a, b, c, d, x[k + 5], S31, 0xfffa3942); /**//* 33 */
                    HH(ref d, a, b, c, x[k + 8], S32, 0x8771f681); /**//* 34 */
                    HH(ref c, d, a, b, x[k + 11], S33, 0x6d9d6122); /**//* 35 */
                    HH(ref b, c, d, a, x[k + 14], S34, 0xfde5380c); /**//* 36 */
                    HH(ref a, b, c, d, x[k + 1], S31, 0xa4beea44); /**//* 37 */
                    HH(ref d, a, b, c, x[k + 4], S32, 0x4bdecfa9); /**//* 38 */
                    HH(ref c, d, a, b, x[k + 7], S33, 0xf6bb4b60); /**//* 39 */
                    HH(ref b, c, d, a, x[k + 10], S34, 0xbebfbc70); /**//* 40 */
                    HH(ref a, b, c, d, x[k + 13], S31, 0x289b7ec6); /**//* 41 */
                    HH(ref d, a, b, c, x[k + 0], S32, 0xeaa127fa); /**//* 42 */
                    HH(ref c, d, a, b, x[k + 3], S33, 0xd4ef3085); /**//* 43 */
                    HH(ref b, c, d, a, x[k + 6], S34, 0x4881d05); /**//* 44 */
                    HH(ref a, b, c, d, x[k + 9], S31, 0xd9d4d039); /**//* 45 */
                    HH(ref d, a, b, c, x[k + 12], S32, 0xe6db99e5); /**//* 46 */
                    HH(ref c, d, a, b, x[k + 15], S33, 0x1fa27cf8); /**//* 47 */
                    HH(ref b, c, d, a, x[k + 2], S34, 0xc4ac5665); /**//* 48 */

                    /**/
                    /* Round 4 */
                    II(ref a, b, c, d, x[k + 0], S41, 0xf4292244); /**//* 49 */
                    II(ref d, a, b, c, x[k + 7], S42, 0x432aff97); /**//* 50 */
                    II(ref c, d, a, b, x[k + 14], S43, 0xab9423a7); /**//* 51 */
                    II(ref b, c, d, a, x[k + 5], S44, 0xfc93a039); /**//* 52 */
                    II(ref a, b, c, d, x[k + 12], S41, 0x655b59c3); /**//* 53 */
                    II(ref d, a, b, c, x[k + 3], S42, 0x8f0ccc92); /**//* 54 */
                    II(ref c, d, a, b, x[k + 10], S43, 0xffeff47d); /**//* 55 */
                    II(ref b, c, d, a, x[k + 1], S44, 0x85845dd1); /**//* 56 */
                    II(ref a, b, c, d, x[k + 8], S41, 0x6fa87e4f); /**//* 57 */
                    II(ref d, a, b, c, x[k + 15], S42, 0xfe2ce6e0); /**//* 58 */
                    II(ref c, d, a, b, x[k + 6], S43, 0xa3014314); /**//* 59 */
                    II(ref b, c, d, a, x[k + 13], S44, 0x4e0811a1); /**//* 60 */
                    II(ref a, b, c, d, x[k + 4], S41, 0xf7537e82); /**//* 61 */
                    II(ref d, a, b, c, x[k + 11], S42, 0xbd3af235); /**//* 62 */
                    II(ref c, d, a, b, x[k + 2], S43, 0x2ad7d2bb); /**//* 63 */
                    II(ref b, c, d, a, x[k + 9], S44, 0xeb86d391); /**//* 64 */

                    A += a;
                    B += b;
                    C += c;
                    D += d;
                }
                return new UInt32[] { A, B, C, D };
            }
            public static byte[] MD5Array(byte[] input)
            {
                MD5_Init();
                UInt32[] block = MD5_Append(input);
                UInt32[] bits = MD5_Trasform(block);

                /**/
                /* Encodes bits (UInt32[]) into output (byte[]). Assumes len is 
         * a multiple of 4. 
             */
                byte[] output = new byte[bits.Length * 4];
                for (int i = 0, j = 0; i < bits.Length; i++, j += 4)
                {

                    output[j] = (byte)(bits[i] & 0xff);
                    output[j + 1] = (byte)((bits[i] >> 8) & 0xff);
                    output[j + 2] = (byte)((bits[i] >> 16) & 0xff);
                    output[j + 3] = (byte)((bits[i] >> 24) & 0xff);
                }
                return output;
            }

            public static string ArrayToHexString(byte[] array, bool uppercase)
            {
                string hexString = "";
                string format = "x2";
                if (uppercase)
                {
                    format = "X2";
                }
                foreach (byte b in array)
                {
                    hexString += b.ToString(format);
                }
                return hexString;
            }

            public static string MDString(string message)
            {
                char[] c = message.ToCharArray();
                byte[] b = new byte[c.Length];
                for (int i = 0; i < c.Length; i++)
                {
                    b[i] = (byte)c[i];
                }
                byte[] digest = MD5Array(b);
                return ArrayToHexString(digest, false);
            }
            public static string MDFile(string fileName)
            {
                FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read);
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, (int)fs.Length);
                byte[] digest = MD5Array(array);
                fs.Close();
                return ArrayToHexString(digest, false);
            }

            public static string Test(string message)
            {
                return " MD5 (" + message + ") = " + MD5.MDString(message);
            }
            public static string TestSuite()
            {
                string s = "";
                s += Test("");
                s += Test("a");
                s += Test("abc");
                s += Test("message digest");
                s += Test("abcdefghijklmnopqrstuvwxyz");
                s += Test("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");
                s += Test("12345678901234567890123456789012345678901234567890123456789012345678901234567890");
                return s;
            }
        }
    }
}
