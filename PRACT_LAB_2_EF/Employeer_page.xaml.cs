using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Employeer_page.xaml
    /// </summary>
    public partial class Employeer_page : Page
    {
        private VodocanalEntities1 DB = new VodocanalEntities1();
        public Employeer_page()
        {
            InitializeComponent();
            Reload();
            table_grid.ItemsSource = DB.Employeers.ToList();
            emlp_post.ItemsSource = DB.Posts.ToList();
            emlp_post.DisplayMemberPath = "post_name";
        }

        private void add_but_Click(object sender, RoutedEventArgs e)
        {
            InterDIS();
            InterEN();
            save_but.IsEnabled = true;

        }

        private void save_but_Click(object sender, RoutedEventArgs e)
        {
            if (empl_name.Text != "" && empl_suname.Text != "" && emlp_midlename.Text != "")
            {
                DB.Employeers.Add(new Employeers(empl_name.Text, empl_suname.Text, emlp_midlename.Text, (emlp_post.SelectedItem as Posts).post_id, emlp_post.SelectedItem as Posts));
                Reload();
                InterDIS();
                save_but.IsEnabled = false;
            }
        }

        private void del_but_Click(object sender, RoutedEventArgs e)
        {
            DB.Employeers.Remove(table_grid.SelectedItem as Employeers);
            Reload();
            InterDIS();
        }

        private void alter_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null && empl_name.Text != "" && empl_suname.Text != "" && emlp_midlename.Text != "")
            {
                var selected = (table_grid.SelectedItem as Employeers);
                selected.employeer_name = empl_name.Text;
                selected.employeer_surname = empl_suname.Text;
                selected.employeer_middlename = emlp_midlename.Text;
                selected.id_post = (emlp_post.SelectedItem as Posts).post_id;
                Reload();
            }
            InterDIS();
        }

        private void table_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InterEN();
            if (table_grid.SelectedItem != null)
            {
                foreach (var i in DB.Posts.ToList())
                {
                    if ((int)(table_grid.SelectedItem as Employeers).id_post == i.post_id)
                        emlp_post.SelectedIndex = DB.Posts.ToList().IndexOf(i);
                }
                empl_name.Text = (table_grid.SelectedItem as Employeers).employeer_name;
                empl_suname.Text = (table_grid.SelectedItem as Employeers).employeer_surname;
                emlp_midlename.Text = (table_grid.SelectedItem as Employeers).employeer_middlename;
                emlp_post.SelectedItem = 0;
            }
        }

        void Reload()
        {
            DB.SaveChanges();
            table_grid.ItemsSource = DB.Employeers.ToList();
        }

        void InterEN()
        {
            empl_name.Visibility = Visibility.Visible;
            empl_suname.Visibility = Visibility.Visible;
            emlp_midlename.Visibility = Visibility.Visible;
            emlp_post.Visibility = Visibility.Visible;
            nt.Visibility = Visibility.Visible;
            st.Visibility = Visibility.Visible;
            mt.Visibility = Visibility.Visible;
            pt.Visibility = Visibility.Visible;
        }

        void InterDIS()
        {
            empl_name.Text = "";
            empl_suname.Text = "";
            emlp_midlename.Text = "";
            empl_name.Visibility = Visibility.Hidden;
            empl_suname.Visibility = Visibility.Hidden;
            emlp_midlename.Visibility = Visibility.Hidden;
            emlp_post.Visibility = Visibility.Hidden;
            nt.Visibility = Visibility.Hidden;
            st.Visibility = Visibility.Hidden;
            mt.Visibility = Visibility.Hidden;
            pt.Visibility = Visibility.Hidden;
        }
    }
}
