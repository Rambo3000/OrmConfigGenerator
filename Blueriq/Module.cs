namespace OrmConfigGenerator.Blueriq
{
    public class Module(string name)
    {
        public string Name { get; set; } = name;
        public List<Entity> Entities { get; set; } = [];
        public override string ToString()
        {
            return Name;
        }
    }
}
