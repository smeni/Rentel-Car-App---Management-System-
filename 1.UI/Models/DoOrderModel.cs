using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    public class DoOrderModel
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string carPicture { get; set; }
        public string carManufacture { get; set; }
        public string carModel { get; set; }
        public System.DateTime Taking_Date { get; set; }
        public System.DateTime Return_Date { get; set; }
        public int Day_late { get; set; }
        public double total { get; set; }
     
        public System.DateTime Actual_return_Date { get; set; }
        public int License_number { get; set; }
        public string IsAvailable { get; set; }
        public bool IsActiv { get; set; }

        
    }
}