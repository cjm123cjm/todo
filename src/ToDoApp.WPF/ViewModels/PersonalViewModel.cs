using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace ToDoApp.WPF.ViewModels
{
    public class PersonalViewModel : BindableBase
    {
        public PersonalViewModel()
        {
            ChangeHueCommand = new DelegateCommand<object?>(ChangeHue);
        }
        #region 修改主题背景颜色

        private bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                if (SetProperty(ref _isDarkTheme, value))
                {
                    ModifyTheme(theme => theme.SetBaseTheme(value ? BaseTheme.Dark : BaseTheme.Light));
                }
            }
        }
        private static void ModifyTheme(Action<Theme> modificationAction)
        {
            var paletteHelper = new PaletteHelper();
            Theme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
        }

        #endregion

        private readonly PaletteHelper themeHelper = new PaletteHelper();
        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;
        public DelegateCommand<object?> ChangeHueCommand { get; }
        private void ChangeHue(object? obj)
        {
            var color = (Color)obj!;

            Theme them = themeHelper.GetTheme();

            them.PrimaryLight = new ColorPair(color.Lighten());
            them.PrimaryMid = new ColorPair(color);
            them.PrimaryDark = new ColorPair(color.Darken());

            themeHelper.SetTheme(them);
        }
    }
}
