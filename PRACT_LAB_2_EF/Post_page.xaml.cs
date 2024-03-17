using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
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

namespace PRACT_LAB_2_EF
{
    /// <summary>
    /// Логика взаимодействия для Post_page.xaml
    /// </summary>
    public partial class Post_page : Page
    {
        private VodocanalEntities1 DB = new VodocanalEntities1();
        public Post_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Posts.ToList();
        }

        private void add_but_Click(object sender, RoutedEventArgs e)
        {
            InterDIS();
            InterEN();
            save_but.IsEnabled = true;
        }

        private void del_but_Click(object sender, RoutedEventArgs e)
        {
            DB.Posts.Remove(table_grid.SelectedItem as Posts);
            Reload();
            InterDIS();
        }

        private void alter_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null && post_name.Text != "" && post_salary.Text != "")
            {
                var selected = (table_grid.SelectedItem as Posts);
                selected.post_name = post_name.Text;
                selected.post_salary = (float)(Convert.ToDouble(post_salary.Text));
                Reload();
            }
            InterDIS();
        }

        private void save_but_Click(object sender, RoutedEventArgs e)
        {
            if (post_name.Text != "" && post_salary.Text != "")
            {
                DB.Posts.Add(new Posts(post_name.Text, (float)(Convert.ToDouble(post_salary.Text))));
                Reload();
                InterDIS();
                save_but.IsEnabled = false;
            }
        }
        private void table_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InterEN();
            if (table_grid.SelectedItem != null)
            {
                post_name.Text = (table_grid.SelectedItem as Posts).post_name;
                post_salary.Text = (table_grid.SelectedItem as Posts).post_salary.ToString();
            }
        }

        void Reload()
        {
            DB.SaveChanges();
            table_grid.ItemsSource = DB.Posts.ToList();
        }

        void InterEN()
        {
            post_name.Visibility = Visibility.Visible;
            post_salary.Visibility = Visibility.Visible;
            nt.Visibility = Visibility.Visible;
            st.Visibility = Visibility.Visible;
        }

        void InterDIS()
        {
            post_name.Text = "";
            post_salary.Text = "";
            post_name.Visibility = Visibility.Hidden;
            post_salary.Visibility = Visibility.Hidden;
            nt.Visibility = Visibility.Hidden;
            st.Visibility = Visibility.Hidden;
        }
    }
}
