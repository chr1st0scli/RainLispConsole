using System.Reflection;

namespace RainLispConsole
{
    internal static class Util
    {
        internal static string? TryGetCurrentVersion()
        {
            try
            {
                return Assembly.GetExecutingAssembly()
                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                    ?.InformationalVersion ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
