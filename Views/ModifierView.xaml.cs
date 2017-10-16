﻿using PERform.Models;
using PERform.Viewmodels;
using System;
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

namespace PERform.Views
{
    /// <summary>
    /// Interaction logic for ModifierView.xaml
    /// </summary>
    public partial class ModifierView : UserControl
    {
        public ModifierView(FileSelector fileSelector)
        {
            InitializeComponent();
            DataContext = new ModifierViewModel(fileSelector);
        }
    }
}
