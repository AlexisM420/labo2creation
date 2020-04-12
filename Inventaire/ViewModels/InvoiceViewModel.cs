using app_models;
using BillingManagement.Business;
using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    public class InvoiceViewModel : BaseViewModel
    {
        readonly InvoicesDataService invoicesDataService = new InvoicesDataService();

        private ObservableCollection<Invoice> invoices;

        #region Props
        public ObservableCollection<Invoice> Invoices
        {
            get => invoices;
            private set
            {
                invoices = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public InvoiceViewModel(ObservableCollection<Customer> customers)
        {
            InitValues();
        }

        private void InitValues()
        {
            Invoices = new ObservableCollection<Invoice>(invoicesDataService.GetAll());
            Debug.WriteLine(Invoices.Count);
        }
    }
}
