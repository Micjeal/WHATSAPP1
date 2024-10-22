using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WHATSAPP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Chat> Chats { get; set; }
        private ObservableCollection<Message> Messages { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            InitializeData();
        }
        private void InitializeData()
        {
            // Initialize sample data
            Chats = new ObservableCollection<Chat>
            {
                new Chat { Name = "John Doe", LastMessage = "Hey, how are you?", ProfilePicture = "Assets/profile1.png" },
                new Chat { Name = "Jane Smith", LastMessage = "Meeting at 3 PM", ProfilePicture = "Assets/profile2.png" }
            };

            Messages = new ObservableCollection<Message>();
            ChatListView.ItemsSource = Chats;
            MessagesListView.ItemsSource = Messages;
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void ChatListView_SelectionChangedd(object sender, SelectionChangedEventArgs e)
        {
            if (ChatListView.SelectedItem is Chat selectedChat)
            {
                CurrentChatName.Text = selectedChat.Name;
                //CurrentChatProfile.ProfilePicture = selectedChat.ProfilePicture;
                LoadMessages(selectedChat);
            }
        }

        private void LoadMessages(Chat chat)
        {
            Messages.Clear();
            // Load messages for selected chat (sample data)
            Messages.Add(new Message { Content = "Hello!", Time = "10:30 AM", IsReceived = true });
            Messages.Add(new Message { Content = "Hi there!", Time = "10:31 AM", IsReceived = false });
        }

        public class Chat
        {
            public string Name { get; set; }
            public string LastMessage { get; set; }
            public string ProfilePicture { get; set; }
        }
        public class Message
        {
            public string Content { get; set; }
            public string Time { get; set; }
            public bool IsReceived { get; set; }
            public int MessageAlignment => IsReceived ? 0 : 2;
            public string MessageColor => IsReceived ? "#FFFFFF" : "#DCF8C6";
        }
    }
}
