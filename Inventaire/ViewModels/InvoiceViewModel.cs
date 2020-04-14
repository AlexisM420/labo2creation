using app_models;
using BillingManagement.Business;
using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    public class InvoiceViewModel : BaseViewModel
    {
        private Invoice invoice;
        public Invoice Invoice
        {
            get => invoice;
             set
            {
                invoice = value;
                OnPropertyChanged();
            }
        }

    }
}
