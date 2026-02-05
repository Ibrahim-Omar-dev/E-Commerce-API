using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Categorys
{
    public class UpdateCategory : CategoryBase
    {
        [Required]
        public Guid Id { get; set; }
    }
}