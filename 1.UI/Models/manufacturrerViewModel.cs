using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1.UI.Models
{
    public class manufacturrerViewModel
    {
        public Car car { get; set; }
        public Cartyp cartyp { get; set; }

       
        public List<SelectListItem> Manufacturer { get; set; }
        public List<SelectListItem> Model { get; set; }
        public List<SelectListItem> YearOfManufacturer { get; set; }
    }
}