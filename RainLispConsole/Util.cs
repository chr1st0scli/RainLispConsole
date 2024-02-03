using System.Reflection;

namespace RainLispConsole
{
    internal static class Util
    {
        internal static string TryGetCurrentVersion()
        {
            try
            {
                return Assembly.GetExecutingAssembly()
                    ?.GetName().Version?.ToString(3) ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        internal static string TryGetRainLispVersion()
        {
            try
            {
                return Assembly.GetAssembly(typeof(RainLisp.Interpreter))
                    ?.GetName().Version?.ToString(3) ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
