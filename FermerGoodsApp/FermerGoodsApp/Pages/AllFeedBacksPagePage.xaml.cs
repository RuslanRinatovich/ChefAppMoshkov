using FermerGoodsApp.Models;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AllFeedBacksPagePage.xaml
    /// </summary>
    public partial class AllFeedBacksPagePage : Page
    {
        int _itemcount = 0;
        public AllFeedBacksPagePage()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {

            DialogHostMoreInformation.IsOpen = false;
        }

        private void DataGridCarLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //событие отображения данного Page
            // обновляем данные каждый раз когда активируется этот Page
            if (Visibility == Visibility.Visible)
            {
                LoadData();
                LoadCategories();
            }
        }
        void LoadCategories()
        {
            var categories = ChefBDEntities.GetContext().Categories.OrderBy(p => p.Title).ToList();
            categories.Insert(0, new Category
            {
                Title = "Все категории"
            }
            );
            ComboCategory.ItemsSource = categories;
            ComboCategory.SelectedIndex = 0;


        }

        // загрузка данных в DataGrid и ComboBox
        void LoadData()
        {
            try
            {
                DtData.ItemsSource = null;
                //загрузка обновленных данных
                ChefBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DtData.ItemsSource = ChefBDEntities.GetContext().GoodFeedBacks.OrderBy(p => p.Date).ThenBy(p => p.Rate).ToList();
                _itemcount = DtData.Items.Count;
                TextBlockCount.Text = $" Результат запроса: {DtData.Items.Count} записей из {_itemcount}";
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }


        }
        // фильтрация продаж по товару
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }


        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  если ни одного объекта не выделено, выходим
                if (DtData.SelectedItem == null) return;
                // получаем выделенный объект
                GoodFeedBack selected = DtData.SelectedItem as GoodFeedBack;

                DialogHostMoreInformation.DataContext = selected;
                DialogHostMoreInformation.IsOpen = true;
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void TBoxSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
        // Поиск товаров конкретного производителя
        private void ComboTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        /// <summary>
        /// Метод для фильтрации и сортировки данных
        /// </summary>
        private void UpdateData()
        {
            DtData.ItemsSource = null;
            // получаем текущие данные из бд
            List<GoodFeedBack> currentData;

            currentData = ChefBDEntities.GetContext().GoodFeedBacks.OrderBy(p => p.Date).ThenBy(p => p.Rate).ToList();
            // выбор только тех товаров, которые принадлежат данному производителю
            if (ComboCategory.SelectedIndex > 0)
                currentData = currentData.Where(p => p.Good.CategoryId == (ComboCategory.SelectedItem as Category).Id).ToList();

            // сортировка
            if (ComboSort.SelectedIndex >= 0)
            {
                // сортировка по возрастанию цены
                if (ComboSort.SelectedIndex == 0)
                    currentData = currentData.OrderBy(p => p.Date).ToList();
                // сортировка по убыванию цены
                if (ComboSort.SelectedIndex == 1)
                    currentData = currentData.OrderByDescending(p => p.Date).ToList();
            }


            // выбор тех товаров, в названии которых есть поисковая строка
            currentData = currentData.Where(p => p.Good.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();


            // В качестве источника данных присваиваем список данных
            DtData.ItemsSource = currentData;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {currentData.Count} записей из {_itemcount}";
        }
        // сортировка товаров 
        private void ComboSortSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtnDeleteClick(object sender, RoutedEventArgs e)
        {
            // удаление выбранного товара из таблицы
            //получаем все выделенные товары
            GoodFeedBack selected = (sender as Button).DataContext as GoodFeedBack;
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {

                    // проверка, есть ли у товара в таблице о продажах связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается


                    ChefBDEntities.GetContext().GoodFeedBacks.Remove(selected);
                    //сохраняем изменения
                    ChefBDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
