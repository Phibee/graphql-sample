using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastraxGlobal.Domain.Entities
{
    public class Episode
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int HeroId { get; set; }
    }
}
