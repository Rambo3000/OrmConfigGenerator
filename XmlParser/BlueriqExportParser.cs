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
                if (projectElem.Attribute("Name") != null) continue;

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
                        if (attributeElem.Attribute("DataType")?.Value == "Number") dataType = BlueriqDataType.Number;
                        else if (attributeElem.Attribute("DataType")?.Value == "Currency") dataType = BlueriqDataType.Currency;
                        else if (attributeElem.Attribute("DataType")?.Value == "String") dataType = BlueriqDataType.Text;
                        else if (attributeElem.Attribute("DataType")?.Value == "Integer") dataType = BlueriqDataType.Integer;
                        else if (attributeElem.Attribute("DataType")?.Value == "Date") dataType = BlueriqDataType.Date;
                        else if (attributeElem.Attribute("DataType")?.Value == "DateTime") dataType = BlueriqDataType.DateTime;
                        else if (attributeElem.Attribute("DataType")?.Value == "Percentage") dataType = BlueriqDataType.Percentage;
                        else if (attributeElem.Attribute("DataType")?.Value == "Boolean") dataType = BlueriqDataType.Boolean;

                        Blueriq.Attribute attribute = new(
                            attributeElem.Attribute("Name")?.Value ?? "?",
                            dataType,
                            bool.Parse(attributeElem.Attribute("MultiValued")?.Value ?? "false")
                        );

                        string entityName = attributeElem.Attribute("Entity")?.Value ?? "";
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
                        Relation relation = new(
                            relationsElem.Attribute("Name")?.Value ?? "?",
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

                    project.Modules.Add(module);
                }

                branch.Projects.Add(project);
            }

            return branch; // Return the fully populated Branch object
        }
    }
}
