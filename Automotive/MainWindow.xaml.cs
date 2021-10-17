// Group2: Jingfei Yao, Grace Pauly, Xiaotong Han.
using System.Windows;

namespace Automotive
{
    public partial class MainWindow : Window
    {
        private readonly ViewModel vm = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            vm.Calc();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            vm.Clear();
        }
    }
}
