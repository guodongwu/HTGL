using Newtonsoft.Json;
using System.Collections.Generic;

namespace HTGL.Common
{
    public class JsonHelper
    {
        /// <summary>
        /// 将对象序列化为Json格式
        /// </summary>
        public static string Serialize(object item)
        {
            return JsonConvert.SerializeObject(item);
        }

        /// <summary>
        /// 解析Json反序列化为对象实体
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        public static T Deserialize<T>(string json) where T:class
        {
            return json != null ? JsonConvert.DeserializeObject<T>(json) : default(T);
        }

        /// <summary>
        /// 解析Json集合反序列化为对象实体集合
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        public static List<T> DeserializeToList<T>(string json) where T:class
        {
            return json != null ? JsonConvert.DeserializeObject<List<T>>(json) : null;
        }
    }
}
