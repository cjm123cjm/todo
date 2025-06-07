using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.API.ApiResponse
{
    /// <summary>
    /// 同意返回值
    /// </summary>
    public class ResponseDto
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// 返回消息
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object? Result { get; set; }
    }
}
