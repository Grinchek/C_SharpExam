using System.Windows;

namespace SimpleFileManager
{
    public partial class InputDialog : Window
    {
        public string Message { get; set; }
        public string ResponseText { get; set; }

        public InputDialog(string message, string defaultResponse = "")
        {
            InitializeComponent();
            DataContext = this;

            Message = message;
            ResponseText = defaultResponse;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}