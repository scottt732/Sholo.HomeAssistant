using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Sholo.HomeAssistant.Validation;

public class Validator : IValidator
{
    private IServiceProvider ServiceProvider { get; }
    private ILogger Logger { get; }

    public Validator(
        IServiceProvider serviceProvider,
        ILogger<Validator> logger
    )
    {
        ServiceProvider = serviceProvider;
        Logger = logger;
    }

    public bool Validate<TObject>(TObject obj)
        where TObject : class
    {
        var context = new ValidationContext(obj, ServiceProvider, items: null);
        var results = new List<ValidationResult>();

        var isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, context, results);
        if (!isValid)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Invalid message:");
            foreach (var result in results)
            {
#pragma warning disable CA1305 // Specify IFormatProvider
                sb.AppendLine($" - {result.ErrorMessage} ({string.Join(", ", result.MemberNames)})");
#pragma warning restore CA1305 // Specify IFormatProvider
            }

            Logger.LogWarning("{Message}", sb.ToString());
            return false;
        }

        return true;
    }
}
