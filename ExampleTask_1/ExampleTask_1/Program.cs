using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExampleTask_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int passCount = 0, extendedPassCount = 0;
            int failedCount = 0;
            string oneCardDatas="";
            
            if (File.Exists("feladat1.txt"))
            {
                string line = "";
                StreamReader streamReader = new StreamReader("feladat1.txt");

                while ((line = streamReader.ReadLine()) != null)
                {
                    
                    if (string.IsNullOrEmpty(line))
                    {
                        if (CheckAllDataTypeExist(oneCardDatas) == false)
                        {
                            failedCount++;
                        }
                        else
                        {
                            passCount++;
                        }
                        //----------másodikrész----------
                        if(cardPartsSeparateAndCheckOk(oneCardDatas)==true)
                        {
                            extendedPassCount++;
                            
                        }
                        //----------másodikrész----------
                        
                        oneCardDatas = "";
                        
                    }
                    else
                    {
                        oneCardDatas += line + " ";  
                    }
                    
                    
                }
                

                if (CheckAllDataTypeExist(oneCardDatas) == false)
                {
                    failedCount++;
                }
                else
                {
                    passCount++;
                }
                
                int allCard = passCount + failedCount;
                 Console.WriteLine("Jó kártyák száma:" + passCount);
                 Console.WriteLine("Rossz kártyák száma:" + failedCount);
                 Console.WriteLine("Összes kártya szám:" + allCard);
                Console.WriteLine("extended passcount" + extendedPassCount);
                Console.ReadKey();
            }     
        }

        public static bool CheckAllDataTypeExist(string inputdata)
        {
            bool Pass = true;
            int i = 0;
            string[] names = { "pid", "byr", "iyr", "eyr", "hgt", "hcl", "ecl" };
            while(Pass==true && i < names.Length)
            {
                if (!inputdata.Contains(names[i]))
                {
                    Pass = false;
                }
                i++;
            }
            return Pass;
        }

        //----------másodikrész----------

        private static bool cardPartsSeparateAndCheckOk(string inputdata)
        {
            bool cardPass=false;
            List<string> list = new List<string>();
            list = inputdata.Split(' ').ToList();
            list.RemoveAt(list.Count - 1);

            foreach(string partsOfParts in list)
            {
                cardPass = false;
                bool exit = false;
                string text;
                int n;
                int num = 0;
                bool isnum;
                string[] words = partsOfParts.Split(':');
                
                switch (words[0])
                {
                    case "pid":
                        num = 0;
                        isnum = int.TryParse(words[1], out n);
                        if (isnum == true && int.Parse(words[1]) == num)
                            cardPass = true; 
                        else
                            exit = true;
                        break;

                    case "byr":
                        if(int.Parse(words[1]) >= 1920 && int.Parse(words[1])<= 2002)
                        {
                            cardPass = true;
                        }
                        else
                            exit = true;
                        break;

                    case "cid":
                        cardPass = true;
                        break;

                    case "iyr":
                        if (int.Parse(words[1]) >= 2010 && int.Parse(words[1]) <= 2021)
                        {
                            cardPass = true;
                        }
                        else
                            exit = true;
                        break;

                    case "eyr":
                        if (int.Parse(words[1]) >= 2021 && int.Parse(words[1]) <= 2031)
                        {
                            cardPass = true;
                        }
                        else
                            exit = true;
                        break;

                    case "hgt":
                        if(words[1].Contains("cm"))
                        {
                            words[1] = words[1].Substring(0, words[1].Length - 2);
                            if (int.Parse(words[1]) >= 50 && int.Parse(words[1]) <= 220)
                            {
                                cardPass = true;
                            }
                            else
                                exit = true;
                        }
                        else if(words[1].Contains("in"))
                        {
                            words[1] = words[1].Substring(0, words[1].Length - 2);
                            if (int.Parse(words[1]) >= 20 && int.Parse(words[1]) <= 90)
                            {
                                cardPass = true;
                            }
                            else
                                exit = true;
                        }
                        break;

                    case "hcl":
                        text = "#";
                        if (words[1].Substring(0,1) == text)
                        {
                            isnum = int.TryParse(words[1], out n);
                            if (words[1].Length == 6 && isnum == true || Regex.IsMatch(words[1], @"^[a-zA-Z]+$") == true )
                            {
                                cardPass = true;

                            }
                        }
                        else
                            exit = true;
                        break;

                    case "ecl":

                        string[] eyecolor = { "grn", "blu","brn","hzl","oth","amb","gry" };

                        bool Pass = true;
                        int i = 0;
                        
                        while (Pass == true && i < eyecolor.Length)
                        {
                            if (words[1].Contains(eyecolor[i]))
                            {
                                cardPass = true;
                            }
                            i++;
                        }

                        if (Pass==true)
                        {
                            exit = true;
                        }
                        break;

                    default:
                        
                        break;

                }
                if(exit == true)
                {
                    break;
                }

             }
            return cardPass;
        }


        //----------másodikrész----------
    }
}
