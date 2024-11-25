using OrmConfigGenerator.Blueriq;
using System.Xml.Linq;

namespace OrmConfigGenerator.XmlParser
{
    internal static class BlueriqExportParser
    {
        public static Branch ParseXmlToBranch(string filePath)
        {
            // Load the XML file
            XDocument xDocument = XDocument.Load(filePath);

            // Get the BranchContent element
            var branchContent = xDocument.Descendants("BranchContent").FirstOrDefault() ?? throw new Exception("BranchContent not found in the XML.");

            // Create a new Branch object
            Branch branch = new(branchContent.Attribute("BranchName")?.Value ?? "");

            // Get all Projects under the BranchContent
            var projects = branchContent.Descendants("Project");
            foreach (var projectElem in projects)
            {
                // Checks if the minimal required elements are available
                if (projectElem.Attribute("Name") != null) continue;
                if (!projectElem.Descendants("Project").Any()) continue;
                if (!projectElem.Descendants("Content").Any()) continue;

                Project project = new(projectElem.Descendants("Project").First().Attribute("Name")?.Value ?? "");

                // Get all Modules under the Project
                var modules = projectElem.Descendants("Module");
                foreach (var moduleElem in modules)
                {
                    if (moduleElem.Attribute("Name") != null) continue;

                    Module module = new(moduleElem.Descendants("Module").First().Attribute("Name")?.Value ?? "");

                    Dictionary<string, Entity> entities = [];

                    // Get all Attributes under the Module
                    var attributes = moduleElem.Descendants("Attribute");
                    foreach (var attributeElem in attributes)
                    {
                        BlueriqDataType dataType = BlueriqDataType.Boolean;
                        string? dataTypeString = attributeElem.Attribute("DataType")?.Value;
                        string? entityName = attributeElem.Attribute("Entity")?.Value;

                        //There are other attribut elements in the XML which should not be used
                        if (dataTypeString == null || entityName == null) continue;

                        if (dataTypeString == "Number") dataType = BlueriqDataType.Number;
                        else if (dataTypeString == "Currency") dataType = BlueriqDataType.Currency;
                        else if (dataTypeString == "String") dataType = BlueriqDataType.Text;
                        else if (dataTypeString == "Integer") dataType = BlueriqDataType.Integer;
                        else if (dataTypeString == "Date") dataType = BlueriqDataType.Date;
                        else if (dataTypeString == "DateTime") dataType = BlueriqDataType.DateTime;
                        else if (dataTypeString == "Percentage") dataType = BlueriqDataType.Percentage;
                        else if (dataTypeString == "Boolean") dataType = BlueriqDataType.Boolean;

                        Blueriq.Attribute attribute = new(
                            attributeElem.Attribute("Name")?.Value ?? "???",
                            dataType,
                            bool.Parse(attributeElem.Attribute("MultiValued")?.Value ?? "false"),
                            attributeElem.Element("QuestionText")?.Value.Replace(Environment.NewLine, " ") ?? string.Empty,
                            attributeElem.Element("Description")?.Value.Replace(Environment.NewLine, " ") ?? string.Empty
                        );

                        if (!entities.TryGetValue(entityName, out Entity? entity))
                        {
                            entity = new(entityName);
                            entities.Add(entityName, entity);
                            module.Entities.Add(entity);
                        }

                        entity.Attributes.Add(attribute);
                    }

                    // Get all Attributes under the Module
                    var relations = moduleElem.Descendants("Relation");
                    foreach (var relationsElem in relations)
                    {
                        if (relationsElem.Attribute("MultiValued")?.Value == null) continue;

                        Relation relation = new(
                            relationsElem.Attribute("Name")?.Value ?? "???",
                            bool.Parse(relationsElem.Attribute("MultiValued")?.Value ?? "false")
                        );

                        string entityNameFrom = relationsElem.Attribute("FromEntity")?.Value ?? "";
                        if (!entities.TryGetValue(entityNameFrom, out Entity? entityFrom))
                        {
                            entityFrom = new(entityNameFrom);
                            entities.Add(entityNameFrom, entityFrom);
                            module.Entities.Add(entityFrom);
                        }
                        string entityNameTo = relationsElem.Attribute("ToEntity")?.Value ?? "";
                        if (!entities.TryGetValue(entityNameTo, out Entity? entityTo))
                        {
                            entityTo = new(entityNameTo);
                            entities.Add(entityNameTo, entityFrom);
                            module.Entities.Add(entityTo);
                        }
                        relation.RelatedEntity = entityTo;

                        entityFrom.Relations.Add(relation);
                    }

                    module.Entities.Sort();
                    foreach (Entity entity in module.Entities)
                    {
                        entity.Attributes.Sort();
                        entity.Relations.Sort();
                    }
                    project.Modules.Add(module);
                }
                project.Modules.Sort();
                branch.Projects.Add(project);
            }
            branch.Projects.Sort();
            return branch; // Return the fully populated Branch object
        }
    }
}
