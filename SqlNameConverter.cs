using System.Text;

namespace OrmConfigGenerator
{
    public static class SqlNameConverter
    {
        // Helper method to convert camelCase or PascalCase to SQL-style names
        public static string Convert(string input)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i > 0 && char.IsUpper(input[i]) && !char.IsUpper(input[i - 1]))
                {
                    result.Append('_');
                }
                result.Append(char.ToUpper(input[i]));
            }
            return result.ToString();
        }
    }
}
