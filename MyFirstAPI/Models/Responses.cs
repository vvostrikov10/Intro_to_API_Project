using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace MyFirstAPI.Models
{
    public class CharacterResponse
    {
        public int statusCode {  get; set; }
        public string statusDescription { get; set; }
        public List<Character> characters { get; set; } = new();
    }

    public class ClassResponse
    {
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public List<CharacterClass> classes { get; set; } = new();
    }

    public class SubClassResponse
    {
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public List<CharacterSubClass> subClasses { get; set; } = new();
    }
}
