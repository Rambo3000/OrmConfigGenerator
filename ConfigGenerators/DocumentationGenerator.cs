using OrmConfigGenerator.Blueriq;
using System.Text;
using Attribute = OrmConfigGenerator.Blueriq.Attribute;

namespace OrmConfigGenerator.ConfigGenerators
{
    public static class DocumentationGenerator
    {
        public static string GenerateDocumentationDatabase(Module module)
        {
            if (module == null || module.Entities == null || module.Entities.Count == 0)
                return "Geen entiteiten beschikbaar in de module.";

            StringBuilder documentation = new();

            foreach (Entity entity in module.Entities)
            {
                if (!entity.UseForExport) continue;

                // Voeg entiteit header toe
                documentation.AppendLine($"h1. {entity.NameOracleSQL}");
                documentation.AppendLine("|| Kolom || Type || Omschrijving ||");

                // Voeg attributen toe
                foreach (Attribute attribute in entity.Attributes)
                {
                    if (!attribute.UseForExport) continue;
                    documentation.AppendLine($"| {attribute.NameOracleSQL} | {attribute.OracleDataType} | {attribute.Description ?? ""} |");
                }

                // Voeg lege regel als er geen attributen zijn
                if (!entity.Attributes.Any(a => a.UseForExport))
                {
                    documentation.AppendLine("| | | |");
                }

                documentation.AppendLine(); // Lege regel tussen attributen en relaties
            }

            return documentation.ToString();
        }
    }
}