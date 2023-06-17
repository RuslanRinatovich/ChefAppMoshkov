using FermerGoodsApp.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FermerGoodsApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddGoodPage.xaml
    /// </summary>
    public partial class AddGoodPage : Page
    {
        //текущий товар
        private Good _currentGood = new Good();
        // путь к файлу
        private string _filePath = null;
        // название текущей главной фотографии
        private string _photoName = null;
        // текущая папка приложения
        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\Images\";

// передача в AddGoodPage товара
public AddGoodPage(Good selectedGood)
        {
            InitializeComponent();
            // если передано null, то мы добавляем новый товар
            if (selectedGood != null)
            {
                _currentGood = selectedGood;
                TextBoxGoodId.Visibility = Visibility.Hidden;
                TextBlockGoodId.Visibility = Visibility.Hidden;
                int x = selectedGood.Id;
                // загрузка комплементарных товаров
               
                _filePath = _currentDirectory + _currentGood.Photo;
            }
            DataContext = _currentGood;
            _photoName = _currentGood.Photo;
            //загрузка производителей
            ComboCategory.ItemsSource = ChefBDEntities.GetContext().Categories.ToList();
        }
        // проверка полей
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentGood.Name))
                s.AppendLine("Поле название пустое");
            if (_currentGood.Category == null)
                s.AppendLine("Выберите категорию");
            if (_currentGood.Price < 0)
                s.AppendLine("Цена не может быть отрицательной");
          
            if (!string.IsNullOrWhiteSpace(TextBoxWeight.Text))
            {
                double x = 0;
                if (!double.TryParse(TextBoxWeight.Text, out x))
                    s.AppendLine("Вес только число");
                else if (x < 0)

                {

                    s.AppendLine("Вес не может быть отрицательным");
                }
            }
            if
            (string.IsNullOrWhiteSpace(_photoName))
                s.AppendLine(  "фото не выбрано пустое     ");
        return s;
        }
        // сохранение
        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            // если ошибки есть, то выводим ошибки
// и прерываем выполнение
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return
                ;
            }
        
            // проверка полей прошла успешно
            if(_currentGood.Id == 0)
        {
                // добавление нового товара
                // формируем новое название файла картинки,
                // так как в папке может быть файл с тем же именем
                string photo = ChangePhotoName();
                // путь куда нужно скопировать файл
                string dest = _currentDirectory + photo;
                File.Copy(_filePath, dest);
                _currentGood.Photo = photo;
                // добавляем товар

        
ChefBDEntities.GetContext().Goods.Add(_currentGood);
            }

  
        
try
            {
                if (_filePath != null)
                {
                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentGood.Photo = photo;
                }
                // Сохраняем изменения в БД
                ChefBDEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись Изменена");
                // Возвращаемся на предыдущую форму
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
       
        // загрузка фото
private void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //Диалог открытия файла
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files(*.gif) | *.gif";
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

      
    }
}