
using System;
using System.AddIn;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using AddInViews;
using NamedPipeWrapper;

namespace WPFAddIn1
{        
    public partial class AddInUserControl : UserControl
    {
        NamedPipeClient<byte[]> _client = new NamedPipeClient<byte[]>("altiview_pipe_addins");
        byte[] SERVER_TEST_RESPONSE = Encoding.ASCII.GetBytes("SERVER_TEST_RESPONSE");
        byte[] CLIENT_TEST_QUERY = Encoding.ASCII.GetBytes("CLIENT_TEST_QUERY");

        public AddInUserControl()
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

        private void clickMeButton_Click(object sender, RoutedEventArgs e) {
            lblResponse.Content = "Waiting for response...";
            _client.PushMessage(CLIENT_TEST_QUERY);
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

        public bool Shutdown()
        {
            Dispatcher.CurrentDispatcher.InvokeShutdown();
            return true;
        }
    }
}
