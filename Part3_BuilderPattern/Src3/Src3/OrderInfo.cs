using System;

namespace Src3
{
    internal class OrderInfo
    {
        public OrderInfo(
            DateTime orderDate,
            string paymentMethod,
            string currency,
            decimal subTotal,
            decimal discountAmount,
            decimal taxAmount,
            decimal totalAmount)
        {
            OrderDate = orderDate;
            PaymentMethod = paymentMethod;
            Currency = currency;
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
            TaxAmount = taxAmount;
            TotalAmount = totalAmount;
        }

        public DateTime OrderDate { get; }
        public string PaymentMethod { get; }
        public string Currency { get; }
        public decimal SubTotal { get; }
        public decimal DiscountAmount { get; }
        public decimal TaxAmount { get; }
        public decimal TotalAmount { get; }
    }
}