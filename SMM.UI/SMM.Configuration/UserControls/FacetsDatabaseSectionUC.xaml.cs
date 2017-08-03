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
using SMM.Configuration.ViewModels;
using SMM.Contract.Model;
using SMM.Contract.ViewModel;
using SMM.Domain.Application;

namespace SMM.Configuration.UserControls
{
    /// <summary>
    /// Interaction logic for FacetsDatabaseSectionUC.xaml
    /// </summary>
    public partial class FacetsDatabaseSectionUC : UserControl
    {
        public FacetsDatabaseSectionUC()
        {
            InitializeComponent();
             
            this.DataContext = new FacetsDatabaseSectionViewModel();

        }

    }
}
