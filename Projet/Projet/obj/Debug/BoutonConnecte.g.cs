﻿#pragma checksum "..\..\BoutonConnecte.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2548733AEA08262355EACA67B5133B69"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Projet;
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


namespace Projet {
    
    
    /// <summary>
    /// BoutonConnecte
    /// </summary>
    public partial class BoutonConnecte : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\BoutonConnecte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ajout;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\BoutonConnecte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button modif;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\BoutonConnecte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button suppr;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\BoutonConnecte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button comment;
        
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
            System.Uri resourceLocater = new System.Uri("/Projet;component/boutonconnecte.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BoutonConnecte.xaml"
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
            this.ajout = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\BoutonConnecte.xaml"
            this.ajout.Click += new System.Windows.RoutedEventHandler(this.Ajout);
            
            #line default
            #line hidden
            return;
            case 2:
            this.modif = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\BoutonConnecte.xaml"
            this.modif.Click += new System.Windows.RoutedEventHandler(this.Modif);
            
            #line default
            #line hidden
            return;
            case 3:
            this.suppr = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\BoutonConnecte.xaml"
            this.suppr.Click += new System.Windows.RoutedEventHandler(this.Suppr);
            
            #line default
            #line hidden
            return;
            case 4:
            this.comment = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\BoutonConnecte.xaml"
            this.comment.Click += new System.Windows.RoutedEventHandler(this.Comment);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

