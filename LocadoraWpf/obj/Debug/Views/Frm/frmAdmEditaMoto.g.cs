﻿#pragma checksum "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B4B031C5035F92BB69AF052626A7C9F01AFC364F"
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
    /// frmAdmEditaMoto
    /// </summary>
    public partial class frmAdmEditaMoto : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNome;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtModelo;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCor;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtValorPorDia;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtValorPorHora;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStatus;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditar;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSair;
        
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
            System.Uri resourceLocater = new System.Uri("/LocadoraWpf;component/views/frm/frmadmeditamoto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml"
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
            this.txtNome = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtModelo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtCor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtValorPorDia = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtValorPorHora = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtStatus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnEditar = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml"
            this.btnEditar.Click += new System.Windows.RoutedEventHandler(this.BtnEditarMoto_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnSair = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\Views\Frm\frmAdmEditaMoto.xaml"
            this.btnSair.Click += new System.Windows.RoutedEventHandler(this.BtnSair_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

