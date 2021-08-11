using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PiePie_Workstation.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow
    {
        public MainWindow() => InitializeComponent();

        App app = (App)Application.Current;

        private void StatusBar_Loaded(object sender, RoutedEventArgs e)
        {
            cpuInformation.Text = App.Cpus[App.CPUIndex];
            gpuInformation.Text = App.Gpus[App.GPUIndex];
        }

        private void FontSelectorInit(object sender, RoutedEventArgs e)
        {
            ((ComboBox)sender).SelectedItem = new FontFamily("Centaur");
        }

        private void EntryMainInterface(object sender, RoutedEventArgs e) => startScreen.IsOpen = false;

        private void ShowAccountInterface(object sender, RoutedEventArgs e) => accountInterface.IsOpen = true;

        private void SwitchToDemoPageA(object sender, RoutedEventArgs e) => mainFrame.Content = app.demoPageA;
        private void SwitchToDemoPageB(object sender, RoutedEventArgs e) => mainFrame.Content = app.demoPageB;
        private void SwitchToDemoPageC(object sender, RoutedEventArgs e) => mainFrame.Content = app.demoPageC;

        private void BaseColorChange(object sender, SelectionChangedEventArgs e)
        {
            if (baseColorSelector != null && colorSchemeSelector != null)
            {
                app.ChangeBaseColor(
                    baseColor: ((System.Xml.XmlAttribute)baseColorSelector.SelectedItem).Value,
                    colorScheme: ((System.Xml.XmlAttribute)colorSchemeSelector.SelectedItem).Value
                );
            }
        }
        private void ColorSchemeChange(object sender, SelectionChangedEventArgs e)
        {
            if (baseColorSelector != null && colorSchemeSelector != null)
            {
                app.ChangeColorScheme(
                    baseColor: ((System.Xml.XmlAttribute)baseColorSelector.SelectedItem).Value,
                    colorScheme: ((System.Xml.XmlAttribute)colorSchemeSelector.SelectedItem).Value
                );
            }
        }
        private void ChangeFont(object sender, SelectionChangedEventArgs e)
        {
            FontFamily fontFamily = (sender as ComboBox).SelectedItem as FontFamily;
            app.ChangeFontFamily(fontFamily);
        }
    }
}
