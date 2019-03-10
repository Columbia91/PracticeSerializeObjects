using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib;
using System.IO;
using SerializeConsoleApp;

namespace DeserializeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PC> pcList = new List<PC>();
            string path = @"S:\new\listSerial.txt";
            
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                for (int i = 0; reader.PeekChar() > -1; i++)
                {
                    PC pc = new PC();
                    pc.Brand = reader.ReadString();
                    pc.SerialNumber = reader.ReadString();
                    pc.CPU = reader.ReadString();

                    pcList.Add(pc);
                }
            }
            Console.ReadLine();
        }
    }
}
