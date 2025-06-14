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
    public class MemoControlViewModel : BindableBase
    {
        public MemoControlViewModel()
        {
            SearchToDo();

            ShowMemoCommand = new DelegateCommand(ShowMemo);
        }

        #region 备忘录
        private List<MemoInfoDto> memoInfoDto;

        public List<MemoInfoDto> MemoInfoDto
        {
            get { return memoInfoDto; }
            set { memoInfoDto = value; RaisePropertyChanged(); }
        }

        private void SearchToDo()
        {
            MemoInfoDto = new List<MemoInfoDto>();
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 1, Title = "学习微服务", Content = "网上学习微服务精度", Status = 0 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 2, Title = "学习WPF", Content = "网上学习微服务精度", Status = 1 });
            MemoInfoDto.Add(new MemoInfoDto { MemoId = 3, Title = "完成EasyWeChat", Content = "完成EasyWeChat，目前进度是ws连接成功", Status = 0 });
        }

        #endregion

        #region 显示备忘录
        private bool isShowMemo;

        public bool IsShowMemo
        {
            get { return isShowMemo; }
            set { isShowMemo = value; RaisePropertyChanged(); }
        }
        public DelegateCommand ShowMemoCommand { get; set; }
        private void ShowMemo()
        {
            IsShowMemo = true;
        }

        #endregion
    }
}
