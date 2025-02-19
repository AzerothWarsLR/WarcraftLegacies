using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits
{
  public static class IllidariObjectInfo
  {
    private const int Unlimited = 200;

    public static IEnumerable<ObjectInfo> GetAllObjectLimits()
    {
      yield return new(UNIT_NNTT_BETRAYER_S_RESERVOIR_ILLIDARI_T1, Unlimited, UnitCategory.TownHall);
      yield return new("n04T", Unlimited); //Monument of Currents
      yield return new("n055", Unlimited); //Temple of Tides
      yield return new("nnad", Unlimited); //Altar of the Depths
      yield return new("nnsg", Unlimited); //Spawning Grounds
      yield return new("h06S", Unlimited); //Coral Forge
      yield return new("n0A3", Unlimited); //Royal Pyramid
      yield return new("nnsa", Unlimited); //Temple of Azshara
      yield return new("nnfm", Unlimited); //Coral Beds
      yield return new("nntg", Unlimited); //Tidal Guardian
      yield return new("n005", Unlimited); //Improved Tidal Guardian
      yield return new("nmrb", Unlimited); //Deep Sea Vault
      yield return new("n08W", Unlimited); //Deep Sea Vault
      yield return new(UNIT_E020_ANCIENT_SHIPYARD_NAGA_SHIPYARD, Unlimited, UnitCategory.Shipyard);
      yield return new(UNIT_NMPE_MUR_GUL_SLAVE_ILLIDARI_NZOTH_WORKER, Unlimited, UnitCategory.Worker);
      yield return new("nmyr", Unlimited); //Myrmidon
      yield return new("nsnp", Unlimited); //Snap Dragon
      yield return new("nnsw", Unlimited); //Siren
      yield return new("nmsc", Unlimited); //Shadowcaster
      yield return new("nnsu", 6); //Summoner
      yield return new("nnrg", 6); //Royal Guard
      yield return new("nhyc", 8); //Dragon Turtle
      yield return new("nwgs", 8); //Couatl
      yield return new("e00Y", 4); //Scylla
      yield return new("h0AC", 6); //Sea Witch
      yield return new("ndrn", Unlimited); //AshtongueMelee
      yield return new("ndrs", 6); //Ashtonguecaster
      yield return new("etrs", Unlimited); //Night Elf Transport Ship
      yield return new("h0AU", Unlimited); // Scout
      yield return new("h0AV", Unlimited); // Frigate
      yield return new("h0B1", Unlimited); // Fireship
      yield return new("h057", Unlimited); // Galley
      yield return new("h0B4", Unlimited); // Boarding
      yield return new("h0BA", Unlimited); // Juggernaut
      yield return new("h0B8", 6); // Bombard
      yield return new("Hvsh", 1); //Vashj
      yield return new("U00S", 1); //Najentus
      yield return new("Naka", 1); //Akama
      yield return new("Eevi", 1); //Illidan
      yield return new(UPGRADE_RNSW_NAGA_SIREN_ADEPT_TRAINING_NAGA_SIREN_MASTER_TRAINING, Unlimited);
      yield return new(UPGRADE_R02V_SHADOWCASTER_MASTER_TRAINING, Unlimited);
    }
  }
}