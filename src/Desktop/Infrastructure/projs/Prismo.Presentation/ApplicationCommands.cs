using Prism.Commands;

namespace Prismo.Presentation
{
    public static class ApplicationCommands
    {
        public static CompositeCommand ShowFlyoutCommand = new CompositeCommand();
        public static CompositeCommand NavigateHomeCommand = new CompositeCommand();
    }

    public interface IApplicationCommands
    {
        CompositeCommand ShowFlyoutCommand { get; }
        CompositeCommand NavigateHomeCommand { get; }
    }

    public class ApplicationCommandsProxy : IApplicationCommands
    {
        public CompositeCommand ShowFlyoutCommand
        {
            get { return ApplicationCommands.ShowFlyoutCommand; }
        }

        public CompositeCommand NavigateHomeCommand
        {
            get { return ApplicationCommands.NavigateHomeCommand; }
        }
    }
}
