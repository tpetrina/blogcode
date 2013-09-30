using System;
using System.Windows.Navigation;

namespace UriMapper1
{
    internal class IdentityUriMapper : UriMapperBase
    {
        public override Uri MapUri(Uri uri)
        {
            return uri;
        }
    }
}