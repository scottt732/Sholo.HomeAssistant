using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Extensions.Options;
using MiniValidation;

namespace Sholo.HomeAssistant.Utilities.Validation;

public class MiniValidatorValidateOptions<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TOptions>
    : IValidateOptions<TOptions>
        where TOptions : class
{
    private IServiceProvider ServiceProvider { get; }

    /// <summary>
    /// Gets the options name.
    /// </summary>
    private string Name { get; }

    /// <summary>
    /// Gets a value indicating whether the object graph should be recursively enumerated
    /// </summary>
    private bool Recurse { get; }

    /// <summary>
    /// Gets a value indicating whether asynchronous validation is allowed
    /// </summary>
    private bool AllowAsync { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MiniValidatorValidateOptions{TOptions}"/> class.
    /// </summary>
    /// <param name="serviceProvider">The <see cref="IServiceProvider" /> used by the validator</param>
    /// <param name="name">The name of the option.</param>
    /// <param name="recurse">Indicates whether or not to recurse object graph during validation</param>
    /// <param name="allowAsync">Allow asynchronous validation</param>
    public MiniValidatorValidateOptions(IServiceProvider serviceProvider, string name, bool recurse, bool allowAsync)
    {
        ServiceProvider = serviceProvider;
        Name = name;
        Recurse = recurse;
        AllowAsync = allowAsync;
    }

    /// <summary>
    /// Validates a specific named options instance (or all when <paramref name="name"/> is null).
    /// </summary>
    /// <param name="name">The name of the options instance being validated.</param>
    /// <param name="options">The options instance.</param>
    /// <returns>The <see cref="ValidateOptionsResult"/> result.</returns>
    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        // Null name is used to configure all named options.
        if (Name != null && Name != name)
        {
            // Ignored if not validating this instance.
            return ValidateOptionsResult.Skip;
        }

        // Ensure options are provided to validate against
        ArgumentNullException.ThrowIfNull(options);

        if (MiniValidator.TryValidate(options, ServiceProvider, Recurse, AllowAsync, out var validationResults))
        {
            return ValidateOptionsResult.Success;
        }

        var allErrors = new List<string>();
        foreach (var (key, errors) in validationResults)
        {
            allErrors.AddRange(errors.Select(error => $"{key}: {error}"));
        }

        return ValidateOptionsResult.Fail(allErrors);
    }
}
