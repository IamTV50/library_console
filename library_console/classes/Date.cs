using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_console.classes {
    public class Date {
        private string dateFormat { get; set; }
        private string dateTimeFormat { get; set; }
        public string date { get; set; }
        public string dateTime { get; set; }

        public Date() {
            dateFormat = "dd-MMMM-yyyy";
            dateTimeFormat = "dd-MMMM-yyyy HH:mm";
            date = DateTime.Now.ToString(dateFormat);
            dateTime = DateTime.Now.ToString(dateTimeFormat);
        }
        public string addDays(string date, int days, bool inclueTime = false) {
            DateTime newDate;
            
            try {
                newDate = DateTime.Parse(date).AddDays(days);
            }
            catch { throw; }
            
            if (inclueTime) {
                return newDate.ToString(dateTimeFormat);
            }

            return newDate.ToString(dateFormat);
        }
    }
}
