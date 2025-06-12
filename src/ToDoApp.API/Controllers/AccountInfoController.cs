using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.ApiResponse;
using ToDoApp.API.Dtos.Inputs;
using ToDoApp.API.Services;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountInfoController : ControllerBase
    {
        private readonly IAccountInfoService _accountInfoService;

        public AccountInfoController(IAccountInfoService accountInfoService)
        {
            _accountInfoService = accountInfoService;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="registerInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseDto> AccountRegister(RegisterInput registerInput)
        {
            return await _accountInfoService.AccountRegisterAsync(registerInput);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseDto> AccountLogin(LoginInput loginInput)
        {
            return await _accountInfoService.AccountLoginAsync(loginInput);
        }
    }
}
