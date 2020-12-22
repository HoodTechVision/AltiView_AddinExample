using System;
using System.AddIn;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using AddInViews;

namespace WPFAddIn1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AddInUserControl : UserControl
    {
        public AddInUserControl()
        {
            InitializeComponent();
        }

        private void clickMeButton_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Hello from WPFAddIn1");
        }
    }

    /// <summary>
    /// Add-In implementation
    /// </summary>
    [AddIn("WPF Test Add-In")]
    public class WPFAddIn : IWPFAddInView {
        public FrameworkElement GetAddInUI() {
            // Return add-in UI
            return new AddInUserControl();
        }
    }
}
