using System;
using System.Collections.Generic;

namespace Sholo.HomeAssistant.Exceptions;

[PublicAPI]
public class HomeAssistantCommandException : Exception
{
    public string? Code { get; }
    public string? TranslationKey { get; set; }
    public string? TranslationDomain { get; set; }
    public IDictionary<string, object?>? TranslationPlaceholders { get; }

    public HomeAssistantCommandException()
        : base("HomeAssistant result did not indicate success")
    {
    }

    public HomeAssistantCommandException(Exception innerException)
        : base("HomeAssistant result did not indicate success", innerException)
    {
    }

    public HomeAssistantCommandException(string message)
        : base(message)
    {
    }

    public HomeAssistantCommandException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public HomeAssistantCommandException(
        string message,
        string code,
        string? translationKey = null,
        string? translationDomain = null,
        IDictionary<string, object?>? translationPlaceholders = null
    )
        : this(message)
    {
        Code = code;
        TranslationKey = translationKey;
        TranslationDomain = translationDomain;
        TranslationPlaceholders = translationPlaceholders;
    }

    public HomeAssistantCommandException(
        Exception innerException,
        string message,
        string code,
        string? translationKey = null,
        string? translationDomain = null,
        IDictionary<string, object?>? translationPlaceholders = null
    )
        : this(message, innerException)
    {
        Code = code;
        TranslationKey = translationKey;
        TranslationDomain = translationDomain;
        TranslationPlaceholders = translationPlaceholders;
    }
}
