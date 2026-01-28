using System;
using System.IO;
using YamlDotNet.Serialization;

namespace OutSystems.YAML2JSON
{
    /// <summary>
    /// The Yaml2Json class implements the IYAM2JSON interface, providing
    /// functionality to convert YAML strings to JSON strings using the YamlDotNet library.
    /// </summary>
    public class Yaml2Json : IYAML2JSON
    {

        /// <summary>
        /// The ConvertYamlToJson method takes a YAML string, converts it to JSON format, and provides
        /// success and error information. If the conversion is successful, it returns the JSON string
        /// and sets IsSuccess to true. If an exception occurs, it captures the error message and sets IsSuccess to false.
        /// </summary>
        /// <param name="YamlToConvert">YAML string to be converted.</param>
        /// <param name="ConvertedJSON">Output parameter for the converted JSON string.</param>
        /// <param name="IsSuccess">Output parameter indicating the success of the conversion.</param>
        /// <param name="ErrorData">Output structure for errors encountered during the conversion.</param>
        public void ConvertYamlToJson(string YamlToConvert, 
                                      out string ConvertedJSON, 
                                      out bool IsSuccess, 
                                      out Yaml2Json_Error ErrorData)
        {
            // Set outputs to default value
            IsSuccess = false;
            ErrorData.Message = String.Empty;
            ConvertedJSON = String.Empty;
            ErrorData = new Yaml2Json_Error();

            try
            {

                if (YamlToConvert == null || YamlToConvert == String.Empty)
                {
                    throw new ArgumentNullException("The yaml text cannot be empty.");
                }

                
                var input = new StringReader(YamlToConvert);
                var deserializer = new DeserializerBuilder()
                    .WithAttemptingUnquotedStringTypeDeserialization()
                    .Build();

           
                var yamlObject = deserializer.Deserialize(input);
                var serializer = new YamlDotNet.Serialization.SerializerBuilder()
                    .JsonCompatible()                  
                    .Build();

                ConvertedJSON = serializer.Serialize(yamlObject);

                IsSuccess = true;
            }
            catch (YamlDotNet.Core.SyntaxErrorException ex)
            {
                IsSuccess = false;
                ErrorData.Start = new Yaml2Json_ErrorPosition(ex.Start.Line, ex.Start.Column, ex.Start.Index);  
                ErrorData.End = new Yaml2Json_ErrorPosition(ex.End.Line, ex.End.Column, ex.End.Index);
                ErrorData.Message = "[" + ex.Start + "] - [" + ex.End + "]: " + ex.Message;
            }
            catch (YamlDotNet.Core.SemanticErrorException ex)
            {
                IsSuccess = false;
                ErrorData.Start = new Yaml2Json_ErrorPosition(ex.Start.Line, ex.Start.Column, ex.Start.Index);
                ErrorData.End = new Yaml2Json_ErrorPosition(ex.End.Line, ex.End.Column, ex.End.Index);
                ErrorData.Message = "[" + ex.Start + "] - [" + ex.End + "]: " + ex.Message;
            }
            /* Parent exception */
            catch (YamlDotNet.Core.YamlException ex)
            {
                IsSuccess = false;
                ErrorData.Start = new Yaml2Json_ErrorPosition(ex.Start.Line, ex.Start.Column, ex.Start.Index);
                ErrorData.End = new Yaml2Json_ErrorPosition(ex.End.Line, ex.End.Column, ex.End.Index);
                ErrorData.Message = "[" + ex.Start + "] - [" + ex.End + "]: " + ex.Message;
            }
            catch (ArgumentNullException ex)
            {
                IsSuccess = false;
                ErrorData.Message = "Error: " + ex.ParamName;
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                ErrorData.Message = "Error: " + ex.Message;
            }
        }
    }
}