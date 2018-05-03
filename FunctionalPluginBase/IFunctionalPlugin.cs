namespace SimpleGrapicsEditor
{    
    /// <summary>
    /// The interface for plugins that provide additional
    /// functionality with storing objects.
    /// </summary>
    public interface IFunctionalPlugin
    {
        /// <summary>
        /// Gets the list of new file formats that can be supported by the
        /// application when the plugin is loaded.
        /// </summary>
        string SupportedFormats { get; }

        /// <summary>
        /// Does additional work after serialization of objects.
        /// </summary>
        /// <param name="graph">The location of target file for storing
        /// serialized objects.</param>
        /// <returns>Processed string.</returns>
        string AfterSerialization(string graph);

        /// <summary>
        /// Does additional work before deserialization of objects.
        /// </summary>
        /// <param name="graph">The location of the tagret file gfor storing
        /// serialized objects.</param>
        /// <returns>Processed string.</returns>
        string BeforeDeserialization(string graph);        
    }
}
