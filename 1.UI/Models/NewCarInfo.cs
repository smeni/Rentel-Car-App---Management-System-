using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    public class NewCarInfo
    {
        [Required]
        public int TypeID { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year_of_Manufacturer { get; set; }
        [Required]
        public string Transmission { get; set; }
        [Required]
        public int Daily_cost { get; set; }
        [Required]
        public int Day_late { get; set; }

        [Required]
        public int CarID { get; set; }
        [Required]
        public int Mileage { get; set; }
        public string Picture { get; set; }
        [Required]
        public string IsRepaired { get; set; }
        [Required]
        public string IsAvailable { get; set; }
        [Required]
        public int C_License_number { get; set; }
        [Required]
        public int BranchID { get; set; }
    }
}