using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.ClassEntity
{
    static public class Service
    {
        static public DataTable GetServiceTable()
        {
            return DBConnection.GetDataTableFromQuery($"Select * from service where Discount>={MainForm.discountFilter1} and Discount<{MainForm.discountFilter2} " +
                $"{MainForm.searchString}");
        }
        static public DataTable GetClientsFioTable()
        {
            return DBConnection.GetDataTableFromQuery($"Select id, concat(FirstName,' ',LastName,' ',Patronymic) as fio from client ");
        }
        static public string GetCount()
        {
            return DBConnection.GetValue($"Select count(id) from service where Discount>={MainForm.discountFilter1} and Discount<{MainForm.discountFilter2} " +
                $"{MainForm.searchString}");
        }
    }
}
