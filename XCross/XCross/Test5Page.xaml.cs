using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCross.Interfaces;

namespace XCross
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test5Page : ContentPage
    {
        public Test5Page()
        {
            InitializeComponent();
        }
        protected async void OnSentButtonClickedAsync(object sender, EventArgs args)
        {
            String sent = SentEditor.Text;
            if (null == sent || (sent = sent.Trim()).Length == 0)
            {
                return;
            }
            StringBuilder builder = new StringBuilder(AllMessagesEditor.Text);
            builder.AppendLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "  我:");
            builder.AppendLine(sent);
            builder.AppendLine();
            SentEditor.Text = String.Empty;
            AllMessagesEditor.Text = builder.ToString();
            String received = await GetResponce(sent);
            builder.AppendLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "  灵儿:");
            builder.AppendLine(received);
            builder.AppendLine();
            AllMessagesEditor.Text = builder.ToString();
        }
        static readonly Encoding encoding = Encoding.UTF8;
        static readonly Int32 port = 10010;
        static readonly String server = "120.79.182.165";
        public async Task<String> GetResponce(String request)
        {
            try
            {
                TcpClient client = new TcpClient(server, port);
                Byte[] data = encoding.GetBytes(request);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                data = new Byte[256];
                String responseData = String.Empty;
                Int32 bytes = await stream.ReadAsync(data, 0, data.Length);
                responseData = encoding.GetString(data, 0, bytes);
                return responseData;
            }
            catch (ArgumentNullException e)
            {
                return $"ArgumentNullException: {e}";
            }
            catch (SocketException e)
            {
                return $"SocketException: {e}";
            }
        }
    }
}