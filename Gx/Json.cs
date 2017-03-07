using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gx
{
    public class Json
    {
        /// <summary>
        /// 对象转成Json字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string ObjToStr(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// Json字符串转成对象
        /// </summary>
        /// <typeparam name="T">待转类型</typeparam>
        /// <param name="json">Json字符串</param>
        /// <returns></returns>
        public static T StrToObj<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
