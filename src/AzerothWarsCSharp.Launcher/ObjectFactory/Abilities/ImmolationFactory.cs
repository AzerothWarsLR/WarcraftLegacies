using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class ImmolationFactory : ActiveAbilityFactory<ImmolationCreep>
  {
    public float[] BufferManaRequired { get; set; } = System.Array.Empty<float>();
    public float[] DamagePerSecond { get; set; } = System.Array.Empty<float>();
    public float[] ManaDrainedPerSecond { get; set; } = System.Array.Empty<float>();
    public float[] AreaOfEffect { get; set; } = System.Array.Empty<float>();

    private void GenerateTooltip(ImmolationCreep ability)
    {
      ability.TextName = TextName;
    }

    private void GenerateCoreImmolation(ImmolationCreep ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataBufferManaRequired[i+1] = i < BufferManaRequired.Length ? BufferManaRequired[i] : 0;
        ability.DataDamagePerInterval[i+1] = i < DamagePerSecond.Length ? DamagePerSecond[i] : 0;
        ability.DataManaDrainedPerSecond[i+1] = i < ManaDrainedPerSecond.Length ? ManaDrainedPerSecond[i] : 0;
        ability.StatsDurationNormal[i + 1] = 1;
      }
      ability.ArtButtonPositionNormalX = ButtonPosition.X;
      ability.ArtButtonPositionNormalY = ButtonPosition.Y;
      ability.ArtIconNormal = ArtIcon;
      ability.ArtIconResearch = ArtIcon;
    }

    public override ImmolationCreep Generate(string newRawCode)
    {
      var newAbility = new ImmolationCreep(newRawCode);
      GenerateCore(newAbility);
      GenerateCoreImmolation(newAbility);
      GenerateTooltip(newAbility);
      return newAbility;
    }

  }
}