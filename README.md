# Checkout Kata
## Description
This kata implements a shop checkout system.

A 'Shop' can contain a list of items that the shop has in stock at any given time. These items can be added/removed to/from a 'Basket' by a user (only these items that are in the shop) during a user 'Shopping Session'.

'Promotions' can be applied to specific items, and depending on the quantity of said item in the basket, could reduce the price, either by a fixed amount, or by a percentage.

---
## Project structure
This project consists of a console app and a unit test library.

---
## Details
A User creates a ShoppingSession whilst 'in the shop'. This ShoppingSession object allows a user to add/remove items to/from a basket. 

While it does this, the shopping session will calculate the cost of adding the item into the basket (and by taking the quantity of items to add into account). Any applicable promotions for that item will be used to determine the final price in the basket. The ShoppingSession uses the Shop instance that is injected into its constructor to get the list of available promotions, as well a list of items in the shop, and the stock levels of each item.
When adding items to a basket, the stock level of that item in the shop will decrease. 

When the stock reaches 0, no more items of that sku can be added to the basket by the user.

Promotions for an item can be created at run time, simply specify the item sku, and the promotions discount calculator.
The discount calculator is responsible for calculating the price of the item, and is set up to support multiple types of calculators. Currently there are two in the system, a fixed price calculator (i.e. for n items, the price for those n items is x), and a percentage calculator (i.e. for n items, the price for those n items is X% off).

---
### Improvements
Mix and match promotions - For example, Allow a 25% off discount when a user adds any combination of two items A or B
(A + A | A + B | B + B all = 25% off).

Some modifications will be needed to the Promotion and discount calculators, namely allowing for multiple Skus to be defined when creating the promotion.