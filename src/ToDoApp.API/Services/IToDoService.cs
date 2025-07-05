using ToDoApp.API.ApiResponse;
using ToDoApp.API.Dtos.Inputs;
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

        /// <summary>
        /// 添加/修改 待办事项
        /// </summary>
        /// <param name="toDoDto"></param>
        /// <returns></returns>
        Task<ResponseDto> AddOrUpdateToDoAsync(ToDoDto toDoDto);

        /// <summary>
        /// 获取待办事项
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<ResponseDto> GetToDosAsync(int accountId);
    }
}
