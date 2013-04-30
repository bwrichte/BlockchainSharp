
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BlockchainSharp.Resources
{
    [DataContract]
    public class BitcoinTransaction
    {
        [DataMember(Name = "time")]
        public long Time { get; set; }

        [DataMember(Name = "block_height")]
        public int BlockHeight { get; set; }

        [DataMember(Name = "vout_sz")]
        public int NumberOfOutputs { get; set; }

        [DataMember(Name = "vin_sz")]
        public int NumberOfInputs { get; set; }

        [DataMember(Name = "hash")]
        public string Hash { get; set; }

        [DataMember(Name = "relayed_by")]
        public string RelayingIPAddress { get; set; }

        [DataMember(Name = "tx_index")]
        public long TransactionIndex { get; set; }

        [DataMember(Name = "ver")]
        public int Version { get; set; }

        [DataMember(Name = "size")]
        public int Size { get; set; }

        [DataMember(Name = "inputs")]
        public List<BitcoinInput> Inputs { get; set; }

        [DataMember(Name = "out")]
        public List<BitcoinOutput> Outputs { get; set; }
    }
}
