using E_Commerce.Application.Dto.Categorys;

using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Commerce.Application.Dto.Product
{
    public class GetProduct : ProductBase
    {
        [Required]
        public Guid Id { get; set; }
        public GetCategory? Categorys{ get; set; }
    }
}
