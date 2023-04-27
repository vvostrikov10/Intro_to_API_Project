using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace MyFirstAPI.Models
{
    public class Character
    {
        [Key]
        public string CharacterName { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public string? CharaClassID { get; set; }
        public CharacterClass? CharaClass { get; set; }
        public string? CharaSubClassID { get; set; }
        public CharacterSubClass? CharaSubClass { get; set; }
    }
}
