using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_AufgabenWebApi.Data
{
    public class Aufgaben
    {
        public int Id { get; set; }


        [Required]
        public string Text { get; set; }

        [Display(Name = "Deadline Date")]
        public DateTime DeadlineDatum { get; set; }

        [Display(Name = "Aufgabe fertig")]
        public bool AufgabeFertig { get; set; }

        public override string ToString()
        {
            return $"{Text}:{DeadlineDatum}:{AufgabeFertig}";
        }

    }
}
