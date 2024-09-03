
namespace SimpleInventoryManagement.Util
{
    /**
     * this static class handle all input/output 
     * operations, reading from user and logging (printing)
     * messages on console.
     */
    public static class ConsoleIO
    {
        /**
         * same as LogPrompt but with newline.
         */
        public static void Log(string message, ConsoleColorType type = ConsoleColorType.Default)
        {
            LogPrompt($"{message}\n", type);
        }

        /**
         * used to print a message on console without newline.
         * take a message string and Log color type,
         * after printing, the console color reset.
         */
        public static void LogPrompt(string message, ConsoleColorType type = ConsoleColorType.Default)
        {
            Console.ForegroundColor = (ConsoleColor)type;
            Console.Write(message);
            Console.ResetColor();
        }

        /**
         * try to read input from user.
         * trim the input to remove white spaces.
         * if input is --abort then
         * throw OperationAbortedException.
         */
        public static string? Read()
        {
            var input = Console.ReadLine()?.Trim();
            if (input == "--abort")
                throw new OperationAbortedException();
            return string.IsNullOrEmpty(input) ? null : input; 
        }

        /**
         * same as Read method but print message before 
         * reading input from user.
         */
        public static string? Read(string msg, 
            ConsoleColorType colorType = ConsoleColorType.Prompt)
        {
            LogPrompt(msg, colorType);
            return Read();
        }

        /**
         * this method try to read non empty string 
         * from user, if it empty or null try again.
         * it takes message to show before take input.
         */
        public static string ReadNonEmpty(string msg)
        {
            string? input;
            do
            {
                input = Read(msg);
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        /**
         * This method try to read double value from user. 
         * it print message before reading input. 
         * if canNull param equals true then user can enter null (empty) value.
         * if it is false then user must enter double value.
         * it also checks that read value belongs to specified range. 
         * it returns read value.
         */
        public static double? ReadDouble(string msg, bool canBeNull = false,
            double leftBound = double.MinValue, double rightBound = double.MaxValue)
        {
            double? value = null;
            bool isValid = false;
            do
            {
                var input = canBeNull ? Read(msg) : ReadNonEmpty(msg);
                if (string.IsNullOrEmpty(input))
                {
                    if (canBeNull) return null;
                    continue;
                }

                isValid = double.TryParse(input, out double parsedValue)
                          && parsedValue >= leftBound && parsedValue <= rightBound;

                if (isValid)
                    value = parsedValue;

            } while (!isValid);

            return value;
        }

        /**
         * This method try to read non negative double value from user. 
         * it print message before reading input. 
         * if canNull param equals true then user can enter null (empty) value.
         * if it is false then user must enter positive double value or zero.
         * it returns read value.
         */
        public static double? ReadNonNegativeDouble(string msg, bool canNull = false)
        {
            return ReadDouble(msg, canNull, 0);
        }
    }
}
