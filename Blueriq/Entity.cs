namespace OrmConfigGenerator.Blueriq
{
    public class Entity (string name)
    {
        public string Name { get; set; } = name;
        public List<Attribute> Attributes { get; set; } = [];
        public List<Relation> Relations { get; set; } = [];
        public bool UseForExport { get; set; } = false;
        public override string ToString()
        {
            return Name;
        }
    }
}
