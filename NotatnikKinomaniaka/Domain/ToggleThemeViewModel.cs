using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace NotatnikKinomaniaka.Domain
{
    public class ToggleThemeViewModel
    {
        public ICommand ToggleBaseCommand { get; } = new ExecuteCommands(o => ApplyBase((bool) o));

        private static void ApplyBase(bool isDark)
        {
            new PaletteHelper().SetLightDark(isDark);
        }
    }
}
