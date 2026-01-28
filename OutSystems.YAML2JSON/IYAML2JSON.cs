using OutSystems.ExternalLibraries.SDK;

namespace OutSystems.YAML2JSON {
    /// <summary>
    /// The IYAM2JSON defines the IYAM2JSON interface, providing
    /// functionality to convert YAML strings to JSON strings using the YamlDotNet library.
    /// </summary>
    [OSInterface(Description = "Extension to allow converting a YAML string into a JSON format using the YamlDotNet library.", IconResourceName = "OutSystems.YAML2JSON.resources.YAML2JSON_icon.png")]
    public interface IYAML2JSON {
        /// <summary>
        /// The ConvertYamlToJson method takes a YAML string, converts it to JSON format, and provides
        /// success and error information. If the conversion is successful, it returns the JSON string
        /// and sets isSuccess to true. If an exception occurs, it captures the error message and sets isSuccess to false.
        /// </summary>
        /// <param name="yamlToConvert">YAML string to be converted.</param>
        /// <param name="convertedJSON">Output parameter for the converted JSON string.</param>
        /// <param name="isSuccess">Output parameter indicating the success of the conversion.</param>
        /// <param name="errorMessage">Output parameter for any error messages encountered during the conversion.</param>
        [OSAction(Description = "Converts a YAML string into a JSON format using using YamlDotNet library (15.1.4). If an exception occurs, it captures the error message and sets isSuccess to false.", IconResourceName = "OutSystems.YAML2JSON.resources.YAML2JSON_icon.png")]
        void ConvertYamlToJson(
            [OSParameterAttribute(Description = "The yaml text to convert.")]
            string YamlToConvert,
            [OSParameterAttribute(Description = "The resulting json from the conversion.")]
            out string ConvertedJSON,
            [OSParameterAttribute(Description = "'True' if the conversion was successful. Otherwise, 'False'.")]
            out bool IsSuccess,
            [OSParameterAttribute(Description = "The information in case of error.")]
            out Yaml2Json_Error ErrorData);
    }
}