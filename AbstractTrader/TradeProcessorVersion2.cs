using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AbstractTrader
{
    class TradeProcessorVersion2 : ITradeProcessor
    {
        public IEnumerable<string> ReadTradeData(Stream stream)
        {
            var tradeData = new List<string>();
            LogMessage("INFO: Simulating ReadTradeData version 2");
            return tradeData;
        }

        public IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> tradeData)
        {
            var trades = new List<TradeRecord>();
            LogMessage("INFO: Simulating ParseTrades version 2");
            return trades;
        }
        public TradeRecord MapTradeDataToTradeRecord(string[] fields)
        {
            var sourceCurrencyCode = fields[0].Substring(0, 3);
            var destinationCurrencyCode = fields[0].Substring(3, 3);
            var tradeAmount = int.Parse(fields[1]);
            var tradePrice = decimal.Parse(fields[2]);
            const float LotSize = 100000f;
            var trade = new TradeRecord
            {
                SourceCurrency = sourceCurrencyCode,
                DestinationCurrency = destinationCurrencyCode,
                Lots = tradeAmount / LotSize,
                Price = tradePrice
            };

            return trade;
        }

        public void StoreTrades(IEnumerable<TradeRecord> trades)
        {
            LogMessage("INFO: Simulating database connection in StoreTrades version 2");
            // Not really connecting to database in this sample
            LogMessage("INFO: {0} trades processed", trades.Count());
        }

        public void LogMessage(string message, params object[] args)
        {
            Console.WriteLine(message, args);
            // added for Request 408
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log>" + message + "</log>", args);
            }

        }

        public void ProcessTrades(Stream stream)
        //public void ProcessTrades(string url)
        {
            var lines = ReadTradeData(stream);
            //var lines = ReadURLTradeData(url);
            var trades = ParseTrades(lines);
            StoreTrades(trades);
        }
    }
}
