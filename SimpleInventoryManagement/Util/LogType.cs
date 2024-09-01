namespace SimpleInventoryManagement.Util
{
    /**
     * This is an enumeration to specify type 
     * of output, each type given a console color. 
     */
    public enum LogType
    {
        Info = ConsoleColor.Blue,
        Error = ConsoleColor.Red,
        Warning = ConsoleColor.DarkYellow,
        Prompt = ConsoleColor.Magenta,
        Success = ConsoleColor.DarkGreen,
        Fail = ConsoleColor.DarkGray,
        Normal = ConsoleColor.White
    }
}
