using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainSharp.API;
using BlockchainSharp.Resources;

namespace BlockchainSharpApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string hash = "0ade9b2864672074864c1d509ac427ffdcf16fe983ef6ebe8b0606afd3fb50a4";
            BitcoinTransaction transaction = BlockchainAPI.GetTransaction(hash);
            Console.WriteLine("Block Number = {0}", transaction.BlockHeight);

            BitcoinBlock latestBlock = BlockchainAPI.GetLatestBlock();

            Console.WriteLine("LatestBlock = {0}", latestBlock.BlockHeight);

            Console.WriteLine("Number of Confirmations = {0}", latestBlock.BlockHeight - transaction.BlockHeight);

            Console.ReadLine();
        }
    }
}
