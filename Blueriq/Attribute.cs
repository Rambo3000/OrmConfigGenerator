namespace OrmConfigGenerator.Blueriq
{
    public class Attribute(string name, BlueriqDataType blueriqDataType, bool multiValued)
    {
        public string Name { get; set; } = name;
        public BlueriqDataType BlueriqDataType { get; set; } = blueriqDataType;
        public bool MultiValued { get; set; } = multiValued;
        public OracleDataType OracleDataType 
        { 
            get 
            {
                //Lists should always be stored concatinated in a string like column
                if (MultiValued) return UseClob ? OracleDataType.CLOB : OracleDataType.VARCHAR2;

                switch (BlueriqDataType)
                {
                    case BlueriqDataType.Boolean: return OracleDataType.NUMBER;
                    case BlueriqDataType.Date: return OracleDataType.DATE;
                    case BlueriqDataType.DateTime: return OracleDataType.DATE;
                    case BlueriqDataType.Integer: return OracleDataType.NUMBER;
                    case BlueriqDataType.Currency: return OracleDataType.NUMBER;
                    case BlueriqDataType.Percentage: return OracleDataType.NUMBER;
                    case BlueriqDataType.Number: return OracleDataType.NUMBER;
                    case BlueriqDataType.Text: return UseClob ? OracleDataType.CLOB : OracleDataType.VARCHAR2;
                    default:
                        break;
                }

                return OracleDataType.CLOB;
            }
        }

        // Additional properties for customization, e.g., size, precision
        public bool UseClob { get; set; } = false;
        public bool IsPrimaryKey { get; set; } = false;
        public bool UseForExport { get; set; } = false;
        public int? Size { get; set; } // For VARCHAR2
        public int? PrecisionBeforeSeperator { get; set; } // For NUMBER(x,y)
        public int? PrecisionAfterSeperator { get; set; } // For NUMBER(x,y)

        public override string ToString()
        {
            return Name;
        }
    }
}
