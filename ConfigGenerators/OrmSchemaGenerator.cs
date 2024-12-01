using OrmConfigGenerator.Blueriq;
using System.Text;
using Attribute = OrmConfigGenerator.Blueriq.Attribute;

namespace OrmConfigGenerator.ConfigGenerators
{
    public static class OrmSchemaGenerator
    {
        public static string Generate(Module module)
        {
            StringBuilder schemaBuilder = new();

            foreach (Entity entity in module.Entities)
            {
                if (!entity.UseForExport) continue;

                // Get entity name and table name from the module
                string entityName = entity.Name; // Adjust this based on how you want to map your module to entity
                string tableName = SqlNameConverter.Convert(entityName); // Assuming TableName is a property of Module

                // List to hold attributes and primary keys
                List<Attribute> attributes = [];
                List<string> primaryKeys = [];

                // Populate attributes and primary keys
                foreach (var attribute in entity.Attributes) // Assuming Attributes is a list of Attribute
                {
                    if (attribute.UseForExport)
                    {
                        attributes.Add(attribute);
                        if (attribute.IsPrimaryKey)
                        {
                            primaryKeys.Add(attribute.Name);
                        }
                    }
                }

                // Add opening ComplexType tag
                schemaBuilder.AppendLine($"<EntityType Name=\"{entityName}\" map:Table=\"{tableName}\">");

                // Add Key element if there are primary keys
                if (primaryKeys != null && primaryKeys.Count > 0)
                {
                    schemaBuilder.AppendLine("\t<Key>");
                    foreach (string pk in primaryKeys)
                    {
                        schemaBuilder.AppendLine($"\t\t<PropertyRef Name=\"{pk}\"/>");
                    }
                    schemaBuilder.AppendLine("\t</Key>");
                }

                // Add properties
                foreach (Attribute attribute in attributes)
                {
                    string nullable = attribute.IsPrimaryKey ? "Nullable=\"false\"" : "";
                    string columnType = GetColumnType(attribute);

                    schemaBuilder.AppendLine($"\t<Property Name=\"{attribute.Name}\" Type=\"{columnType}\" map:Column=\"{SqlNameConverter.Convert(attribute.Name)}\" {nullable}/>");
                }

                // Close the ComplexType tag
                schemaBuilder.AppendLine("</EntityType>");
                schemaBuilder.AppendLine();
            }

            return schemaBuilder.ToString();
        }

        // Method to map your attributes to the Edm types
        private static string GetColumnType(Attribute attribute)
        {
            if (attribute.UseClob) return "Edm.Clob";
            if (attribute.MultiValued) return "Edm.String";

            return attribute.BlueriqDataType switch
            {
                BlueriqDataType.Boolean => "Edm.Boolean",
                BlueriqDataType.Currency => "Edm.Double",
                BlueriqDataType.Date => "Edm.Date",
                BlueriqDataType.DateTime => "Edm.DateTimeOffset",
                BlueriqDataType.Integer => "Edm.Int32",
                BlueriqDataType.Number => "Edm.Double",
                BlueriqDataType.Percentage => "Edm.Double",
                BlueriqDataType.Text => "Edm.String",
                _ => "Edm.?",
            };
        }
    }
}
