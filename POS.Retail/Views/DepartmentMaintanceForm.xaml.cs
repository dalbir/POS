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
using POS.Domain;
using POS.Services.Common;
using POS.Repository.SQLServer;
using POS.Domain.Common;
using POS.Retail.Views;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for DepartmentMaintanceForm.xaml
    /// </summary>
    public partial class DepartmentMaintanceForm : Window
    {
        DepartmentClass objdptclass = new DepartmentClass();
        //DataBaseManagement db = new DataBaseManagement();
        int index = 0;
        DataTable dt = new DataTable();

        //GlobalClass glo = new GlobalClass();

        public DepartmentMaintanceForm()
        {
            InitializeComponent();
        }
        List<string> category_id_list = new List<string>();


        public void FillCombo()
        {
            try
            {
                if (objdptclass.flage == "0")
                {
                    objdptclass.flage = "comboFill";
                    POSManagementService objMgtServices = new POSManagementService();
                    objdptclass = objMgtServices.LoadCatIdToDpt(objdptclass);
                    cmb_cetegory.ItemsSource = objdptclass.LoadDept.DefaultView;
                    cmb_cetegory.DisplayMemberPath = "CatName";
                    cmb_cetegory.SelectedValuePath = "Cat_ID";

                    objdptclass.flage = "fillList";
                    objdptclass = objMgtServices.LoadCatIdToDpt(objdptclass);
                    for (int i = 0; i <= objdptclass.LoadDept.Rows.Count; i++)
                    {
                        category_id_list.Add(objdptclass.LoadDept.Rows[i]["Dept_ID"].ToString());
                        objdptclass.flage = "0";
                    }
                    
                }
                else
                {
                    objdptclass.flage = "comboFill";
                    POSManagementService objMgtServices = new POSManagementService();
                    objdptclass = objMgtServices.LoadCatIdToDpt(objdptclass);
                    cmb_cetegory.ItemsSource = objdptclass.LoadDept.DefaultView;
                    cmb_cetegory.DisplayMemberPath = "CatName";
                    cmb_cetegory.SelectedValuePath = "Cat_ID";

                    objdptclass.flage = "fillList";
                    objdptclass = objMgtServices.LoadCatIdToDpt(objdptclass);
                    for (int i = 0; i <= objdptclass.LoadDept.Rows.Count; i++)
                    {
                        category_id_list.Add(objdptclass.LoadDept.Rows[i]["Dept_ID"].ToString());
                    }
                }

                
               
            }
            catch (Exception ex)
            {
 
            }

            //glo.con.Open();

            //SqlCommand Query = new SqlCommand("Select Dept_ID FROM Departments", glo.con);
            //SqlDataReader rr = Query.ExecuteReader();



            //while (rr.Read())
            //{
            //    category_id_list.Add(rr["Dept_ID"].ToString());
            //}

            //rr.Close();

            //SqlCommand Query1 = new SqlCommand("Select Cat_ID FROM Categories", glo.con);
            //SqlDataReader rr1 = Query1.ExecuteReader();



            //while (rr1.Read())
            //{
            //    cmb_cetegory.Items.Add(rr1["Cat_ID"].ToString());
            //}

            //rr1.Close();

            //glo.con.Close();
        }

        public void fun_clear_allfields()
        {
            //txt_dept_id.Clear();
            txt_dept_descrption.Clear();
            txt_costper.Clear();
            txt_dept_notes.Clear();
            txt_sqfootage.Clear();
            rb_emp.IsChecked = false;
            rb_regular.IsChecked = false;
            rb_rental.IsChecked = false;
            chk_bartax.IsChecked = false;
            chk_print_dept.IsChecked = false;
            chk_req_permission.IsChecked = false;
            chk_req_serial.IsChecked = false;
            chk_sale_export.IsChecked = false;
        }

        private void btn_category_mantance_Click(object sender, RoutedEventArgs e)
        {
            CategoryMaintenance objcateg = new CategoryMaintenance();
            objcateg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            objcateg.ShowDialog();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            if (btn_exit.Content.Equals("Exit"))
            {
                this.Close();
            }
            else if (btn_exit.Content.Equals("Cancel"))
            {
                btn_add_dept.Content = "Add Department";
                btn_exit.Content = "Exit";

                btn_next.IsHitTestVisible = true;
                btn_previous.IsHitTestVisible = true;
                btn_savechages.IsHitTestVisible = true;
                btn_delete.IsHitTestVisible = true;
                txt_dept_id.Background = Brushes.White;
                btn_category_mantance.IsHitTestVisible = true;
                btn_deuplicate.IsHitTestVisible = true;
            }
        }

        private void btn_previous_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                    int count = category_id_list.Count;
                    int res = category_id_list.FindIndex(label => label == txt_dept_id.Text);

                    if (count - res != count)
                    {
                        int x = res - 1;
                        txt_dept_id.Text = category_id_list[x];
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = category_id_list.Count;
                int res = category_id_list.FindIndex(label => label == txt_dept_id.Text);

                if (count != res)
                {
                    int x = res + 1;
                    txt_dept_id.Text = category_id_list[x];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_add_dept_Click(object sender, RoutedEventArgs e)
        {
            if (btn_add_dept.Content.Equals("Add Department"))
            {
                btn_add_dept.Content = "Save";
                btn_exit.Content = "Cancel";

                btn_next.IsHitTestVisible = false;
                btn_previous.IsHitTestVisible = false;
                btn_savechages.IsHitTestVisible = false;
                btn_delete.IsHitTestVisible = false;
                txt_dept_id.Focus();
                txt_dept_id.Background = Brushes.Yellow;
                btn_category_mantance.IsHitTestVisible = false;
                btn_deuplicate.IsHitTestVisible = false;
                fun_clear_allfields();
                txt_dept_id.Clear();
                txt_dept_id.IsEnabled = true;
            }
            else if (btn_add_dept.Content.Equals("Save"))
            {
                string regular, rental, employee, printdprt, requirperm, required, bartaxt, includeinscale;
                var Type = 4;
                regular = rb_regular.IsChecked.Value.ToString();
                rental = rb_rental.IsChecked.Value.ToString();
                employee = rb_emp.IsChecked.Value.ToString();
                if (regular == "True")
                {
                    Type = 0;
                }
                else if (rental == "True")
                {
                    Type = 1;
                }
                else if (employee == "True")
                {
                    Type = 2;
                }

                var print = 0;
                var permision = 0;
                var Serial = 0;
                var tax = 0;
                var Scale = 0;

                printdprt = chk_print_dept.IsChecked.Value.ToString();
                requirperm = chk_req_permission.IsChecked.Value.ToString();
                required = chk_req_serial.IsChecked.Value.ToString();
                bartaxt = chk_bartax.IsChecked.Value.ToString();
                includeinscale = chk_sale_export.IsChecked.Value.ToString();

                if (printdprt == "True")
                {
                    print = 1;
                }
                if (requirperm == "True")
                {
                    permision = 1;
                }

                if (required == "True")
                {
                    Serial = 1;
                }
                if (bartaxt == "True")
                {
                    tax = 1;
                }
                if (includeinscale == "True")
                {
                    Scale = 1;
                }
                

                try
                {
                    if (txt_dept_id.Text.Trim() == "" || txt_dept_descrption.Text.Trim() == "" || Type == 4 || cmb_cetegory.Text.Trim() == "")
                        MessageBox.Show("You must enter Important fields of Department");
                    else
                    {

                       
                        objdptclass.Dept_ID = txt_dept_id.Text.Trim();
                        objdptclass.Store_ID = "1001";
                        objdptclass.Description = txt_dept_descrption.Text.Trim();
                        objdptclass.Type = Type;
                        objdptclass.TSDisplay = Convert.ToInt32("0");
                        objdptclass.Cost_MarkUp="0";
                        objdptclass.Dirty = Convert.ToInt32("0");
                        objdptclass.SubType = cmb_cetegory.SelectedValue.ToString();
                        objdptclass.Print_Dept_Notes = print;
                        objdptclass.Dept_Notes = txt_dept_notes.Text.Trim();
                        objdptclass.Require_Permission = permision;
                        objdptclass.Require_Serials = Serial;
                        objdptclass.BarTaxInclusive = tax;
                        objdptclass.Cost_Calculation_Percentage = txt_costper.Text.Trim();
                        objdptclass.Square_Footage =Convert.ToInt32( txt_sqfootage.Text.Trim());
                        objdptclass.AvailableOnline =Convert.ToInt32( "0");
                        objdptclass.IncludeInScaleExport = Scale;

                        POSManagementService objMgtService = new POSManagementService();
                        if (objdptclass.flage == "0")
                        {
                            objdptclass.flage = "ReadDept";
                            string ids = Convert.ToString(objMgtService.loadReadedData(objdptclass).ToString());
                            if (ids == txt_dept_id.Text)
                            {
                                MessageBox.Show("Department ID is already exist", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Error);
                                objdptclass.flage = "0";
                                return;
                            }
                        }
                        else
                        {
                            objdptclass.flage = "ReadDept";
                            string ids = Convert.ToString(objMgtService.loadReadedData(objdptclass).ToString());
                            if (ids == txt_dept_id.Text)
                            {
                                MessageBox.Show("Department ID is already exist", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Error);
                                
                                return;
                            }
                        }
                        {
                            objdptclass.flage = "insert";
                            objMgtService.InsertDeptInfo(objdptclass);
                        }
                        if(objdptclass.IsSuccessfull==true)
                        {
                            MessageBox.Show("Record Have Added Succesfully", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        fun_clear_allfields();
                        //glo.con.Open();
                        //SqlCommand Query = new SqlCommand("INSERT INTO Departments (Dept_ID, Store_ID, Description, Type, TSDisplay, Cost_MarkUp, Dirty, SubType, Print_Dept_Notes, Dept_Notes, Require_Permission, Require_Serials, " +
                        //                    "BarTaxInclusive, Cost_Calculation_Percentage, Square_Footage, AvailableOnline, IncludeInScaleExport)" +
                        //                    "VALUES('" + txt_dept_id.Text.Trim() + "','1001','" + txt_dept_descrption.Text.Trim() + "','" + Type + "','0','0','0','" + cmb_cetegory.Text.Trim() + "','" + print + "','" + txt_dept_notes.Text.Trim() + "','" + permision + "','" + Serial + "','" + tax + "','" + txt_costper.Text.Trim() + "','" + txt_sqfootage.Text.Trim() + "','0','" + Scale + "')", glo.con);

                        //Query.ExecuteNonQuery();

                        //SqlCommand refs = new SqlCommand("INSERT INTO ", glo.con);

                        //glo.con.Close();
                        
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        private void chk_print_dept_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            { 
               FillCombo();
               txt_dept_id.Text = category_id_list[0]; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void cmb_cetegory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cmb_cetegory.SelectedIndex != -1)
            //{

            //}
        }

        private void btn_savechages_Click(object sender, RoutedEventArgs e)
        {
            string regular, rental, employee, printdprt, requirperm, required, bartaxt, includeinscale;
            var Type = 4;
            regular = rb_regular.IsChecked.Value.ToString();
            rental = rb_rental.IsChecked.Value.ToString();
            employee = rb_emp.IsChecked.Value.ToString();
            if (regular == "True")
            {
                Type = 0;
            }
            else if (rental == "True")
            {
                Type = 1;
            }
            else if (employee == "True")
            {
                Type = 2;

            }

            var print = 0;
            var permision = 0;
            var Serial = 0;
            var tax = 0;
            var Scale = 0;

            printdprt = chk_print_dept.IsChecked.Value.ToString();
            requirperm = chk_req_permission.IsChecked.Value.ToString();
            required = chk_req_serial.IsChecked.Value.ToString();
            bartaxt = chk_bartax.IsChecked.Value.ToString();
            includeinscale = chk_sale_export.IsChecked.Value.ToString();

            if (printdprt == "True")
            {
                print = 1;
            }
            if (requirperm == "True")
            {
                permision = 1;
            }

            if (required == "True")
            {
                Serial = 1;

            }
            if (bartaxt == "True")
            {
                tax = 1;
            }
            if (includeinscale == "True")
            {
                Scale = 1;
            }
            
            
            objdptclass.Dept_ID = txt_dept_id.Text.Trim();
            objdptclass.Store_ID = "1001";
            objdptclass.Description = txt_dept_descrption.Text.Trim();
            objdptclass.Type = Type;
            objdptclass.TSDisplay = Convert.ToInt32("0");
            objdptclass.Cost_MarkUp = "0";
            objdptclass.Dirty = Convert.ToInt32("0");
            objdptclass.SubType = cmb_cetegory.SelectedValue.ToString();
            objdptclass.Print_Dept_Notes = print;
            objdptclass.Dept_Notes = txt_dept_notes.Text.Trim();
            objdptclass.Require_Permission = permision;
            objdptclass.Require_Serials = Serial;
            objdptclass.BarTaxInclusive = tax;
            objdptclass.Cost_Calculation_Percentage = txt_costper.Text.Trim();
            objdptclass.Square_Footage = Convert.ToInt32(txt_sqfootage.Text.Trim());
            objdptclass.AvailableOnline = Convert.ToInt32("0");
            objdptclass.IncludeInScaleExport = Scale;
            objdptclass.flage = "update";
            POSManagementService objMgtServce = new POSManagementService();
            objMgtServce.InsertDeptInfo(objdptclass);
            if (objdptclass.IsSuccessfull == true)
            {
                MessageBox.Show("Record was updated Succesfully", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            fun_clear_allfields();
            //glo.con.Open();
            //SqlCommand Query = new SqlCommand("UPDATE Departments SET Dept_ID ='" + txt_dept_id.Text.Trim() + "', Store_ID = '1001', Description = '" + txt_dept_descrption.Text.Trim() + "', Type = '" + Type + "'," +
            //    "TSDisplay = '0', Cost_MarkUp = '0', Dirty = '0', SubType = '0', Print_Dept_Notes ='" + txt_dept_notes.Text.Trim() + "', Dept_Notes = '" + txt_dept_notes.Text.Trim() + "', Require_Permission = '" + permision + "'," +
            //    "Require_Serials = '" + Serial + "', BarTaxInclusive = '" + tax + "', Cost_Calculation_Percentage = '" + txt_costper.Text.Trim() + "', Square_Footage = '" + txt_sqfootage.Text.Trim() + "'," +
            //    "AvailableOnline = '0', IncludeInScaleExport = '" + Scale + "' WHERE Dept_ID ='" + txt_dept_id.Text + "'", glo.con);

            //Query.ExecuteNonQuery();
            //glo.con.Close();
        }

        private void selectData()
        {
            fun_clear_allfields();
            objdptclass.Dept_ID = txt_dept_id.Text.Trim();
            objdptclass.flage = "SelectDept";
            POSManagementService objmbtSer = new POSManagementService();
            objmbtSer.LoadCatIdToDpt(objdptclass);
            
            if (objdptclass.LoadDept.Rows.Count > 0)
            {
                for (int i = 0; i < objdptclass.LoadDept.Rows.Count; i++)
                {
                    if (objdptclass.LoadDept.Rows[i]["Type"].ToString() == "0")
                    {
                        rb_regular.IsChecked = true;
                        rb_emp.IsChecked = false;
                        rb_rental.IsChecked = false;
                    }
                    else if (objdptclass.LoadDept.Rows[i]["Type"].ToString() == "1")
                    {
                        rb_regular.IsChecked = false;
                        rb_emp.IsChecked = true;
                        rb_rental.IsChecked = false;
                    }
                    else if (objdptclass.LoadDept.Rows[i]["Type"].ToString() == "2")
                    {
                        rb_regular.IsChecked = false;
                        rb_emp.IsChecked = false;
                        rb_rental.IsChecked = true;
                    }
                    if (objdptclass.LoadDept.Rows[i]["TSDisplay"].ToString() == "True")
                    {

                    }
                    else
                    {

                    }
                    if (objdptclass.LoadDept.Rows[i]["Print_Dept_Notes"].ToString() == "True")
                    {
                        chk_print_dept.IsChecked = true;
                    }
                    else
                    {
                        chk_print_dept.IsChecked = false;
                    }
                    txt_dept_notes.Text = objdptclass.LoadDept.Rows[i]["Dept_Notes"].ToString();

                    if (objdptclass.LoadDept.Rows[i]["Require_Permission"].ToString() == "True")
                    {
                        chk_req_permission.IsChecked = true;
                    }
                    else
                    {
                        chk_req_permission.IsChecked = false;
                    }
                    if (objdptclass.LoadDept.Rows[i]["Require_Serials"].ToString() == "True")
                    {
                        chk_req_serial.IsChecked = true;
                    }
                    else
                    {
                        chk_req_serial.IsChecked = false;
                    }
                    if (objdptclass.LoadDept.Rows[i]["BarTaxInclusive"].ToString() == "True")
                    {
                        chk_bartax.IsChecked = true;
                    }
                    else
                    {
                        chk_bartax.IsChecked = false;
                    }
                    txt_dept_descrption.Text = objdptclass.LoadDept.Rows[i]["Description"].ToString();

                    txt_costper.Text = objdptclass.LoadDept.Rows[i]["Cost_Calculation_Percentage"].ToString();
                    txt_sqfootage.Text = objdptclass.LoadDept.Rows[i]["Square_Footage"].ToString();
                    if (objdptclass.LoadDept.Rows[i]["IncludeInScaleExport"].ToString() == "True")
                    {
                        chk_sale_export.IsChecked = true;
                    }
                    else
                    {
                        chk_sale_export.IsChecked = false;
                    }
                    cmb_cetegory.SelectedValue = objdptclass.LoadDept.Rows[i]["SubType"].ToString();
                    //objdptclass.SubType = objdptclass.LoadDept.Rows[i]["SubType"].ToString();
                    //objdptclass.flage = "selectCateg";
                    //objmbtSer.LoadCatIdToDpt(objdptclass);
                    //cmb_cetegory.ItemsSource = objdptclass.LoadDept.DefaultView;
                    //cmb_cetegory.Text = "CatName";
                    //cmb_cetegory.SelectedValuePath = "Cat_ID";
                   

                }
            }
        }
        private void txt_dept_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (objdptclass.flage == "0")
            {
               // txt_dept_id.Clear();

                return;
            }
            else
            {
                selectData();
            }
            
            
            //fun_clear_allfields();
            //objdptclass.Dept_ID = txt_dept_id.Text.Trim();
            //objdptclass.flage = "SelectDept";
            //POSManagementService objmbtSer = new POSManagementService();
            //objmbtSer.LoadCatIdToDpt(objdptclass);
            //if (objdptclass.LoadDept.Rows.Count > 0)
            //{
            //    for (int i = 0; i < objdptclass.LoadDept.Rows.Count; i++)
            //    { 
            //        if (objdptclass.LoadDept.Rows[i]["Type"].ToString() == "0")
            //        {
            //            rb_regular.IsChecked = true;
            //            rb_emp.IsChecked = false;
            //            rb_rental.IsChecked = false;
            //        }
            //        else if (objdptclass.LoadDept.Rows[i]["Type"].ToString() == "1")
            //        {
            //            rb_regular.IsChecked = false;
            //            rb_emp.IsChecked = true;
            //            rb_rental.IsChecked = false;
            //        }
            //        else if (objdptclass.LoadDept.Rows[i]["Type"].ToString() == "2")
            //        {
            //            rb_regular.IsChecked = false;
            //            rb_emp.IsChecked = false;
            //            rb_rental.IsChecked = true;
            //        }
            //        if (objdptclass.LoadDept.Rows[i]["TSDisplay"].ToString() == "True")
            //        {

            //        }
            //        else
            //        {
 
            //        }
            //        if (objdptclass.LoadDept.Rows[i]["Print_Dept_Notes"].ToString() == "True")
            //        {
            //            chk_print_dept.IsChecked = true;
            //        }
            //        else
            //        {
            //            chk_print_dept.IsChecked = false;
            //        }
            //        txt_dept_notes.Text = objdptclass.LoadDept.Rows[i]["Dept_Notes"].ToString();

            //        if (objdptclass.LoadDept.Rows[i]["Require_Permission"].ToString() == "True")
            //        {
            //            chk_req_permission.IsChecked = true;
            //        }
            //        else
            //        {
            //            chk_req_permission.IsChecked = false;
            //        }
            //        if (objdptclass.LoadDept.Rows[i]["Require_Serials"].ToString() == "True")
            //        {
            //            chk_req_serial.IsChecked = true;
            //        }
            //        else
            //        {
            //            chk_req_serial.IsChecked = false;
            //        }
            //        if (objdptclass.LoadDept.Rows[i]["BarTaxInclusive"].ToString() == "True")
            //        {
            //            chk_bartax.IsChecked = true;
            //        }
            //        else
            //        {
            //            chk_bartax.IsChecked = false;
            //        }
            //        txt_costper.Text = objdptclass.LoadDept.Rows[i]["Cost_Calculation_Percentage"].ToString();
            //        txt_sqfootage.Text = objdptclass.LoadDept.Rows[i]["Square_Footage"].ToString();
            //        if (objdptclass.LoadDept.Rows[i]["IncludeInScaleExport"].ToString() == "True")
            //        {
            //            chk_sale_export.IsChecked = true;
            //        }
            //        else
            //        {
            //            chk_sale_export.IsChecked = false;
            //        }
                   
            //        objdptclass.SubType = objdptclass.LoadDept.Rows[i]["SubType"].ToString();
            //        objdptclass.flage = "selectCateg";
            //        objmbtSer.LoadCatIdToDpt(objdptclass);
            //        cmb_cetegory.ItemsSource = objdptclass.LoadDept.DefaultView;
            //        cmb_cetegory.DisplayMemberPath = "CatName";
            //        cmb_cetegory.SelectedValuePath = "Cat_ID";

            //    }
            }

    //        glo.con.Open();

    //        SqlCommand com = new SqlCommand("SELECT * FROM Departments WHERE Dept_ID = '" + txt_dept_id.Text + "'", glo.con);
    //        SqlDataReader rr = com.ExecuteReader();
    //        while (rr.Read())
    //        {
    //            txt_dept_id.Text = rr["Dept_ID"].ToString();
    //            //txt_ rr["Store_ID"];
    //            txt_dept_descrption.Text = rr["Description"].ToString();
    //            if (rr["Type"].ToString() == "1")
    //            {
    //                rb_regular.IsChecked = true;
    //                rb_emp.IsChecked = false;
    //                rb_rental.IsChecked = false;
    //            }
    //            else if (rr["Type"].ToString() == "2")
    //            {
    //                rb_rental.IsChecked = true;
    //                rb_regular.IsChecked = false;
    //                rb_emp.IsChecked = false;
    //            }
    //            else if (rr["Type"].ToString() == "3")
    //            {
    //                rb_emp.IsChecked = true;
    //                rb_rental.IsChecked = false;
    //                rb_regular.IsChecked = false;
    //            }
    //            if (rr["TSDisplay"].ToString() == "True")
    //            {

    //            }
    //            else
    //            {

    //            }
    //            //rr["Cost_MarkUp"];
    //            //rr["Dirty"];

    //            cmb_cetegory.Text = rr["SubType"].ToString();

    //            if (rr["Print_Dept_Notes"].ToString() == "True")
    //            {
    //                chk_print_dept.IsChecked = true;
    //            }
    //            else
    //            {
    //                chk_print_dept.IsChecked = false;
    //            }

    //            if (rr["Dept_Notes"].ToString() == "True")
    //            {
    //                chk_print_dept.IsChecked = true;
    //            }
    //            else
    //            {
    //                chk_print_dept.IsChecked = false;
    //            }

    //            if (rr["Require_Permission"].ToString() == "True")
    //            {
    //                chk_req_permission.IsChecked = true;
    //            }
    //            else
    //            {
    //                chk_req_permission.IsChecked = false;
    //            }

    //            if (rr["Require_Serials"].ToString() == "True")
    //            {
    //                chk_req_serial.IsChecked = true;
    //            }
    //            else
    //            {
    //                chk_req_serial.IsChecked = false;
    //            }

    //            if (rr["BarTaxInclusive"].ToString() == "True")
    //            {
    //                chk_bartax.IsChecked = true;
    //            }
    //            else
    //            {
    //                chk_bartax.IsChecked = false;
    //            }

    //            txt_costper.Text = rr["Cost_Calculation_Percentage"].ToString();
    //            txt_sqfootage.Text = rr["Square_Footage"].ToString();

    //            //rr["AvailableOnline"];
    //            if (rr["IncludeInScaleExport"].ToString() == "True")
    //            {
    //                chk_sale_export.IsChecked = true;
    //            }
    //            else
    //            { 
    //                chk_sale_export.IsChecked = false;
    //            }

    //        }



    //        glo.con.Close();
        

        private void btnLookup_Click(object sender, RoutedEventArgs e)
        {
            SelectDepartmentFrm objSlctDpt = new SelectDepartmentFrm();
            objSlctDpt.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            objSlctDpt.ShowDialog();
            if (objSlctDpt.SetDptId != null ||objSlctDpt.SetDptDescription!=null)
            {
                txt_dept_id.Text = objSlctDpt.SetDptId;
                txt_dept_descrption.Text = objSlctDpt.SetDptDescription;
            }
        }

        private void cmb_cetegory_DropDownOpened(object sender, EventArgs e)
        {
            FillCombo();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                objdptclass.Dept_ID = txt_dept_id.Text.Trim();
                objdptclass.flage = "delete";
                POSManagementService objMgtServc = new POSManagementService();
                
                var result = MessageBox.Show("Are you sure you Want to Delete this Department", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    objdptclass = objMgtServc.InsertDeptInfo(objdptclass);
                    if (objdptclass.IsSuccessfull == true)
                    {
                        FillCombo();
                        MessageBox.Show("Record Have Deleted Succesfully", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                fun_clear_allfields();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_deuplicate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                objdptclass.flage = "0";
                btn_add_dept.Content = "Save";
                btn_exit.Content = "Cancel";

                btn_next.IsHitTestVisible = false;
                btn_previous.IsHitTestVisible = false;
                btn_savechages.IsHitTestVisible = false;
                btn_delete.IsHitTestVisible = false;
                txt_dept_id.Focus();
                txt_dept_id.Background = Brushes.Yellow;
                btn_category_mantance.IsHitTestVisible = false;
                btn_deuplicate.IsHitTestVisible = false;
                
                txt_dept_id.Clear();
                txt_dept_id.IsEnabled = true;
                //if (txt_dept_id.Text == "")
                //{
                //    MessageBox.Show("Please enter Department ID", "Information", MessageBoxButton.OK, MessageBoxImage.Information); return;

                //}
                //else
                //{
                //    POSManagementService objMgtService = new POSManagementService();
                //    string ids = Convert.ToString(objMgtService.loadReadedData(objdptclass).ToString());
                //    if (ids == txt_dept_id.Text)
                //    {
                //        MessageBox.Show("Department ID is already exist", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Error);
                //        return;
                //    }
                //    else
                //    {
                //        objdptclass.flage = "insert";
                //        objMgtService.InsertDeptInfo(objdptclass);
                //    }
                //    if (objdptclass.IsSuccessfull == true)
                //    {
                //        MessageBox.Show("Record Have Added Succesfully", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                //    }
                //    fun_clear_allfields();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

       
        
    }
}
