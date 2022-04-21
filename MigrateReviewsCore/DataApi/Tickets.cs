using Newtonsoft.Json;

namespace MigrateReviewsCore.DataApi
{
    internal class CreationTeket
    { 
        public Tickets ticket { get; set; }
    }
    internal class Tickets
    {
        public Comment comment { get; set; }
        public string priority { get; set; }
        public string subject { get; set; }
        public string[] tags { get; set; }
        public CustomFilds custom_fields { get; set; }
    }

    internal class Comment
    { 
        public string body { get; set; }
    }
    internal class CustomFilds
    {
        //рейтинг
        [JsonProperty(PropertyName = "360017986557")]
        public int rating { get;set;}

        [JsonProperty(PropertyName = "360016140737")]
        public string? NumberPlace { get; set; }

        [JsonProperty(PropertyName = "360016145197")]
        public string InvoceId { get; set; }
    }
}
