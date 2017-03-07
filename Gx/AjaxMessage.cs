using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gx
{
    /// <summary>
    /// AJAX返回处理后的数据
    /// </summary>
    public class AjaxMessage
    {
        /// <summary>
        /// 结果
        /// </summary>
        public bool result;
        /// <summary>
        /// 返回消息
        /// </summary>
        public object message;
        public override string ToString()
        {
            return Gx.Json.ObjToStr(this);
        }
    }
}
