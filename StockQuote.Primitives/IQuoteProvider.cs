using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockQuote.Primitives
{
    public interface IQuoteProvider
    {
        IQuote GetQuote(string ticker);
    }
}
