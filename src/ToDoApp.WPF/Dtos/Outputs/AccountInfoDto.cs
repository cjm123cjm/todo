namespace ToDoApp.WPF.Dtos.Outputs
{
    /// <summary>
    /// 用户信息Dto
    /// </summary>
    public class AccountInfoDto
    {
        public int AccountId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 登录账号
        /// </summary>
        public string Account { get; set; } = null!;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
