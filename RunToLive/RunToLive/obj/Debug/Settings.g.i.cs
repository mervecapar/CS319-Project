﻿#pragma checksum "..\..\Settings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DF28C09357CD97D70528CEB17CC941ED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RunToLive;
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


namespace RunToLive {
    
    
    /// <summary>
    /// Settings
    /// </summary>
    public partial class Settings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button @return;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button play;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Options;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox level;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Easy;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Medium;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Hard;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox sound;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Soundoff;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SoundOn;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox Character;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Male;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Female;
        
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
            System.Uri resourceLocater = new System.Uri("/RunToLive;component/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Settings.xaml"
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
            this.@return = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Settings.xaml"
            this.@return.Click += new System.Windows.RoutedEventHandler(this.return_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.play = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Settings.xaml"
            this.play.Click += new System.Windows.RoutedEventHandler(this.play_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Options = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.level = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 5:
            this.Easy = ((System.Windows.Controls.RadioButton)(target));
            
            #line 33 "..\..\Settings.xaml"
            this.Easy.Checked += new System.Windows.RoutedEventHandler(this.Easy_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Medium = ((System.Windows.Controls.RadioButton)(target));
            
            #line 35 "..\..\Settings.xaml"
            this.Medium.Checked += new System.Windows.RoutedEventHandler(this.Medium_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Hard = ((System.Windows.Controls.RadioButton)(target));
            
            #line 36 "..\..\Settings.xaml"
            this.Hard.Checked += new System.Windows.RoutedEventHandler(this.Hard_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.sound = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 9:
            this.Soundoff = ((System.Windows.Controls.RadioButton)(target));
            
            #line 42 "..\..\Settings.xaml"
            this.Soundoff.Checked += new System.Windows.RoutedEventHandler(this.Soundoff_Checked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SoundOn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 43 "..\..\Settings.xaml"
            this.SoundOn.Checked += new System.Windows.RoutedEventHandler(this.SoundOn_Checked);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Character = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 12:
            this.Male = ((System.Windows.Controls.RadioButton)(target));
            
            #line 48 "..\..\Settings.xaml"
            this.Male.Checked += new System.Windows.RoutedEventHandler(this.Male_Checked);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Female = ((System.Windows.Controls.RadioButton)(target));
            
            #line 49 "..\..\Settings.xaml"
            this.Female.Checked += new System.Windows.RoutedEventHandler(this.Female_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

