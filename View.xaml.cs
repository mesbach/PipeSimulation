using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Water_Flow_Simulation_v1.Pipa;

namespace Water_Flow_Simulation_v1
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {
        public View()
        {
            InitializeComponent();
        }
        public View(List<BeanTable> datasource) {
            InitializeComponent();
            view.ItemsSource = datasource;
        }

    }
}
