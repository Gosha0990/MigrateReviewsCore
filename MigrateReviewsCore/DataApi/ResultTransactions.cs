using System;

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
        public string InvoiceId { get; set; }
        public string Comment { get; set; }
        public ItemReting Rating { get; set; }
        public string PlaceExternalId { get; set; }
    }
    internal class ItemReting
    {
        public int Score { get; set; }
    }
}
