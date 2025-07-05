namespace ToDoApp.API.Dtos.Inputs
{
    /// <summary>
    /// 待办事项输出参数
    /// </summary>
    public class ToDoDto
    {
        /// <summary>
        /// id
        /// </summary>
        public int ToDoId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; } = null!;

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int AccountId { get; set; }
    }
}
