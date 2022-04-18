using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore.DataApi
{
    internal class ResultTransactions
    {
        public Data data { get; set; }
    }
    internal class Data
    { 
        public Items[] Items { get; set; }
    }
    internal class Items
    { 
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string Rating { get; set; }
        public string PlaceExternalId { get; set; }
    }
}
