using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using OpenApogee.ViewModels;
using OpenApogee.Views;

namespace OpenApogee {
    public class App : Application {
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted() {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                desktop.MainWindow = new MainWindow {
                    DataContext = new MainWindowViewModel()
                };

            base.OnFrameworkInitializationCompleted();
        }
    }
}