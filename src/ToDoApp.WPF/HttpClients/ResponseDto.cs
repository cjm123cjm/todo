namespace ToDoApp.WPF.HttpClients
{
    /// <summary>
    /// 统一返回结构
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
