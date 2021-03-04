using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cryptography
{
    abstract class RailwayFence
    {
        protected int key;
        protected string source_str;

        public int SetKey
        { 
            set { key = value; }
        }
        public string InputString
        {
            set { source_str = value; }
        }
    }
    class Crypt_RailwayFence: RailwayFence
    {
        private string crypt_str;
        public void crypt()
        {
            int i = 0, j = 0;
            int retreat = 0;
            bool start_str = false;
            char[] c_crypt_str = source_str.ToArray();
            char[,] c_str = new char[key, source_str.Length];
            for (i = 0; i < key; i++)
            {
                retreat = 0;
                start_str = false;
                for (j = 0; j < source_str.Length; j++)
                {
                    if (i == j)
                    {
                        c_str[i, j] = c_crypt_str[j];
                        retreat = j + key;
                        start_str = true;
                    }
                    if ((j == retreat) && start_str)
                    {
                        c_str[i, j] = c_crypt_str[j];
                        retreat = j + key;
                    }
                }
            }
            int z = 0;
            for (i = 0; i < key; i++)
            {
                for (j = 0; j < source_str.Length; j++)
                {
                    if (c_str[i, j] != '\0')
                    {
                        c_crypt_str[z] = c_str[i, j];
                        z++;
                    }
                }
            }
            crypt_str = new string(c_crypt_str);
        }
        public void PrintCryptString()
        {
            Console.WriteLine("Crypt string: {0}",crypt_str);
        }
    }
    class Program
    {
        static void Main()
        {
            Crypt_RailwayFence First = new Crypt_RailwayFence();
            Console.Write("Input key (height): ");
            First.SetKey = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input string: ");
            First.InputString = Console.ReadLine();
            First.crypt();
            First.PrintCryptString();
        }
    }
}
