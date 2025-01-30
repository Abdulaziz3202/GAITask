using System.ComponentModel.DataAnnotations;

namespace GAITask.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}