using System.ComponentModel.DataAnnotations;
using WebAPI_Super.Enums;

namespace WebAPI_Super.Models
{
    public class SuperPoderesModel
    {
        [Key]
        public int Id { get; set; }
        public SuperPoderesEnum SuperPoder { get; set; }
        public string Descricao { get; set; }
    }
}
