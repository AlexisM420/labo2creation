using BillingManagement.Business;
using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    class InvoiceListViewModel : BaseViewModel
    {
        readonly InvoicesDataService invoicesDataService = new InvoicesDataService();

        private ObservableCollection<Invoice> invoices;
        private Invoice selectedInvoice;

        public ObservableCollection<Invoice> Invoices
        {
            get => invoices;
            private set
            {
                invoices = value;
                OnPropertyChanged();
            }
        }

        public Invoice SelectedInvoice
        {
            get => selectedInvoice;
            set
            {
                selectedInvoice = value;
                invoiceViewModel.Invoice = selectedInvoice;
                OnPropertyChanged();
            }
        }

        InvoiceViewModel invoiceViewModel;
        public InvoiceListViewModel(InvoiceViewModel ivm)
        {
            InitValues();
            invoiceViewModel = ivm;
        }

        private void InitValues()
        {
            Invoices = new ObservableCollection<Invoice>(invoicesDataService.GetAll());
            Debug.WriteLine(Invoices.Count);
        }
    }
}
