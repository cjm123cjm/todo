using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoApp.API.ApiResponse;
using ToDoApp.API.Data;
using ToDoApp.API.Dtos.Inputs;
using ToDoApp.API.Dtos.Outputs;
using ToDoApp.API.Models;

namespace ToDoApp.API.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoContext _context;
        private ResponseDto responseDto;
        private readonly IMapper _mapper;

        public ToDoService(ToDoContext context, IMapper mapper)
        {
            _context = context;
            responseDto = new ResponseDto();
            _mapper = mapper;
        }

        /// <summary>
        /// 添加/修改 待办事项
        /// </summary>
        /// <param name="toDoDto"></param>
        /// <returns></returns>
        public async Task<ResponseDto> AddOrUpdateToDoAsync(ToDoDto toDoDto)
        {
            if (toDoDto.ToDoId == 0)
            {
                var todo = _mapper.Map<ToDoInfo>(toDoDto);

                await _context.ToDoInfos.AddAsync(todo);

                await _context.SaveChangesAsync();

                return responseDto;
            }
            else
            {
                var model = await _context.ToDoInfos.FirstOrDefaultAsync(t => t.ToDoId == toDoDto.ToDoId);
                if (model == null)
                {
                    responseDto.IsSuccess = false;
                    responseDto.Message = "数据不存在";
                    return responseDto;
                }

                _mapper.Map(toDoDto, model);

                await _context.SaveChangesAsync();

                return responseDto;
            }
        }

        /// <summary>
        /// 统计待办事项
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto> ToDoSummanyAsync(int accountId)
        {
            var todos = await _context.ToDoInfos.AsNoTracking().Where(t => t.AccountId == accountId).ToListAsync();

            var finish = todos.Where(t => t.Status == 1).Count();

            ToDoStatisticDto statisticDto = new ToDoStatisticDto
            {
                TotalCount = todos.Count,
                FinishCount = finish
            };

            responseDto.Result = statisticDto;

            return responseDto;
        }

        /// <summary>
        /// 获取待办事项
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<ResponseDto> GetToDosAsync(int accountId)
        {
            var todos = await _context.ToDoInfos.AsNoTracking().Where(t => t.AccountId == accountId && t.Status == 0).ToListAsync();

            responseDto.Result = _mapper.Map<List<ToDoDto>>(todos);

            return responseDto;
        }
    }
}
