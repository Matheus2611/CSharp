﻿#pragma checksum "..\..\..\..\Views\Frm\frmReservaCarro.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B41D9A479BC46A867802B142D8EFCA0065AE0C43"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LocadoraWpf.Views.Frm;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace LocadoraWpf.Views.Frm {
    
    
    /// <summary>
    /// frmReservaCarro
    /// </summary>
    public partial class frmReservaCarro : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Views\Frm\frmReservaCarro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtReserva;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Views\Frm\frmReservaCarro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboHoraReserva;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Views\Frm\frmReservaCarro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirmar;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Views\Frm\frmReservaCarro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboHoraDevolucao;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\Views\Frm\frmReservaCarro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtDevolucao;
        
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
            System.Uri resourceLocater = new System.Uri("/LocadoraWpf;component/views/frm/frmreservacarro.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Frm\frmReservaCarro.xaml"
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
            this.dtReserva = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.cboHoraReserva = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.btnConfirmar = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\Views\Frm\frmReservaCarro.xaml"
            this.btnConfirmar.Click += new System.Windows.RoutedEventHandler(this.BtnConfirmar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cboHoraDevolucao = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.dtDevolucao = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
