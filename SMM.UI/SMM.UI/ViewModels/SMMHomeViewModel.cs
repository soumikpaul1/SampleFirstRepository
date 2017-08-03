using SMM.Contract.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using SMM.Contract.View;
using SMM.UI.Command;
using SMM.UI.UserControls;

namespace SMM.UI.ViewModels
{
    public class SMMHomeViewModel : ViewModelBase
    {
        public SMMHomeViewModel()
        {
            ActionItems = new ObservableCollection<MetroTabItem>();
           
            OnHamburgerMenuItemClickedCommand = new DelegateCommand(OnHamburgerMenuItemClicked);
        }

        private void OnHamburgerMenuItemClicked(object obj)
        {
            var glyphItem = obj as HamburgerMenuGlyphItem;
            if (glyphItem == null) return;
            switch (glyphItem.Label)
            {
                case "Qualifier Group Maintainence":
                    //Check if already exists or not
                    if (ActionItems.Any(tabItem => string.Compare("mnuQualGroup",tabItem.Name,StringComparison.OrdinalIgnoreCase) == 0))
                        return;
                    ActionItems.Add(new MetroTabItem()
                    {
                        Name = "mnuQualGroup",
                        Header = "Qualifier Group Maintenance",
                        CloseButtonEnabled = true,
                        IsSelected = true,
                        Content = new QualifierGroupUc()
                    });
                    break;
                default:
                    break;
                        
            }
        }

        public ObservableCollection<MetroTabItem> ActionItems { get; private set; }

        public ICommand OnHamburgerMenuItemClickedCommand { get; private set; }
    }
}
