using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Address_Book_LINQ
{
    public class AddressBookDataTable
    {
        public void CreateAddressBookDataTable()
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
        }
    }
}
