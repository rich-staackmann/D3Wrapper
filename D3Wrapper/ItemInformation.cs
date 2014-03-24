//
// @desc The class contains functions that retrieve data about items.
// examples include GetAllItemInformation() and GetBasicItemInformation()
// @author Richard Staackmann

using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using D3Wrapper.ResponseObjects;

namespace D3Wrapper
{
    public static class ItemInformation
    {
        private const string baseURL = "http://us.battle.net/api/d3/data/item/";
        private static WebClient client = new WebClient();

        // @desc Gets all the possible data on an item
        // @params string itemId - a string that identifies the item
        // @return Item - a custom class that holds all item data
        public static D3Item GetAllItemInformation(string itemId)
        {
            try
            {
                Stream jsonSource = client.OpenRead(baseURL + itemId);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(D3Item));
                D3Item item = (D3Item)serializer.ReadObject(jsonSource);
                item = FixNullJSON(item);

                return item;
            }
            catch (Exception e)
            {
                return CreateNullItem();
            }
            finally
            {
                client.Dispose();
            }
        }

        // @desc Gets a subset of the possible data on an item
        // @params string itemId - a string that identifies the item
        // @return BasicItem - a custom class that holds some item data
        public static D3BasicItem GetBasicItemInformation(string itemId)
        {
            try
            {
                Stream jsonSource = client.OpenRead(baseURL + itemId);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(D3BasicItem));
                D3BasicItem item = (D3BasicItem)serializer.ReadObject(jsonSource);
                item = FixNullJSON(item);

                return item;
            }
            catch (Exception e)
            {
                return CreateNullBasicItem();
            }
            finally
            {
                client.Dispose();
            }
        }

       
        // @desc create a BasicItem that has no meaningful data, return this instead of NULL
        // @params none
        // @return BasicItem - a custom class that holds some item data
        private static D3BasicItem CreateNullBasicItem()
        {
            return new D3BasicItem() 
            {
                attributes = new string[1] { string.Empty },
                dps = new DPS()
            };
        }

        // @desc create an Item that has no meaningful data, return this instead of NULL
        // @params none
        // @return Item - a custom class that holds all item data
        private static D3Item CreateNullItem()
        {
            return new D3Item() 
            { 
                attributes = new string[1] { string.Empty }, 
                type = new D3Wrapper.ResponseObjects.Type(), 
                dps = new DPS(),
                attacksPerSecond = new AttacksPerSecond(),
                minDamage = new MinDamage(),
                maxDamage = new MaxDamage(),
            };
        }

        // @desc create an Item that has no NULL references
        // @params Item
        // @return Item - a custom class that holds all item data
        private static D3Item FixNullJSON(D3Item item)
        {
            item.type = item.type ?? new ResponseObjects.Type();
            item.dps = item.dps ?? new DPS();
            item.attacksPerSecond = item.attacksPerSecond ?? new AttacksPerSecond();
            item.minDamage = item.minDamage ?? new MinDamage();
            item.maxDamage = item.maxDamage ?? new MaxDamage();
            item.attributes = item.attributes ?? new string[1] { string.Empty };

            return item;
        }

        // @desc create a BasicItem that has no NULL references
        // @params BasicItem
        // @return BasicItem - a custom class that holds some item data
        private static D3BasicItem FixNullJSON(D3BasicItem item)
        {
            item.attributes = item.attributes ?? new string[1] { string.Empty };
            item.dps = item.dps ?? new DPS();

            return item;
        }
    }
}
