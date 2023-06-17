using FermerGoodsApp.Models;
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

namespace FermerGoodsApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddFeedBackWindow.xaml
    /// </summary>
    public partial class AddFeedBackWindow : Window
    {
        public GoodFeedBack currentItem { get; private set; }
        int id = 0;
        public AddFeedBackWindow(GoodFeedBack p)
        {
            InitializeComponent();
            
            currentItem = p;
            currentItem.ClientUserName = Manager.currentClient.UserName;
           
            this.DataContext = currentItem;
            var categories = ChefBDEntities.GetContext().Categories.OrderBy(c => c.Title).ToList();
            categories.Insert(0, new Category
            {
                Title = "Все категории"
            }
            );
            ComboCategory.ItemsSource = categories;
            ComboCategory.SelectedIndex = 0;

            ComboGood.ItemsSource = ChefBDEntities.GetContext().Goods.ToList();
            if (currentItem != null)
            {
                Good good = ChefBDEntities.GetContext().Goods.Find(currentItem.GoodId);
                ComboCategory.Text = good.Category.Title;
                ComboGood.SelectedValue = currentItem.GoodId;
             
            }

            if (currentItem.GoodId != 0)
            {

                Good good = ChefBDEntities.GetContext().Goods.Find(currentItem.GoodId);
                ComboCategory.Text = good.Category.Title;
                ComboGood.SelectedValue = currentItem.GoodId;
            }

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if ((ComboGood.SelectedIndex == -1) || (RatingBarRate.Value == 0) )
                return;
            currentItem.Rate = Convert.ToDouble(RatingBarRate.Value);
            
            this.DialogResult = true;
        }

        private void ComboGood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (currentItem.Id != 0)
            {
                Good g = ChefBDEntities.GetContext().Goods.Find(currentItem.GoodId);
               
                ComboGood.SelectedValue = g.Id;
            }
            if (currentItem.GoodId != 0)
            {

                Good good = ChefBDEntities.GetContext().Goods.Find(currentItem.GoodId);
                ComboCategory.Text = good.Category.Title;
                ComboGood.SelectedValue = currentItem.GoodId;
            }
        }

        private void ComboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboCategory.SelectedIndex > 0)
            {
                Category category = (ComboCategory.SelectedItem) as Category;
                ComboGood.Visibility = Visibility.Visible;
                ComboGood.ItemsSource = ChefBDEntities.GetContext().Goods.Where(p => p.CategoryId == category.Id).ToList();
            }
            else
            {
               
                ComboGood.ItemsSource = ChefBDEntities.GetContext().Goods.ToList(); ;
            }
        }
    }
}