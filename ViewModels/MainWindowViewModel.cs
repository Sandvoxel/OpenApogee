using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Avalonia.Logging;
using ReactiveUI;

namespace OpenMissile.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public MainWindowViewModel() {
            LaunchRocketCommand = ReactiveCommand.Create(() => {
                Logger.Sink.Log(LogEventLevel.Information,LogArea.Control,"0", "Rocket Launched");
            });
        }

        public ICommand LaunchRocketCommand { get; }
    }
    
}