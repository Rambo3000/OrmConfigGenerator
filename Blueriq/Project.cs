namespace OrmConfigGenerator.Blueriq
{
    public class Project(string name)
    {
        public string Name { get; set; } = name;
        public List<Module> Modules { get; set; } = [];
        public override string ToString()
        {
            return Name;
        }
    }
}
