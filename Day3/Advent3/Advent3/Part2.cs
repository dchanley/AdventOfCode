using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent3
{
    class Part2
    {
        private List<string> solutionHolder = new List<string>();
        private List<string> gearHolder = new List<string>();
        private int solution;
        public Part2()
        {
            solution = 0;
            List<ElfDataObject> list = new List<ElfDataObject>();
            System.IO.StreamReader sr = new System.IO.StreamReader("ElfData.txt");
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
                        gearHolder = new List<string>();
                        if (rowCounter > 0)
                        {
                            getSolution(list[rowCounter - 1], collumnCounter,c);
                        }
                        getSolution(list[rowCounter], collumnCounter, c);
                        if (rowCounter < list.Count)
                        {
                            getSolution(list[rowCounter + 1], collumnCounter, c);
                        }
                        if (gearHolder.Count > 1)
                        {
                            int tempNumber = 1;
                            foreach (string temp in gearHolder)
                            {
                                tempNumber = tempNumber * Convert.ToInt32(temp);
                            }
                            solutionHolder.Add(tempNumber.ToString());
                        }
                    }
                    collumnCounter++;
                }
                rowCounter++;
            }
            foreach (string tempNumber in solutionHolder)
            {
                Console.WriteLine(tempNumber);
                solution = solution + Convert.ToInt32(tempNumber);
            }
            Console.WriteLine(solution);
            Console.ReadLine();
        }
        public void getSolution(ElfDataObject tester, int originalIndex, char symbol)
        {            
            int indexTester = originalIndex - 1;
            while (indexTester <= (originalIndex + 1))
            {
                if (indexTester >= 0)
                {
                    if (System.Char.IsDigit(tester.Chars[indexTester]))
                    {
                        getData(tester.Chars, indexTester, symbol);
                    }
                }
                indexTester++;
            }            
        }
        public void getData(Char[] array, int index, char symbol)
        {
            string tempNumber = "";
            int tempIndex = index;
            while (tempIndex >= 0)
            {
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
                    tempNumber = tempNumber + array[tempIndex];
                    array[tempIndex] = '.';
                }
                else
                {
                    break;
                }
                tempIndex++;
            }            
            if (symbol == '*')
            {
                gearHolder.Add(tempNumber);
            }
            else {

            }
            

        }
    }
}
