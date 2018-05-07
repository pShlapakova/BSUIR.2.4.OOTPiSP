namespace XmlToJsonFunctionalPlugin
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Text;
    using System.Text.RegularExpressions;
    using FunctionalPluginBase;

    /// <summary>
    /// Converts XML <see cref="string"/> to JSON <see cref="string"/>.
    /// </summary>
    [Export(typeof(IFunctionalPlugin))]
    [ExportMetadata("Name", "XML to JSON")]
    public class XmlToJsonPlugin : IFunctionalPlugin
    {
        /// <summary>
        /// Gets formats supported by this plugin.
        /// </summary>
        public string SupportedFormats { get; } = "XML file|*.xml";        

        /// <summary>
        /// Performs special transformations with serialized text.
        /// </summary>
        /// <param name="graph">Serialized text.</param>
        /// <returns>Transformed text.</returns>
        public string AfterSerialization(string graph)
        {
            return graph;
        }

        /// <summary>
        /// Performs special transformations with serialized text.
        /// </summary>
        /// <param name="graph">Text from file with serialized objects.</param>
        /// <returns>Transformed text.</returns>
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

                foreach (KeyValuePair<string, string> pair in baseProperties)
                {
                    jsonResult.Append(",\"" + pair.Key + "\":" + pair.Value);
                }

                foreach (KeyValuePair<string, string> pair in extendedProperties)
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
