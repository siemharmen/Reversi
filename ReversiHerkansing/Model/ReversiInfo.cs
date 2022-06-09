using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiHerkansing.Model
{
    public class ReversiInfo
    {
        [Key]
        public int Id { get; set; }

        public int Beurt { get ; set; }

        public int SpelId { get; set; }

        public int Zwart { get; set; }
        public int Wit { get; set; }
        public int addZwart { get; set; }
        public int addWit { get; set; }

        public ReversiInfo(int beurt, int spelId, int zwart, int wit, int addZwart, int addWit)
        {
            Beurt = beurt;
            SpelId = spelId;
            Zwart = zwart;
            Wit = wit;
            this.addZwart = addZwart;
            this.addWit = addWit;
        }
    }
}
