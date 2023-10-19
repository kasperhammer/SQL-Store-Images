using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //this is my Image Model where i store my ImageId and the Byte Array
    public class Images
    {
        [Key]
        public int ImageID { get; set; }

        public byte[] ImageURl { get; set; }

       
    }
}
