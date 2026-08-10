using MacroTools.Localization;
using MacroTools.TestSupport;

namespace MacroTools.Tests.Localization;

public sealed class LocalizedTextTests : LocTestsBase
{
  [Fact]
  public void ToString_PlainStringImplicitConversion_ReturnsTranslatedText()
  {
    // Arrange
    Loc.SetTranslations(new Dictionary<string, IReadOnlyDictionary<string, string>>
    {
      ["lang-with-translation"] = new Dictionary<string, string>
      {
        ["source"] = "translated"
      }
    });
    LocalizedText text = "source";

    // Act
    var result = text.ToString("lang-with-translation");

    // Assert
    Assert.Equal("translated", result);
  }

  [Fact]
  public void ToString_SingleArgWithTranslatedTemplate_SubstitutesTranslatedTemplateAndValue()
  {
    // Arrange
    Loc.SetTranslations(new Dictionary<string, IReadOnlyDictionary<string, string>>
    {
      ["lang-with-translation"] = new Dictionary<string, string>
      {
        ["template {x}"] = "translated {x}"
      }
    });
    var text = LocalizedText.Create("template {x}", LocalizedTextArg.Create("{x}", "x-value"));

    // Act
    var result = text.ToString("lang-with-translation");

    // Assert
    Assert.Equal("translated x-value", result);
  }

  [Fact]
  public void ToString_NoTranslationForLanguage_ReturnsEnglishTemplateFallback()
  {
    // Arrange
    var text = LocalizedText.Create("template {a}", LocalizedTextArg.Create("{a}", "a-value"));

    // Act
    var result = text.ToString("lang-without-translation");

    // Assert
    Assert.Equal("template a-value", result);
  }

  [Fact]
  public void ToString_CalledTwiceWithDifferentLanguages_ProducesDifferentOutputFromTheSameStoredValue()
  {
    // Arrange
    Loc.SetTranslations(new Dictionary<string, IReadOnlyDictionary<string, string>>
    {
      ["lang-with-translation"] = new Dictionary<string, string>
      {
        ["template {x}"] = "translated {x}"
      }
    });
    var text = LocalizedText.Create("template {x}", LocalizedTextArg.Create("{x}", "x-value"));

    // Act
    var english = text.ToString(null);
    var translated = text.ToString("lang-with-translation");

    // Assert
    Assert.Equal("template x-value", english);
    Assert.Equal("translated x-value", translated);
  }

  [Fact]
  public void ToString_ResolvedArgValueContainsAnotherArgsToken_DoesNotReSubstituteIt()
  {
    // Arrange
    var text = LocalizedText.Create("{a} {b}",
      LocalizedTextArg.Create("{a}", "{b}"),
      LocalizedTextArg.Create("{b}", "b-value"));

    // Act
    var result = text.ToString(null);

    // Assert
    Assert.Equal("{b} b-value", result);
  }

  [Fact]
  public void ToString_TokenAppearsTwiceInTemplate_SubstitutesBothOccurrences()
  {
    // Arrange
    var text = LocalizedText.Create("{a} {a}", LocalizedTextArg.Create("{a}", "a-value"));

    // Act
    var result = text.ToString(null);

    // Assert
    Assert.Equal("a-value a-value", result);
  }

  [Fact]
  public void ToString_ThreeArgsWithTokenFarFromStart_SubstitutesAll()
  {
    // Arrange
    var text = LocalizedText.Create("before {a} ({b}/{c})",
      LocalizedTextArg.Create("{a}", "a-value"),
      LocalizedTextArg.Create("{b}", "b-value"),
      LocalizedTextArg.Create("{c}", "c-value"));

    // Act
    var result = text.ToString(null);

    // Assert
    Assert.Equal("before a-value (b-value/c-value)", result);
  }

  [Fact]
  public void ToString_ArgsOutOfOrderRelativeToTemplate_SubstitutesInTemplateOrder()
  {
    // Arrange
    var text = LocalizedText.Create("{second} then {first}",
      LocalizedTextArg.Create("{first}", "first-value"),
      LocalizedTextArg.Create("{second}", "second-value"));

    // Act
    var result = text.ToString(null);

    // Assert
    Assert.Equal("second-value then first-value", result);
  }

  [Fact]
  public void ToString_WithPrefixOnMultiArgTemplate_PrependsAfterResolution()
  {
    // Arrange
    var text = LocalizedText.Create("{a}{b}",
        LocalizedTextArg.Create("{a}", "1"),
        LocalizedTextArg.Create("{b}", "2"))
      .WithPrefix("0");

    // Act
    var result = text.ToString(null);

    // Assert
    Assert.Equal("012", result);
  }

  [Fact]
  public void ToString_WithSuffixOnMultiArgTemplate_AppendsAfterResolution()
  {
    // Arrange
    var text = LocalizedText.Create("{a}{b}",
        LocalizedTextArg.Create("{a}", "1"),
        LocalizedTextArg.Create("{b}", "2"))
      .WithSuffix("3");

    // Act
    var result = text.ToString(null);

    // Assert
    Assert.Equal("123", result);
  }

  [Fact]
  public void ToString_MultiArgsWithOneTokenAbsentFromTemplate_IgnoresUnusedArg()
  {
    // Arrange
    var text = LocalizedText.Create("Only {used} appears here",
      LocalizedTextArg.Create("{used}", "used-value"),
      LocalizedTextArg.Create("{unused}", "unused-value"));

    // Act
    var result = text.ToString(null);

    // Assert
    Assert.Equal("Only used-value appears here", result);
  }

  [Fact]
  public void ToString_MultiArgsWithRepeatedToken_SubstitutesAllOccurrences()
  {
    // Arrange
    var text = LocalizedText.Create("{a} {a} then {b}",
      LocalizedTextArg.Create("{a}", "a-value"),
      LocalizedTextArg.Create("{b}", "b-value"));

    // Act
    var result = text.ToString(null);

    // Assert
    Assert.Equal("a-value a-value then b-value", result);
  }

  [Fact]
  public void ToString_ArgValueIsNestedLocalizedTextWithItsOwnArgs_ResolvesRecursively()
  {
    // Arrange
    var text = LocalizedText.Create("outer:{a}", LocalizedTextArg.Create("{a}",
      LocalizedText.Create("inner:{b}", LocalizedTextArg.Create("{b}", "b-value"))));

    // Act
    var result = text.ToString(null);

    // Assert
    Assert.Equal("outer:inner:b-value", result);
  }

  [Fact]
  public void ToString_ArgValueIsNestedLocalizedTextRequiringItsOwnTranslation_TranslatesRecursively()
  {
    // Arrange
    Loc.SetTranslations(new Dictionary<string, IReadOnlyDictionary<string, string>>
    {
      ["lang-with-translation"] = new Dictionary<string, string>
      {
        ["source"] = "translated"
      }
    });
    var text = LocalizedText.Create("outer:{a}", LocalizedTextArg.Create("{a}", "source"));

    // Act
    var result = text.ToString("lang-with-translation");

    // Assert
    Assert.Equal("outer:translated", result);
  }
}
