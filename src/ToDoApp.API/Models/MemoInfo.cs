using System.ComponentModel.DataAnnotations;

namespace ToDoApp.API.Models
{
    /// <summary>
    /// 备忘录
    /// </summary>
    public class MemoInfo
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
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
