using System;
using System.Collections.Generic;
using System.Linq;
using static GalaxyProgram.CustomMethods;

namespace GalaxyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var galaxyList = new List<Galaxy>();
            var starList = new List<Star>();
            var planetList = new List<Planet>();
            var moonList = new List<Moon>();
            var starDictionary = new Dictionary<string, List<Star>>();
            var planetDictionary = new Dictionary<string, List<Planet>>();
            var moonDictionary = new Dictionary<string, List<Moon>>();
            
            var testGalaxy = new Galaxy("Milky way", "elliptical", "13.2B");
            galaxyList.Add(testGalaxy);
            starDictionary.Add(testGalaxy.Name, new List<Star>());
            
            var testGalaxy2 = new Galaxy("Andromeda", "spiral", "14M");
            galaxyList.Add(testGalaxy2);
            starDictionary.Add(testGalaxy2.Name, new List<Star>());
            
            var testStar = new Star("Sun", 140, 180, 500000, 300000);
            starList.Add(testStar);
            starDictionary[testGalaxy.Name].Add(testStar);
            planetDictionary.Add(testStar.Name, new List<Planet>());
            
            var testStar2 = new Star("Bigger Sun", 280, 1900, 60000, 280000);
            starList.Add(testStar2);
            starDictionary[testGalaxy.Name].Add(testStar2);
            planetDictionary.Add(testStar2.Name, new List<Planet>());
            
            var testPlanet = new Planet("Earth", "terrestrial", "yes");
            planetList.Add(testPlanet);
            planetDictionary[testStar.Name].Add(testPlanet);
            moonDictionary.Add(testPlanet.Name, new List<Moon>());
            
            while (true)
            {
                string input = Console.ReadLine();
                
                //Connects to prototype InputFilter, if the Exctractor() seems complicated/not working.
                
                /*input = input.Replace("[", String.Empty);
                Console.WriteLine(input);*/
                //
                
                if (input == "exit") break;
                else
                {
                    if (input.Contains("add"))
                    {
                        string name = Extractor(input, '[', ']');
                        string[] separators = {" ", "[", "]", "add", name};
                        var split = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        if (split[0] == "galaxy")
                        {
                            string type = split[1];
                            string age = split[2];
                            var galaxy = new Galaxy(name, type, age);
                            galaxyList.Add(galaxy);
                            starDictionary.Add(galaxy.Name, new List<Star>());
                        }
                        else if (split[0] == "star")
                        {
                            bool isFound = false;
                            foreach (var galaxy in galaxyList)
                            {
                                if (galaxy.Name == name)
                                {
                                    isFound = true;
                                    break;
                                }
                            }
                            if (isFound)
                            {
                                string parent = name;
                                string starName = split[1];
                                double mass = double.Parse(split[2]);
                                double size = double.Parse(split[3]);
                                int temperature = int.Parse(split[4]);
                                double luminosity = double.Parse(split[5]);
                                var star = new Star(starName, mass, size, temperature, luminosity);
                                if (star.StarClass == 'X')
                                {
                                    Console.WriteLine("WARNING: STAR CLASS 'X'! EITHER ERROR OR NEW STAR TYPE FOUND!");
                                }
                                starList.Add(star);
                                starDictionary[parent].Add(star);
                                planetDictionary.Add(star.Name, new List<Planet>());
                            }
                            else
                            {
                                Console.WriteLine("No such galaxy was found.");
                            }
                        }
                        else if (split[0] == "planet")
                        {
                            bool isFound = false;
                            foreach (var star in starList)
                            {
                                if (star.Name == name)
                                {
                                    isFound = true;
                                    break;
                                }
                            }
                            if (isFound)
                            {
                                string parent = name;
                                string planetName = split[1];
                                string type = split[2];
                                string habitable = split[3];
                                var planet = new Planet(planetName, type, habitable);
                                planetList.Add(planet);
                                planetDictionary[parent].Add(planet);
                                moonDictionary.Add(planet.Name, new List<Moon>());
                            }
                            else
                            {
                                Console.WriteLine("No such star system was found.");
                            }
                        }
                        else if (split[0] == "moon")
                        {
                            bool isFound = false;
                            foreach (var planet in planetList)
                            {
                                if (planet.Name == name)
                                {
                                    isFound = true;
                                    break;
                                }
                            }

                            if (isFound)
                            {
                                string parent = name;
                                string moonName = split[1];
                                var moon = new Moon(moonName);
                                moonList.Add(moon);
                                moonDictionary[parent].Add(moon);
                            }
                            else
                            {
                                Console.WriteLine("No such planet was found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Unknown space object.");
                        }
                    }
                    else if (input.Contains("print"))
                    {
                        string name = Extractor(input, '[', ']');
                        bool galaxyIsFound = false;
                        foreach (var galaxy in galaxyList)
                        {
                            if (galaxy.Name == name)
                            {
                                galaxyIsFound = true;
                                Console.WriteLine($"--- Data for {galaxy.Name} galaxy ---");
                                Console.WriteLine($"Type: {galaxy.Type}");
                                Console.WriteLine($"Age: {galaxy.Age}");
                                Console.Write("Stars:");
                                int starCounter = 0;
                                foreach (var kvpStar in starDictionary)
                                {
                                    if (kvpStar.Key == name)
                                    {
                                        foreach (var star in kvpStar.Value)
                                        {
                                            starCounter += 1;
                                            Console.WriteLine($"   -  Name: {star.Name}");
                                            Console.WriteLine($"      Class: {star.StarClass} ({star.Mass}, {star.Size}, {star.Temperature}, {star.Luminosity})");
                                            Console.Write("      Planets:");
                                            int planetCounter = 0;
                                            foreach (var kvpPlanet in planetDictionary)
                                            {
                                                if (kvpPlanet.Key == star.Name)
                                                {
                                                    foreach (var planet in kvpPlanet.Value)
                                                    {
                                                        planetCounter += 1;
                                                        Console.WriteLine($"       o  Name: {planet.Name}");
                                                        Console.WriteLine($"          Type: {planet.PlanetType}");
                                                        Console.WriteLine($"          Support life: {planet.Habitation}");
                                                        Console.Write("          Moons:");
                                                        int moonCounter = 0;
                                                        foreach (var kvpMoon in moonDictionary)
                                                        {
                                                            if (kvpMoon.Key == planet.Name)
                                                            {
                                                                foreach (var moon in kvpMoon.Value)
                                                                {
                                                                    moonCounter += 1;
                                                                    Console.Write($"           ▀  Name: {moon.Name}");
                                                                }
                                                            }
                                                        }
                                                        if (moonCounter == 0)
                                                        {
                                                            Console.Write(" None\n");
                                                        }
                                                    }
                                                }
                                            }
                                            if (planetCounter == 0)
                                            {
                                                Console.Write(" None\n");
                                            }
                                        }
                                    }
                                }
                                if (starCounter == 0)
                                {
                                    Console.Write(" None\n");
                                }
                                Console.WriteLine($"--- End of data for {galaxy.Name} galaxy ---");
                            }
                        }
                        if (!galaxyIsFound)
                        {
                            Console.WriteLine("No such galaxy was found.");
                        }
                    }
                    else if (input.Contains("stats"))
                    {
                        Statistic(galaxyList, starList, planetList, moonList);
                    }
                    else if (input.Contains("list"))
                    {
                        if (input.Contains("galaxies"))
                        {
                            List("galaxies", galaxyList, starList, planetList, moonList );
                        }
                        else if (input.Contains("stars"))
                        {
                            List("stars", galaxyList, starList, planetList, moonList );
                        }
                        else if (input.Contains("planets"))
                        {
                            List("planets", galaxyList, starList, planetList, moonList );
                        }
                        else if (input.Contains("moons"))
                        {
                            List("moons", galaxyList, starList, planetList, moonList );
                        }
                        else
                        {
                            Console.WriteLine("Unknown space object.");
                        }
                    }
                }
            }
        }
    }
}