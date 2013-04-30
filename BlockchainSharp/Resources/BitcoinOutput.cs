
using System.Runtime.Serialization;

namespace BlockchainSharp.Resources
{
    [DataContract]
    public class BitcoinOutput
    {
        [DataMember(Name = "value")]
        public long Value { get; set; }

        [DataMember(Name = "n")]
        public int OutputIndex { get; set; }

        [DataMember(Name = "addr")]
        public string ToAddress { get; set; }

        // 0 = Address, 1 = PublicKey, 2 = Strange
        [DataMember(Name = "type")]
        public int Type { get; set; }
    }
}
