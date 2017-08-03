using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SMM.UI.ViewModels.QualGroups;

namespace SMM.UI.UserControls
{
    /// <summary>
    /// Interaction logic for QualifierGroupUc.xaml
    /// </summary>
    public partial class QualifierGroupUc : UserControl
    {
        private readonly ColumnDefinition _column1CloneForLayer0;
        private IQualifierGroupViewModel _viewModel;
        public QualifierGroupUc()
        {
            InitializeComponent();
            _column1CloneForLayer0 = new ColumnDefinition() { SharedSizeGroup = "column1" };
        }

        private void BtnQualGroupFilters_OnMouseEnter(object sender, MouseEventArgs e)
        {
            FilterGrid.Visibility = Visibility.Visible;

            Panel.SetZIndex(FilterGrid,1);
        }

        private void QualifierDetailsGrid_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (BtnQualGroupFilters.Visibility == Visibility.Visible)
            {
                FilterGrid.Visibility = Visibility.Collapsed;
            }
        }


        private void BtnPane1Pin_OnClick(object sender, RoutedEventArgs e)
        {
            var pinButton = TryFindResource("BtnPane1Pin") as Button;
            if (BtnQualGroupFilters.Visibility == Visibility.Collapsed)
            {
                UnDockFilterGridPane();
                if (pinButton != null)
                {
                   pinButton.LayoutTransform = new RotateTransform() {Angle = 45};
                }
            }
            else
            {
                DockFilterGridPane();
                if (pinButton != null)
                {
                    pinButton.LayoutTransform = new RotateTransform() { Angle = -45 };
                }
            }
        }

        private void DockFilterGridPane()
        {
            BtnQualGroupFilters.Visibility = Visibility.Collapsed;
            QualifierDetailsGrid.ColumnDefinitions.Add(_column1CloneForLayer0);
        }

        private void UnDockFilterGridPane()
        {
            FilterGrid.Visibility = Visibility.Visible;
            BtnQualGroupFilters.Visibility = Visibility.Visible;
            QualifierDetailsGrid.ColumnDefinitions.Remove(_column1CloneForLayer0);
        }

        private void QualifierGroupUc_OnLoaded(object sender, RoutedEventArgs e)
        {
            var dc = DataContext;
        }
    }
}
