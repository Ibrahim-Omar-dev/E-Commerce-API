using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Categorys
{
    public class CategoryUpdate : CategoryBase
    {
        [Required]
        public Guid Id { get; set; }
    }
}