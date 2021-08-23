// Author : Chetan Lathi.    
// Created HamaraBasket feature for Accenture
// Created on : 23rd August 2021


// Solution Details : 
//1. Item class contains the properties like ItemName, SellBy, Quality, ItemType to maintain the list of items in Basket
//2. ItemType is enum to mainatain the type of item e.g. Noramal Item, Legendary Item
//3. Basket class contains the listof items and function to check Quality of Items 
//4. IQualityCheck interface is used to define common methods to check Quality of Item
//5. QualityEngineRule is used to define the quality rules
//6. FactoryItem class is used to provide the inatances of Items.
//7. For example 1) "Movie Tickets " increases in Quality as its SellBy value approaches
//               2) "Forest Honey" being a Legendary item, never has to be sold or decreases in Quality    

///Below are the assumtions for implimenting QualityEngineRule 
/// 1) Basic Quality Rule check the below condtions
/// - The Quality of an item is never negative
/// - The Quality of an item is never more than 50
//  2) If Item type is NormalItem  
//   - Quality increases by 2 when SellBy value is 10 days or less 
//   - Quality increases by 3 when SellBy value is 5 days or less 
//   - Quality drops to 0 after the Show.
//   - Once the sell by date has passed, Quality degrades twice as fast 
//  3) If Item type is LegendrayItem
//    - No Effect on Quality value its not increases or decreases

using System;

namespace HamaraBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            Basket objBasket = new Basket();
            objBasket.Items.Add(new Item (ItemType.NormalItem) { ItemName = "Indian Wine", SellBy = 10, Quality =11});
            objBasket.Items.Add(new Item (ItemType.LegendaryItem) { ItemName = "Forest Honey", SellBy = 10, Quality = 10 });
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Movie Tickets", SellBy = 4, Quality = 10});
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Apple", SellBy = 10, Quality = -1 });
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Spinach", SellBy = 0, Quality = 5 });
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Orange", SellBy = 15, Quality = 8 });
            objBasket.CheckQualityofItems();
            Console.ReadLine();
        }
    }
}
