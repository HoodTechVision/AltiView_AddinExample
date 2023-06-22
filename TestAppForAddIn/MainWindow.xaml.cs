using NamedPipeWrapper;
using System;
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


namespace TestAppForAddIn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NamedPipeClient<byte[]> _client = new NamedPipeClient<byte[]>("altiview_pipe_addins");
        byte[] SERVER_TEST_RESPONSE = Encoding.ASCII.GetBytes("SERVER_TEST_RESPONSE");
        byte[] CLIENT_TEST_QUERY = Encoding.ASCII.GetBytes("CLIENT_TEST_QUERY");

        public MainWindow()
        {
            InitializeComponent();
            _client.ServerMessage += _client_ServerMessage;
            _client.Start();            
        }


        private void _client_ServerMessage(NamedPipeConnection<byte[], byte[]> connection, byte[] message)
        {
            if (message.SequenceEqual(SERVER_TEST_RESPONSE))
            {
                Dispatcher.Invoke(() =>
                {
                    lblResponse.Content = "Response Received: " + Encoding.ASCII.GetString(message);
                    lblLastReceived.Content = "Timestamp: " + DateTime.Now.ToString();
                });
            }
        }

        private void clickMeButton_Click(object sender, RoutedEventArgs e)
        {
            lblResponse.Content = "Waiting for response...";
            _client.PushMessage(CLIENT_TEST_QUERY);
        }
    }
}
