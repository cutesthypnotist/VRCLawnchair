using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Transactions;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using ReactiveUI;

namespace VRCLawnchair.ViewModels
{
    
    public record struct Options(bool noVR, int fps, bool legacyfbt, int profile, bool worlds, bool avatars, bool fullscreen, int width, int height, bool udon, bool sdklevels, bool debuggui);

    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand StartVRCCmd { get; }
        public Options options = new(false, 90, false, 0, false, false, true, 0, 0, false, false, false);

        public Options Options
        {
            get => options; 
            set => options = value;
        }
        public string Greeting { get; set; } = "Welcome";
        public MainWindowViewModel()
        {
            StartVRCCmd = ReactiveCommand.CreateFromTask(StartVRC);
            if (!File.Exists(".\\options.json"))
            {
                using StreamWriter file = File.CreateText(".\\options.json");
                file.WriteLine(JsonSerializer.Serialize(options, new JsonSerializerOptions() {WriteIndented = true}));
            }
            else
            {
                using FileStream file = File.OpenRead(".\\options.json");
                var option = Task<Options>.Run(async () => await JsonSerializer.DeserializeAsync<Options>(file));
                Options = option.Result;
            }

            Greeting = JsonSerializer.Serialize(options);
        }

        private async Task StartVRC()
        {
            //TODO: Actually process.start VRC.
            Process.GetCurrentProcess().Kill();
        }
    }
}
