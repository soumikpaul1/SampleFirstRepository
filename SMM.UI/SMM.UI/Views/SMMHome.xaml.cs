using SMM.Contract.View;
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
using System.Windows.Shapes;
using SMM.Contract.ViewModel;
using MahApps.Metro.Controls;
using SMM.UI.ViewModels;
using SMM.UI.ViewModels.QualGroups;

namespace SMM.UI.Views
{
    /// <summary>
    /// Interaction logic for SMMHome.xaml
    /// </summary>
    public partial class SMMHome : MetroWindow
    {
        

        public SMMHome(SMMHomeViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
