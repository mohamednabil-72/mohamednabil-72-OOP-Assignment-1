1. Why is a single 20-parameter constructor a problem in practice?

A 20-parameter constructor is difficult to read and maintain.
It is easy to pass values in the wrong order  especially when multiple parameters have the same type such as strings or decimal amounts.
It also makes it harder to understand which values are important and which are optional.


2. Is this purely a "constructor is too long" problem, or is there a deeper design issue?

There is a deeper design issue.
The Invoice contains many loosely related properties such as billing information shipping information and order/payment information.
Putting all of them into one large constructor makes the class harder to understand and the object harder to create correctly.
The data should be logically grouped which is what the Builder pattern will help us achieve


Single responsibility: Each builder has one clear responsibility. AddressBuilder handles address information, while OrderBuilder handles order and payment information.

Independent validation: Each smaller builder can validate its own data without putting all validation rules inside one large builder.

Reuse: The same AddressBuilder can be used for both billing and shipping addresses, so the address-building logic does not need to be duplicated.

Readability: The composed builder makes the call site easier to understand because billing, shipping, and order information are built separately and then combined into the final Invoice.