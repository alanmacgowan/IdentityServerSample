using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServerSample.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public decimal? Price { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public int? Pages { get; set; }
    }
}
