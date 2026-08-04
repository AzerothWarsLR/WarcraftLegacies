using MacroTools.Localization;

namespace MacroTools.Tests.Localization;

public sealed class LocTests
{
  [Fact]
  public void Get_TranslationExists_ReturnsTranslatedText()
  {
    // Arrange

    // Act
    var result = Loc.Get("Completed", "es");

    // Assert
    Assert.Equal("Completado", result);
  }

  [Fact]
  public void Get_NoTranslationForLanguage_ReturnsEnglishFallback()
  {
    // Arrange

    // Act
    var result = Loc.Get("Completed", "zh");

    // Assert
    Assert.Equal("Completed", result);
  }

  [Fact]
  public void Get_UnknownKey_ReturnsInputUnchanged()
  {
    // Arrange

    // Act
    var result = Loc.Get("Some untranslated string", "es");

    // Assert
    Assert.Equal("Some untranslated string", result);
  }

  [Fact]
  public void Get_NullLanguage_ReturnsEnglishFallback()
  {
    // Arrange

    // Act
    var result = Loc.Get("Completed", null);

    // Assert
    Assert.Equal("Completed", result);
  }

  [Fact]
  public void Format_TranslationExists_SubstitutesLocalizedToken()
  {
    // Arrange

    // Act
    var result = Loc.Format("You have joined {team}.", "es", ("{team}", "Alianza"));

    // Assert
    Assert.Equal("Te uniste a Alianza.", result);
  }

  [Fact]
  public void Format_NoTranslation_SubstitutesIntoEnglishTemplate()
  {
    // Arrange

    // Act
    var result = Loc.Format("You have joined {team}.", null, ("{team}", "Alliance"));

    // Assert
    Assert.Equal("You have joined Alliance.", result);
  }
}
