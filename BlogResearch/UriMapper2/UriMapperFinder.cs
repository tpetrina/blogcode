using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Navigation;
using System.Xml.Linq;
using Microsoft.Phone.Controls;

namespace UriMapper2
{
    public class UriMapperFinder : UriMapperBase
    {
        public UriMapperFinder()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var pages = assembly.GetTypes()
                                .Where(type => type.BaseType == typeof(PhoneApplicationPage))
                                .ToList();

            var assemblyFullName = assembly.ToString();
            var baseName = assemblyFullName.Substring(0, assemblyFullName.IndexOf(",")) + ".g";

            var names = assembly.GetManifestResourceNames();
            var manager = new ResourceManager(baseName, assembly);
            var set = manager.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, true, true);
            using (var stream = manager.GetStream("app.xaml"))
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
            }
            foreach (DictionaryEntry resource in set)
            {
                if (resource.Key.ToString().EndsWith(".xaml"))
                {
                    var doc = XDocument.Load(resource.Value as Stream);
                    if (doc.Root.Name == "{clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone}PhoneApplicationPage")
                    {
                        Debug.WriteLine(resource.Key + " is a Page");
                    }
                }
            }
        }

        public override Uri MapUri(Uri uri)
        {
            return uri;
        }
    }
}
