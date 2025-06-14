using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.WPF.Dtos.Outputs;

namespace ToDoApp.WPF.ViewModels
{
    public class ToDoControlViewModel : BindableBase
    {
        public ToDoControlViewModel() 
        {
            SearchToDo();

            ShowToDoCommand=new DelegateCommand(ShowToDo);
        }

        #region 待办事项
        private List<ToDoDto> toDoDto;

        public List<ToDoDto> ToDoDto
        {
            get { return toDoDto; }
            set { toDoDto = value; RaisePropertyChanged(); }
        }

        private void SearchToDo()
        {
            ToDoDto = new List<ToDoDto>();
            ToDoDto.Add(new ToDoDto { ToDoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            ToDoDto.Add(new ToDoDto { ToDoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            ToDoDto.Add(new ToDoDto { ToDoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
            ToDoDto.Add(new ToDoDto { ToDoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            ToDoDto.Add(new ToDoDto { ToDoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            ToDoDto.Add(new ToDoDto { ToDoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
        }

        #endregion

        #region 显示添加待办
        private bool isShowToDo;

        public bool IsShowToDo
        {
            get { return isShowToDo; }
            set { isShowToDo = value; RaisePropertyChanged(); }
        }
        public DelegateCommand ShowToDoCommand { get; set; }
        private void ShowToDo()
        {
            IsShowToDo = true;
        }

        #endregion
    }
}
