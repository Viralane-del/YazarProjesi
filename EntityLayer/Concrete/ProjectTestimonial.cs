using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProjectTestimonial
    {
        [Key]
        public int TestimonialID{ get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Comment{ get; set; }
    }
}
