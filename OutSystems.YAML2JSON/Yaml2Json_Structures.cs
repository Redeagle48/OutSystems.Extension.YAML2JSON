using OutSystems.ExternalLibraries.SDK;

namespace OutSystems.YAML2JSON
{
    [OSStructure(Description = "Structure to hold conversion error data.")]
    public struct Yaml2Json_Error
    {
        [OSStructureField(Description = "Start position of the error.")]
        public Yaml2Json_ErrorPosition Start;
        [OSStructureField(Description = "End position of the error.")]
        public Yaml2Json_ErrorPosition End;
        [OSStructureField(Description = "Generated error message.")]
        public string Message;

        // Default constructor
        public Yaml2Json_Error()
        {
            Start = new Yaml2Json_ErrorPosition();
            End = new Yaml2Json_ErrorPosition();
            Message = string.Empty; // Default value for string
        }

        // Parameterized constructor
        public Yaml2Json_Error(Yaml2Json_ErrorPosition start, Yaml2Json_ErrorPosition end, string message)
        {
            Start = start;
            End = end;
            Message = message;
        }
    }

    [OSStructure(Description = "Structure to hold error position data.")]
    public struct Yaml2Json_ErrorPosition
    {
        [OSStructureField(Description = "Position line. Default value = -1.", DefaultValue = "-1")]
        public int Line;
        [OSStructureField(Description = "Position column. Default value = -1.", DefaultValue = "-1")]
        public int Column;
        [OSStructureField(Description = "Position index. Default value = -1.", DefaultValue = "-1")]
        public int Index;

        // Default constructor
        public Yaml2Json_ErrorPosition()
        {
            Line = -1; // Default value for int
            Column = -1; // Default value for int
            Index = -1; // Default value for int
        }

        // Parameterized constructor
        public Yaml2Json_ErrorPosition(int line, int column, int index)
        {
            Line = line;
            Column = column;
            Index = index;
        }
    }
}
