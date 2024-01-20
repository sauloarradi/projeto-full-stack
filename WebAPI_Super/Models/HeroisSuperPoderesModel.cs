using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Super.Models
{
    [Keyless]
    public class HeroisSuperPoderesModel
    {
        public int HeroiId { get; set; }
        public int SuperPoderId { get; set; }
    }
}
