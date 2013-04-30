
using System.Runtime.Serialization;

namespace BlockchainSharp.Resources
{
    [DataContract]
    public class BitcoinInput
    {
        [DataMember(Name = "prev_out")]
        public BitcoinOutput PreviousOutput { get; set; }
    }
}
