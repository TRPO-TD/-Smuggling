﻿#pragma checksum "..\..\..\..\Pages\DBTables\AddressPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F279878CA3E96661C406E3E1C4D74A46A7AF455B0E7836FAF148B017889E5EE4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseWork4Test.Pages.DBTables;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace CourseWork4Test.Pages.DBTables {
    
    
    /// <summary>
    /// AddressPage
    /// </summary>
    public partial class AddressPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridAddress;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LocalityTB;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StreetTB;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BuildingTB;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewRecordBtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteRecordBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveTableBtn;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateBtn;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GoBackBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseWork4Test;component/pages/dbtables/addresspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
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
            this.DataGridAddress = ((System.Windows.Controls.DataGrid)(target));
            
            #line 19 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
            this.DataGridAddress.AutoGeneratedColumns += new System.EventHandler(this.DataGridAddress_AutoGeneratedColumns);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
            this.DataGridAddress.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridAddress_Selected);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LocalityTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.StreetTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.BuildingTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.NewRecordBtn = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
            this.NewRecordBtn.Click += new System.Windows.RoutedEventHandler(this.NewRecordBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteRecordBtn = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
            this.DeleteRecordBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteRecordBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SaveTableBtn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
            this.SaveTableBtn.Click += new System.Windows.RoutedEventHandler(this.SaveTableBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.UpdateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
            this.UpdateBtn.Click += new System.Windows.RoutedEventHandler(this.UpdateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.GoBackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\Pages\DBTables\AddressPage.xaml"
            this.GoBackBtn.Click += new System.Windows.RoutedEventHandler(this.GoBackBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

