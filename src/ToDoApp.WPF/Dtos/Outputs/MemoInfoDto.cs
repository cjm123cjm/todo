namespace ToDoApp.WPF.Dtos.Outputs
{
    /// <summary>
    /// 备忘录dto
    /// </summary>
    public class MemoInfoDto
    {
        /// <summary>
        /// id
        /// </summary>
        public int MemoId { get; set; }

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
    }
}
