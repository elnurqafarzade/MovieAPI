using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB201MovieApp.Core.Entities
{
    public class MovieImage : BaseEntity
    {
        public int MovieId { get; set; }
        public string ImageUrl { get; set; }
        public Movie Movie { get; set; }
    }
}
