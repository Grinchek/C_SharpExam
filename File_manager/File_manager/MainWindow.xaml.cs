using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SimpleFileManager
{
    public partial class MainWindow : Window
    {
        private string currentPath;

        public MainWindow()
        {
            InitializeComponent();
            currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            LoadTreeView(currentPath);
        }

        private void LoadTreeView(string path)
        {
            try
            {
                FolderTreeView.Items.Clear();

                TreeViewItem rootItem = CreateTreeItem(path);
                FolderTreeView.Items.Add(rootItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tree view: " + ex.Message);
            }
        }

        private TreeViewItem CreateTreeItem(string path)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = Path.GetFileName(path);
            item.Tag = path;
            item.Items.Add(null);

            item.Expanded += FolderTreeItem_Expanded;

            return item;
        }

        private void FolderTreeItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;

            if (item.Items.Count == 1 && item.Items[0] == null)
            {
                item.Items.Clear();

                string path = (string)item.Tag;
                string[] directories = Directory.GetDirectories(path);

                foreach (string directory in directories)
                {
                    TreeViewItem subItem = CreateTreeItem(directory);
                    item.Items.Add(subItem);
                }
            }
        }

        private void FolderTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem selectedItem = FolderTreeView.SelectedItem as TreeViewItem;

            if (selectedItem != null)
            {
                string selectedPath = selectedItem.Tag.ToString();
                LoadFiles(selectedPath);
                UpdateCurrentPath(selectedPath);
            }
        }

        private void LoadFiles(string path)
        {
            try
            {
                FileList.Items.Clear();

                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    FileList.Items.Add(Path.GetFileName(file));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading files: " + ex.Message);
            }
        }

        private void UpdateCurrentPath(string path)
        {
            currentPath = path;
            CurrentPathTextBlock.Text = $"Current Path: {currentPath}";
        }

        private void CreateFolderButton_Click(object sender, RoutedEventArgs e)
        {
            string newFolderName = PromtForNewItem();
            string newFolderPath = Path.Combine(currentPath, newFolderName);
            int count = 1;

            while (Directory.Exists(newFolderPath))
            {
                newFolderPath = Path.Combine(currentPath, $"{newFolderName} ({count++})");
            }

            Directory.CreateDirectory(newFolderPath);
            RefreshTreeView();
        }
        private void CreateFileButton_Click(object sender, RoutedEventArgs e)
        {
            string newFileName = PromtForNewItem();
            string newFilePath = Path.Combine(currentPath, newFileName);
            int count = 1;

            while (File.Exists(newFilePath))
            {
                newFilePath = Path.Combine(currentPath, $"{newFileName} ({count++})");
            }
            using (StreamWriter sw = File.CreateText(newFilePath)) ;
            RefreshTreeView();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            bool decision = PromtForDeleteItem();
            if (decision)
            {

                if (FileList.SelectedItem != null)
                {

                    string selectedFile = FileList.SelectedItem.ToString();
                    string filePath = Path.Combine(currentPath, selectedFile);

                    if (File.Exists(filePath))
                    {

                        File.Delete(filePath);
                        LoadFiles(currentPath);

                    }
                }


                else if (FolderTreeView.SelectedItem != null)
                {
                    TreeViewItem selectedItem = FolderTreeView.SelectedItem as TreeViewItem;
                    string selectedPath = selectedItem.Tag.ToString();

                    if (Directory.Exists(selectedPath))
                    {

                        Directory.Delete(selectedPath, true);
                        RefreshTreeView();


                    }
                }

            }
        }

        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            if (FileList.SelectedItem != null)
            {
                string selectedFile = FileList.SelectedItem.ToString();
                string filePath = Path.Combine(currentPath, selectedFile);

                if (File.Exists(filePath))
                {
                    string newFileName = PromptForNewName(Path.GetFileName(filePath));
                    if (!string.IsNullOrWhiteSpace(newFileName))
                    {
                        string newFilePath = Path.Combine(currentPath, newFileName);

                        File.Move(filePath, newFilePath);
                        LoadFiles(currentPath);
                    }
                }
            }
            else if (FolderTreeView.SelectedItem != null)
            {
                TreeViewItem selectedItem = FolderTreeView.SelectedItem as TreeViewItem;
                string selectedPath = selectedItem.Tag.ToString();

                if (Directory.Exists(selectedPath))
                {
                    string newFolderName = PromptForNewName(Path.GetFileName(selectedPath));
                    if (!string.IsNullOrWhiteSpace(newFolderName))
                    {
                        string newFolderPath = Path.Combine(Path.GetDirectoryName(selectedPath), newFolderName);

                        Directory.Move(selectedPath, newFolderPath);
                        RefreshTreeView();
                    }
                }
            }
        }

        private string PromptForNewName(string currentName)
        {
            InputDialog inputDialog = new InputDialog("Enter new name:", currentName);
            if (inputDialog.ShowDialog() == true)
            {
                return inputDialog.ResponseText;
            }
            return null;
        }
        private string PromtForNewItem()
        {
            InputDialog inputDialog = new InputDialog("Enter name:");
            if (inputDialog.ShowDialog() == true)
            {
                return inputDialog.ResponseText;
            }
            return null;
        }
        private bool PromtForDeleteItem()
        {
            Aproof aproofDialog = new Aproof("Are you shoure");
            if (aproofDialog.ShowDialog() == true)
            {
                return true;
            }
            return false;
        }

        private void RefreshTreeView()
        {
            TreeViewItem selectedItem = FolderTreeView.SelectedItem as TreeViewItem;
            if (selectedItem != null)
            {
                string parentPath = Path.GetDirectoryName((string)selectedItem.Tag);
                LoadTreeView(parentPath);
            }
            else
            {
                LoadTreeView(currentPath);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentPath) && Directory.GetParent(currentPath) != null)
            {
                string parentPath = Directory.GetParent(currentPath).FullName;
                LoadTreeView(parentPath);
                LoadFiles(parentPath);
                UpdateCurrentPath(parentPath);
            }
        }
    }
}