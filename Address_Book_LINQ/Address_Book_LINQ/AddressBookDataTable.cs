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
            DataTable addressBookDataTable1 = new DataTable();

            addressBookDataTable1.Columns.Add("FirstName", typeof(string));
            addressBookDataTable1.Columns.Add("LastName", typeof(string));
            addressBookDataTable1.Columns.Add("Address", typeof(string));
            addressBookDataTable1.Columns.Add("City", typeof(string));
            addressBookDataTable1.Columns.Add("State", typeof(string));
            addressBookDataTable1.Columns.Add("Zip", typeof(int));
            addressBookDataTable1.Columns.Add("PhoneNumber", typeof(long));
            addressBookDataTable1.Columns.Add("Email", typeof(string));
            addressBookDataTable1.Columns.Add("AddressBookType", typeof(string));
            addressBookDataTable1.Columns.Add("AddressBookName", typeof(string));

            //Add Values for Columns
            addressBookDataTable1.Rows.Add("Amit", "Rana", "Ashish Plaza", "Pune", "MH", 663222, 8979325434, "Amit@gmail.com", "Friends", "AddressBook1");
            addressBookDataTable1.Rows.Add("Rohit", "Rana", "Venu Hights", "Pune", "MH", 763226, 833343210, "rohit@gmail.com", "Friends", "AddressBook1");
            addressBookDataTable1.Rows.Add("Neha", "Negi", "Flex Road", "Mumbai", "MH", 303222, 6876543210, "neha@gmail.com", "Family", "AddressBook2");
            addressBookDataTable1.Rows.Add("Aman", "Rawat", "Neer Road", "Benglore", "Karnataka", 400028, 889000880, "aman@gmail.com", "Friends", "AddressBook1");
            addressBookDataTable1.Rows.Add("sumit", "Semwal", "Panji", "Panaji", "Goa", 323254, 8877743210, "sumit@gmail.com", "Friends", "AddressBook1");
            addressBookDataTable1.Rows.Add("Naman", "Magare", "Indor", "Indor", "MP", 485254, 7877743990, "naman@gmail.com", "Family", "AddressBook2");
            addressBookDataTable1.Rows.Add("Rekha", "rani", "baroda", "Baroda", "MP", 43254, 7888743210, "rekha@gmail.com", "Professional", "AddressBook3");
            addressBookDataTable1.Rows.Add("Pratiksha", "Swami", "baroda", "Baroda", "MP", 43254, 7888743210, "rekha@gmail.com", "Friends", "AddressBook1");
            addressBookDataTable1.Rows.Add("Diksha", "Swami", "baroda", "Baroda", "MP", 43254, 7888743210, "rekha@gmail.com", "Friends", "AddressBook1");


            return addressBookDataTable1;
        }
        /// <summary>
        /// Display contact
        /// </summary>
        /// <param name="table"></param>
        public void DisplayContacts(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>();
            foreach (var contact in contacts)
            {
                Console.WriteLine("\n------------------------------------");
                Console.Write("\nFirst Name : " + contact.Field<string>(0) + " " + "\nLast Name : " + contact.Field<string>("LastName") + " " + "\nAddress : " + contact.Field<string>("Address") + " " + "\nCity : " + contact.Field<string>("City") + " " + "\nState : " + contact.Field<string>("State")
                    + " " + "\nZip : " + contact.Field<int>("Zip") + " " + "\nPhone Number : " + contact.Field<long>("PhoneNumber") + " " + "\nEmail : " + contact.Field<string>("Email") + " " + "\nAddressBookType: " + contact.Field<string>("AddressBookType") + " " + "\nAddressBookName: " + contact.Field<string>("AddressBookName") + " ");
                Console.WriteLine("\n------------------------------------");
            }
        }
        /// <summary>
        /// Adit contact by first name 
        /// </summary>
        /// <param name="table"></param>
        public void EditContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Naman");
            foreach (var contact in contacts)
            {
                contact.SetField("LastName", "Dhiyani");
                contact.SetField("City", "Banglore");
                contact.SetField("State", "Karnataka");
                contact.SetField("Email", "Naman@yahoo.com");
            }
            Console.WriteLine("\n**************************************************");
            Console.WriteLine("These is recently Updated Contact");
            DisplayContacts(contacts.CopyToDataTable());
        }

        /// <summary>
        /// Delet contact
        /// </summary>
        /// <param name="table"></param>
        public void DeleteContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(r => r.Field<string>("FirstName") != "Amit").CopyToDataTable();
            Console.WriteLine("Following Contacts are present in Datatable after deletion of Contact of Person 'Pratiksha' ");
            DisplayContacts(contacts);
        }


        /// <summary>
        /// Retrieve Contact Belonging To Perticular City OR State
        /// </summary>
        /// <param name="table"></param>
        public void RetrieveContactBelongingToPerticularCityORState(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                             .Where(x => x["City"].Equals("Pune") || x["State"].Equals("MH")).CopyToDataTable();
            Console.WriteLine("Following Contacts belonging to perticular City or State ");
            DisplayContacts(contacts);
        }

        /// <summary>
        /// Count Contacts From Perticular City ANDS tate
        /// </summary>
        /// <param name="table"></param>
        public void CountContactsFromPerticularCityANDState(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                             .Where(x => x["City"].Equals("Pune") && x["State"].Equals("MH")).Count();
            Console.WriteLine($"Count of Persons Beloning to City 'Baroda' and State 'MP' : {contacts} ");
        }
        /// <summary>
        ///Sort Contacts by first name 
        /// </summary>
        /// <param name="table"></param>
        public void SortContacts(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                           .OrderBy(x => x.Field<string>("FirstName"));
            Console.WriteLine("\n**************************************************");
            Console.WriteLine("\nSorted Contacts using Person's first name");
            DisplayContacts(contacts.CopyToDataTable());
        }

        /// <summary>
        ///Count Contacts By Address Book Type
        /// </summary>
        /// <param name="table"></param>
        public void CountContactsByAddressBookType(DataTable table)
        {
            var friendsContacts = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Friends")).Count();
            Console.WriteLine($"Number of Persons belongs to type 'Friends' : {friendsContacts} ");
            var familyContact = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Family")).Count();
            Console.WriteLine($"Number of Persons belongs to type 'Family' : {familyContact}");
        }
    }
}
