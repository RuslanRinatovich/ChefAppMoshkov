using FermerGoodsApp.Models;
using FermerGoodsApp.Pages;
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
using static FermerGoodsApp.Models.Manager;
using Word = Microsoft.Office.Interop.Word;

namespace FermerGoodsApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _login = false;
        int _itemcount = 0;


        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new CatalogPage());
            BtnEdit.Visibility = Visibility.Collapsed;
            BtnSellerOrders.Visibility = Visibility.Collapsed;
            BtnMyAccount.Visibility = Visibility.Collapsed;
            BtnMyFeedBacks.Visibility = Visibility.Collapsed;
            BtnMyOrders.Visibility = Visibility.Collapsed;
            
           // TbCount.Visibility = Visibility.Collapsed;
            //BtnBuy.Visibility = Visibility.Collapsed;
            BadgeCount.Visibility = Visibility.Collapsed;
            Manager.MainFrame = MainFrame;
           // Manager.TbCount = TbCount;
            Manager.BadgeCount = BadgeCount;
        }




        private void BtnCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // на экране отображается форма с двумя кнопками
            MessageBoxResult x = MessageBox.Show("Вы действительно хотите закрыть приложение?",
            "Выйти", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (x == MessageBoxResult.Cancel)
                e.Cancel = true;
        }


        private void BtnAdminClick(object sender, RoutedEventArgs e)
        {
            if (_login)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show($"Выйти из системы??? ", "Выход", MessageBoxButton.OKCancel,
MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    IconBtnKey.Kind = MaterialDesignThemes.Wpf.PackIconKind.Login;
                    _login = false;
                    BtnEdit.Visibility = Visibility.Collapsed;
                    BtnSellerOrders.Visibility = Visibility.Collapsed;
                    BtnMyAccount.Visibility = Visibility.Collapsed;
                    BtnMyFeedBacks.Visibility = Visibility.Collapsed;
                    BtnMyOrders.Visibility = Visibility.Collapsed;
                    BadgeCount.Visibility = Visibility.Collapsed;
                    Manager.currentClient = null;
                    BadgeCount.Badge = null;
                    ImgUserPhoto.Source = null;
                    ImgUserPhoto.Visibility = Visibility.Collapsed;
                    //TbUserInfo.Visibility = Visibility.Collapsed;
                    TbUserInfo.Text = "";
                    Manager.buyGoods.Clear();
                    MainFrame.NavigationService.Refresh();
                    //MainFrame.Navigate(new CatalogPage());
                    TbPass.Password = "";
                    TbLogin.Text = "";
                    return;
                }
            }
            else
                AccessWindow.IsOpen = true;
        }

        private void BtnCancelClick(object sender, RoutedEventArgs e)
        {
            AccessWindow.IsOpen = false;
        }

        private void BtnOkClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //загрузка всех пользователей из БД в список
                List<Client> clients = ChefBDEntities.GetContext().Clients.ToList();
                //попытка найти пользователя с указанным паролем и логином
                //если такого пользователя не будет обнаружено то переменная u будет равна null
                Client u = clients.FirstOrDefault(p => p.Password == TbPass.Password && p.UserName == TbLogin.Text);

               

                if (u != null)
                {
                    // логин и пароль корректные запускаем главную форму приложения
                    //клиент
                    if (u.RoleId == 1)
                    {
                        IconBtnKey.Kind = MaterialDesignThemes.Wpf.PackIconKind.Logout;
                        _login = true;
                        Manager.currentClient = u;
                        BtnMyFeedBacks.Visibility = Visibility.Visible;
                        BtnMyAccount.Visibility = Visibility.Visible;
                        BtnClients.Visibility = Visibility.Collapsed;
                        BtnMyOrders.Visibility = Visibility.Visible;
                        BadgeCount.Visibility = Visibility.Visible;
                        ImgUserPhoto.Visibility = Visibility.Visible;
                        ImgUserPhoto.Source = new BitmapImage(new Uri(u.GetPhoto));
                        TbUserInfo.Text = Manager.currentClient.GetFio;
                        AccessWindow.IsOpen = false;
                        MessageBox.Show("Вы вошли в систему как покупатель");
                        MainFrame.NavigationService.Refresh();
                        return;
                    }
                    // админ
                    if (u.RoleId == 2)
                    {
                        IconBtnKey.Kind = MaterialDesignThemes.Wpf.PackIconKind.Logout;
                        _login = true;
                        Manager.currentClient = u;
                        BtnMyAccount.Visibility = Visibility.Visible;
                        BtnClients.Visibility = Visibility.Visible;
                        ImgUserPhoto.Visibility = Visibility.Visible;
                        ImgUserPhoto.Source = new BitmapImage(new Uri(u.GetPhoto));
                        AccessWindow.IsOpen = false;
                        BtnEdit.Visibility = Visibility.Visible;
                        BtnSellerOrders.Visibility = Visibility.Visible;
                        TbUserInfo.Text = Manager.currentClient.GetFio;
                        MessageBox.Show("Вы вошли в систему как админ");
                        MainFrame.NavigationService.Refresh();
                        return;
                    }


                }
                

                MessageBox.Show("Не верный логин или пароль");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void MainFrameContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
                BtnAdmin.Visibility = Visibility.Collapsed;
                BtnMyAccount.Visibility = Visibility.Collapsed;
                BtnMyFeedBacks.Visibility = Visibility.Collapsed;
                BtnClients.Visibility = Visibility.Collapsed;
                BtnMyOrders.Visibility = Visibility.Collapsed;
                BadgeCount.Visibility = Visibility.Collapsed;
                BtnEdit.Visibility = Visibility.Collapsed;
                BtnSellerOrders.Visibility = Visibility.Collapsed;
            }
            else
            {
                BtnBack.Visibility = Visibility.Collapsed;
                BtnAdmin.Visibility = Visibility.Visible;

                if  (Manager.currentClient == null)
                {
                    BtnMyOrders.Visibility = Visibility.Collapsed;
                    BtnMyAccount.Visibility = Visibility.Collapsed;
                    BtnMyFeedBacks.Visibility = Visibility.Collapsed;
                    BtnClients.Visibility = Visibility.Collapsed;
                    BadgeCount.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnMyAccount.Visibility = Visibility.Visible;



                    if (Manager.currentClient.RoleId == 2)
                    {
                        BtnEdit.Visibility = Visibility.Visible;
                        BtnSellerOrders.Visibility = Visibility.Visible;
                        BtnMyFeedBacks.Visibility = Visibility.Collapsed;
                        BtnMyAccount.Visibility = Visibility.Visible;
                        BtnClients.Visibility = Visibility.Visible;
                        BtnMyOrders.Visibility = Visibility.Collapsed;
                        BadgeCount.Visibility = Visibility.Collapsed;
                        TbUserInfo.Text = Manager.currentClient.GetFio;
                        ImgUserPhoto.Source = null;
                        ImgUserPhoto.Source = new BitmapImage(new Uri(Manager.currentClient.GetPhoto));
                    }
                    else
                    {
                        BtnEdit.Visibility = Visibility.Collapsed;
                        BtnSellerOrders.Visibility = Visibility.Collapsed;
                        BtnMyFeedBacks.Visibility = Visibility.Visible;
                        BtnClients.Visibility = Visibility.Collapsed;
                        BtnMyOrders.Visibility = Visibility.Visible;
                        BtnMyAccount.Visibility = Visibility.Visible;
                        BadgeCount.Visibility = Visibility.Visible;
                        if (Manager.currentClient != null)
                        {
                            ImgUserPhoto.Source = null;
                            TbUserInfo.Text = Manager.currentClient.GetFio;
                            ImgUserPhoto.Source = new BitmapImage(new Uri(Manager.currentClient.GetPhoto));
                        }
                    }
                }

            }
        }

        private void BtnEditClick(object sender, RoutedEventArgs e)
        {
           
         
            MainFrame.Navigate(new GoodPage());


        }


        private void BtnMaximizeMin_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                IconMaximize.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
            }

            else
            {
                this.WindowState = WindowState.Normal;
                IconMaximize.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
            }

        }



        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void BtnRegsBuyer_Click(object sender, RoutedEventArgs e)
        {
            RegsBuyerWindow regsWindow = new RegsBuyerWindow();
            regsWindow.ShowDialog();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
      
            if (Manager.buyGoods.Count == 0)
                BadgeCount.Badge = null;


            Manager.MainFrame.GoBack();

        }

     
        

        private void BtnMyAccount_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.currentClient != null)
            {
                MainFrame.Navigate(new EditClientPage(Manager.currentClient));
            }
        
        }

        private void BtnBuyClick(object sender, RoutedEventArgs e)
        {
            LbBuy.ItemsSource = null;
            LbBuy.ItemsSource = Manager.buyGoods;
            BuysWindow.IsOpen = true;


        }

        private void BtnOkBuy_Click(object sender, RoutedEventArgs e)
        {
            BuysWindow.IsOpen = false;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LbBuy.SelectedIndex == -1)
                return;

            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить товар из корзины???", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                if (LbBuy.SelectedIndex >= 0)
                {
                    var x = (LbBuy.SelectedValue as Good);
                    Manager.buyGoods.Remove(x);
                    LbBuy.ItemsSource = null;
                    LbBuy.ItemsSource = Manager.buyGoods;
                    BadgeCount.Badge = Manager.buyGoods.Count;
                 //   TbCount.Text = $"В корзине {Manager.buyGoods.Count} товаров";
                }
            }
            if (Manager.buyGoods.Count == 0)
                BadgeCount.Badge = null;

        }

        private void BtnMyFeedBacks_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new FeedBackPage());
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
                Manager.buyGoods[x] = new Manager.BuyItem { Count = k, Total = p };
                LbBuy.ItemsSource = null;
                LbBuy.ItemsSource = Manager.buyGoods;
            }

        }

        private void BtnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            var x = (sender as Button).DataContext as Good;
            //Good g = ChefBDEntities.GetContext().Goods.Find(x.Good.Id);
            //MessageBox.Show(x.Name);
            if (Manager.buyGoods.ContainsKey(x))
            {
                int k = Manager.buyGoods[x].Count;
                if (k > 0)  k--;

                if (k == 0)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить товар из корзины???", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    //если пользователь нажал ОК пытаемся удалить запись
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        Manager.buyGoods.Remove(x);
                        LbBuy.ItemsSource = null;
                        LbBuy.ItemsSource = Manager.buyGoods;
                        BadgeCount.Badge = Manager.buyGoods.Count;
                      //  TbCount.Text = $"В корзине {Manager.buyGoods.Count} товаров";
                    }
                    else
                    {
                        k = 1;
                        BadgeCount.Badge = Manager.buyGoods.Count;
                        //  TbCount.Text = $"В корзине {Manager.buyGoods.Count} товаров";
                        double p = x.Price * k;
                        Manager.buyGoods[x] = new Manager.BuyItem { Count = k, Total = p };
                        LbBuy.ItemsSource = null;
                        LbBuy.ItemsSource = Manager.buyGoods;
                    }
                }
                else
                {
                    BadgeCount.Badge = Manager.buyGoods.Count;
                    //  TbCount.Text = $"В корзине {Manager.buyGoods.Count} товаров";
                    double p = x.Price * k;
                    Manager.buyGoods[x] = new Manager.BuyItem { Count = k, Total = p };
                    LbBuy.ItemsSource = null;
                    LbBuy.ItemsSource = Manager.buyGoods;
                }
               
                
            }
            if (Manager.buyGoods.Count == 0)
                BadgeCount.Badge = null;
        }

        private void BtnBuyItemClick(object sender, RoutedEventArgs e)
        {
            BuysWindow.IsOpen = false;
            if (Manager.buyGoods.Count == 0)
                return;
            MainFrame.Navigate(new AddOrderPage(null));
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
         

        }

        private void BtnMyOrders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MyOrdersPage());

        }

        private void BtnSellerOrders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SellerOrdersPage());
        }

        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientsPage());
        }
    }
}
