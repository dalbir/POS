﻿#pragma checksum "..\..\..\Views\StoreStationForm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "777F436A08D32801CCC6464550AC263E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
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
    /// StoreStationForm
    /// </summary>
    public partial class StoreStationForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox groupBox1;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstb_stores;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lsb_stations;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_select_dept;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_add_station;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_done;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_store_cancel;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label3;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_store_id;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\StoreStationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_station_id;
        
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
            System.Uri resourceLocater = new System.Uri("/POS.Retail;component/views/storestationform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\StoreStationForm.xaml"
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
            
            #line 4 "..\..\..\Views\StoreStationForm.xaml"
            ((POS.Retail.StoreStationForm)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.groupBox1 = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 3:
            this.lstb_stores = ((System.Windows.Controls.ListBox)(target));
            
            #line 8 "..\..\..\Views\StoreStationForm.xaml"
            this.lstb_stores.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lstb_stores_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lsb_stations = ((System.Windows.Controls.ListBox)(target));
            
            #line 9 "..\..\..\Views\StoreStationForm.xaml"
            this.lsb_stations.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lsb_stations_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmb_select_dept = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btn_add_station = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Views\StoreStationForm.xaml"
            this.btn_add_station.Click += new System.Windows.RoutedEventHandler(this.btn_add_station_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_done = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.btn_store_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Views\StoreStationForm.xaml"
            this.btn_store_cancel.Click += new System.Windows.RoutedEventHandler(this.btn_store_cancel_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.label3 = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.lbl_store_id = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.lbl_station_id = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

