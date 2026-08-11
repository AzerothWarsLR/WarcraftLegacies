using MacroTools.Localization;
using MacroTools.TestSupport;

namespace MacroTools.Tests.Localization;

public sealed class LocTests : LocTestsBase
{
  [Fact]
  public void Get_TranslationExists_ReturnsTranslatedText()
  {
    // Arrange
    Loc.SetTranslations(new Dictionary<string, IReadOnlyDictionary<string, string>>
    {
      ["lang-with-translation"] = new Dictionary<string, string>
      {
        ["source"] = "translated"
      }
    });

    // Act
    var result = Loc.Get("source", "lang-with-translation");

    // Assert
    Assert.Equal("translated", result);
  }

  [Fact]
  public void Get_NoTranslationForLanguage_ReturnsEnglishFallback()
  {
    // Arrange

    // Act
    var result = Loc.Get("source", "lang-without-translation");

    // Assert
    Assert.Equal("source", result);
  }

  [Fact]
  public void Get_UnknownKey_ReturnsInputUnchanged()
  {
    // Arrange
    Loc.SetTranslations(new Dictionary<string, IReadOnlyDictionary<string, string>>
    {
      ["lang-with-translation"] = new Dictionary<string, string>
      {
        ["source"] = "translated"
      }
    });

    // Act
    var result = Loc.Get("other-source", "lang-with-translation");

    // Assert
    Assert.Equal("other-source", result);
  }

  [Fact]
  public void Get_NullLanguage_ReturnsEnglishFallback()
  {
    // Arrange

    // Act
    var result = Loc.Get("source", null);

    // Assert
    Assert.Equal("source", result);
  }

  [Fact]
  public void Format_TranslationExists_SubstitutesTranslatedTemplateAndValue()
  {
    // Arrange
    Loc.SetTranslations(new Dictionary<string, IReadOnlyDictionary<string, string>>
    {
      ["lang-with-translation"] = new Dictionary<string, string>
      {
        ["Hello, {name}"] = "Translated hello, {name}",
        ["name"] = "translated name"
      }
    });

    // Act
    var result = Loc.Format("Hello, {name}", "lang-with-translation", ("{name}", "name"));

    // Assert
    Assert.Equal("Translated hello, translated name", result);
  }

  [Fact]
  public void Format_NoTranslationForLanguage_SubstitutesIntoEnglishTemplate()
  {
    // Arrange

    // Act
    var result = Loc.Format("Hello, {name}", null, ("{name}", "name"));

    // Assert
    Assert.Equal("Hello, name", result);
  }
}
