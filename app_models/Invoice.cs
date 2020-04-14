using app_models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace BillingManagement.Models
{
    public class Invoice : INotifyPropertyChanged
    {
        public int InvoiceId { get;  set; }

        readonly DateTime creationDateTime;
        private Customer customer;
        private double subTotal;
        public int globalID = 0;


        public double fedTax;
        public double provTax;
        public double total;
        #region Propriétés

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
                //OnPropertyChanged(nameof(FedTax));
                //OnPropertyChanged(nameof(ProvTax));
                //OnPropertyChanged(nameof(Total));
            }
        }

        public double FedTax
        {
            get => SubTotal * 0.05;
            set
            {
                fedTax = value;
            }
        }

        public double ProvTax
        {
            get => SubTotal * 0.0975;
            set
            {
                provTax = value;
            }
        }

        public double Total
        {
            get => SubTotal + FedTax + ProvTax;
            set
            {
                total = value;
            }
        }

        public DateTime CreationDateTime { get; set; }
        #endregion

        //public double FedTax => SubTotal*0.05;
        //public double ProvTax => SubTotal * 0.0975;
        //public double Total => SubTotal + FedTax + ProvTax;

        public Invoice()
        {
            InvoiceId = Interlocked.Increment(ref globalID);             // might be autoincrement solution
            creationDateTime = DateTime.Now;
            //InvoiceId++;
            //Debug.WriteLine(InvoiceId);
        }

        public Invoice(Customer c)
        {
            InvoiceId = Interlocked.Increment(ref globalID);             // might be autoincrement solution
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
