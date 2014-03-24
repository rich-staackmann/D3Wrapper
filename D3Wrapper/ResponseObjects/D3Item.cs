//
//  This file contains the object model for a Diablo 3 item.
//  It also contains all the inner classes necessary to parse the item from JSON
//

using System.Runtime.Serialization;

namespace D3Wrapper.ResponseObjects
{
    [DataContract]
    public class D3Item
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string icon { get; set; }

        [DataMember]
        public string displayColor { get; set; }

        [DataMember]
        public int requiredLevel { get; set; }

        [DataMember]
        public int itemLevel { get; set; }

        [DataMember]
        public int bonusAffixes { get; set; }

        [DataMember]
        public int bonusAffixesMax { get; set; }

        [DataMember]
        public bool accountBound { get; set; }

        [DataMember]
        public Type type { get; set; }

        [DataMember]
        public DPS dps { get; set; }

        [DataMember]
        public AttacksPerSecond attacksPerSecond { get; set; }

        [DataMember]
        public MinDamage minDamage { get; set; }

        [DataMember]
        public MaxDamage maxDamage { get; set; }

        [DataMember]
        public string[] attributes { get; set; }
    }

    [DataContract]
    public class Type
    {
        [DataMember]
        public bool twoHanded { get; set; } 
        
        [DataMember]
        public string id { get; set; }
    }

    [DataContract]
    public class DPS
    {
        [DataMember]
        public double min { get; set; }

        [DataMember]
        public double max { get; set; }
    }

    [DataContract]
    public class AttacksPerSecond
    {
        [DataMember]
        public double min { get; set; }

        [DataMember]
        public double max { get; set; }
    }

    [DataContract]
    public class MinDamage
    {
        [DataMember]
        public double min { get; set; }

        [DataMember]
        public double max { get; set; }
    }

    [DataContract]
    public class MaxDamage
    {
        [DataMember]
        public double min { get; set; }

        [DataMember]
        public double max { get; set; }
    }
}
