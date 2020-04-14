using app_models;
using BillingManagement.Models;
using BillingManagement.UI.ViewModels.Commands;
using BillingManagement.UI.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel leftVM;

        public BaseViewModel LeftVM
        {
            get { return leftVM;  }
            set
            {
                leftVM = value;
                OnPropertyChanged();
            }
        }

        private BaseViewModel rightVM;

        public BaseViewModel RightVM
        {
            get { return rightVM; }
            set
            {
                rightVM = value;
                OnPropertyChanged();
            }
        }
        CustomerListViewModel customerListViewModel;
        CustomerViewModel customerViewModel;

        InvoiceViewModel invoiceViewModel;
        InvoiceListViewModel invoiceListViewModel;

        public ChangeViewCmd ChangeViewCmd { get; set; }

        public MainViewModel()
        {
            ChangeViewCmd = new ChangeViewCmd(ChangeView);

            customerViewModel = new CustomerViewModel();
            customerListViewModel = new CustomerListViewModel(customerViewModel);

            invoiceViewModel = new InvoiceViewModel();
            invoiceListViewModel = new InvoiceListViewModel(invoiceViewModel);

            LeftVM = customerListViewModel;
            RightVM = customerViewModel;
        }

        private void ChangeView(string vm)
        {
            switch (vm)
            {
                case "Clients":
                    LeftVM = customerListViewModel;
                    RightVM = customerViewModel;
                    break;
                case "Factures":
                    LeftVM = invoiceListViewModel;
                    RightVM = invoiceViewModel;
                    break;
            }
        }
    }
}
