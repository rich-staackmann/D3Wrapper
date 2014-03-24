using System.Runtime.Serialization;

namespace D3Wrapper.ResponseObjects
{
    [DataContract]
    public class D3Follower
    {
        [DataMember]
        public string slug { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string  realName { get; set; }

        [DataMember]
        public string portrait { get; set; }

        [DataMember]
        public Skills skills { get; set; }
    }

    [DataContract]
    public class Skills
    {
        [DataMember]
        public Skill[] active { get; set; }

        [DataMember]
        public Skill[] passive { get; set; }
    }

    [DataContract]
    public class Skill
    {
        [DataMember]
        public string slug { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string icon { get; set; }

        [DataMember]
        public int level { get; set; }

        [DataMember]
        public string tooltipUrl { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string simpleDescription { get; set; }

        [DataMember]
        public string skillCalcId { get; set; }
    }
}
