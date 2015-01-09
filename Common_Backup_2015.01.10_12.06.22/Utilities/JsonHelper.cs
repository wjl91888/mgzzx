using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace RICH.Common.Utilities
{
    /// <summary>
    /// JSON帮助类。用于将对象转换为Json格式的字符串，或者将Json的字符串转化为对象。
    /// </summary>
    public static class JsonHelper
    {
        // 从一个对象信息生成Json串
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        // 从一个Json串生成对象信息
        public static object JsonToObject(string jsonString, object obj)
        {
            return JsonConvert.DeserializeObject(jsonString, obj.GetType());
        }
    }
}