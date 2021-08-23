// Author : Chetan Lathi.    
// Created class QualityEngineRule by implimenting the interface IQualityCheck,
// QualityEngineRule is used to define the quality rules
// Created on : 23rd August 2021

///Below are the specification for implimenting QualityEngineRule 
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
//  4) ValidationLinker is used to connect to one validation to another

using System;

namespace HamaraBasket
{
    public class BasicQualityCheck : IQualityCheck
    {
        public bool ValidateQuality(Item Items)
        {
            if (!(Items.Quality >= 0 && Items.Quality <= 50))
            {
                return false;
            }
            return true;
        }
    }

    public class ValidationLinker : IQualityCheck
    {
        private IQualityCheck nextQualityChecker = null;
        public ValidationLinker(IQualityCheck _nextQualityChecker)
        {
            nextQualityChecker = _nextQualityChecker;
        }
        
        public virtual bool ValidateQuality(Item Items)
        {
             return nextQualityChecker.ValidateQuality(Items);
        }
    }

    public class NormalItemQualityCheck : ValidationLinker
    {
        public NormalItemQualityCheck(IQualityCheck qualityChecks)
            : base(qualityChecks) { }

        public override bool ValidateQuality(Item Items)
        {
            if (base.ValidateQuality(Items))
            {
                if (Items.SellBy < 0)
                {
                    Items.Quality = Items.Quality / 2;
                    Items.SellBy = Items.SellBy - 1;
                }
                else if (Items.SellBy == 0) 
                {
                    Items.Quality = 0;                   
                }
                else if (Items.SellBy <= 5)
                {
                    Items.Quality = Items.Quality + 3;
                    Items.SellBy = Items.SellBy - 1;
                }
                else if(Items.SellBy <= 10 && Items.SellBy > 5)
                {
                    Items.Quality = Items.Quality + 2;
                    Items.SellBy = Items.SellBy - 1;
                }               
                else
                {
                    if (Items.Quality != 0)
                        Items.Quality = Items.Quality - 1;
                    Items.SellBy = Items.SellBy - 1;
                }
               
                return true;
            }
            return false;
        }
    }

    public class LegendaryItemQualityCheck : ValidationLinker
    {
        public LegendaryItemQualityCheck(IQualityCheck qualityChecks)
            : base(qualityChecks) { }

        public override bool ValidateQuality(Item Items)
        {
            if (base.ValidateQuality(Items))
            {
                if (Items.SellBy != 0)
                    Items.SellBy = Items.SellBy - 1;
                Console.WriteLine(Items.ItemName + " is Legendary item !!! So its Quality will not be Changed");
                return true;
            }
            return false;
        }
    }
}
