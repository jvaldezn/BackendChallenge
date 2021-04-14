using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendChallenge.API.Models
{
    public class CurrencyExchange
    {
        public int CurrencyExchangeId { get; set; }
        public int CurrencyId_From { get; set; }
        public int CurrencyId_To { get; set; }
        public double Equivalent { get; set; }
    }
}
