using FermerGoodsApp.Models;
using FermerGoodsApp.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для FeedBackPage.xaml
    /// </summary>
    public partial class FeedBackPage : Page
    {
        public FeedBackPage()
        {
            InitializeComponent();
            LoadData();

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
            }
        }


        // загрузка данных в DataGrid и ComboBox
        void LoadData()
        {
            try
            {
                DtData.ItemsSource = null;
                //загрузка обновленных данных
                ChefBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DtData.ItemsSource = ChefBDEntities.GetContext().GoodFeedBacks.Where(p => p.ClientUserName == Manager.currentClient.UserName).OrderBy(p => p.Date).ThenBy(p => p.Rate).ToList();
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

              
                AddFeedBackWindow window = new AddFeedBackWindow(new GoodFeedBack());
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

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (DtData.SelectedItem == null) return;
                // получаем выделенный объект
                GoodFeedBack selected = DtData.SelectedItem as GoodFeedBack;

                //double k = selected.Count;

                AddFeedBackWindow window = new AddFeedBackWindow(
                    new GoodFeedBack
                    {
                        Id = selected.Id,
                        ClientUserName = selected.ClientUserName,
                        Date = selected.Date,
                        Rate = selected.Rate,
                        Info = selected.Info,
                        GoodId = selected.GoodId
                        
                    }
                    );

                if (window.ShowDialog() == true)
                {
                    selected = ChefBDEntities.GetContext().GoodFeedBacks.Find(window.currentItem.Id);
                    // получаем измененный объект
                    if (selected != null)
                    {

                        selected.Id = window.currentItem.Id;
                        selected.ClientUserName = window.currentItem.ClientUserName;
                        selected.Date = window.currentItem.Date;
                        selected.Rate = window.currentItem.Rate;
                        selected.Info = window.currentItem.Info;
                        selected.GoodId = window.currentItem.GoodId;
                        ChefBDEntities.GetContext().Entry(selected).State = EntityState.Modified;
                        ChefBDEntities.GetContext().SaveChanges();
                        LoadData();

                        MessageBox.Show("Запись изменена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
            }
        }
            catch
            {
                MessageBox.Show("Ошибка");
            }


}

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               

                // если ни одного объекта не выделено, выходим
                if (DtData.SelectedItem == null) return;
                // получаем выделенный объект
                MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись? ", "Удаление", MessageBoxButton.OKCancel,
MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    GoodFeedBack deletedItem = DtData.SelectedItem as GoodFeedBack;



                    ChefBDEntities.GetContext().GoodFeedBacks.Remove(deletedItem);

                    ChefBDEntities.GetContext().SaveChanges();


                    LoadData();
                    MessageBox.Show("Запись удалена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       
    }
}
