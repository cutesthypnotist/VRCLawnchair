using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaSpacedGrid;
using VRCLawnchair.ViewModels;

namespace VRCLawnchair.Views
{
    public partial class MainWindow : Window
    {
        private SpacedGrid spacedGrid;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif            
            spacedGrid = this.FindControl<SpacedGrid>("SpacedGrid");
            textBlock_Profile = this.FindControl<TextBlock>("textBlock_Profile");
            textBlock_FPS = this.FindControl<TextBlock>("textBlock_FPS");   
            DataContext = new MainWindowViewModel();
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        private void FPSSliderPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property.Name.Equals("Value", StringComparison.OrdinalIgnoreCase))
            {
                //var test = DataContext as MainWindowViewModel;
                //test.options.fps = (double)e.NewValue!;
                textBlock_FPS.Text = e.NewValue.ToString();
            }
        }

        private void ProfileSliderPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property.Name.Equals("Value", StringComparison.OrdinalIgnoreCase))
            {
                //spacedGrid.ColumnSpacing = (double)e.NewValue!;
                textBlock_Profile.Text = e.NewValue.ToString();
            }
        }        
    }
}