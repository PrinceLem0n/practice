﻿#pragma checksum "..\..\Log.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "072ECA05DFA58C46A67FE3275BFBB9F59C1013FFCB46FC11504A444D3A4A0B20"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Practic;
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


namespace Practic {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image logo;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Enter_btn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Log_tb;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Pas_tb;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image open_eye;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image close_eye;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Reg_lb;
        
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
            System.Uri resourceLocater = new System.Uri("/Practic;component/log.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Log.xaml"
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
            
            #line 8 "..\..\Log.xaml"
            ((Practic.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.logo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.Enter_btn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Log.xaml"
            this.Enter_btn.Click += new System.Windows.RoutedEventHandler(this.Show_btn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Log_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\Log.xaml"
            this.Log_tb.GotFocus += new System.Windows.RoutedEventHandler(this.Log_tb_GotFocus);
            
            #line default
            #line hidden
            
            #line 39 "..\..\Log.xaml"
            this.Log_tb.LostFocus += new System.Windows.RoutedEventHandler(this.Log_tb_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Pas_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\Log.xaml"
            this.Pas_tb.GotFocus += new System.Windows.RoutedEventHandler(this.Pas_tb_GotFocus);
            
            #line default
            #line hidden
            
            #line 41 "..\..\Log.xaml"
            this.Pas_tb.LostFocus += new System.Windows.RoutedEventHandler(this.Pas_tb_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.open_eye = ((System.Windows.Controls.Image)(target));
            
            #line 42 "..\..\Log.xaml"
            this.open_eye.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.open_eye_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.close_eye = ((System.Windows.Controls.Image)(target));
            
            #line 43 "..\..\Log.xaml"
            this.close_eye.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.close_eye_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Reg_lb = ((System.Windows.Controls.Label)(target));
            
            #line 45 "..\..\Log.xaml"
            this.Reg_lb.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Reg_lb_MouseEnter);
            
            #line default
            #line hidden
            
            #line 45 "..\..\Log.xaml"
            this.Reg_lb.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Reg_lb_MouseLeave);
            
            #line default
            #line hidden
            
            #line 45 "..\..\Log.xaml"
            this.Reg_lb.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Reg_lb_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

