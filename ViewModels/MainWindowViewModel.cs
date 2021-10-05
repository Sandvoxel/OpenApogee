using System.Windows.Input;
using Avalonia.Logging;
using OpenApogee.Models.Physics;
using ReactiveUI;

namespace OpenApogee.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public MainWindowViewModel() {
            LaunchRocketCommand = ReactiveCommand.Create(() => {
                Logger.Sink.Log(LogEventLevel.Information,LogArea.Control,"0", "Rocket Launched");
                SimplePhysicsSim sim = new SimplePhysicsSim(new Vector3(0, 5, 0));
                sim.Update();
                Logger.Sink.Log(LogEventLevel.Information,LogArea.Control,"0", sim.Velocity.ToString());



            });
        }

        public ICommand LaunchRocketCommand { get; }
    }
    
}