using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PrepareWebSiteData.Helper
{
    public class JsonHelper
    {
        public string SerializeObject(object myObject)
        {
            return JsonConvert.SerializeObject(
                myObject,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }
    }
}
