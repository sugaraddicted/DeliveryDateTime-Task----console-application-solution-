# DeliveryDateTime-Task----console-application-solution

Write a C# console program that calculates a delivery date and time of the order.
The console application prompts the order date and time, entered by user in format dd.MM.yyyy HH:mm and after pressing Enter the program outputs an estimated delivery date and time.

The regular delivery time is 48 hours if the order date is made on Mon-Fri from 08:00-17:00 (business hours). Saturday and Sunday are off, not business hours.

If the order is made outside of business hours the starting date is counted from the next earliest working day and time.
