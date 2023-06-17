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
    /// Логика взаимодействия для GoodPage.xaml
    /// </summary>
    public partial class GoodPage : Page
    {
        int _itemcount = 0;
        public GoodPage()
        {
            InitializeComponent();
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
        // Поиск товаров, которые содержат данную поисковую строку
        private void TBoxSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
        // Поиск товаров конкретного производителя
        private void ComboTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        private void ComboDeveloper_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        /// <summary>
        /// Метод для фильтрации и сортировки данных
        /// </summary>
        private void UpdateData()
        {
            DataGridGood.ItemsSource = null;
            // получаем текущие данные из бд
            List<Good> currentGoods;

            currentGoods = ChefBDEntities.GetContext().Goods.OrderBy(p => p.Name).ThenBy(p => p.Price).ToList();
            // выбор только тех товаров, которые принадлежат данному производителю
            if (ComboCategory.SelectedIndex > 0)
                currentGoods = currentGoods.Where(p => p.CategoryId == (ComboCategory.SelectedItem as Category).Id).ToList();

            // сортировка
            if (ComboSort.SelectedIndex >= 0)
            {
                // сортировка по возрастанию цены
                if (ComboSort.SelectedIndex == 0)
                    currentGoods = currentGoods.OrderBy(p => p.Price).ToList();
                // сортировка по убыванию цены
                if (ComboSort.SelectedIndex == 1)
                    currentGoods = currentGoods.OrderByDescending(p => p.Price).ToList();
            }


            // выбор тех товаров, в названии которых есть поисковая строка
            currentGoods = currentGoods.Where(p => p.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();


            // В качестве источника данных присваиваем список данных
            DataGridGood.ItemsSource = currentGoods;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {currentGoods.Count} записей из {_itemcount}";
        }
        // сортировка товаров 
        private void ComboSortSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
            {
                // открытие редактирования товара
                // передача выбранного товара в AddGoodPage
                Manager.MainFrame.Navigate(new AddGoodPage((sender as Button).DataContext as Good));
            }
            private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                //событие отображения данного Page
                // обновляем данные каждый раз когда активируется этот Page
                if (Visibility == Visibility.Visible)
                {
                LoadCategories();
                    DataGridGood.ItemsSource = null;
                    //загрузка обновленных данных
                    ChefBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    List<Good> goods = ChefBDEntities.GetContext().Goods.OrderBy(p => p.Name).ToList();
                    DataGridGood.ItemsSource = goods;
                     _itemcount = DataGridGood.Items.Count;
                TextBlockCount.Text = $" Результат запроса: {_itemcount} записей из {_itemcount}";
            }
            }
            private void BtnAddClick(object sender, RoutedEventArgs e)
            {
                // открытие AddGoodPage для добавления новой записи
                Manager.MainFrame.Navigate(new AddGoodPage(null));
            }
            private void BtnDeleteClick(object sender, RoutedEventArgs e)
            {
                // удаление выбранного товара из таблицы
                //получаем все выделенные товары
                var selectedGoods = DataGridGood.SelectedItems.Cast<Good>().ToList();
                // вывод сообщения с вопросом Удалить запись?
                MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedGoods.Count()} записей ??? ",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                //если пользователь нажал ОК пытаемся удалить запись
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    try
                    {
                        // берем из списка удаляемых товаров один элемент
                        Good x = selectedGoods[0];
                        // проверка, есть ли у товара в таблице о продажах связанные записи
                        // если да, то выбрасывается исключение и удаление прерывается
                        if (x.OrderGoods.Count > 0)
                            throw new Exception("Есть записи в продажах");
                        //ищем записи в таблице Complect, с которой связан этот товар
                       
                    // удаляем товара
                    ChefBDEntities.GetContext().Goods.Remove(x);
                    //сохраняем изменения
                    ChefBDEntities.GetContext().SaveChanges();

                        
                    
MessageBox.Show("Записи удалены");
                        List<Good> goods = ChefBDEntities.GetContext().Goods.OrderBy(p => p.Name).ToList();
                        DataGridGood.ItemsSource = null;
                        DataGridGood.ItemsSource = goods;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    }
                }
            }
            private void BtnSellClick(object sender, RoutedEventArgs e)
            {
                // открытие страницы о продажах SellGoodsPage
                // передача в него выбранного товара
                //Manager.MainFrame.Navigate(new SellGoodsPage((sender as Button).DataContext as Good));
            }
        // отображение номеров строк в DataGrid
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
            {
                e.Row.Header = (e.Row.GetIndex() + 1).ToString();
            }
        }
}
