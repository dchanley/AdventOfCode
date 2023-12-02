using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay2
{
    internal class Part2
    {
        private int red;
        private int green;
        private int blue;


        public Part2() {
            
            List<int> data = new List<int>();
            StreamReader sr = new StreamReader("elfData.txt");
            while (!sr.EndOfStream)
            {
                red = 0;
                green = 0;
                blue = 0;
                string[] temp = sr.ReadLine().Split(':');
                string[] gameList = temp[1].Split(',');
                foreach (string game in gameList)
                {
                    if (game.Contains(";"))
                    {
                        string[] moreTemp = game.Split(';');
                        foreach (string holding in moreTemp)
                        {

                                checkData(holding);

                        }
                    }
                    else
                    {

                      checkData(game);

                    }
                } 
                data.Add(red * green * blue);
            }
            sr.Close();
            int outData = 0;
            foreach (int d in data)
            {
                Console.WriteLine("solution: " + d);
                outData = outData + d;
            }
            Console.WriteLine("Total: " + outData);
            Console.ReadLine();
        }
        private bool checkData(string checkData)
        {
            bool possible = true;
            if (checkData.ToLower().Contains("blue"))
            {
                string[] test = checkData.Trim().Split(' ');
                if (Convert.ToInt32(test[0]) > blue)
                {
                    blue = Convert.ToInt32(test[0]);
                }
            }
            if (checkData.ToLower().Contains("red"))
            {
                string[] test = checkData.Trim().Split(' ');
                if (Convert.ToInt32(test[0]) > red)
                {
                    red = Convert.ToInt32(test[0]);
                }
            }
            if (checkData.ToLower().Contains("green"))
            {
                string[] test = checkData.Trim().Split(' ');
                if (Convert.ToInt32(test[0]) > green)
                {
                    green = Convert.ToInt32(test[0]);
                }
            }
            return possible;
        }
    }
    
}
