﻿#pragma checksum "..\..\..\Views\TaxSetupForm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C5F7C459A73312293EE59344AE20793F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace POS.Retail {
    
    
    /// <summary>
    /// TaxSetupForm
    /// </summary>
    public partial class TaxSetupForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Views\TaxSetupForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabControl1;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\Views\TaxSetupForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabItem1;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Views\TaxSetupForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.DataGridView DG_tax_rates;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\TaxSetupForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DG_area_rates;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\TaxSetupForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_add_tax_area;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\TaxSetupForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_remove_tax_area;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\TaxSetupForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_change_rate_taxarea;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Views\TaxSetupForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_update_rates;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Views\TaxSetupForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cancel_rates;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/POS.Retail;component/views/taxsetupform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\TaxSetupForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\Views\TaxSetupForm.xaml"
            ((POS.Retail.TaxSetupForm)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tabControl1 = ((System.Windows.Controls.TabControl)(target));
            return;
            case 3:
            this.tabItem1 = ((System.Windows.Controls.TabItem)(target));
            return;
            case 4:
            this.DG_tax_rates = ((System.Windows.Forms.DataGridView)(target));
            return;
            case 5:
            this.DG_area_rates = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btn_add_tax_area = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Views\TaxSetupForm.xaml"
            this.btn_add_tax_area.Click += new System.Windows.RoutedEventHandler(this.btn_add_tax_area_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_remove_tax_area = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Views\TaxSetupForm.xaml"
            this.btn_remove_tax_area.Click += new System.Windows.RoutedEventHandler(this.btn_remove_tax_area_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_change_rate_taxarea = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Views\TaxSetupForm.xaml"
            this.btn_change_rate_taxarea.Click += new System.Windows.RoutedEventHandler(this.btn_change_rate_taxarea_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_update_rates = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\Views\TaxSetupForm.xaml"
            this.btn_update_rates.Click += new System.Windows.RoutedEventHandler(this.btn_update_rates_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_cancel_rates = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\Views\TaxSetupForm.xaml"
            this.btn_cancel_rates.Click += new System.Windows.RoutedEventHandler(this.btn_cancel_rates_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

