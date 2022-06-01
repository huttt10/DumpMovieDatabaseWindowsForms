using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseWindowsForms.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Director { get; set; }

        public int Year { get; set; }

        public int Score { get; set; }

        public int BestRanking { get; set; }

        public int PopularRanking { get; set; }

        public bool Seen { get; set; }
    

        public override string ToString()
        {
            string ret = string.Empty;
            ret = this.Name + ", " +  this.Director + ", " + this.Year + ", " + this.Score + ", " + this.BestRanking + ", " + this.PopularRanking + ", " + this.Seen;

            return ret;
        }
    }
}
