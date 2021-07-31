using System;
using System.IO;
using System.Net;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace NetMsixUpdater.YamlInfo
{
    internal sealed class YamlUpdateInfo : IDisposable
    {
        private string yamlText { get; set; }
        private bool isInServer { get; set; }

        internal YamlUpdateInfo(string yamlFilePath)
        {
            isInServer = Uri.CheckSchemeName(yamlFilePath);

            if(isInServer) 
                using(WebClient webClient = new()) yamlText = webClient.DownloadString(yamlFilePath);
            else 
                yamlText = File.ReadAllText(yamlFilePath);
        }
        ~YamlUpdateInfo() => Dispose();

        internal object DeserializeYaml<T>()
        {
            IDeserializer deserialize = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();

            return deserialize.Deserialize<T>(yamlText);
        }

        private bool disposed { get; set; } = false;
        public void Dispose()
        {
            if(disposed) return;

            GC.SuppressFinalize(this);
        }
    }
}
