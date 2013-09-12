using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Windows.Navigation;
using System.Xml.Linq;

namespace MultipleLayouts
{
    public class WideUriMapper : UriMapperBase
    {
        public WideUriMapper()
        {
            var assemblyFullName = System.Reflection.Assembly.GetExecutingAssembly().ToString();
            var baseName = assemblyFullName.Substring(0, assemblyFullName.IndexOf(",")) + ".g";

            var manager = new ResourceManager(baseName, System.Reflection.Assembly.GetExecutingAssembly());
            var set = manager.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, true, true);
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
            return new Uri(uri.OriginalString.Replace(".xaml", "_large.xaml"), UriKind.Relative);
        }
    }
}