using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent3
{
    internal class Part1
    {
        private int solution;
        public Part1()
        {
            solution = 0;
            List<ElfDataObject> list = new List<ElfDataObject>();
            StreamReader sr = new StreamReader("ElfData.txt");
            while (!sr.EndOfStream)
            {
                ElfDataObject obj = new ElfDataObject();
                obj.Chars = sr.ReadLine().ToCharArray();
                list.Add(obj);                
            }
            sr.Close();
            int rowCounter = 0;
            
            foreach (ElfDataObject obj in list)
            {
                int collumnCounter = 0;
                foreach (char c in obj.Chars)
                {
                    if (c != '.' && !System.Char.IsDigit(c))
                    {

                    }
                    collumnCounter++;
                }
                rowCounter++;
            }
        }
    }
}
