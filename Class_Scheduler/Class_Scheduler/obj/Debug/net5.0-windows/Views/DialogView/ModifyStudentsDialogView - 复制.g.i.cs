﻿#pragma checksum "..\..\..\..\..\Views\DialogView\ModifyStudentsDialogView - 复制.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B68F7F310C0173C6A0A9F2FF188D0DF9E420200B"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Class_Scheduler.Views.DialogView;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using Prism.DryIoc;
using Prism.Interactivity;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Services.Dialogs;
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


namespace Class_Scheduler.Views.DialogView {
    
    
    /// <summary>
    /// ModifyStudentsDialogView
    /// </summary>
    public partial class ModifyStudentsDialogView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\..\..\Views\DialogView\ModifyStudentsDialogView - 复制.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox studentName;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\Views\DialogView\ModifyStudentsDialogView - 复制.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox @class;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Views\DialogView\ModifyStudentsDialogView - 复制.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailAddr;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\Views\DialogView\ModifyStudentsDialogView - 复制.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sex;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Class_Scheduler;V1.0.0.0;component/views/dialogview/modifystudentsdialogview%20-" +
                    "%20%e5%a4%8d%e5%88%b6.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\DialogView\ModifyStudentsDialogView - 复制.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.studentName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.@class = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.emailAddr = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.sex = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

