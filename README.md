# VirtualBasket

Problem Statement : 
Welcome to team HamaraBasket.com. We are a small online retail shop,
we buy from local sources and sell you the best products.  We need help in building our quality rule engine which helps us in making informed decisions about pricing and discounts.Please help us build this system.

Expected Behavior
            - All items have a SellBy value which denotes the number of days we have to sell the item
            - All items have a Quality value which denotes how valuable the item is
            - At the end of each day our system lowers both values by 1 for every item
Special cases
           - Once the sell by date has passed, Quality degrades twice as fast
            - The Quality of an item is never negative
            - "Indian Wine" increases in Quality the older it gets
            - The Quality of an item is never more than 50
            - "Forest Honey", being a legendary item, never has to be sold or decreases in Quality
            - "Movie Tickets ", like Indian Wine, increases in Quality as its SellBy value approaches;
            Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
            Quality drops to 0 after the Show.

Solution Details : 
      //1. Item class contains the properties like ItemName, SellBy, Quality, ItemType to maintain the list of items in Basket
      //2. ItemType is enum to mainatain the type of item e.g. Noramal Item, Legendary Item
      //3. Basket class contains the listof items and function to check Quality of Items 
      //4. IQualityCheck interface is used to define common methods to check Quality of Item
      //5. QualityEngineRule is used to define the quality rules
      //6. FactoryItem class is used to provide the inatances of Items.
      //7. For example 1) "Movie Tickets " increases in Quality as its SellBy value approaches
      //               2) "Forest Honey" being a Legendary item, never has to be sold or decreases in Quality    

Below are the assumtions for implimenting QualityEngineRule 
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
