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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FermerGoodsApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        private string _filePath = null;
        // название текущей главной фотографии
        private string _photoName = null;
        // текущая папка приложения
        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\Images\";
        public Client currentItem { get; private set; }

        bool badName = false;
        public EditClientPage(Client p)
        {
            InitializeComponent();
            if (p == null)
            {
                p = new Client();
                TbUserName.IsEnabled = true;
                TbUserName.IsReadOnly = false;
            }
            currentItem = p;
           

            this.DataContext = currentItem;
        }
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            if (badName)
                s.AppendLine("Задайте другое имя пользователя");
            if (string.IsNullOrWhiteSpace(currentItem.UserName))
                s.AppendLine("Задайте имя пользователя");
            if (string.IsNullOrWhiteSpace(currentItem.FirstName))
                s.AppendLine("Поле имя пустое");
          
            if (string.IsNullOrWhiteSpace(currentItem.LastName))
                s.AppendLine("Поле фамилия пустое");
            if (string.IsNullOrWhiteSpace(currentItem.Phone))
                s.AppendLine("Поле телефон пустое");
            if (string.IsNullOrWhiteSpace(currentItem.Email))
                s.AppendLine("Поле email пустое");
            if (string.IsNullOrWhiteSpace(currentItem.Photo))
                s.AppendLine("фото не выбрано пустое");


            if (CheckBoxChangePassword.IsChecked == true)
            {
                Client client = ChefBDEntities.GetContext().Clients.Find(currentItem.UserName);
                if ((PasswordBoxNewPassword1.Password != PasswordBoxNewPassword2.Password) && (PasswordBoxOldPassword.Password == client.Password))
                {
                    s.AppendLine("Пароли не совпадают");
                }
                else
                {
                    currentItem.Password = PasswordBoxNewPassword1.Password;
                }
            }
            return s;
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

            if (_photoName != null)
            {


                // формируем новое название файла картинки,
                // так как в папке может быть файл с тем же именем
                string photo = ChangePhotoName();
                // путь куда нужно скопировать файл
                string dest = _currentDirectory + photo;
                File.Copy(_filePath, dest);
                currentItem.Photo = photo;


            }
            try
            {
                ChefBDEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись изменена");
                Manager.MainFrame.GoBack();
            }
            catch
            {
            }


        }

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

        private void TbUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string username = TbUserName.Text.ToLower();
            Client Client = ChefBDEntities.GetContext().Clients.Where(p => p.UserName.ToLower() == username).FirstOrDefault();
            if (Client == currentItem)
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

        private void TbUserName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^a-zA-Z\s]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
