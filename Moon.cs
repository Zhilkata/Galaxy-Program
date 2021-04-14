namespace GalaxyProgram
{
    public class Moon : SpaceObject
    {
        public Moon(string name)
        {
            Name = name;
        }
        public override string Name { get; set; }
    }
}