using System.ComponentModel.DataAnnotations;

namespace Sholo.HomeAssistant.Client.Settings
{
    public class HomeAssistantAuthOptions
    {
        [Required]
        public string Token { get; set; }
    }
}
