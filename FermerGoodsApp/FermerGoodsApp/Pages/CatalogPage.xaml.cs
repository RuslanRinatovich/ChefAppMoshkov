using FermerGoodsApp.Models;
using FermerGoodsApp.Windows;
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

using Word = Microsoft.Office.Interop.Word;

namespace FermerGoodsApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        int _itemcount = 0;
        public CatalogPage()
        {
            InitializeComponent();
            LoadData();
            LoadCategories();

        }

        private void BtnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            Good quest = (sender as Button).DataContext as Good;
            if (quest.GoodFeedBacks.Count == 0)
                return;
           
            ListBoxRewiews.ItemsSource = quest.GoodFeedBacks;
            DialogHostMoreInformation.DataContext = quest;
            DialogHostMoreInformation.IsOpen = true;
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {

            DialogHostMoreInformation.IsOpen = false;
        }
        void LoadData()
        {
 
            LViewGoods.ItemsSource = ChefBDEntities.GetContext().Goods.OrderBy(p => p.Name).ThenBy(p => p.Price).ToList();
            _itemcount = LViewGoods.Items.Count;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {_itemcount} записей из {_itemcount}";
        }
        void LoadCategories()
        {
            var categories = ChefBDEntities.GetContext().Categories.OrderBy(p =>p.Title).ToList();
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
        /// <summary>
        /// Метод для фильтрации и сортировки данных
        /// </summary>
        private void UpdateData()
        {
            LViewGoods.ItemsSource = null;
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
            LViewGoods.ItemsSource = currentGoods;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {currentGoods.Count} записей из {_itemcount}";
        }
        // сортировка товаров 
        private void ComboSortSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        void ExportWord(Good selected)
        {

            string fileName = Directory.GetCurrentDirectory() + "\\" + "AboutBanner" + ".dotx";
            Word.Application wrdApp = new Word.Application();
            try
            {

                Word.Document document = wrdApp.Documents.Add(fileName);
                document.Bookmarks["Name"].Range.Text = selected.Name;
                document.Bookmarks["Price"].Range.Text = selected.Price.ToString();

                document.Bookmarks["Category"].Range.Text = selected.Category.Title;


                object oRange = document.Bookmarks["Photo"].Range;
                object saveWithDocument = true;
                object missing = Type.Missing;
                string pictureName = selected.GetPhoto;
                document.InlineShapes.AddPicture(pictureName, ref missing, ref saveWithDocument, ref oRange);





                //document.SaveAs("В");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                wrdApp.Quit();
            }
            finally
            {
                wrdApp.Visible = true;
                wrdApp.ScreenUpdating = true;
            }



        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //обновление данных после каждой активации окна
            if (Visibility == Visibility.Visible)
            {
                //ChefBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                //LViewGoods.ItemsSource = ChefBDEntities.GetContext().Goods.OrderBy(p =>
                //p.Name).ToList();
                LoadData();
                LoadCategories();
                if (Manager.buyGoods.Count == 0)
                    Manager.BadgeCount.Badge = null;
            }
        }

        private void ComboDeveloper_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboDeveloper_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

      
        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            var x = (sender as Button).DataContext as Good;
            Status status = ChefBDEntities.GetContext().Status.Find(1);
            if (Manager.buyGoods.ContainsKey(x))
            {
                int k = Manager.buyGoods[x].Count + 1;
                double p = x.Price * k;
                Manager.buyGoods[x] = new Manager.BuyItem { Count = k, Total = p };
            }
            else
            {
                int k = 1;
                double p = x.Price * k;
                Manager.buyGoods[x] = new Manager.BuyItem { Count = k, Total = p};
            }
            //MessageBox.Show("Товар добавлен в корзину " + Manager.buyGoods.Count.ToString());
            // Manager.TbCount.Text = $"В корзине {Manager.buyGoods.Count} товаров";
            Manager.BadgeCount.Badge = Manager.buyGoods.Count;

        }

        private void BtnEditGood_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddGoodPage((sender as Button).DataContext as Good));
        }

        private void BtnMakeRewiew_Click(object sender, RoutedEventArgs e)
        {
            var x = (sender as Button).DataContext as Good;

            try
            {


                AddFeedBackWindow window = new AddFeedBackWindow(new GoodFeedBack
                {
                    
                    GoodId = x.Id

                });
                if (window.ShowDialog() == true)
                {
                    window.currentItem.ClientUserName = Manager.currentClient.UserName;

                    ChefBDEntities.GetContext().GoodFeedBacks.Add(window.currentItem);
                    ChefBDEntities.GetContext().SaveChanges();

                    LoadData();
                    MessageBox.Show("Запись добавлена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
