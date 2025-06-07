using System.ComponentModel.DataAnnotations;

namespace ToDoApp.API.Models
{
    public class AccountInfo
    {
        [Key]
        public int AccountId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 登录账号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Account { get; set; } = null!;

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Password { get; set; } = null!;
    }
}
