using System.Collections.Generic;
namespace GalaxyProgram
{
    public class Star : SpaceObject
    {
        public Star(string name, double mass, double size, int temperature, double luminosity)
        {
            Name = name;
            Mass = mass;
            Size = size;
            Temperature = temperature;
            Luminosity = luminosity;
            StarClass = ClassFinder();
        }
        
        public override string Name { get; set; }
        public char StarClass { get; set; }
        public double Mass { get; set; }
        public double Size { get; set; }
        public int Temperature { get; set; }
        public double Luminosity { get; set; }
        
        private char ClassFinder()
        {
            if (Temperature >= 30000 && Luminosity >= 30000 & Mass >= 16 & Size / 2 >= 6.6)
            {
                return 'O';
            }
            else if (Temperature >= 10000 && Temperature < 30000 && Luminosity >= 25 && Luminosity < 30000 &&
                     Mass >= 2.1 && Mass < 16 && Size/2 >= 1.8 && Size/2 < 6.6)
            {
                return 'B';
            }
            else if (Temperature >= 7500 && Temperature < 10000 && Luminosity >= 5 && Luminosity < 25 &&
                     Mass >= 1.4 && Mass < 2.1 && Size/2 >= 1.4 && Size/2 < 1.8)
            {
                return 'A';
            }
            else if (Temperature >= 6000 && Temperature < 7500 && Luminosity >= 1.5 && Luminosity < 5 &&
                     Mass >= 1.04 && Mass < 1.4 && Size/2 >= 1.15 && Size/2 < 1.4)
            {
                return 'F';
            }
            else if (Temperature >= 5200 && Temperature < 6000 && Luminosity >= 0.6 && Luminosity < 1.5 &&
                     Mass >= 0.8 && Mass < 1.04 && Size/2 >= 0.96 && Size/2 < 1.15)
            {
                return 'G';
            }
            else if (Temperature >= 3700 && Temperature < 5200 && Luminosity >= 0.08 && Luminosity < 0.6 &&
                     Mass >= 0.45 && Mass < 0.8 && Size/2 >= 0.7 && Size/2 < 0.96)
            {
                return 'K';
            }
            else if (Temperature >= 2400 && Temperature < 3700 && Luminosity <= 0.08 && Mass >= 0.08 && Mass < 0.45 &&
                     Size / 2 <= 0.7)
            {
                return 'M';
            }
            else return 'X';
        }
    }
}