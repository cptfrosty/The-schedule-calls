﻿#pragma checksum "..\..\TaskShedule.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B3C7CD88780E151F503F3F552E110E516F7B6F80"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using TheScheduleCalls;


namespace TheScheduleCalls {
    
    
    /// <summary>
    /// TaskShedule
    /// </summary>
    public partial class TaskShedule : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\TaskShedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_day;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\TaskShedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_month;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\TaskShedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addTask;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\TaskShedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_main;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\TaskShedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_reduced;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\TaskShedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_trainingAllertCall;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\TaskShedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_hour;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\TaskShedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_minutes;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\TaskShedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_hour_box;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\TaskShedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_minutes_box;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\TaskShedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel sp_listTask;
        
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
            System.Uri resourceLocater = new System.Uri("/TheScheduleCalls;component/taskshedule.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TaskShedule.xaml"
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
            this.tb_day = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tb_month = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.addTask = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\TaskShedule.xaml"
            this.addTask.Click += new System.Windows.RoutedEventHandler(this.addTask_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rb_main = ((System.Windows.Controls.RadioButton)(target));
            
            #line 22 "..\..\TaskShedule.xaml"
            this.rb_main.Click += new System.Windows.RoutedEventHandler(this.HideTimeBox);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rb_reduced = ((System.Windows.Controls.RadioButton)(target));
            
            #line 23 "..\..\TaskShedule.xaml"
            this.rb_reduced.Click += new System.Windows.RoutedEventHandler(this.HideTimeBox);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rb_trainingAllertCall = ((System.Windows.Controls.RadioButton)(target));
            
            #line 24 "..\..\TaskShedule.xaml"
            this.rb_trainingAllertCall.Click += new System.Windows.RoutedEventHandler(this.ShowTimeBox);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tb_hour = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.tb_minutes = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.tb_hour_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tb_minutes_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.sp_listTask = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
