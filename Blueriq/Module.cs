namespace OrmConfigGenerator.Blueriq
{
    public class Module(string name) : IComparable<Module>
    {
        public string Name { get; set; } = name;
        public List<Entity> Entities { get; set; } = [];
        public override string ToString()
        {
            return Name;
        }
        public int CompareTo(Module? other)
        {
            if (other == null) return 1;

            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}
