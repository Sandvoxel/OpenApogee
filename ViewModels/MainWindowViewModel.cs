using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using ReactiveUI;

namespace OpenMissile.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public MainWindowViewModel() {
            LaunchRocketCommand = ReactiveCommand.Create(() => {
                Trace.WriteLine("Launched Rocket");
            });
        }

        public ICommand LaunchRocketCommand { get; }
    }
    
}