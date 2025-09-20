namespace WarcraftLegacies.Source.Spells.ExactJustice;

public sealed class ExactJusticeEffectSettings
{
  public string SparklePath { get; init; } = "";

  public float SparkleScale { get; init; } = 1f;

  public string RingPath { get; init; } = "";

  public float RingScale { get; init; } = 1f;

  public string ProgressBarPath { get; init; } = "";

  public float ProgressBarScale { get; init; } = 1f;

  public float ProgressBarHeight { get; init; } = 225f;

  public string ExplodePath { get; init; } = "";

  public float ExplodeScale { get; init; } = 1f;

  public float AlphaRing { get; init; } = 255;

  public float AlphaFade { get; init; }
}
