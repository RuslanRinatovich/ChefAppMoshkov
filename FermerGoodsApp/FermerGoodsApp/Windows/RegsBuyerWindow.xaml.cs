using FermerGoodsApp.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace FermerGoodsApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegsBuyerWindow.xaml
    /// </summary>
    public partial class RegsBuyerWindow : Window
    {
        private Client _currentItem = new Client();
        // путь к файлу
        private string _filePath = null;
        // название текущей главной фотографии
        private string _photoName = null;
        // текущая папка приложения
        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\Images\";
        bool badName = false;

        public RegsBuyerWindow()
        {
            InitializeComponent();
            _currentItem = new Client();
            DataContext = _currentItem;

        }
        // загрузка фото 
        private void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //Диалог открытия файла
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                // диалог вернет true, если файл был открыт
                if (op.ShowDialog() == true)
                {
                    // проверка размера файла
                    // по условию файл дожен быть не более 2Мб.
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > (1024 * 1024 * 2))
                    {
                        // размер файла меньше 2Мб. Поэтому выбрасывается новое исключение
                        throw new Exception("Размер файла должен быть меньше 2Мб");
                    }
                    ImagePhoto.Source = new BitmapImage(new Uri(op.FileName));
                    _photoName = op.SafeFileName;
                    _filePath = op.FileName;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _filePath = null;
            }
        }
        //подбор имени файла
        string ChangePhotoName()
        {
            string x = _currentDirectory + _photoName;
            string photoname = _photoName;
            int i = 0;
            if (File.Exists(x))
            {
                while (File.Exists(x))
                {
                    i++;
                    x = _currentDirectory + i.ToString() + photoname;
                }
                photoname = i.ToString() + photoname;
            }
            return photoname;

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            // если ошибки есть, то выводим ошибки в MessageBox
            // и прерываем выполнение 
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }

            try
            {
                // формируем новое название файла картинки,
                // так как в папке может быть файл с тем же именем
                string photo = ChangePhotoName();
                // путь куда нужно скопировать файл
                string dest = _currentDirectory + photo;
                File.Copy(_filePath, dest);
                _currentItem.Photo = photo;
                _currentItem.Password = PasswordBoxNewPassword1.Password;
                ChefBDEntities.GetContext().Clients.Add(_currentItem);
                ChefBDEntities.GetContext().SaveChanges();
                MessageBox.Show("Регистрация прошла успешно");
                // Возвращаемся на предыдущую форму
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }


        }
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            if (badName)
                s.AppendLine("Задайте другое имя пользователя");
            if (string.IsNullOrWhiteSpace(_currentItem.UserName))
                s.AppendLine("Задайте имя пользователя");
            if (string.IsNullOrWhiteSpace(_currentItem.FirstName))
                s.AppendLine("Поле имя пустое");
            if (string.IsNullOrWhiteSpace(_currentItem.LastName))
                s.AppendLine("Поле фамилия пустое");
            if (string.IsNullOrWhiteSpace(_currentItem.Phone))
                s.AppendLine("Поле телефон пустое");
            if (string.IsNullOrWhiteSpace(_currentItem.Email))
                s.AppendLine("Поле email пустое");
            if (string.IsNullOrWhiteSpace(_photoName))
                s.AppendLine("фото не выбрано пустое");

            if (string.IsNullOrWhiteSpace(PasswordBoxNewPassword1.Password))
                s.AppendLine("Введите пароль");
            if (PasswordBoxNewPassword1.Password != PasswordBoxNewPassword2.Password)
                s.AppendLine("Пароли не совпадают");

         
            List<Client> clients = ChefBDEntities.GetContext().Clients.ToList();
            //попытка найти пользователя с указанным паролем и логином
            //если такого пользователя не будет обнаружено то переменная u будет равна null
            Client c = clients.FirstOrDefault(p => p.UserName == TbUserName.Text);
            if (c != null)
            {
                s.AppendLine("Данный логин занят, выберите другой логин");
            }
            return s;
        }

        private void TbUserName_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TbUserName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex(@"[^a-zA-Z\s]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TbUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string username = TbUserName.Text.ToLower();
            Client Client = ChefBDEntities.GetContext().Clients.Where(p => p.UserName.ToLower() == username).FirstOrDefault();
            if (Client == _currentItem)
                return;
            if (Client != null)
            {
                TbUserName.Foreground = new SolidColorBrush(Colors.Red);
                badName = true;
            }
            else
            {
                TbUserName.Foreground = new SolidColorBrush(Colors.Green);
                badName = false;
            }
        }
    }
}
