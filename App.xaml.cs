using Avalonia;
using Avalonia.Markup.Xaml;

namespace SimpleSettingsExample
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}