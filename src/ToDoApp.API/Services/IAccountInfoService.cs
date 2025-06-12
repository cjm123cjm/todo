using ToDoApp.API.ApiResponse;
using ToDoApp.API.Dtos.Inputs;

namespace ToDoApp.API.Services
{
    public interface IAccountInfoService
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="registerInput"></param>
        /// <returns></returns>
        Task<ResponseDto> AccountRegisterAsync(RegisterInput registerInput);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        Task<ResponseDto> AccountLoginAsync(LoginInput loginInput);
    }
}
