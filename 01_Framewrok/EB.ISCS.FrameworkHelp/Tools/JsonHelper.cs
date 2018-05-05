using Newtonsoft.Json.Linq;

namespace EB.ISCS.FrameworkHelp.Tools
{
    public class JsonHelper
    {
        public static string SerializeObject(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeObject<T>(string str)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
        }
    }
}
