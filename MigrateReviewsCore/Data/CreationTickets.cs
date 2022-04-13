using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore.Data
{
    internal class CreationTickets
    {
        public Comment Comment { get; set; }
    }

    internal class Comment
    { 
        public string Body { get; set; }
    }
}
