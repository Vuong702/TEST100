using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST100.Models
{
    public class NVVHN
    {
        [Key]
        public string Quequan { get; set; }
        [ForeignKey("Quequan")]
        public NVVBN? NVVBN{get; set;}
        
        public string NGo { get; set; }
       
        public string Sonha{ get; set; }
       
    }
}
