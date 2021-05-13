using System.ComponentModel.DataAnnotations;

namespace DotnetIntro.Requests
{
    public class CommandCreateRequest
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}