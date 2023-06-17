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
    /// Логика взаимодействия для SellerOrdersPage.xaml
    /// </summary>
    public partial class SellerOrdersPage : Page
    {
        ICollectionView collectionView;
        string imagePath = AppDomain.CurrentDomain.BaseDirectory + "Images/";
        public SellerOrdersPage()
        {
            InitializeComponent();
            LoadData();
        }




        void LoadData()
        {
            DataGridOrders.ItemsSource = null;

            //загрузка обновленных данных
            ChefBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            List<Order> billboards = ChefBDEntities.GetContext().Orders.OrderBy(p => p.DateStart).ToList();
            collectionView = CollectionViewSource.GetDefaultView(billboards);

            DataGridOrders.ItemsSource = collectionView;


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
                OrderGood x = item as OrderGood;
                return x.OrderId == id;

            };
            collectionView.Refresh();
        }

        void FilterByClient(string s)
        {
            collectionView.Filter = item =>
            {
                OrderGood x = item as OrderGood;
                //return x.OrderID == id;
                return x.Order.Client.GetFio.ToLower().Contains(s.ToLower());
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
                OrderGood x = item as OrderGood;
                //return x.OrderID == id;
                return x.Order.DateStart == y;
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
                        xlSheet.Cells[row, 5] = order.Status.Name.ToString();
                        xlSheet.Cells[row, 4] = order.Client.GetFio.ToString();
                        xlSheet.Cells[row, 7] = order.TotalPrice.ToString();

                        row++;
                        Excel.Range r = xlSheet.get_Range("A" + row.ToString(), "I" + row.ToString());
                        r.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
                    }
                }
                row--;
                xlSheetRange = xlSheet.get_Range("A2:I" + (row + 1).ToString(), Type.Missing);
                xlSheetRange.Borders.LineStyle = true;
                xlSheet.Cells[row + 1, 9] = "=SUM(I2:I" + row.ToString() + ")";

                xlSheet.Cells[row + 1, 8] = "ИТОГО:";
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
            //if (Visibility == Visibility.Visible)
            //{
            //    LoadData();
            //}
        }

    

        private void BtnGet_Click(object sender, RoutedEventArgs e)
        {
            int id = ((sender as Button).DataContext as Order).Id;
            Order order = ChefBDEntities.GetContext().Orders.Find(id);
            order.StatusId = 2;
            ChefBDEntities.GetContext().SaveChanges();
            LoadData();
        }

        private void BtnRoad_Click(object sender, RoutedEventArgs e)
        {
            int id = ((sender as Button).DataContext as Order).Id;
            Order order = ChefBDEntities.GetContext().Orders.Find(id);
            order.StatusId = 3;
            ChefBDEntities.GetContext().SaveChanges();
            LoadData();
        }

        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {
            int id = ((sender as Button).DataContext as Order).Id;
            Order order = ChefBDEntities.GetContext().Orders.Find(id);
            order.StatusId = 4;
            ChefBDEntities.GetContext().SaveChanges();
            LoadData();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            int id = ((sender as Button).DataContext as Order).Id;
            Order order = ChefBDEntities.GetContext().Orders.Find(id);
            order.StatusId = 1;
            ChefBDEntities.GetContext().SaveChanges();
            LoadData();
        }

        private void BtnMore_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddOrderPage((sender as Button).DataContext as Order));
        }
    }
}
