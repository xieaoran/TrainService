using System.Windows;
using TrainService.LocalData;

namespace TrainService
{
    /// <summary>
    ///     App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Runtime.Load();
        }
    }
}