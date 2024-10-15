namespace OrmConfigGenerator.Blueriq
{
    public class Relation(string name, bool multiValued)
    {
        public string Name { get; set; } = name;
        public Entity? RelatedEntity { get; set; }
        public bool MultiValued { get; set; } = multiValued;
        public bool UseForExport { get; set; } = false;
        public override string ToString()
        {
            return Name;
        }
    }
}
