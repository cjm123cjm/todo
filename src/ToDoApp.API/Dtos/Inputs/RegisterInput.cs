namespace ToDoApp.API.Dtos.Inputs
{
    /// <summary>
    /// 注册输入参数
    /// </summary>
    public class RegisterInput
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; } = null!;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
