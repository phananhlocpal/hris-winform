using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMngt.Model
{
    class CalendarModel
    {
        public string UserID { get; set; }
        public DateTime Date { get; set; }
        public DateTime RegisterCheckIn { get; set; }
        public DateTime RegisterCheckOut { get; set; }
        public DateTime? RealCheckIn { get; set; }
        public DateTime? RealCheckOut { get; set; }
        public string CheckInLocation { get; set; }
        public string CheckOutLocation { get; set; }
        public string Status { get; set; }

    }
}
