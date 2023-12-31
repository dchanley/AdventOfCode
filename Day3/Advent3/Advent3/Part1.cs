﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent3
{
    internal class Part1
    {
        private List<string> solutionHolder = new List<string>();
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
                        if (rowCounter > 0)
                        {
                            getSolution(list[rowCounter-1],collumnCounter);
                        }
                        getSolution(list[rowCounter], collumnCounter);
                        if (rowCounter < list.Count)
                        {
                            getSolution(list[rowCounter + 1], collumnCounter);
                        }
                    }
                    collumnCounter++;
                }
                rowCounter++;
            }
            Console.WriteLine(solution);
            Console.ReadLine();
        }
        public void getSolution(ElfDataObject tester, int originalIndex)
        {
            int indexTester = originalIndex - 1;
            while (indexTester <= (originalIndex +1))
            {
                if (indexTester >= 0)
                {
                    if (System.Char.IsDigit(tester.Chars[indexTester]))
                    {
                        getData(tester.Chars,indexTester);
                    }
                }                
                indexTester++;
            }
        }
        public void getData(Char[] array, int index)
        {
            string tempNumber ="";
            int tempIndex = index;
            while (tempIndex >= 0) { 
                if (tempIndex >= 0 && System.Char.IsDigit(array[tempIndex]))
                {
                    tempNumber = array[tempIndex] + tempNumber;
                    array[tempIndex] = '.';
                }
                else
                {
                    break;
                }
                tempIndex--;
            }
            tempIndex = index + 1;
            while (tempIndex < array.Length)
            {
                if (tempIndex >= 0 && System.Char.IsDigit(array[tempIndex]))
                {
                    tempNumber = tempNumber + array[tempIndex] ;
                    array[tempIndex] = '.';
                }
                else
                {
                    break;
                }
                tempIndex++;
            }
            Console.WriteLine(tempNumber);
            solutionHolder.Add(tempNumber);
            solution = solution + Convert.ToInt32(tempNumber);

        }
    }
}
