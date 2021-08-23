// Author : Chetan Lathi.  
// Created enum ItemType and Items, Basket classes to matain the item list and check quality of item
// Created on : 23rd August 2021

using System;
using System.Collections.Generic;

namespace HamaraBasket
{
    public enum ItemType
    {
        NormalItem=0,
        LegendaryItem = 1       
    }
    
    public class Item
    {
        public IQualityCheck _qualityCheck = null;

        public Item(ItemType type)
        {
            ItemType = type;          
            _qualityCheck = FactoryItem.Create(type);          
        }
       
        public string ItemName { get; set; }
        public int SellBy { get; set; }
        public int Quality { get; set; }
        public ItemType ItemType { get; set; }

        public void CheckQuality(Item item)
        {
            Console.WriteLine("Quality of Item : " + item.ItemName);
            if (_qualityCheck.ValidateQuality(item))
            {                
                Console.WriteLine("Current Quality value of " + item.ItemName + " is " + item.Quality + " & SellBy Days reamining " + item.SellBy + " Days");
                Console.WriteLine();
            }  
            else
            {
                Console.WriteLine("Quality is Never negative & Never more than 50");
                Console.WriteLine();
            }
        }
    }

    public class Basket
    {
        public List<Item> Items { get; set; }
                      
        public Basket()
        {           
            Items = new List<Item>();
        }

        public void CheckQualityofItems()
        {
            foreach(Item item in this.Items)
            {
                item.CheckQuality(item);
            }
            
        }      
    }

}
