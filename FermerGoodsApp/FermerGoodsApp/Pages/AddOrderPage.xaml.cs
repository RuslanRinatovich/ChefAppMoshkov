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
using FermerGoodsApp.Models;
using FermerGoodsApp.Windows;
using System.Data.Entity;
using Excel = Microsoft.Office.Interop.Excel;

namespace FermerGoodsApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        //текущий товар
        private Order _currentItem = new Order();
        Dictionary<Good, Manager.BuyItem> currentItems = new Dictionary<Good, Manager.BuyItem>();
        string _userName = "";
        public AddOrderPage(Order selected)
        {
            InitializeComponent();
            
                _userName = Manager.currentClient.GetFio;
                 //ComboStatus.IsEnabled = false;
                _currentItem = selected;
            if (selected == null)
            {

              //    MessageBox.Show("+");
                _currentItem = new Order();
                _currentItem.DateStart = DateTime.Now;
                _currentItem.DeliveryTime = DateTime.Now.AddHours(1).TimeOfDay;
                TbPhone.Text = Manager.currentClient.Phone;
                TbAddress.Text = Manager.currentClient.Address;

                _currentItem.Address = Manager.currentClient.Address;
                _currentItem.ContactPhone = Manager.currentClient.Phone;
                _currentItem.StatusId = 1;
                
                _currentItem.UserName = Manager.currentClient.UserName;

                tbClient.Text = Manager.currentClient.GetFio;
                btnSave.Visibility = Visibility.Visible;
                btnCancel.Visibility = Visibility.Collapsed;
                tbOrderId.Visibility = Visibility.Hidden;
                if (_currentItem != null)
                    DtOrderPriceList.ItemsSource = Manager.buyGoods;
                CalculateTotalPrice();

            }
            else {
              //  MessageBox.Show(_currentItem.DeliveryTime.ToString());
                SetReadOnly();

                btnSave.Visibility = Visibility.Collapsed;
                btnCancel.Visibility = Visibility.Visible;
                tbClient.Text = selected.Client.GetFio;
                LoadCurrentData();
            }

            DataContext = _currentItem;
            TimePickerDeleveryTime.Value = Convert.ToDateTime(_currentItem.DeliveryTime.ToString());
        }

        void SetReadOnly()
        {
            tbClient.IsReadOnly = true;
            TimePickerDeleveryTime.IsReadOnly = true;
            TbAddress.IsReadOnly = true;
            tbStartDate.IsReadOnly = true;
            tbOrderId.IsReadOnly = true;
        }
        void LoadData()
        {

            
            DataContext = _currentItem;
        }

        void LoadCurrentData()
        {
            

            List<OrderGood> orderGoods = ChefBDEntities.GetContext().OrderGoods.Where(p => p.OrderId ==_currentItem.Id).ToList();
            List<Good> goods = ChefBDEntities.GetContext().Goods.ToList();

            foreach (OrderGood order in orderGoods)
            {
                Good good = goods.Where(p => p.Id == order.GoodId).FirstOrDefault(); 
                currentItems[good] = new Manager.BuyItem { Count = order.Count, Total = good.Price * order.Count };
            }
            DtOrderPriceList.ItemsSource = currentItems;
            DtOrderPriceList.Columns[5].Visibility = Visibility.Collapsed;
            DtOrderPriceList.IsReadOnly = true;
            TbTotalPrice.Value = _currentItem.TotalPrice;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            var x = (sender as Button).DataContext as Good;
            //Good g = ChefBDEntities.GetContext().Goods.Find(x.Good.Id);
            //MessageBox.Show(x.Name);
            if (Manager.buyGoods.ContainsKey(x))
            {
                int k = Manager.buyGoods[x].Count + 1;
                double p = x.Price * k;
                Status status = ChefBDEntities.GetContext().Status.Find(1);
                Manager.buyGoods[x] = new Manager.BuyItem { Count = k, Total = p};
                DtOrderPriceList.ItemsSource = null;
                DtOrderPriceList.ItemsSource = Manager.buyGoods;
            }
            CalculateTotalPrice();
        }

        private void BtnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            var x = (sender as Button).DataContext as Good;
            //Good g = ChefBDEntities.GetContext().Goods.Find(x.Good.Id);
            //MessageBox.Show(x.Name);
            Status status = ChefBDEntities.GetContext().Status.Find(1);
            if (Manager.buyGoods.ContainsKey(x))
            {
                int k = Manager.buyGoods[x].Count;
                if (k > 0) k--;

                if (k == 0)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить товар из корзины???", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    //если пользователь нажал ОК пытаемся удалить запись
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        Manager.buyGoods.Remove(x);
                        if (Manager.buyGoods.Count == 0)
                            Manager.MainFrame.GoBack();
                        DtOrderPriceList.ItemsSource = null;
                        DtOrderPriceList.ItemsSource = Manager.buyGoods;
                    }
                    else
                    {
                        k = 1;
                        double p = x.Price * k;
                        Manager.buyGoods[x] = new Manager.BuyItem { Count = k, Total = p };
                        DtOrderPriceList.ItemsSource = null;
                        DtOrderPriceList.ItemsSource = Manager.buyGoods;
                    }
                }
                else
                {
                    double p = x.Price * k;
                    Manager.buyGoods[x] = new Manager.BuyItem { Count = k, Total = p };
                    DtOrderPriceList.ItemsSource = null;
                    DtOrderPriceList.ItemsSource = Manager.buyGoods;
                }


            }
            CalculateTotalPrice();


        }
        void CalculateTotalPrice()
        {

            if (_currentItem.Id == 0)
            {
                  double total = 0;
            foreach (KeyValuePair<Good, Manager.BuyItem> valuePair in Manager.buyGoods)
            {
                total += valuePair.Value.Total;
            }
            TbTotalPrice.Value = total;
                if (Manager.buyGoods.Count == 0)
                {
                    btnSave.IsEnabled = false;
                    btnExcel.IsEnabled = false;
                }
                else
                {
                    btnSave.IsEnabled = true;
                    btnExcel.IsEnabled = true;
                }
            }

        }

        private void btnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить товар из корзины???", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                if (DtOrderPriceList.SelectedIndex >= 0)
                {
                    var x = (DtOrderPriceList.SelectedValue as Good);
                    Manager.buyGoods.Remove(x);
                    if (Manager.buyGoods.Count == 0)
                        Manager.MainFrame.GoBack();
                    DtOrderPriceList.ItemsSource = null;
                    DtOrderPriceList.ItemsSource = Manager.buyGoods;
                }
            }
            CalculateTotalPrice();
        }

        private void BtnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var x = (sender as Button).DataContext as Good;
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить товар из корзины???", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                Manager.buyGoods.Remove(x);

                if (Manager.buyGoods.Count == 0)
                    Manager.MainFrame.GoBack();

                    DtOrderPriceList.ItemsSource = null;
                DtOrderPriceList.ItemsSource = Manager.buyGoods;
            }
          
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateTotalPrice();
            TimePickerDeleveryTime.Text = _currentItem.DeliveryTime.ToString();
        }

        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentItem.UserName))
                s.AppendLine("Выберите клиента");
            if (string.IsNullOrWhiteSpace(_currentItem.ContactPhone))
                s.AppendLine("Укажите контактный телефон");
            if (string.IsNullOrWhiteSpace(_currentItem.Address))
                s.AppendLine("Укажите адрес доставки");

            if (Manager.buyGoods.Count == 0)
                s.AppendLine("В корзине нет товаров");

            return s;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            // если ошибки есть, то выводим ошибки в MessageBox
            // и прерываем выполнение 
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }


            // проверка полей прошла успешно
            if (_currentItem.Id == 0)
            {
                _currentItem.StatusId = 1;
                _currentItem.DeliveryTime = Convert.ToDateTime(TimePickerDeleveryTime.Value).TimeOfDay;
                ChefBDEntities.GetContext().Orders.Add(_currentItem);
                try
                {
                    _currentItem.TotalPrice = Convert.ToDouble(TbTotalPrice.Value);
                    ChefBDEntities.GetContext().SaveChanges();
                    int id = _currentItem.Id;
                    tbOrderId.Text = id.ToString();
                    List<OrderGood> orderGoods = new List<OrderGood>();
                    double total = 0;
                    foreach (KeyValuePair<Good, Manager.BuyItem> valuePair in Manager.buyGoods)
                    {

                        OrderGood orderGood = new OrderGood();
                        orderGood.OrderId = id;
                        orderGood.GoodId = valuePair.Key.Id;
                        orderGood.Count = valuePair.Value.Count;
                       
                        total += valuePair.Value.Total;
                        orderGoods.Add(orderGood);

                    }

                    ChefBDEntities.GetContext().OrderGoods.AddRange(orderGoods);
                    ChefBDEntities.GetContext().SaveChanges();
                    MessageBox.Show($"Ваш заказ номер {_currentItem.Id} создан"); ;
                    tbOrderId.Visibility = Visibility.Visible;
                    btnExcel.IsEnabled = true;
                    btnSave.Visibility = Visibility.Collapsed;
                    btnCancel.Visibility = Visibility.Visible;
                    DtOrderPriceList.Columns[5].Visibility = Visibility.Collapsed;
                    DtOrderPriceList.IsReadOnly = true;
                    Manager.buyGoods.Clear();
                    LoadCurrentData();

                    SetReadOnly();
                    // Возвращаемся на предыдущую форму
                    // Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
            else
            {
                //try
                //{
                //    int id = _currentItem.Id;
                //    List<OrderGood> del = ChefBDEntities.GetContext().OrderGoods.Where(p => p.OrderId == id).ToList();
                //    ChefBDEntities.GetContext().SaveChanges();
                //    ChefBDEntities.GetContext().OrderGoods.RemoveRange(del);

                //    //   ChefBDEntities.GetContext().SaveChanges();


                //    List<OrderGood> orderGoods = new List<OrderGood>();
                //    double total = 0;
                //    foreach (KeyValuePair<Good, Manager.BuyItem> valuePair in Manager.buyGoods)
                //    {

                //        OrderGood orderGood = new OrderGood();
                //        orderGood.OrderId = id;
                //        orderGood.GoodId = valuePair.Key.Id;
                //        orderGood.Count = valuePair.Value.Count;
                //        orderGood.StatusId = 1;
                //        total += valuePair.Value.Total;
                //        orderGoods.Add(orderGood);

                //    }

                //    ChefBDEntities.GetContext().OrderGoods.AddRange(orderGoods);
                //    ChefBDEntities.GetContext().SaveChanges();
                //    LoadData();
                //    btnExcel.IsEnabled = true;
                //    // Возвращаемся на предыдущую форму
                //    // Manager.MainFrame.GoBack();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message.ToString());
                //}
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Status status = ChefBDEntities.GetContext().Status.Find(1);
            bool b = false;
            //foreach (KeyValuePair<Good, Manager.BuyItem> valuePair in currentItems)
            //{

            //    if (valuePair.Value.StatusName != status.Name)
            //    {
            //        b = true;
            //        break;
            //    }    

            //}
            if (_currentItem.StatusId != 1)
            {
                MessageBox.Show("Отменить заказ на данном этапе не возможно");
                return;
            }


            // удаление выбранного товара из таблицы
            //получаем все выделенные товары
            MessageBoxResult messageBoxResult = MessageBox.Show($"Отменить заказ???",
                "Отмена заказа", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых товаров один элемент
                    Order deletedItem = _currentItem;
                    // проверка, есть ли у товара в таблице о продажах связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    List<OrderGood> delItems = ChefBDEntities.GetContext().OrderGoods.Where(p => p.OrderId == deletedItem.Id).ToList();
                    ChefBDEntities.GetContext().OrderGoods.RemoveRange(delItems);
                    ChefBDEntities.GetContext().SaveChanges();
                    ChefBDEntities.GetContext().Orders.Remove(deletedItem);
                    //сохраняем изменения
                    ChefBDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Заявка отменена");
                    Manager.MainFrame.GoBack();
                   
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DtOrderPriceList_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            if (_currentItem.Id == 0)
                return;
            PrintExcel();

        }

        private void PrintExcel()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\" + "Check" + ".xltx";
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
                int row = 9;
                int i = 0;

                xlSheet.Cells[4, 3] = tbOrderId.Text;
                xlSheet.Cells[5, 3] = _currentItem.Client.GetFio;
                xlSheet.Cells[6, 3] = _currentItem.Client.Phone; ;
                //ServiceName = service.ServiceName,
                //                             DryOrderID = dryorder.DryOrderID,
                //                             OrderID = dryorder.OrderID,
                //                             ServiceID = service.ServiceID,
                //                             DryOrderContent = dryorder.DryOrderContent,
                //                             ServicePrice = dryorder.ServicePrice,
                //                             DryOrderCount = dryorder.DryOrderCount,
                //                             DryOrderPrice = dryorder.DryOrderPrice



                foreach (KeyValuePair<Good, Manager.BuyItem> valuePair in currentItems)
                {


                    xlSheet.Cells[row, 1] = (i + 1).ToString();
                    // DateTime y = Convert.ToDateTime(dtOrders.Rows[i].Cells[1].Value);
                    xlSheet.Cells[row, 2] = valuePair.Key.Name;
                    xlSheet.Cells[row, 5] = valuePair.Key.Category.Title;
                    xlSheet.Cells[row, 6] = valuePair.Key.Price.ToString();
                    xlSheet.Cells[row, 7] = valuePair.Value.Count.ToString();
                    xlSheet.Cells[row, 8] = valuePair.Value.Total.ToString();


                    row++;
                    Excel.Range r = xlSheet.get_Range("A" + row.ToString(), "H" + row.ToString());
                    r.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
                    Excel.Range x = xlSheet.get_Range("B" + row.ToString(), "D" + row.ToString());
                    x.Merge();

                }
             
                row--;
                xlSheetRange = xlSheet.get_Range("A9:H" + (row + 1).ToString(), Type.Missing);
                xlSheetRange.Borders.LineStyle = true;
                row++;
                Excel.Range t = xlSheet.get_Range("A" + row.ToString(), "G" + row.ToString());
                t.Merge();
                xlSheet.Cells[row, 8] = "=SUM(H9:H" + (row - 1).ToString() + ")";
                xlSheet.Cells[row, 1] = "ИТОГО:";
                t = xlSheet.get_Range("A" + row.ToString());
                t.Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                row += 2;
                xlSheet.Cells[row, 3] = _currentItem.Client.GetFio;
                row++;
                xlSheet.Cells[row, 3] = DateTime.Today.ToShortDateString();
                //выбираем всю область данных*/
                xlSheetRange = xlSheet.UsedRange;
                //выравниваем строки и колонки по их содержимому
                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();
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
    }
    
}
