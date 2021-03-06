#pragma checksum "..\..\..\..\Pages\Products.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4CB2F8C44E9DBE5B3D98131D2F7E17A28A920C99"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EasyChair2.Controls;
using EasyChair2.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace EasyChair2.Pages {
    
    
    /// <summary>
    /// Products
    /// </summary>
    public partial class Products : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Pages\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbSearch;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Pages\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbSort;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Pages\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbFilt;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Pages\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LvProducts;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Pages\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TbCount;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Pages\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PagePanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EasyChair2;component/pages/products.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Products.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\..\Pages\Products.xaml"
            this.TbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchChanged);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\Pages\Products.xaml"
            this.TbSearch.GotFocus += new System.Windows.RoutedEventHandler(this.SearchGotFocus);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\Pages\Products.xaml"
            this.TbSearch.LostFocus += new System.Windows.RoutedEventHandler(this.SearchLostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CbSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\..\Pages\Products.xaml"
            this.CbSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SortChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CbFilt = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\..\..\Pages\Products.xaml"
            this.CbFilt.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FiltChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LvProducts = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.TbCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.PagePanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

