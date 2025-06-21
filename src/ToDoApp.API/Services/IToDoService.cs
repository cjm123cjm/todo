using ToDoApp.API.ApiResponse;
using ToDoApp.API.Dtos.Outputs;

namespace ToDoApp.API.Services
{
    public interface IToDoService
    {
        /// <summary>
        /// 统计待办事项
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto> ToDoSummanyAsync(int accountId);
    }
}
