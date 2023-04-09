using Prism;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prismo.Presentation.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prismo.ViewModels
{
    public enum ShellViewSwitchModes
    {
        Login,
        Home,
        Secondary
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// This is not an Active awared component.
    /// </remarks>
    public class ShellViewModel : BindableBase
    {
        private readonly object _home;
        private readonly object _content;

        public ShellViewModel(IContainerProvider container, IEventAggregator eventAggregator)
        {
            _home = container.Resolve<Views.HomeView>();
            _content = container.Resolve<Views.ContentView>();

            CurrentView = _home;

            OpenModuleCommand = new DelegateCommand(OpenModule);

            eventAggregator.GetEvent<SwitchToDashboardEvent>().Subscribe(moduleName => CurrentView = _home);
        }

        public event EventHandler ShellContentChanged;

        public ICommand OpenModuleCommand { get; private set; }

        private void OpenModule()
        {
            CurrentView = _content;
        }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                if (!value.Equals(_currentView))
                {
                    SetProperty(ref _currentView, value);
                    ShellContentChanged?.Invoke(this, new EventArgs());
                }
            }
        }

    }
}
