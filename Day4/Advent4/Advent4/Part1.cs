using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent4
{
    internal class Part1
    {
        List<int> solution = new List<int> ();
        List<int> number = new List<int> ();
        int finalSolution;

        public Part1()
        {
            finalSolution = 0;
            StreamReader sr = new StreamReader("ElfData.txt.txt");
            //StreamReader sr = new StreamReader("ElfDataTest.txt.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                int index = line.IndexOf (':');
                line = line.Remove (0,index + 1);
                string[] holder = line.Trim().Split('|');
                foreach (string item in holder[0].Trim().Split(' '))
                {
                    if (int.TryParse(item, out int num))
                    {
                        solution.Add(num);
                    }
                }

                foreach (string item in holder[1].Trim().Split(' '))
                {
                    if (int.TryParse(item, out int num))
                    {
                        number.Add(num);
                    }
                }
                int tempHolder = 0;
                bool first = true;
                foreach(int item in number)
                {
                    if (solution.Contains(item))
                    {
                        if (first)
                        {
                            first = false;
                            tempHolder = 1;
                        }
                        else
                        {
                            tempHolder = tempHolder * 2;
                        }
                    }
                }
                solution.Clear();
                number.Clear();
                Console.WriteLine(tempHolder);
                finalSolution = finalSolution + tempHolder;
            }
            sr.Close();
            Console.WriteLine(finalSolution);
            Console.ReadLine();
        }
    }
}
