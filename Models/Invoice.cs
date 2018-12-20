using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Invoice
    {
      [Key]
      public int InvoiceId {get;set;}
        public int OrderId { get; set; }
        
        public int Qty { get; set; }
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public int CardNo { get; set; }
        [DataType(DataType.CreditCard)]
        public string PaymentTypeName { get; set; }


        public string ChildFirstName { get; set; }

        public string ChildLasttName { get; set; }
        public int RoomNo { get; set; }
        public string TeacherName { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public virtual List<Menu> Menus { get; set; }

        public Parent Parent { get; set; }
    }
}