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
using System.Data.Entity;
using FermerGoodsApp.Models;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;

namespace FermerGoodsApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyOrdersPage.xaml
    /// </summary>
    public partial class MyOrdersPage : Page
    {
        ICollectionView collectionView;
        string imagePath = AppDomain.CurrentDomain.BaseDirectory + "Images/";
        public MyOrdersPage()
        {
            InitializeComponent();
            LoadData();
        }




        void LoadData()
        {
            DataGridOrders.ItemsSource = null;
           
                //загрузка обновленных данных
                ChefBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<Order> billboards = ChefBDEntities.GetContext().Orders.Where(p => p.UserName == Manager.currentClient.UserName).OrderBy(p => p.DateStart).ToList();
                collectionView = CollectionViewSource.GetDefaultView(billboards);

                DataGridOrders.ItemsSource = collectionView;
           

        }




        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

            int selind = cmbSearchType.SelectedIndex;
            if (tbSearchID.Text == "")
            {
                collectionView.Filter = null;
                return;
            }
            switch (selind)
            {
                case 0:
                    FilterByID(tbSearchID.Text);
                    break;
                case 1:
                    FilterByClient(tbSearchID.Text);
                    break;
                case 2:
                    FilterByDate(tbSearchID.Text);
                    break;

                default: collectionView.Filter = null; break;
            }





        }
        void FilterByID(string s)
        {
            int id = -1;
            bool b = int.TryParse(s, out id);
            if (!b)
                collectionView.Filter = null;

            collectionView.Filter = item =>
            {
                Order x = item as Order;
                return x.Id == id;

            };
            collectionView.Refresh();
        }

        void FilterByClient(string s)
        {
            collectionView.Filter = item =>
            {
                Order x = item as Order;
                //return x.OrderID == id;
                return x.Client.GetFio.ToLower().Contains(s.ToLower());
            };
            collectionView.Refresh();
        }


        void FilterByDate(string s)
        {
            DateTime y = DateTime.Now;

            bool b = DateTime.TryParse(s, out y);
            if (b == false)
            {
                return;
            }
            collectionView.Filter = item =>
            {
                Order x = item as Order;
                //return x.OrderID == id;
                return x.DateStart == y;
            };
            collectionView.Refresh();
        }



        private void BtnClearSearch_Click(object sender, RoutedEventArgs e)
        {

            collectionView.Filter = null;
            collectionView.Refresh();

        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            PrintExcel();

        }

        private void PrintExcel()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\" + "Orders" + ".xltx";
            Excel.Application xlApp = new Excel.Application();
            Excel.Worksheet xlSheet = new Excel.Worksheet();
            try
            {
                //добавляем книгу
                xlApp.Workbooks.Open(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing);
                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;
                Excel.Range xlSheetRange;
                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                xlSheet.Name = "Список заявок";
                int row = 2;
                int i = 0;


                if (DataGridOrders.Items.Count > 0)
                {
                    for (i = 0; i < DataGridOrders.Items.Count; i++)
                    {

                        Order order = DataGridOrders.Items[i] as Order;

                        xlSheet.Cells[row, 1] = (i + 1).ToString();
                        // DateTime y = Convert.ToDateTime(dtOrders.Rows[i].Cells[1].Value);
                        xlSheet.Cells[row, 2] = order.Id.ToString();
                        xlSheet.Cells[row, 3] = order.DateStart.ToShortDateString();
                        xlSheet.Cells[row, 5] = order.Status.ToString();
                        xlSheet.Cells[row, 4] = order.Client.GetFio.ToString();
                        xlSheet.Cells[row, 6] = order.TotalPrice.ToString();

                        row++;
                        Excel.Range r = xlSheet.get_Range("A" + row.ToString(), "F" + row.ToString());
                        r.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
                    }
                }
                row--;
                xlSheetRange = xlSheet.get_Range("A2:F" + (row + 1).ToString(), Type.Missing);
                xlSheetRange.Borders.LineStyle = true;
                xlSheet.Cells[row + 1, 6] = "=SUM(F2:F" + row.ToString() + ")";

                xlSheet.Cells[row + 1, 5] = "ИТОГО:";
                row++;

                //выбираем всю область данных*/
                xlSheetRange = xlSheet.UsedRange;
                //выравниваем строки и колонки по их содержимому
                //xlSheetRange.Columns.AutoFit();
                //xlSheetRange.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;
                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;
            }
        }



        private void CmbSearchType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSearchType.SelectedIndex == 3)
                tbSearchID.Text = DateTime.Today.Date.ToShortDateString();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Manager.MainFrame.Navigate(new AddOrderPage(null));
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

        private void BtnLook_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddOrderPage((sender as Button).DataContext as Order));
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Order selectedItem = (sender as Button).DataContext as Order;
            // удаление выбранного товара из таблицы

            Status status = ChefBDEntities.GetContext().Status.Find(1);
            bool b = false;

            
            if (selectedItem.StatusId != 1)
            {
                MessageBox.Show("Отменить заказ на данном этапе не возможно");
                return;
            }
            //получаем все выделенные товары
          
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Отменить заказ???",
                "Отмена заказа", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых товаров один элемент
                   
                    // проверка, есть ли у товара в таблице о продажах связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    List<OrderGood> delItems = ChefBDEntities.GetContext().OrderGoods.Where(p => p.OrderId == selectedItem.Id).ToList();
                    ChefBDEntities.GetContext().OrderGoods.RemoveRange(delItems);
                    ChefBDEntities.GetContext().SaveChanges();
                    ChefBDEntities.GetContext().Orders.Remove(selectedItem);
                    //сохраняем изменения
                    ChefBDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Заявка отменена");
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
