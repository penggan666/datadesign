﻿#pragma checksum "..\..\fix.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7617C3FF38ED931EB0167E004470719715E52E1E"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
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
using datadesign;


namespace datadesign {
    
    
    /// <summary>
    /// fix
    /// </summary>
    public partial class fix : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\fix.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar toolBar;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\fix.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\fix.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButton1;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\fix.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButton2;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\fix.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\fix.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu dgmenu1;
        
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
            System.Uri resourceLocater = new System.Uri("/datadesign;component/fix.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\fix.xaml"
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
            this.toolBar = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 2:
            this.radioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\fix.xaml"
            this.radioButton.Checked += new System.Windows.RoutedEventHandler(this.radioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.radioButton1 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 17 "..\..\fix.xaml"
            this.radioButton1.Checked += new System.Windows.RoutedEventHandler(this.radioButton1_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.radioButton2 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 18 "..\..\fix.xaml"
            this.radioButton2.Checked += new System.Windows.RoutedEventHandler(this.radioButton2_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\fix.xaml"
            this.dataGrid.ContextMenuOpening += new System.Windows.Controls.ContextMenuEventHandler(this.dataGrid_ContextMenuOpening);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dgmenu1 = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 7:
            
            #line 23 "..\..\fix.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
