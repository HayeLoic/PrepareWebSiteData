using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PrepareWebSiteData.Helper
{
    public class JsonHelper
    {
        private const string JsonFileExtension = ".json";

        public string SerializeObject(object myObject)
        {
            return JsonConvert.SerializeObject(
                myObject,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }

        public bool IsJsonFileExtension(string fileFullPath)
        {
            return Path.GetExtension(fileFullPath) == JsonFileExtension;
        }

        public string GetJsonFileExtension()
        {
            return JsonFileExtension;
        }
    }
}
