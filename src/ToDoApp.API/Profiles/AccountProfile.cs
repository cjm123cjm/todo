using AutoMapper;
using ToDoApp.API.Dtos.Inputs;
using ToDoApp.API.Dtos.Outputs;
using ToDoApp.API.Models;

namespace ToDoApp.API.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<RegisterInput, AccountInfo>().ReverseMap();

            CreateMap<AccountInfo, AccountInfoDto>().ReverseMap();
        }
    }
}
