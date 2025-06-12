using RestSharp;

namespace ToDoApp.WPF.HttpClients
{
    /// <summary>
    /// 请求模型
    /// </summary>
    public class ApiRequest
    {
        /// <summary>
        /// 请求地址/api
        /// </summary>
        public string Route { get; set; } = null!;

        /// <summary>
        /// 请求方式
        /// </summary>
        public Method Method { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public object Parameters { get; set; } = null!;

        /// <summary>
        /// 发送的数据类型
        /// </summary>
        public string ContentType { get; set; } = "application/json";
    }
}
