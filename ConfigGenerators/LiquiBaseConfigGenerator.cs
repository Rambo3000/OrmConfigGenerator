using OrmConfigGenerator.Blueriq;
using System.Text;
using Attribute = OrmConfigGenerator.Blueriq.Attribute;

namespace OrmConfigGenerator.ConfigGenerators
{
    internal static class LiquiBaseConfigGenerator
    {
        public static string GenerateLiquiBaseScript(Module module, string authorName, string changeSetIdDescription)
        {
            StringBuilder sb = new();
            int changeSetId = 1;

            foreach (Entity entity in module.Entities)
            {
                // Skip entity if it's not for export
                if (!entity.UseForExport) continue;

                sb.AppendLine($"<changeSet author=\"{authorName}\" id=\"{changeSetIdDescription}-{changeSetId}\">");
                sb.AppendLine($"\t<createTable tableName=\"{SqlNameConverter.Convert(entity.Name)}\">");

                foreach (Attribute attribute in entity.Attributes)
                {
                    // Skip attribute if it's not for export
                    if (!attribute.UseForExport) continue;

                    // Start column definition

                    // Add primary key constraint if applicable, otherwise skip constraints for non-PK attributes
                    if (attribute.IsPrimaryKey)
                    {
                        sb.AppendLine($"\t\t<column name=\"{SqlNameConverter.Convert(attribute.Name)}\" type=\"{GetOracleColumnType(attribute)}\">");
                        sb.AppendLine($"\t\t\t<constraints nullable=\"false\" primaryKey=\"true\" primaryKeyName=\"{SqlNameConverter.Convert(entity.Name)}_PK\"/>");
                        sb.AppendLine("\t\t</column>");
                    }
                    else
                    {
                        sb.AppendLine($"\t\t<column name=\"{SqlNameConverter.Convert(attribute.Name)}\" type=\"{GetOracleColumnType(attribute)}\"/>");
                    }
                }

                sb.AppendLine("\t</createTable>");
                sb.AppendLine("</changeSet>");
                changeSetId++;
            }

            return sb.ToString();
        }

        // Helper method to get Oracle data type
        private static string GetOracleColumnType(Attribute attribute)
        {
            if (attribute.OracleDataType == OracleDataType.NUMBER)
            {
                string precision = attribute.PrecisionBeforeSeperator.HasValue ? attribute.PrecisionBeforeSeperator.Value.ToString() : "???";
                string scale = attribute.PrecisionAfterSeperator.HasValue ? attribute.PrecisionAfterSeperator.Value.ToString() : "???";
                if (!attribute.PrecisionBeforeSeperator.HasValue && !attribute.PrecisionAfterSeperator.HasValue &&
                    (attribute.BlueriqDataType == BlueriqDataType.Number || attribute.BlueriqDataType == BlueriqDataType.Percentage || attribute.BlueriqDataType == BlueriqDataType.Currency))
                {
                    return $"NUMBER";
                }
                return $"NUMBER({precision},{scale})";
            }
            else if (attribute.OracleDataType == OracleDataType.VARCHAR2)
            {
                string size = attribute.Size.HasValue ? attribute.Size.Value.ToString() : "???";
                return $"VARCHAR2({size} CHAR)";
            }
            return attribute.OracleDataType.ToString(); // Default to simple type
        }
    }
}
