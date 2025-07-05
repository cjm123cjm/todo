using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.ApiResponse;
using ToDoApp.API.Dtos.Inputs;
using ToDoApp.API.Services;

namespace ToDoApp.API.Controllers
{
    /// <summary>
    /// 待办事项
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService service)
        {
            _service = service;
        }

        /// <summary>
        /// 统计待办事项
        /// </summary>
        /// <returns></returns>
        [HttpGet("{accountId}")]
        public async Task<ResponseDto> ToDoSummany(int accountId)
        {
            return await _service.ToDoSummanyAsync(accountId);
        }

        /// <summary>
        /// 添加/修改 待办事项
        /// </summary>
        /// <param name="toDoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseDto> AddOrUpdateToDo([FromBody] ToDoDto toDoDto)
        {
            return await _service.AddOrUpdateToDoAsync(toDoDto);
        }

        /// <summary>
        /// 获取待办事项
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("{accountId}")]
        public async Task<ResponseDto> GetToDos(int accountId)
        {
            return await _service.GetToDosAsync(accountId);
        }
    }
}
