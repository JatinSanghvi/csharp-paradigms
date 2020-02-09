namespace Paradigms.Oop
{
    using System;
    using System.IO;
    using System.Net;

    internal sealed class WebDataLoader : IDataLoader
    {
        private readonly Uri uri;

        public WebDataLoader(Uri uri)
        {
            this.uri = uri;
        }

        public string LoadData()
        {
            var client = new WebClient();
            return client.DownloadString(this.uri);
        }
    }
}
