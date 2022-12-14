using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace HexViewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numele fisierului");
            string file = Console.ReadLine();
            if (!File.Exists(file)) Console.WriteLine("Fisierul nu exista");
            else
            {
                int nrl = 0;
                BinaryReader br = new BinaryReader(File.OpenRead(file), Encoding.UTF8, false);
                long length = new System.IO.FileInfo(file).Length;
                string copy = string.Empty;    
                int nrk = 1;
                    Console.Write(Convert.ToString(nrk, toBase: 16).PadLeft(7, '0'), 7);
                    Console.Write("|");
                    for (long i = 0; i < length; i++)
                    {
                        int b = br.ReadByte();
                        if (nrl < 16)
                        {

                            Console.Write(Convert.ToString(b, toBase: 16).PadLeft(2, '0') + " ");
                            if (b < 20 || b > 127) copy += ".";
                            else copy += Convert.ToChar(b);
                            nrl++;
                        }
                        else
                        {
                            nrk++;
                            Console.Write("|"+copy);
                            Console.WriteLine();
                            Console.Write(Convert.ToString(nrk, toBase: 16).PadLeft(7, '0'), 7);
                            Console.Write("|");
                            nrl = 0;
                        char d;
                        if (b < 20 || b > 127) d = '.';
                        else d=Convert.ToChar(b);
                            copy = Convert.ToString(d);
                        }
                    }
                    
                    while (nrl < 16)
                    {
                        Console.Write("00" + " ");
                        nrl++;
                    }
                    Console.Write("|");
                    Console.Write(copy);
            }
        }
    }
}
