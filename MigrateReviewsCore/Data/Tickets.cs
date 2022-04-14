using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore.Data
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

    }

    internal class Comment
    { 
        public string body { get; set; }
    }
}
