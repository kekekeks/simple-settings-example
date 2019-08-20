using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace SimpleSettingsExample
{
    public class MySettings : INotifyPropertyChanged
    {
        public static MySettings Instance {get;} = new MySettings();
        static string _settingsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YourCompany", "YourApp");
        static string _settingsPath = Path.Combine(_settingsDir, "config.json");
        private string _setting1 = "Default Setting 1";

        static MySettings()
        {
            Directory.CreateDirectory(_settingsDir);
            if(File.Exists(_settingsPath))
                Instance = JsonConvert.DeserializeObject<MySettings>(File.ReadAllText(_settingsPath));
        }
        public void Save() => File.WriteAllText(_settingsPath, JsonConvert.SerializeObject(this));


        public string Setting1
        {
            get => _setting1;
            set
            {
                if (value == _setting1) return;
                _setting1 = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}