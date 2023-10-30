using System.ComponentModel.DataAnnotations;

namespace Sholo.HomeAssistant.Settings
{
    public class HomeAssistantAuthOptions
    {
        [Required]
        public string Token { get; set; } = null!;
    }
}
