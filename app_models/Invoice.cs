using app_models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace BillingManagement.Models
{
    public class Invoice : INotifyPropertyChanged
    {
        public static int invoiceId = 0;
        readonly DateTime creationDateTime;
        private Customer customer;
        private double subTotal;

        #region Propriétés

        public int InvoiceId { get; set; }

        public Customer Customer
        {
            get => customer;
            set
            {
                customer=value;
                OnPropertyChanged();
            }
        }

        public double SubTotal
        {
            get => subTotal;
            set
            {
                subTotal=value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FedTax));
                OnPropertyChanged(nameof(ProvTax));
                OnPropertyChanged(nameof(Total));
            }
        }

        public DateTime CreationDateTime { get; set; }
        #endregion

        public double FedTax => SubTotal*0.05;
        public double ProvTax => SubTotal * 0.0975;
        public double Total => SubTotal + FedTax + ProvTax;

        public Invoice()
        {
            invoiceId = Interlocked.Increment(ref invoiceId);             // might be autoincrement solution
            creationDateTime = DateTime.Now;
        }

        public Invoice(Customer c)
        {
            invoiceId = Interlocked.Increment(ref invoiceId);             // might be autoincrement solution
            Customer = c;
            creationDateTime = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
