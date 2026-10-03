
using System;

namespace Src3
{
    internal class Invoice
    {
        public Invoice(
            int invoiceId,
            string customerName,
            string customerEmail,
            string customerPhone,
            Address billingAddress,
            Address shippingAddress,
            OrderInfo orderInfo)
        {
            InvoiceId = invoiceId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;

            BillingStreet = billingAddress.Street;
            BillingCity = billingAddress.City;
            BillingState = billingAddress.State;
            BillingZipCode = billingAddress.ZipCode;
            BillingCountry = billingAddress.Country;

            ShippingStreet = shippingAddress.Street;
            ShippingCity = shippingAddress.City;
            ShippingState = shippingAddress.State;
            ShippingZipCode = shippingAddress.ZipCode;
            ShippingCountry = shippingAddress.Country;

            OrderDate = orderInfo.OrderDate;
            PaymentMethod = orderInfo.PaymentMethod;
            Currency = orderInfo.Currency;
            SubTotal = orderInfo.SubTotal;
            DiscountAmount = orderInfo.DiscountAmount;
            TaxAmount = orderInfo.TaxAmount;
            TotalAmount = orderInfo.TotalAmount;
        }

        public int InvoiceId { get; private set; }

        public string CustomerName { get; private set; }
        public string CustomerEmail { get; private set; }
        public string CustomerPhone { get; private set; }

        public string BillingStreet { get; private set; }
        public string BillingCity { get; private set; }
        public string BillingState { get; private set; }
        public string BillingZipCode { get; private set; }
        public string BillingCountry { get; private set; }

        public string ShippingStreet { get; private set; }
        public string ShippingCity { get; private set; }
        public string ShippingState { get; private set; }
        public string ShippingZipCode { get; private set; }
        public string ShippingCountry { get; private set; }

        public DateTime OrderDate { get; private set; }

        public string PaymentMethod { get; private set; }
        public string Currency { get; private set; }

        public decimal SubTotal { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public decimal TaxAmount { get; private set; }
        public decimal TotalAmount { get; private set; }
    }
}