namespace FunctionalPlugins
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Text;
    using System.Text.RegularExpressions;
    using SimpleGrapicsEditor;

    [Export(typeof(IFunctionalPlugin))]
    [ExportMetadata("Name", "XML to JSON")]
    public class XmlToJsonPlugin : IFunctionalPlugin
    {
        public string SupportedFormats { get; } = "XML file|*.xml";        

        public string AfterSerialization(string graph)
        {
            return graph;
        }

        public string BeforeDeserialization(string graph)
        {
            if (!graph.StartsWith("<?xml"))
            {
                // Return source string without any changes.
                return graph;
            }
            
            var shapeMatches = Regex.Matches(graph, "<AbstractShape xsi:type=\"(.+)\">(\\s+(.+\\s+)+?)</AbstractShape>");

            if (shapeMatches.Count == 0)
            {
                // No one shape was found in the text.
                return graph;
            }

            StringBuilder jsonResult = new StringBuilder();
            jsonResult.Append('[');

            foreach (Match shapeMatch in shapeMatches)
            {
                var baseProperties = new SortedDictionary<string, string>();
                var extendedProperties = new SortedDictionary<string, string>();

                jsonResult.Append("{\"__type\":\"");
                jsonResult.Append(shapeMatch.Groups[1].Value); // Append type of the shape.
                jsonResult.Append('\"');

                var propertyMatches = Regex.Matches(shapeMatch.Groups[2].Value, "<(\\w+)>(.*)</\\w+>"); // All properties with its values.

                foreach (Match propertyMatch in propertyMatches)
                {
                    if (propertyMatch.Groups[1].Value.StartsWith("Pen"))
                    {
                        baseProperties.Add(propertyMatch.Groups[1].Value, propertyMatch.Groups[2].Value);
                    }
                    else
                    {
                        extendedProperties.Add(propertyMatch.Groups[1].Value, propertyMatch.Groups[2].Value);
                    }
                }

                foreach (var pair in baseProperties)
                {
                    jsonResult.Append(",\"" + pair.Key + "\":" + pair.Value);
                }

                foreach (var pair in extendedProperties)
                {
                    jsonResult.Append(",\"" + pair.Key + "\":" + pair.Value);
                }

                jsonResult.Append("},");
            }

            // Remove last excess ","
            jsonResult.Remove(jsonResult.Length - 1, 1);

            jsonResult.Append(']');

            return jsonResult.ToString();
        }
    }
}
