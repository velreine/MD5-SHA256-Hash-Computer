using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Compute_Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            string sFile = "hashme.txt";
            string result = "";

            if (File.Exists(sFile))
            {
                Console.WriteLine("File:: " + sFile);
                Console.WriteLine("MD5: " + ComputeMD5(sFile));
                Console.WriteLine("SHA256: " + ComputeSHA256(sFile));
            }else
            {
                Console.WriteLine("File does not exist!");

            }

            Console.ReadKey();
            System.Threading.Thread.Sleep(2500);

        }



        private static string ComputeMD5(string file)
        {
            MD5 md5 = MD5.Create();
            FileStream stream = File.OpenRead(file);

            byte[] bytes = md5.ComputeHash(stream);
            string formattedstring = string.Empty;

            foreach (byte x in bytes)
            {
                formattedstring += String.Format("{0:x2}", x);
            }

            //return Encoding.Default.GetString( md5.ComputeHash(stream) );
            return formattedstring;
        }


        private static string ComputeSHA256(string file)
        {


            SHA256Managed sha = new SHA256Managed();
            FileStream stream = File.OpenRead(file);

            byte[] bytes = sha.ComputeHash(stream);
            string formattedstring = string.Empty;

            foreach (byte x in bytes)
            {
                formattedstring += String.Format("{0:x2}", x);
            }


            // return Encoding.Default.GetString( sha.ComputeHash(stream) );
            return formattedstring;



        }



    }
}
