using System.IO;
using System.Linq;

namespace ActiveRecordNET.Lib.Common.Tests
{
    public static class PathUtils
    {
        public static string TryGetRootPath()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.csproj").Any())
            {
                directory = directory.Parent;
            }

            return directory.FullName;
        }
    }
}
