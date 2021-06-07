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
            OrderStatus = OrderStatus.Created;
        }

        public string ShippedAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int AppUserID { get; set; }
        public int EmployeeID { get; set; }
        public int ShipperID { get; set; }


        //Relational Properties
        public virtual AppUser AppUser { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }


    }
}
