﻿#pragma checksum "..\..\..\Factura.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B5A61C3374C2D460C382D37407A94790EDFEC435"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AppEscritorio;
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


namespace AppEscritorio {
    
    
    /// <summary>
    /// Factura
    /// </summary>
    public partial class Factura : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\Factura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Seccion2;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Factura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RFCTextBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Factura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FacturaTextBlock;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Factura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Seccion1;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Factura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FechaTextBlock;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Factura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MontoTextBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Factura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox IdAgregarComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AppEscritorio;component/factura.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Factura.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 18 "..\..\..\Factura.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Inicio_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 20 "..\..\..\Factura.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Persona_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 21 "..\..\..\Factura.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Persona_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 22 "..\..\..\Factura.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Persona_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 26 "..\..\..\Factura.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Seccion_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 27 "..\..\..\Factura.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Seccion_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Seccion2 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.RFCTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\Factura.xaml"
            this.RFCTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\Factura.xaml"
            this.RFCTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 39 "..\..\..\Factura.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BuscarFactura_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.FacturaTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.Seccion1 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 12:
            this.FechaTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.MontoTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\Factura.xaml"
            this.MontoTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\Factura.xaml"
            this.MontoTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 14:
            this.IdAgregarComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            
            #line 51 "..\..\..\Factura.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GuardarFactura_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

