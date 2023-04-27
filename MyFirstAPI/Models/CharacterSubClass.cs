using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstAPI.Models
{
    public class CharacterSubClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? CharaSubClassID { get; set; }
        public string? SubClassFeatures { get; set; }
    }
}
