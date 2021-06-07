using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Order:BaseEntity
    {
        public Order()
        {
            OrderDate = DateTime.Now;
        }

        public string ShippedAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public int AppUserID { get; set; }


        //Relational Properties
        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }


    }
}
