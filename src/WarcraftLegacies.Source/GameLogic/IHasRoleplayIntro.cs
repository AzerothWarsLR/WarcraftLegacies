namespace WarcraftLegacies.Source.GameLogic;

/// <summary>A faction with its own intro text for Roleplay mode.</summary>
public interface IHasRoleplayIntro
{
  /// <summary>The intro shown instead of the faction's usual one in Roleplay mode.</summary>
  string RoleplayIntroText { get; }
}
