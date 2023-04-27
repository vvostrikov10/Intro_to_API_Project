using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstAPI.Models
{
    public class CharacterClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? CharaClassID { get; set; }
        public string? Proficiencies { get; set; }
        public string? ClassFeatures { get; set; }
    }
}
