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
        [Required]
        public int Year { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public int BestRanking { get; set; }
        [Required]
        public int PopularRanking { get; set; }
        [Required]
        public bool Seen { get; set; }
    

        public override string ToString()
        {            
            string ret = this.Name + "," +  this.Director + "," + this.Year + "," + this.Score + "," + this.BestRanking + "," + this.PopularRanking + "," + this.Seen;                
            return ret;
        }
    }
}
