using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3Wrapper;
using D3Wrapper.ResponseObjects;

namespace D3WrapperClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get all info on an item
            Console.WriteLine("Get all info on an item");
            D3Item item = ItemInformation.GetAllItemInformation("COGHsoAIEgcIBBXIGEoRHYQRdRUdnWyzFB2qXu51MA04kwNAAFAKYJMD");
            Console.WriteLine("Name : " + item.name);
            Console.WriteLine("Required level : " + item.requiredLevel);
            Console.WriteLine("Account bound? : " + item.accountBound);
            Console.WriteLine("Weapon type : " + item.type.id);
            Console.WriteLine("DPS : " + item.dps.min + " - " + item.dps.max);
            Console.WriteLine("Attacks per sec : " + item.attacksPerSecond.min);
            Console.WriteLine("Min damage : " + item.minDamage.min);
            Console.WriteLine("Max damage : " + item.maxDamage.min);
            Console.Write("Attributes : ");
            foreach (string attribute in item.attributes)
                Console.Write(attribute + ", ");
            Console.WriteLine();

            //Get basic info on an item
            Console.WriteLine("\nGet basic info on an item");
            D3BasicItem basicItem = ItemInformation.GetBasicItemInformation("COGHsoAIEgcIBBXIGEoRHYQRdRUdnWyzFB2qXu51MA04kwNAAFAKYJMD");
            Console.WriteLine("Item Level : " + basicItem.itemLevel);
            Console.WriteLine("DPS : " + basicItem.dps.min + " - " + basicItem.dps.max);
            Console.Write("Attributes : ");
            foreach (string attribute in basicItem.attributes)
                Console.Write(attribute + ", ");
            Console.WriteLine();

            //Get an item that doesn't exist
            Console.WriteLine("\nGet an item that doesn't exist");
            D3Item notAnItem = ItemInformation.GetAllItemInformation("lOGHsoAIEgcIBBXIGEoRHYQRdRUdnWyzFB2qXu51MA04kwNAAFAKYJMD");
            Console.WriteLine("Name : " + notAnItem.name);

            //Get DPS of an item that doesn't have that stat (ie boots)
            Console.WriteLine("\nGet DPS of an item that doesn't have that stat (ie boots)");
            D3Item bootItemDPS = ItemInformation.GetAllItemInformation("Boots_203");
            Console.WriteLine(bootItemDPS.dps.min + " - " + bootItemDPS.dps.max);


            //Get all follower info
            Console.WriteLine("\nGet all follower info");
            D3Follower follower = FollowerInformation.GetAllFollowerInformation("scoundrel");
            Console.WriteLine(follower.name);
            Console.WriteLine(follower.portrait);
            Console.WriteLine(follower.slug);
            foreach (Skill s in follower.skills.active)
                Console.WriteLine(s.name);

            Console.Read();
        }
    }
}
