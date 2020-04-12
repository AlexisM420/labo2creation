using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using app_models;
using BillingManagement.Models;

namespace BillingManagement.Business
{
    public class InvoicesDataService : IDataService<Invoice>
    {
        readonly List<Invoice> invoices;
        readonly CustomersDataService customersDataService = new CustomersDataService();

        private ObservableCollection<Customer> customers;
        public InvoicesDataService()
        {
            customers = new ObservableCollection<Customer>(customersDataService.GetAll());
            //List<ContactInfo> contactInfos = new ContactInfosDataService().GetAll().ToList();

            Random rnd = new Random();

            foreach (Customer c in customers)
            {
                //c.in = new ObservableCollection<ContactInfo>();

                //var nbContacts = rnd.Next(1, 4);

                //for (int i = 0; i < nbContacts; i++)
                //{
                //    var index = rnd.Next(contactInfos.Count);
                //    var ci = contactInfos[index];
                //    c.ContactInfos.Add(ci);
                //}


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
