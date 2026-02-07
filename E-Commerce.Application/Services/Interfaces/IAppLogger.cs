using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Services.Interfaces
{
    public interface IAppLogger
    {
        void LogWarning(string message);
        void LogError(string message, Exception exception = null!);
        void LogInformation(string message);
    }
}
