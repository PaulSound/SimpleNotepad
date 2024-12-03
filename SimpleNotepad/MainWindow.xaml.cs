using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.AccessControl;
using SimpleNotepad.Models;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Runtime.Serialization;
namespace SimpleNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [DataContract]
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        [JsonIgnore]
        private string directory = @"C:\Users\user\Desktop";
        [JsonIgnore]
        private string runningDirectory = string.Empty;
        [DataMember]
        private string _notePadText = string.Empty;
        public string Text
        {
            get => _notePadText; set
            {
                _notePadText = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            DataContext = this;
            SetDirectory();
            InitializeComponent();
        }

        private async void CreateFile(object sender, RoutedEventArgs e)
        {
            string rellevantName = await GetRellevantName("txt");
            FileInfo fileInfo=new FileInfo(rellevantName);
            using (var fs = File.Create(rellevantName, 1000, FileOptions.Asynchronous))
            {
                MessageBoxResult result = MessageBox.Show($"Файл {fs.Name} усешно создан! " +
                    $"Нажмите Yes что бы использовать, не сохраненные данные будут потеряны!", "SUCCESS!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes) { 
                    
                    runningDirectory = fileInfo.FullName;
                    Text = string.Empty;
                }
                else return;
            }
        }
  
        private async void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите файл";
            openFileDialog.Filter = "(*.txt)|*.txt";

                bool? isChosen= openFileDialog.ShowDialog(this);
            if ((bool)isChosen)
            {
                var stream = openFileDialog.OpenFile();
                runningDirectory = openFileDialog.FileName;

                using (StreamReader fs = new StreamReader(stream))
                {
                    Text = await fs.ReadToEndAsync();
                }
            }
            else return ;
        }

        private  void SaveFile(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(runningDirectory))
            {
                using (StreamWriter sw=new StreamWriter(runningDirectory))
                {
                    sw.WriteLine(Text);
                }
            }
            else
            {
                SaveFileDialog saveFileDialog=new SaveFileDialog();
                saveFileDialog.Title = "Выберите файл для сохранения или создайте новый!";
                saveFileDialog.Filter = "(*.txt)|*.txt";
                saveFileDialog.DefaultExt = "txt";
                bool? isPicked=  saveFileDialog.ShowDialog();
                if ((bool)isPicked) {
                    runningDirectory = saveFileDialog.FileName;
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(Text);
                        }
                    }
                    
                } else return;
            }
        }
        private async void JsonFileSave(object sender, RoutedEventArgs e)
        {
            string newName = await GetRellevantName("json");
            using (FileStream fs = new FileStream($"{directory}\\{newName}", FileMode.OpenOrCreate,FileAccess.ReadWrite))
            {
                await JsonSerializer.SerializeAsync<string>(fs,Text);
            }
            MessageBox.Show("Success!");
        }
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private async Task<string> GetRellevantName(string extension)
        {
            string[] files = Directory.GetFiles(directory, $"Новый текстовый документ*.{extension}");
            if(files.Length<1)
            {
                return $"Новый текстовый документ.{extension}";
            }
            Array.Reverse(files);
            Array.Sort(files, 0, files.Length - 1, new NumericStringComparer());
            int i = 1;
            for (; i < files.Length; i++) 
            {
                string dir = $"{directory}\\Новый текстовый документ ({i + 1}).{extension}";
                    if (files[i]!=dir)
                    {
                        return $"Новый текстовый документ ({i+1}).{extension}";
                    }
            }    
           await Task.Delay(0);
            return $"Новый текстовый документ ({++i}).{extension}";
        }
        private void SetDirectory()
        {
            if (!Directory.Exists(directory))
                directory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(directory);
        }
        private async void Reset_Click(object sender, RoutedEventArgs e)
        {
            runningDirectory=string.Empty;
            Text="Блокнот успешно обновлен, откройте существующий файл или содайте новый...";
            await Task.Delay(5000);
            Text = string.Empty;
        }
    }
}


/*  
 private async Task<string> GetRellevantName()
        {
            string[] files = Directory.GetFiles(directory, "Новый текстовый документ*.txt");
            if(files.Length<1)
            {
                await Task.Delay(0);
                return "Новый текстовый документ.txt";
            }
              
            Array.Sort(files, 0, files.Length - 1, new NumericStringComparer());
            Array.Reverse(files);
            int i = 1;
            for (; i < files.Length; i++) 
            {
                string dir = $"{directory}\\Новый текстовый документ ({i + 1}).txt";
                    if (files[i]!=dir)
                    {
                        return $"Новый текстовый документ ({i+1}).txt";
                    }
            }    
          
            return $"Новый текстовый документ ({++i}).txt";
        }
 */