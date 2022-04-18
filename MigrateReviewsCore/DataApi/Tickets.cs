using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore.DataApi
{
    internal class CreationTeket
    { 
        public Tickets Ticket { get; set; }
    }
    internal class Tickets
    {
        public Comment Comment { get; set; }
        public string Priority { get; set; }
        public string Bubject { get; set; }
        public string[] Tags { get; set; }
    }
    internal class Comment
    { 
        public string Body { get; set; }
    }
}
