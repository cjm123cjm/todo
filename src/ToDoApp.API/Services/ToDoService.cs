using Microsoft.EntityFrameworkCore;
using ToDoApp.API.ApiResponse;
using ToDoApp.API.Data;
using ToDoApp.API.Dtos.Outputs;

namespace ToDoApp.API.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoContext _context;
        private ResponseDto responseDto;

        public ToDoService(ToDoContext context)
        {
            _context = context;
            responseDto = new ResponseDto();
        }

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
    }
}
