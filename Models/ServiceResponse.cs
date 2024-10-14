using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ServiceResponse
    {
        public object Response { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
    }
    public class Contacts
    {
        public string CODE { get; set; }
        public string DETAIL1 { get; set; }
        public string DETAIL2 { get; set; }
        public string DETAIL3 { get; set; }
        public string DETAIL4 { get; set; }
        public string DETAIL5 { get; set; }
        public string DETAIL6 { get; set; }
    }
    public class CustomerRequest
    {
        public string User { get; set; }
        public string CustomerId { get; set; }
    }

    public class Customer
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
    }

    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryExpected { get; set; }
        public bool ContainsGift { get; set; }
    }

    public class OrderItem
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

}