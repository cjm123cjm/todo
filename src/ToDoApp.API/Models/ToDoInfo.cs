using System.ComponentModel.DataAnnotations;

namespace ToDoApp.API.Models
{
    /// <summary>
    /// 待办事项
    /// </summary>
    public class ToDoInfo
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int ToDoId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// 名称
        /// </summary>
        public string Content { get; set; } = null!;

        /// <summary>
        /// 状态 0-待办 1-已完成
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 用户id
        /// </summary>
        public int AccountId { get; set; }
    }
}
