﻿#pragma checksum "..\..\..\..\Models\Windows\Log.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "77A80E3E86A815D668414F814A63D1D76631AB61689377BAE44BCFD027C560B3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Practic.Models.Windows;
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


namespace Practic.Models.Windows {
    
    
    /// <summary>
    /// Log
    /// </summary>
    public partial class Log : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Models\Windows\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image logo;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Models\Windows\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Log_tb;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Models\Windows\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Pas_tb;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Models\Windows\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image open_eye;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Models\Windows\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image close_eye;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Models\Windows\Log.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Enter_btn;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Models\Windows\Log.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Practic;component/models/windows/log.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Models\Windows\Log.xaml"
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
            
            #line 8 "..\..\..\..\Models\Windows\Log.xaml"
            ((Practic.Models.Windows.Log)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.logo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.Log_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\..\Models\Windows\Log.xaml"
            this.Log_tb.GotFocus += new System.Windows.RoutedEventHandler(this.Log_tb_GotFocus);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\..\Models\Windows\Log.xaml"
            this.Log_tb.LostFocus += new System.Windows.RoutedEventHandler(this.Log_tb_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Pas_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\..\Models\Windows\Log.xaml"
            this.Pas_tb.GotFocus += new System.Windows.RoutedEventHandler(this.Pas_tb_GotFocus);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\..\Models\Windows\Log.xaml"
            this.Pas_tb.LostFocus += new System.Windows.RoutedEventHandler(this.Pas_tb_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.open_eye = ((System.Windows.Controls.Image)(target));
            
            #line 21 "..\..\..\..\Models\Windows\Log.xaml"
            this.open_eye.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.open_eye_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.close_eye = ((System.Windows.Controls.Image)(target));
            
            #line 22 "..\..\..\..\Models\Windows\Log.xaml"
            this.close_eye.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.close_eye_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Enter_btn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Models\Windows\Log.xaml"
            this.Enter_btn.Click += new System.Windows.RoutedEventHandler(this.Show_btn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Reg_lb = ((System.Windows.Controls.Label)(target));
            
            #line 45 "..\..\..\..\Models\Windows\Log.xaml"
            this.Reg_lb.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Reg_lb_MouseEnter);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\..\Models\Windows\Log.xaml"
            this.Reg_lb.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Reg_lb_MouseLeave);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\..\Models\Windows\Log.xaml"
            this.Reg_lb.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Reg_lb_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

