using E_Commerce.Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Validation.Services
{
    public interface IValidationServices
    {
        Task<ServicesResponse> ValidateAsync<T>(T model, IValidator<T> validator);
    }
}
