using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent1
{
    internal class Part1
    {
        public Part1()
        {
            StreamReader sr = new StreamReader("elf.txt");
            List<string> elf = new List<string>();
            List<int> solution = new List<int>();
            int finalAnwser = 0;
            while (!sr.EndOfStream)
            {
                elf.Add(sr.ReadLine());
            }
            sr.Close();
            foreach (string item in elf)
            {
                char[] chars = item.ToCharArray();
                bool first = true;
                string firstD = "", lastD = "";
                int hold = 0;
                foreach (char c in chars)
                {
                    if (System.Char.IsDigit(c))
                    {
                        if (first)
                        {
                            firstD = c.ToString();
                            first = false;
                        }
                        lastD = c.ToString();
                    }
                }
                hold = Convert.ToInt32(firstD + lastD);
                solution.Add(hold);
            }
            foreach (int item in solution)
            {
                finalAnwser = finalAnwser + item;
            }
            Console.WriteLine("Final solution: " + finalAnwser);
            Console.ReadLine();
        }
    }
}
