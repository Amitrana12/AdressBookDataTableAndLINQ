using System;
using System.Data;

namespace Address_Book_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcomr to my Addresh book using LINQand DATATable by Amit Rana [-_-]");
            AddressBookDataTable addressBookDataTable = new AddressBookDataTable();
            DataTable table = addressBookDataTable.CreateAddressBookDataTable();
            //addressBookDataTable.DisplayContacts(table);
            //addressBookDataTable.EditContact(table);
            Console.WriteLine("\n**************************************************");
            //addressBookDataTable.DeleteContact(table);

            //addressBookDataTable.RetrieveContactBelongingToPerticularCityORState(table);

            // addressBookDataTable.CountContactsFromPerticularCityANDState(table);
            addressBookDataTable.SortContacts(table);

        }
    }
}
