using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AlepoWSRC
{
    class ResourceHelper
    {
        public static void AddOrUpdateResource(string key, string value)
        {
            var resx = new List<DictionaryEntry>();
            using (var reader = new ResXResourceReader("userData.resx"))
            {
                resx = reader.Cast<DictionaryEntry>().ToList();
                var existingResource = resx.Where(r => r.Key.ToString() == key).FirstOrDefault();
                if (existingResource.Key == null && existingResource.Value == null)
                {
                    resx.Add(new DictionaryEntry() { Key = key, Value = value });
                }
                else // MODIFIED RESOURCE!
                {
                    var modifiedResx = new DictionaryEntry()
                    { Key = existingResource.Key, Value = value };
                    resx.Remove(existingResource);
                    resx.Add(modifiedResx);
                }
            }
            using (var writer = new ResXResourceWriter("userData.resx"))
            {
                resx.ForEach(r =>
                {

                    writer.AddResource(r.Key.ToString(), r.Value.ToString());
                });
                writer.Generate();
            }
        }

        public static string ReadResource(string key)
        {
            string value = "";

            var resx = new List<DictionaryEntry>();
            using (var reader = new ResXResourceReader("userData.resx"))
            {
                resx = reader.Cast<DictionaryEntry>().ToList();
                var existingResource = resx.Where(r => r.Key.ToString() == key).FirstOrDefault();

                value = existingResource.Value.ToString();
            }

            return value;

        }

        public static bool CheckResource(string key)
        {
            var resx = new List<DictionaryEntry>();
            using (var reader = new ResXResourceReader("userData.resx"))
            {
                resx = reader.Cast<DictionaryEntry>().ToList();
                var existingResource = resx.Where(r => r.Key.ToString() == key).FirstOrDefault();
                if (existingResource.Value.ToString() != string.Empty)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
