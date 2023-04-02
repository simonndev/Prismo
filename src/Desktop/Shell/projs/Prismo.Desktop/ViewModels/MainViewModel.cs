using Prism;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prismo.ViewModels
{
    public enum ShellViewSwitchModes
    {
        Login,
        Dashboard,
        Content
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// This is not an Active awared component.
    /// </remarks>
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
        }

        private ShellViewSwitchModes _currentView;
        public ShellViewSwitchModes CurrentView
        {
            get { return _currentView; }
            set
            {
                if (value != _currentView)
                {
                    SetProperty(ref _currentView, value);
                }
            }
        }
    }
}
