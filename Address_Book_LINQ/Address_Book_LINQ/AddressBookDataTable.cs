using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Address_Book_LINQ
{
    public class AddressBookDataTable
    {

        /// <summary>
        /// Method to Create AddressBook DataTable
        /// </summary>
        public DataTable CreateAddressBookDataTable()
        {
            DataTable addressBookDataTable = new DataTable();

            addressBookDataTable.Columns.Add("FirstName", typeof(string));
            addressBookDataTable.Columns.Add("LastName", typeof(string));
            addressBookDataTable.Columns.Add("Address", typeof(string));
            addressBookDataTable.Columns.Add("City", typeof(string));
            addressBookDataTable.Columns.Add("State", typeof(string));
            addressBookDataTable.Columns.Add("Zip", typeof(int));
            addressBookDataTable.Columns.Add("PhoneNumber", typeof(long));
            addressBookDataTable.Columns.Add("Email", typeof(string));

            //Add Values for Columns
            addressBookDataTable.Rows.Add("Amit", "Rana", "Ashish Plaza", "Pune", "MH", 663222, 8979325434, "Amit@gmail.com");
            addressBookDataTable.Rows.Add("Rohit", "Rana", "Venu Hights", "Pune", "MH", 763226, 833343210, "rohit@gmail.com");
            addressBookDataTable.Rows.Add("Neha", "Negi", "Flex Road", "Mumbai", "MH", 303222, 6876543210, "neha@gmail.com");
            addressBookDataTable.Rows.Add("Aman", "Rawat", "Neer Road", "Benglore", "Karnataka", 400028, 889000880, "aman@gmail.com");
            addressBookDataTable.Rows.Add("sumit", "Semwal", "Panji", "Panaji", "Goa", 323254, 8877743210, "sumit@gmail.com");
            addressBookDataTable.Rows.Add("Naman", "Magare", "Indor", "Indor", "MP", 485254, 7877743990, "naman@gmail.com");
            addressBookDataTable.Rows.Add("Rekha", "rani", "baroda", "Baroda", "MP", 43254, 7888743210, "rekha@gmail.com");


            return addressBookDataTable;
        }

        public void DisplayContacts(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>();
            foreach (var contact in contacts)
            {
                Console.WriteLine("\n------------------------------------");
                Console.Write("\nFirst Name : " + contact.Field<string>(0) + " " + "\nLast Name : " + contact.Field<string>("LastName") + " " + "\nAddress : " + contact.Field<string>("Address") + " " + "\nCity : " + contact.Field<string>("City") + " " + "\nState : " + contact.Field<string>("State")
                    + " " + "\nZip : " + contact.Field<int>("Zip") + " " + "\nPhone Number : " + contact.Field<long>("PhoneNumber") + " " + "\nEmail : " + contact.Field<string>("Email") + " ");
                Console.WriteLine("\n------------------------------------");
            }
        }
    }
}
