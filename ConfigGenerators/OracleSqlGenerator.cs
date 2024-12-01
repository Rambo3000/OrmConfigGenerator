using OrmConfigGenerator.Blueriq;
using System.Text;
using Attribute = OrmConfigGenerator.Blueriq.Attribute;

namespace OrmConfigGenerator.ConfigGenerators
{
    public static class OracleSqlGenerator
    {
        public static string GenerateOracleSqlScript(Module module)
        {
            StringBuilder sqlScript = new();

            foreach (var entity in module.Entities)
            {
                if (!entity.UseForExport) continue; // Skip entities not marked for export

                sqlScript.AppendLine($"CREATE TABLE {entity.NameOracleSQL} (");

                List<string> primaryKeys = [];

                foreach (var attribute in entity.Attributes)
                {
                    if (!attribute.UseForExport) continue; // Skip attributes not marked for export

                    string columnName = attribute.NameOracleSQL;
                    string columnType = GetOracleColumnType(attribute);

                    sqlScript.Append($"\t{columnName} {columnType}");

                    if (attribute.IsPrimaryKey)
                    {
                        primaryKeys.Add(columnName);
                        sqlScript.Append(" NOT NULL");
                    }

                    sqlScript.AppendLine(",");
                }

                // Remove last comma from the last column definition
                if (sqlScript[^3] == ',')
                {
                    sqlScript.Remove(sqlScript.Length - 3, 1);
                }

                // Add Primary Key constraint if any
                if (primaryKeys.Count > 0)
                {
                    string primaryKeyConstraint = string.Join(", ", primaryKeys);
                    sqlScript.AppendLine("\t");
                    sqlScript.AppendLine($"\tCONSTRAINT {entity.NameOracleSQL}_PK PRIMARY KEY ({primaryKeyConstraint})");
                }

                sqlScript.AppendLine(");");
                sqlScript.AppendLine();
            }

            return sqlScript.ToString();
        }

        private static string GetOracleColumnType(Attribute attribute)
        {
            switch (attribute.OracleDataType)
            {
                case OracleDataType.NUMBER:
                    if (attribute.PrecisionBeforeSeperator.HasValue || attribute.PrecisionAfterSeperator.HasValue)
                    {
                        string precisionBefore = attribute.PrecisionBeforeSeperator == null ? "???" : attribute.PrecisionBeforeSeperator.ToString() ?? "???";
                        string precisionAfter = attribute.PrecisionAfterSeperator == null ? "???" : attribute.PrecisionAfterSeperator.ToString() ?? "???";
                        return $"NUMBER({precisionBefore},{precisionAfter})";
                    }
                    return "NUMBER"; // Handle missing precision
                case OracleDataType.VARCHAR2:
                    string size = attribute.Size == null ? "???" : attribute.Size.ToString() ?? "???";
                    return $"VARCHAR2({size} CHAR)";
                case OracleDataType.CLOB:
                    return "CLOB";
                case OracleDataType.DATE:
                    return "DATE";
                default:
                    return "VARCHAR2(? CHAR)"; // Default to VARCHAR2 with unknown size
            }
        }
    }
}
