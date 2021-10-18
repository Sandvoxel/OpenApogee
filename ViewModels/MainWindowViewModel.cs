using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia.Logging;
using Avalonia.Threading;
using JetBrains.Annotations;
using OpenApogee.Models.Physics;
using ReactiveUI;

namespace OpenApogee.ViewModels {
    public class MainWindowViewModel : INotifyPropertyChanged {
        private RocketObject _rocketObject = new(1, 15, 1);
        private readonly DispatcherTimer timer;
        private const int UpdateInterval = 1;
        public String time { get; set; }

        private void TimerTick(object sender, EventArgs e)
        {
            time = DateTime.Now.ToString();
            OnPropertyChanged("time");
        }
        public MainWindowViewModel() {
            LaunchRocketCommand = ReactiveCommand.Create(() => {
                Logger.Sink.Log(LogEventLevel.Information, LogArea.Control, "0", "Rocket Launched");
                _rocketObject.Simulate();
                Logger.Sink.Log(LogEventLevel.Information, LogArea.Control, "0", $"{_rocketObject.Apogee}");
                Logger.Sink.Log(LogEventLevel.Information, LogArea.Control, "0", $"{_rocketObject.VMax}");
            });
            
            timer = new DispatcherTimer{Interval = TimeSpan.FromSeconds(UpdateInterval)};
            timer.Tick += TimerTick;
            timer.Start();
        }

        public ICommand LaunchRocketCommand { get; }
        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}