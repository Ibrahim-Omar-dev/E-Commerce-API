using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Commerce.Application.Dto.Cart
{
    public class GetPaymentMethod
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
