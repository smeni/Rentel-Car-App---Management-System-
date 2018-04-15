using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    public class OrdersViewModel
    {  //User
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }
       
        public string Gender { get; set; }
      
        public string E_mail { get; set; }

        //typecar details
        //public int TypeID { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year_of_Manufacturer { get; set; }

        //car details
        public int Mileage { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public int C_License_number { get; set; }
        [Required]
        public int BranchID { get; set; }

        //order details
        [Required]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        [Required]
        public DateTime Taking_Date { get; set; }
        
        public DateTime Return_Date { get; set; }
        public DateTime Actual_return_Date { get; set; }
    }
}