using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo.DTO
{
    public class SDImageDto
    {
        public int ATRCImageId { get; set; }
        public int ATRCId { get; set; }
        public string ImageName { get; set; }
        public string ContentType { get; set; }
        public string NewImageName { get; set; }
        public DateTime InsertedOn { get; set; }
        public string SDDec { get; set; }
        public string SDName { get; set; }
        public bool? IsSD { get; set; }
        public string ATRCName { get; set; }
        public string DiningFromTime { get; set; }
        public string DiningToTime { get; set; }
        public string Address { get; set; }
        public string SDDes { get; set; }
    }
}
