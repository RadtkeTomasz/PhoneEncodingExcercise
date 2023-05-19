using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public record InputString
    {
        [MaxLength(20)]
        public string Text { get; set; } = string.Empty;
    }
}
