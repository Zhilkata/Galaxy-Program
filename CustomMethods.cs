using System;
using System.Collections.Generic;

//Organisational part, can be safely included as static method pack in Program.cs

namespace GalaxyProgram
{
    public static class CustomMethods
    {
        public static void Statistic(List<Galaxy> galaxyList, List<Star> starList, List<Planet> planetList, List<Moon> moonList)
        {
            Console.WriteLine("--- Stats ---");
            if (galaxyList.Count == 0)  Console.WriteLine("Galaxies: None");
            else Console.WriteLine($"Galaxies: {galaxyList.Count}");
            if (starList.Count == 0) Console.WriteLine("Stars: None");
            else Console.WriteLine($"Stars: {starList.Count}");
            if (planetList.Count == 0) Console.WriteLine("Planets: None");
            else Console.WriteLine($"Planets: {planetList.Count}");
            if (moonList.Count == 0) Console.WriteLine("Moons: None");
            else Console.WriteLine($"Moons: {moonList.Count}");
            Console.WriteLine("--- End of stats ---");
        }
        
        public static void List(string command, List<Galaxy> galaxyList, List<Star> starList, List<Planet> planetList, List<Moon> moonList )
        {
            if (command == "galaxies")
            {
                Console.WriteLine("--- List of all researched galaxies ---");
                if (galaxyList.Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    for (int counter = 0; counter < galaxyList.Count; counter++)
                    {
                        if (counter == galaxyList.Count - 1)
                        {
                            Console.Write($"{galaxyList[counter].Name}\n");
                        }
                        else
                        {
                            Console.Write($"{galaxyList[counter].Name}, ");
                        }
                    }
                }
                Console.WriteLine("--- End of galaxies list ---");
            }
            else if (command == "stars")
            {
                Console.WriteLine("--- List of all researched stars ---");
                if (starList.Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    for (int counter = 0; counter < starList.Count; counter++)
                    {
                        if (counter == starList.Count - 1)
                        {
                            Console.Write($"{starList[counter].Name}\n");
                        }
                        else
                        {
                            Console.Write($"{starList[counter].Name}, ");
                        }
                    }
                }
                Console.WriteLine("--- End of stars list ---");
            }
            else if (command == "planets")
            {
                Console.WriteLine("--- List of all researched planets ---");
                if (planetList.Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    for (int counter = 0; counter < planetList.Count; counter++)
                    {
                    
                        if (counter == planetList.Count - 1)
                        {
                            Console.Write($"{planetList[counter].Name}\n");
                        }
                        else
                        {
                            Console.Write($"{planetList[counter].Name}, ");
                        }
                    }
                }
                Console.WriteLine("--- End of planets list ---");
            }
            else if (command == "moons")
            {
                Console.WriteLine("--- List of all researched moons ---");
                if (moonList.Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    for (int counter = 0; counter < moonList.Count; counter++)
                    {
                    
                        if (counter == moonList.Count - 1)
                        {
                            Console.Write($"{moonList[counter].Name}\n");
                        }
                        else
                        {
                            Console.Write($"{moonList[counter].Name}, ");
                        }
                    }
                }
                Console.WriteLine("--- End of moons list ---");
            }
        }

        public static string Extractor(string input, char charFrom, char charTo)
        {
            int posFrom = input.IndexOf(charFrom);
            if (posFrom != -1)
            {
                int posTo = input.IndexOf(charTo, posFrom + 1);
                if (posTo != -1)
                {
                    return input.Substring(posFrom + 1, posTo - posFrom - 1);
                }
            }

            return string.Empty;
        }

        /*public static string InputFilter(this string str, List<char> charsToFilter)
        {
            foreach (var c in charsToFilter)
            {
                str = str.Replace(c.ToString(), String.Empty);
            }

            return str;
        }*/
    }
}