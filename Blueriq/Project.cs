namespace OrmConfigGenerator.Blueriq
{
    public class Project(string name) : IComparable<Project>
    {
        public string Name { get; set; } = name;
        public List<Module> Modules { get; set; } = [];
        public override string ToString()
        {
            return Name;
        }
        public int CompareTo(Project? other)
        {
            if (other == null) return 1;

            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}
