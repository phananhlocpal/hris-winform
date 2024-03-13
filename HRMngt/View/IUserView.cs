using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMngt.View
{
    public interface IUserView
    {
        // Properties - Fields
        string userID { get; set; }
        string name { get; set; }
        string email { get; set; }
        string phone { get; set; }
        string address { get; set; }
        string birthday { get; set; }
        string sex { get; set; }
        string position { get; set; }
        int salary { get; set; }
        string username { get; set; }
        string password { get; set; }
        string managerID { get; set; }
        string departmentID { get; set; }
        string contract_type { get; set; }
        string close_date { get; set; }
        string scan_contract { get; set; }
        string note { get; set; }
        string ava { get; set; }
        string status { get; set; }

        // Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;


        // Methods
        void SetUserListBindingSource(BindingSource userList);
        void Show();
    }
}
