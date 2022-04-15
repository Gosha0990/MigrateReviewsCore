using System.ComponentModel.DataAnnotations;

namespace MigrateReviewsCore.DataBase
{

    internal class CloudTips
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Data { get; set; }
        [Required]
        public string Comment { get; set; }
        
    }
}
