using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent1
{
    internal class Part2
    {
        public Part2()
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
                string Newitem = replaceString(item);
                char[] chars = Newitem.ToCharArray();
                bool first = true;
                string firstD = "", lastD = "";
                int hold;
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
                Console.WriteLine(hold);
                solution.Add(hold);
            }
            foreach (int item in solution)
            {
                finalAnwser = finalAnwser + item;
            }
            Console.WriteLine("Final solution: " + finalAnwser);
            Console.ReadLine();
            
        }
        public string replaceString(string orignal)
        {
            if (orignal.ToLower().Contains("one"))
            {
                orignal = orignal.Replace("one", "o1e");
            }
            if (orignal.ToLower().Contains("two"))
            {
                orignal = orignal.Replace("two", "t2o");
            }
            if (orignal.ToLower().Contains("three"))
            {
                orignal = orignal.Replace("three", "t3e");
            }
            if (orignal.ToLower().Contains("four"))
            {
                orignal = orignal.Replace("four", "f4r");
            }
            if (orignal.ToLower().Contains("five"))
            {
                orignal = orignal.Replace("five", "f5e");
            }
            if (orignal.ToLower().Contains("six"))
            {
                orignal = orignal.Replace("six", "s6x");
            }
            if (orignal.ToLower().Contains("seven"))
            {
                orignal = orignal.Replace("seven", "s7n");
            }
            if (orignal.ToLower().Contains("eight"))
            {
                orignal = orignal.Replace("eight", "e8t");
            }
            if (orignal.ToLower().Contains("nine"))
            {
                orignal = orignal.Replace("nine", "n9e");
            }            
            return orignal;
        }

    }
}
