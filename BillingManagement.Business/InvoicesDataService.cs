using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using app_models;
using BillingManagement.Models;

namespace BillingManagement.Business
{
    public class InvoicesDataService : IDataService<Invoice>
    {
        readonly List<Invoice> invoices = new List<Invoice>();

        List<Customer> customers = new CustomersDataService().GetAll().ToList();

        public InvoicesDataService()
        {
            Random rdm = new Random();

            for(int i = 0; i < 100; i++)
            {
                int total = rdm.Next(20, 2000);
                Invoice invoicee = new Invoice() { SubTotal = total, InvoiceId=i,Customer=customers[i] };
                invoices.Add(invoicee);
            }
        }
        public IEnumerable<Invoice> GetAll()
        {
            foreach (Invoice c in invoices)
            {
                yield return c;
            }
        }
    }
}
