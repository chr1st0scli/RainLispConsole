using System.Runtime.InteropServices;

namespace RainLispConsole
{
    internal static class Repl
    {
        private static readonly bool _windowsPlatform;

        static Repl()
            => _windowsPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        internal static string? ReadLine()
        {
            Console.Write(Resources.REPL_PROMPT);
            return Console.ReadLine();
        }

        internal static string? ReadLines()
        {
            const char CTRL_Z = '\u001a', CTRL_D = '\u0004';

            Console.WriteLine(_windowsPlatform ? Resources.REPL_MULTILINE_PROMPT_WIN_OS : Resources.REPL_MULTILINE_PROMPT_OTHER_OS);

            string input = Console.In.ReadToEnd();

            // Remove the Ctrl + Z in case the user typed it in next to other characters, instead on its own on a separate line.
            return input.Trim().Trim(_windowsPlatform ? CTRL_Z : CTRL_D);
        }

        internal static void Print(string result)
        {
            if (string.IsNullOrEmpty(result))
                return;

            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine(result);

            Console.ForegroundColor = originalColor;
        }

        internal static void PrintError(string message, Exception ex, bool unknownError)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Error.WriteLine(message);

            // Print the entire exception if it is unknown.
            if (unknownError)
                Console.Error.WriteLine(ex.ToString());

            // Or print the exception's message if one provided by a programmer extending the library.
            else if (!string.IsNullOrWhiteSpace(ex.Message) && !ex.Message.StartsWith("Exception of type"))
                Console.Error.WriteLine(ex.Message);

            Console.ForegroundColor = originalColor;
        }
    }
}
