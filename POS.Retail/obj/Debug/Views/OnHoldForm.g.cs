﻿#pragma checksum "..\..\..\Views\OnHoldForm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6395084C1101E2760B3278B027FE29A7"
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
    /// OnHoldForm
    /// </summary>
    public partial class OnHoldForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Views\OnHoldForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_onhold;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Views\OnHoldForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_scroll_down;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Views\OnHoldForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_scroll_up;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Views\OnHoldForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cancel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Views\OnHoldForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_select;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Views\OnHoldForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_type_in;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\OnHoldForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_type_holdid;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\OnHoldForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\OnHoldForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
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
            System.Uri resourceLocater = new System.Uri("/POS.Retail;component/views/onholdform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\OnHoldForm.xaml"
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
            
            #line 4 "..\..\..\Views\OnHoldForm.xaml"
            ((POS.Retail.OnHoldForm)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dg_onhold = ((System.Windows.Controls.DataGrid)(target));
            
            #line 6 "..\..\..\Views\OnHoldForm.xaml"
            this.dg_onhold.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dg_onhold_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_scroll_down = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Views\OnHoldForm.xaml"
            this.btn_scroll_down.Click += new System.Windows.RoutedEventHandler(this.btn_scroll_down_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_scroll_up = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Views\OnHoldForm.xaml"
            this.btn_scroll_up.Click += new System.Windows.RoutedEventHandler(this.btn_scroll_up_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Views\OnHoldForm.xaml"
            this.btn_cancel.Click += new System.Windows.RoutedEventHandler(this.btn_cancel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_select = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Views\OnHoldForm.xaml"
            this.btn_select.Click += new System.Windows.RoutedEventHandler(this.btn_select_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_type_in = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Views\OnHoldForm.xaml"
            this.btn_type_in.Click += new System.Windows.RoutedEventHandler(this.btn_type_in_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txt_type_holdid = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\Views\OnHoldForm.xaml"
            this.txt_type_holdid.KeyDown += new System.Windows.Input.KeyEventHandler(this.txt_type_holdid_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

