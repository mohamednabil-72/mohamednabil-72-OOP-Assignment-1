using System;

namespace Src3
{
    internal class InvoiceBuilder
    {
        private int invoiceId;
        private string customerName;
        private string customerEmail;
        private string customerPhone;

        private Address billingAddress;
        private Address shippingAddress;

        private OrderInfo orderInfo;

        public InvoiceBuilder SetInvoiceId(int invoiceId)
        {
            this.invoiceId = invoiceId;
            return this;
        }

        public InvoiceBuilder SetCustomerName(string customerName)
        {
            this.customerName = customerName;
            return this;
        }

        public InvoiceBuilder SetCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
            return this;
        }

        public InvoiceBuilder SetCustomerPhone(string customerPhone)
        {
            this.customerPhone = customerPhone;
            return this;
        }

        public InvoiceBuilder SetBillingAddress(AddressBuilder addressBuilder)
        {
            billingAddress = addressBuilder.Build();
            return this;
        }

        public InvoiceBuilder SetShippingAddress(AddressBuilder addressBuilder)
        {
            shippingAddress = addressBuilder.Build();
            return this;
        }

        public InvoiceBuilder SetOrderInfo(OrderBuilder orderBuilder)
        {
            orderInfo = orderBuilder.Build();
            return this;
        }

        public Invoice Build()
        {
            if (invoiceId <= 0)
                throw new Exception("InvoiceId is required.");

            if (string.IsNullOrWhiteSpace(customerName))
                throw new Exception("CustomerName is required.");

            if (string.IsNullOrWhiteSpace(customerEmail))
                throw new Exception("CustomerEmail is required.");

            if (billingAddress == null)
                throw new Exception("Billing address is required.");

            if (shippingAddress == null)
                throw new Exception("Shipping address is required.");

            if (orderInfo == null)
                throw new Exception("Order information is required.");

            return new Invoice(
                invoiceId,
                customerName,
                customerEmail,
                customerPhone,
                billingAddress,
                shippingAddress,
                orderInfo
            );
        }
    }
}