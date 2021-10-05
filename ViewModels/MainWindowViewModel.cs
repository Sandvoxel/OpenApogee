using System.Windows.Input;
using Avalonia.Logging;
using ReactiveUI;

namespace OpenApogee.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public MainWindowViewModel() {
            LaunchRocketCommand = ReactiveCommand.Create(() => {
                Logger.Sink.Log(LogEventLevel.Information,LogArea.Control,"0", "Rocket Launched");
            });
        }

        public ICommand LaunchRocketCommand { get; }
    }
    
}