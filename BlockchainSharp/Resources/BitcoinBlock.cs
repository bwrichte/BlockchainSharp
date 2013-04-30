
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BlockchainSharp.Resources
{
    [DataContract]
    public class BitcoinBlock
    {
        [DataMember(Name = "hash")]
        public string Hash { get; set; }

        [DataMember(Name = "time")]
        public long Time { get; set; }

        [DataMember(Name = "block_index")]
        public int BlockIndex { get; set; }

        [DataMember(Name = "height")]
        public int BlockHeight { get; set; }

        [DataMember(Name = "txIndexes")]
        public List<long> TransactionIndexes { get; set; }
    }
}
