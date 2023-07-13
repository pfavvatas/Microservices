/*
    We create the Models box from Screenshots\Platform_Service_Architecture.PNG
*/
using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Publisher { get; set; }

        [Required]
        public string? Cost { get; set; }
    }
}