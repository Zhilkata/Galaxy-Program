namespace GalaxyProgram
{
    public class Galaxy : SpaceObject
    {
        public Galaxy(string name, string type, string age)
        {
            Name = name;
            Type = type;
            Age = age;
        }
        
        public override string Name { get; set; }
        public string Type { get; set; }
        public string Age { get; set; }
        
        /*public string AgeInfo()
        {
            if (Age.Contains("B"))
            {
                string yearsOnly = new String(Age.Where(Char.IsDigit).ToArray());
                return $"{double.Parse(yearsOnly)} billion years old";
            }
            else
            {
                string yearsOnly = new String(Age.Where(Char.IsDigit).ToArray());
                return $"{double.Parse(yearsOnly)} million years old";
            }
        }*/
    }
}