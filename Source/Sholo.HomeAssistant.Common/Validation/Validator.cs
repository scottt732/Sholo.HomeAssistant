using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Sholo.HomeAssistant.Validation
{
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

        public bool Validate<TObject>(TObject @object)
            where TObject : class
        {
            var context = new ValidationContext(@object, ServiceProvider, items: null);
            var results = new List<ValidationResult>();

            var isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(@object, context, results);
            if (!isValid)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Invalid message:");
                foreach (var result in results)
                {
                    sb.AppendLine($" - {result.ErrorMessage} ({string.Join(", ", result.MemberNames)})");
                }

                Logger.LogWarning(sb.ToString());
                return false;
            }

            return true;
        }
    }
}