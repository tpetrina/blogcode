using System;
using System.Windows.Navigation;

namespace UriMapper1
{
    public class BasicBasicUriRewriter : UriMapperBase
    {
        public override Uri MapUri(Uri uri)
        {
            if (uri.OriginalString.EndsWith(".xaml"))
                return uri;

            return new Uri("/" + uri.OriginalString + "Page.xaml", UriKind.Relative);
        }
    }
}
