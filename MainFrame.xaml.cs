﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisualStudioExtensionDesignGuidelines
{
    /// <summary>
    /// Interaction logic for MainFrame.xaml
    /// </summary>
    public partial class MainFrame : UserControl
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        public void SetTextColor(string colorKey)
        {
            ContrastChecker.ColorKey1 = colorKey;
            ContrastChecker.Visibility = Visibility.Visible;
        }

        public void SetBackgroundColor(string colorKey)
        {
            ContrastChecker.ColorKey2 = colorKey;
            ContrastChecker.Visibility = Visibility.Visible;
        }
    }
}
