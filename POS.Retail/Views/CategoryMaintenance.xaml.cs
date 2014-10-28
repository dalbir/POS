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
using System.Windows.Shapes;
using System.Windows.Threading;
using POS.Retail.Common;
using POS.Domain;
using POS.Domain.Common;
using POS.Services.Common;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for CategoryMaintenance.xaml
    /// </summary>
    public partial class CategoryMaintenance : Window
    {
    
        string Query = string.Empty;
        int index = 0;
        DataTable dt = new DataTable();
        DispatcherTimer timer;
        //CategoriesClass CategoryObj;
        CategoriesClass obCategoriesClass = new CategoriesClass();
        public CategoryMaintenance()
        {
            InitializeComponent();

            ////////////////////

            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1.0);
            //timer.Start();
            //timer.Tick += new EventHandler(delegate(object s, EventArgs a)
            //{
            //    if (DateTime.Now.Hour.ToString().Length == 1 && DateTime.Now.Minute.ToString().Length == 1 && DateTime.Now.Second.ToString().Length == 1)
            //    {
            //        label3.Content = "0" + DateTime.Now.Hour + ":0"
            //          + DateTime.Now.Minute + ":0"
            //          + DateTime.Now.Second;
            //    }
            //    else if (DateTime.Now.Hour.ToString().Length == 2 && DateTime.Now.Minute.ToString().Length == 1 && DateTime.Now.Second.ToString().Length == 1)
            //    {
            //        label3.Content = "" + DateTime.Now.Hour + ":0"
            //          + DateTime.Now.Minute + ":0"
            //          + DateTime.Now.Second;
            //    }
            //    else if (DateTime.Now.Hour.ToString().Length == 2 && DateTime.Now.Minute.ToString().Length == 2 && DateTime.Now.Second.ToString().Length == 1)
            //    {
            //        label3.Content = "" + DateTime.Now.Hour + ":"
            //          + DateTime.Now.Minute + ":0"
            //          + DateTime.Now.Second;
            //    }
            //    else if (DateTime.Now.Hour.ToString().Length == 2 && DateTime.Now.Minute.ToString().Length == 2 && DateTime.Now.Second.ToString().Length == 2)
            //    {
            //        label3.Content = "" + DateTime.Now.Hour + ":"
            //          + DateTime.Now.Minute + ":"
            //          + DateTime.Now.Second;
            //    }
            //    else if (DateTime.Now.Hour.ToString().Length == 1 && DateTime.Now.Minute.ToString().Length == 2 && DateTime.Now.Second.ToString().Length == 2)
            //    {
            //        label3.Content = "0" + DateTime.Now.Hour + ":"
            //          + DateTime.Now.Minute + ":"
            //          + DateTime.Now.Second;
            //    }
            //    else if (DateTime.Now.Hour.ToString().Length == 1 && DateTime.Now.Minute.ToString().Length == 1 && DateTime.Now.Second.ToString().Length == 2)
            //    {
            //        label3.Content = "0" + DateTime.Now.Hour + ":0"
            //          + DateTime.Now.Minute + ":"
            //          + DateTime.Now.Second;
            //    }
            //    else if (DateTime.Now.Hour.ToString().Length == 1 && DateTime.Now.Minute.ToString().Length == 2 && DateTime.Now.Second.ToString().Length == 1)
            //    {
            //        label3.Content = "0" + DateTime.Now.Hour + ":"
            //          + DateTime.Now.Minute + ":0"
            //          + DateTime.Now.Second;
            //    }
            //    else if (DateTime.Now.Hour.ToString().Length == 2 && DateTime.Now.Minute.ToString().Length == 1 && DateTime.Now.Second.ToString().Length == 2)
            //    {
            //        label3.Content = "" + DateTime.Now.Hour + "0:"
            //          + DateTime.Now.Minute + ":"
            //          + DateTime.Now.Second;
            //    }
            //});

        }

        public void FillCombo()
        {
            try
            {
                obCategoriesClass.flage = "comboFill";
                POSManagementService mangementServ = new POSManagementService();
                mangementServ.LoadCategoryInfo(obCategoriesClass);
                cmb_select_category.ItemsSource = obCategoriesClass.loadCategory.DefaultView;
                cmb_select_category.DisplayMemberPath = "Cat_ID";
                cmb_select_category.SelectedValuePath = "Cat_ID";
            }
            catch(Exception)
            { }
        }

        private void btn_categ_exit_Click(object sender, RoutedEventArgs e)
        {
            if (btn_categ_exit.Content.Equals("Exit"))
            {
                this.Close();
            }
            if (btn_categ_exit.Content.Equals("Cancel"))
            {
                btn_categ_add.Content = "Add";
                btn_categ_exit.Content = "Exit";
                btn_categ_delete.IsHitTestVisible = true;
                btn_cate_next.IsEnabled = true;
                btn_cate_prev.IsEnabled = true;
                cmb_select_category.Visibility = Visibility.Visible;
                btn_categ_update.IsEnabled = true;
                txt_categ_id.Focus();
                txt_categ_id.Background = Brushes.White;
                FillCombo();
                txt_categ_id.IsEnabled = false;
                lblSearch.Visibility = Visibility.Visible;
            }
        }

        private void btn_categ_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btn_categ_add.Content.Equals("Add"))
                {
                    btn_categ_add.Content = "Save";
                    btn_categ_exit.Content = "Cancel";
                    btn_categ_delete.IsEnabled = false;
                    btn_cate_next.IsEnabled = false;
                    btn_cate_prev.IsEnabled = false;
                    cmb_select_category.Visibility = Visibility.Hidden;
                    btn_categ_update.IsEnabled = false;                  
                    txt_categ_id.Clear();
                    txt_categ_description.Clear();
                    txt_categ_id.IsEnabled = true;
                    txt_categ_id.Focus();
                    txt_categ_id.Background = Brushes.Yellow;
                    lblSearch.Visibility = Visibility.Hidden;
                    
                }
                else if (btn_categ_add.Content.Equals("Save"))
                {

                    CategoriesClass obCategoriesClass = new CategoriesClass();
                    if (txt_categ_id.Text == "")
                    {
                        MessageBox.Show("In Order to Add a Category you must Enter a Category ID", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    obCategoriesClass.flage = "insert";
                    obCategoriesClass.Cat_ID = txt_categ_id.Text;
                    obCategoriesClass.Description = txt_categ_description.Text;
                    POSManagementService mangementServ = new POSManagementService();
                    mangementServ.InsertCategoryInfo(obCategoriesClass);
                    if (obCategoriesClass.IsSuccessfull == true)
                    {
                        FillCombo();
                        //MessageBox.Show("Record Have Added Succesfully", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                        var result = MessageBox.Show("Your Category has been Added, Would you like to Add another?", "Info Prompt", MessageBoxButton.YesNo, MessageBoxImage.Information);
                        if (result == MessageBoxResult.Yes)
                        {
                            btn_categ_add.Content = "Save";
                            btn_categ_exit.Content = "Cancel";
                            btn_categ_delete.IsEnabled = false;
                            btn_cate_next.IsEnabled = false;
                            btn_cate_prev.IsEnabled = false;
                            cmb_select_category.Visibility = Visibility.Hidden;
                            btn_categ_update.IsEnabled = false;
                            txt_categ_id.Focus();
                            txt_categ_id.Background = Brushes.Yellow;
                            txt_categ_id.Clear();
                            txt_categ_description.Clear();
                        }
                        else
                        {
                            btn_categ_add.Content = "Add";
                            btn_categ_exit.Content = "Exit";
                            btn_categ_delete.IsEnabled = true;
                            btn_cate_next.IsEnabled = true;
                            btn_cate_prev.IsEnabled = true;
                            cmb_select_category.Visibility = Visibility.Visible;
                            btn_categ_update.IsEnabled = true;
                            txt_categ_id.Focus();
                            txt_categ_id.Background = Brushes.White;
                            txt_categ_id.IsEnabled = false;
                            lblSearch.Visibility = Visibility.Visible;
                        }
                    }

                }
            }
            catch(Exception)
            { }
        }

        private void btn_categ_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CategoriesClass obCategoriesClass = new CategoriesClass();
                obCategoriesClass.flage = "update";
                obCategoriesClass.Cat_ID = txt_categ_id.Text;
                obCategoriesClass.Description = txt_categ_description.Text;
                POSManagementService mangementServ = new POSManagementService();
                mangementServ.InsertCategoryInfo(obCategoriesClass);
                if (obCategoriesClass.IsSuccessfull == true)
                {
                    MessageBox.Show("Record Have Updated Succesfully", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                FillCombo();
            }
            catch(Exception)
            { }
        }

        private void btn_categ_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CategoriesClass obCategoriesClass = new CategoriesClass();
                obCategoriesClass.flage = "delete";
                obCategoriesClass.Cat_ID = txt_categ_id.Text;
                obCategoriesClass.Description = txt_categ_description.Text;
                POSManagementService mangementServ = new POSManagementService();
                var result = MessageBox.Show("Are you sure you Want to Delete this Category", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    mangementServ.InsertCategoryInfo(obCategoriesClass);
                    if (obCategoriesClass.IsSuccessfull == true)
                    {
                        FillCombo();
                        MessageBox.Show("Record Have Deleted Succesfully", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if(obCategoriesClass.IsSuccessfull == false)
                    {
                        MessageBox.Show("This Category cannot be Deleted, as it is used.", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_categ_id.Text != null || txt_categ_description.Text != null)
                {
                    FillCombo();
                    cmb_select_category.SelectedIndex = 0;
                    txt_categ_id.IsEnabled = false;
                }
            }
            catch(Exception)
            { }
        }

        private void btn_cate_next_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int count = cmb_select_category.Items.Count;

                if (cmb_select_category.SelectedIndex != count)
                {
                    cmb_select_category.SelectedIndex = cmb_select_category.SelectedIndex + 1;
                }
                else
                {
                    cmb_select_category.SelectedIndex = 0;
                }
            }
            catch(Exception)
            {

            }
        }

        private void btn_cate_prev_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = cmb_select_category.Items.Count;

                if (cmb_select_category.SelectedIndex != 0)
                {
                    cmb_select_category.SelectedIndex = cmb_select_category.SelectedIndex - 1;
                }
                else
                {
                    cmb_select_category.SelectedIndex = cmb_select_category.SelectedIndex + count;
                }
            }
            catch(Exception)
            { }
        }

        private void cmb_select_category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CategoriesClass objCategory = new CategoriesClass();
                objCategory.flage = "RetriveRecord";
                objCategory.Cat_ID = cmb_select_category.SelectedValue.ToString();
                POSManagementService mangementServ = new POSManagementService();
                mangementServ.LoadCategoryInfo(objCategory);
                if (objCategory.loadCategorydt.Rows.Count > 0)
                {
                    txt_categ_description.Text = objCategory.loadCategorydt.Rows[0]["Description"].ToString();
                    txt_categ_id.Text = objCategory.loadCategorydt.Rows[0]["Cat_ID"].ToString();
                }
            }
            catch(Exception)
            {

            }         
        }

        private void txt_categ_id_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Background = Brushes.Yellow;
        }

        private void txt_categ_id_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Background = Brushes.White;
        }
    }
}
