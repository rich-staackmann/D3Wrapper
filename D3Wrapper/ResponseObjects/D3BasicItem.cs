//
// This class is a simplified model of a diablo 3 item
//
using System.Runtime.Serialization;

namespace D3Wrapper.ResponseObjects
{
    [DataContract]
    public class D3BasicItem
    {
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
        public bool accountBound { get; set; }

        [DataMember]
        public string[] attributes { get; set; }

        [DataMember]
        public DPS dps { get; set; }
    }
}
