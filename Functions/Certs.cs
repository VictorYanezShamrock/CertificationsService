using System.Collections.Concurrent;
using System.Diagnostics;

namespace CertsService.Functions;


 public static class Certs
    {
        private static readonly string certsDirectory = Path.Combine("S:", "QA", "Inspection Reports & Records & Certs", "Certifications");
        private static readonly ConcurrentDictionary<string, List<string>> fileCache = new();

        // Method to get certification files based on the lookup value.
        public static IEnumerable<string> GetCerts(string lookupValue)
        {
            // Load all files into cache if not already loaded
            if (!fileCache.ContainsKey(certsDirectory))
            {
                fileCache[certsDirectory] = Directory.EnumerateFiles(certsDirectory, "*", SearchOption.AllDirectories).ToList();
            }

            // Filter cached files in memory based on the lookup value.
            return fileCache[certsDirectory].Where(file => file.Contains(lookupValue));
        }
    }