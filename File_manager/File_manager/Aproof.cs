using System.Windows;

namespace SimpleFileManager
{
    public partial class Aproof:Window
    {
        public string Message { get; set; }
        public string ResponseText { get; set; }

        public Aproof(string message, string defaultResponse = "")
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
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
