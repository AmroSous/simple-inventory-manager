namespace SimpleInventoryManagement.Util
{
    /**
     * This is an enumeration to specify type 
     * of output, each type given a console color. 
     */
    public enum ConsoleColorType
    {
        Default = ConsoleColor.White,
        Information = ConsoleColor.Blue,
        Error = ConsoleColor.DarkRed,
        Warning = ConsoleColor.DarkYellow,
        Prompt = ConsoleColor.Magenta,
        Success = ConsoleColor.DarkGreen,
        Failure = ConsoleColor.DarkGray,
        Important = ConsoleColor.Red,
        Help = ConsoleColor.Cyan
    }
}
