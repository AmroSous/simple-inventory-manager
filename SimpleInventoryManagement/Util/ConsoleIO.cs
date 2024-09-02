
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
         * used to print a message on console.
         * take a message string and log type, to specify color of log.
         * after printing, the console color reset.
         */
        public static void Log(string message, ConsoleColorType type)
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
            string? input;
            input = Console.ReadLine();
            if (input == null) return null;
            input = input.Trim();
            if (input.Equals("--abort"))
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
            Log(msg, colorType);
            return Read();
        }

        /**
         * this method try to read non empty string 
         * from user, if it empty or null try again.
         * it takes message to show before take input.
         */
        public static string ReadNotNull(string msg)
        {
            string? input;
            do
            {
                Log(msg, ConsoleColorType.Prompt);
                input = Read();
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
        public static double? ReadDouble(string msg, bool canNull = false,
            double left_bound = double.MinValue, double right_bound = double.MaxValue)
        {
            string? input;
            double value;
            bool parsed;
            do
            {
                input = canNull ? Read(msg) : ReadNotNull(msg);
                parsed = double.TryParse(input, out value);
                if (parsed && (value < left_bound || value > right_bound)) parsed = false;

            } while ((!canNull && !parsed) || (canNull && !string.IsNullOrEmpty(input) && !parsed));

            return string.IsNullOrEmpty(input) ? null : value;
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
