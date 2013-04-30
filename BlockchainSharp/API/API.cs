using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using BlockchainSharp.Resources;

namespace BlockchainSharp.API
{
    public static class HttpWebRequestExtensions
    {
        public static void UploadData(
            this HttpWebRequest request,
            object data,
            Type dataType
            )
        {
            if (dataType != null && data != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    DataContractJsonSerializer serializer =
                        new DataContractJsonSerializer(dataType);
                    serializer.WriteObject(ms, data);
                    request.ContentLength = ms.Length;

                    ms.Position = 0;

                    using (Stream stream = request.GetRequestStream())
                    {
                        ms.CopyTo(stream);
                    }
                }
            }
        }

        public static object DownloadResponse(
            this HttpWebRequest request,
            Type responseType
            )
        {
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    DataContractJsonSerializer serializer =
                        new DataContractJsonSerializer(responseType);
                    return serializer.ReadObject(stream);
                }
            }
        }
    }

    public class BlockchainAPI
    {
        public static string BlockchainURL
        {
            get
            {
                return "http://blockchain.info/";
            }
        }

        public static HttpWebRequest CreateRequest(
            string controller
            )
        {
            return CreateRequest(controller, null, null);
        }

        public static HttpWebRequest CreateRequest(
            string controller,
            string action,
            IDictionary<string, string> parameters
            )
        {
            var builder = new UriBuilder(BlockchainURL);

            if (!string.IsNullOrWhiteSpace(controller))
            {
                builder.Path += (string.IsNullOrWhiteSpace(action))
                    ? controller
                    : string.Format("{0}/{1}", controller, action);
            }


            var queryParams = HttpUtility.ParseQueryString(string.Empty);

            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    queryParams[key] = parameters[key];
                }
            }

            builder.Query = queryParams.ToString();

            return WebRequest.CreateHttp(builder.Uri);
        }

        #region HttpGet

        public static object GetResource(
            string controller,
            Type type
            )
        {
            return GetResource(controller, null, type);
        }

        public static object GetResource(
            string controller,
            string action,
            Type type
            )
        {
            return GetResource(controller, action, null, type);
        }

        public static object GetResource(
            string controller,
            string action,
            IDictionary<string, string> parameters,
            Type type
            )
        {
            HttpWebRequest request = CreateRequest(
                controller,
                action,
                parameters
                );
            try
            {
                return request.DownloadResponse(type);
            }
            catch (WebException)
            {
                //
                // TODO: Make a constructor of type WebException?
                //
                return null;
            }
        }

        #endregion

        #region SINGLE TRANSACTION

        public static BitcoinTransaction GetTransaction(string hash)
        {
            return (BitcoinTransaction)GetResource("rawtx", hash, typeof(BitcoinTransaction));
        }

        public static BitcoinBlock GetLatestBlock()
        {
            return (BitcoinBlock)GetResource("latestblock", typeof(BitcoinBlock));
        }

        #endregion
    }
}
