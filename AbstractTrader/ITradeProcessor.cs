using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AbstractTrader
{
    public interface ITradeProcessor
    {
        IEnumerable<string> ReadTradeData(Stream stream);

        IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> tradeData);

        void LogMessage(string message, params object[] args);

        void StoreTrades(IEnumerable<TradeRecord> trades);

        void ProcessTrades(Stream stream);


    }
}
