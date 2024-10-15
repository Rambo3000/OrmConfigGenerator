namespace OrmConfigGenerator.Blueriq
{
    public class Branch(string name)
    {
        public string Name { get; set; } = name;
        public List<Project> Projects { get; set; } = [];
        public override string ToString()
        {
            return Name;
        }
    }
}
