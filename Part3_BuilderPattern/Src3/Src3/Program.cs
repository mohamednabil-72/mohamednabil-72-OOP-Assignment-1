using System;

namespace Src3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBuilder billingAddress = new AddressBuilder()
                .SetStreet("Main Street")
                .SetCity("Assiut")
                .SetState("Assiut")
                .SetZipCode("71511")
                .SetCountry("Egypt");

            AddressBuilder shippingAddress = new AddressBuilder()
                .SetStreet("University Street")
                .SetCity("Assiut")
                .SetState("Assiut")
                .SetZipCode("71515")
                .SetCountry("Egypt");

            OrderBuilder order = new OrderBuilder()
                .SetOrderDate(DateTime.Now)
                .SetPaymentMethod("Visa")
                .SetCurrency("EGP")
                .SetSubTotal(1000)
                .SetDiscountAmount(100)
                .SetTaxAmount(90)
                .SetTotalAmount(990);

            Invoice invoice = new InvoiceBuilder()
                .SetInvoiceId(1)
                .SetCustomerName("Mohamed Nabil")
                .SetCustomerEmail("mohamed@example.com")
                .SetCustomerPhone("01000000000")
                .SetBillingAddress(billingAddress)
                .SetShippingAddress(shippingAddress)
                .SetOrderInfo(order)
                .Build();

            Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
            Console.WriteLine($"Customer: {invoice.CustomerName}");
            Console.WriteLine($"Total Amount: {invoice.TotalAmount}");
        }
    }
}