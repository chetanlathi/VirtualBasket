// Author : Chetan Lathi.  
// Created Item Factoy calss which creates the intances of Items
// Created on : 23rd August 2021

using Unity;
using Unity.Injection;

namespace HamaraBasket
{
   public static class FactoryItem
    {
        private static IUnityContainer obj = null;

        public static IQualityCheck Create(ItemType type) {

            if (obj == null)
            {
                obj= new UnityContainer();
                obj.RegisterType<IQualityCheck, NormalItemQualityCheck>(ItemType.NormalItem.ToString(),new InjectionConstructor( new BasicQualityCheck()));
                obj.RegisterType<IQualityCheck, LegendaryItemQualityCheck>(ItemType.LegendaryItem.ToString(), new InjectionConstructor(new BasicQualityCheck()));
            }
            return obj.Resolve<IQualityCheck>(type.ToString());
        }
    }
}
