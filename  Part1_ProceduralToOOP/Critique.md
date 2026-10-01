1. Extensive Use of Global Variables
1. The program stores almost all of its data in global variables.
1. This makes the program difficult to maintain because any function can directly modify the shared data.

2. Parallel Arrays
 The program represents a single customer using several separate arrays. The same approach is used for products and orders.
 This creates a strong dependency between the arrays. If one array is modified incorrectly or its indexes become inconsistent with the others the customer data can become corrupted.

3. Heavy Dependence on Array Indexes
This makes the code harder to understand because the relationship between an order and its customer or products is represented indirectly through indexes rather than explicit objects.

4. Business Logic and User Interface Are Mixed
 Some functions are responsible for business operations while also printing error messages directly to the console

5. Hard-Coded Business Rules
 The VIP discount is directly hard-coded inside calculateOrderTotal as a 10% discount
If the discount percentage changes or different customer types are introduced, the function itself must be modified. This makes the system less flexible and harder to extend.

6. Functions Depend Directly on Shared State
 Functions such as calculateOrderTotal, markOrderPaid, and printOrder directly access multiple global arrays.
This creates tight coupling between functions and the global data structure. Changing how orders or products are stored would require changes in many different functions.