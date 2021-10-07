using System;
using System.Globalization;
using System.Windows.Input;
using Avalonia.Logging;
using OpenApogee.Models.Physics;
using ReactiveUI;

namespace OpenApogee.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        private RocketObject _rocketObject = new(1, 15, 1);

        public MainWindowViewModel() {
            LaunchRocketCommand = ReactiveCommand.Create(() => {
                Logger.Sink.Log(LogEventLevel.Information, LogArea.Control, "0", "Rocket Launched");
                _rocketObject.Simulate();
                Logger.Sink.Log(LogEventLevel.Information, LogArea.Control, "0", $"{_rocketObject.Apogee}");
                Logger.Sink.Log(LogEventLevel.Information, LogArea.Control, "0", $"{_rocketObject.VMax}");
            });
        }

        public ICommand LaunchRocketCommand { get; }
    }
}