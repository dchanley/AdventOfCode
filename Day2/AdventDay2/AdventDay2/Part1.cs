using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay2
{
    internal class Part1
    {
        const int red = 12;
        const int green = 13;
        const int blue = 14;

        public Part1() {
            List<int> data = new List<int>();
            StreamReader sr = new StreamReader("elfData.txt");
            while(!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(':');
                string[] gameList = temp[1].Split(',');
                bool possible = true;
                foreach(string game in gameList)
                {
                    if (game.Contains(";"))
                    {
                        string[] moreTemp = game.Split(';');
                        foreach (string holding in moreTemp)
                        {
                            if (possible) { 
                            possible = checkData(holding);
                            }
                        }
                    }
                    else
                    {
                        if (possible) { 
                        possible = checkData(game);
                        }
                    }
                }
                if (possible)
                {
                    data.Add(Convert.ToInt32(temp[0].Remove(0,4)));
                }
            }         
            sr.Close();
            int outData = 0;
            foreach (int d in data)
            {
                Console.WriteLine("game: " + d);
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
                    possible = false;
                }
            }
            if (checkData.ToLower().Contains("red"))
            {
                string[] test = checkData.Trim().Split(' ');
                if (Convert.ToInt32(test[0]) > red)
                {
                    possible = false;
                }
            }
            if (checkData.ToLower().Contains("green"))
            {
                string[] test = checkData.Trim().Split(' ');
                if (Convert.ToInt32(test[0]) > green)
                {
                    possible = false;
                }
            }
            return possible;
        }
    }
}
