using System;

namespace Src3
{
    internal class OrderBuilder
    {
        private DateTime orderDate;
        private string paymentMethod;
        private string currency;
        private decimal subTotal;
        private decimal discountAmount;
        private decimal taxAmount;
        private decimal totalAmount;

        public OrderBuilder SetOrderDate(DateTime orderDate)
        {
            this.orderDate = orderDate;
            return this;
        }

        public OrderBuilder SetPaymentMethod(string paymentMethod)
        {
            this.paymentMethod = paymentMethod;
            return this;
        }

        public OrderBuilder SetCurrency(string currency)
        {
            this.currency = currency;
            return this;
        }

        public OrderBuilder SetSubTotal(decimal subTotal)
        {
            this.subTotal = subTotal;
            return this;
        }

        public OrderBuilder SetDiscountAmount(decimal discountAmount)
        {
            this.discountAmount = discountAmount;
            return this;
        }

        public OrderBuilder SetTaxAmount(decimal taxAmount)
        {
            this.taxAmount = taxAmount;
            return this;
        }

        public OrderBuilder SetTotalAmount(decimal totalAmount)
        {
            this.totalAmount = totalAmount;
            return this;
        }

        public OrderInfo Build()
        {
            return new OrderInfo(
                orderDate,
                paymentMethod,
                currency,
                subTotal,
                discountAmount,
                taxAmount,
                totalAmount
            );
        }
    }
}