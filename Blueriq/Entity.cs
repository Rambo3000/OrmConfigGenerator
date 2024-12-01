namespace OrmConfigGenerator.Blueriq
{
    public class Entity(string name) : IComparable<Entity>
    {
        public string Name { get; set; } = name;
        public string NameOracleSQL { get { return SqlNameConverter.Convert(Name); } }
        public List<Attribute> Attributes { get; set; } = [];
        public List<Relation> Relations { get; set; } = [];
        public bool UseForExport { get; set; } = false;
        public override string ToString()
        {
            return Name;
        }
        public int CompareTo(Entity? other)
        {
            if (other == null) return 1;

            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}
