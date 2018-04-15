using _4.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1.UI.Models
{
    public class NewOrderVIewModel
    {

        public List<SelectListItem> user { get; set; }
        public List<SelectListItem> car { get; set; }


        //order details
        [Required]
        public Order order { get; set; }

        [Required]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        [Required]
        public DateTime Taking_Date { get; set; }

        public DateTime Return_Date { get; set; }
        public DateTime Actual_return_Date { get; set; }

    }
}