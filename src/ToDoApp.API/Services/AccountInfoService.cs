using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoApp.API.ApiResponse;
using ToDoApp.API.Data;
using ToDoApp.API.Dtos.Inputs;
using ToDoApp.API.Dtos.Outputs;
using ToDoApp.API.Models;

namespace ToDoApp.API.Services
{
    public class AccountInfoService : IAccountInfoService
    {
        private readonly ToDoContext _context;
        private readonly IMapper _mapper;
        private ResponseDto response;

        public AccountInfoService(ToDoContext context, IMapper mapper)
        {
            _context = context;
            response = new ResponseDto();
            _mapper = mapper;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        public async Task<ResponseDto> AccountLoginAsync(LoginInput loginInput)
        {
            var account = await _context.AccountInfos.FirstOrDefaultAsync(t => t.Account == loginInput.Account && t.Password == loginInput.Password);
            if (account == null)
            {
                response.IsSuccess = false;
                response.Message = "账号或密码错误";
                return response;
            }

            response.Result = _mapper.Map<AccountInfoDto>(account);

            return response;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="registerInput"></param>
        /// <returns></returns>
        public async Task<ResponseDto> AccountRegisterAsync(RegisterInput registerInput)
        {
            bool any = await _context.AccountInfos.AnyAsync(t => t.Account == registerInput.Account);
            if (any)
            {
                response.IsSuccess = false;
                response.Message = "账号已存在";
                return response;
            }

            var account = _mapper.Map<AccountInfo>(registerInput);

            _context.AccountInfos.Add(account);

            await _context.SaveChangesAsync();

            return response;
        }
    }
}
