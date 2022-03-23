//Scourge always has vision over Northrend.

using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Mechanics.Scourge
{
  public static class NorthrendVision
  {
    private static fogmodifier[] _scourgeFogModifiers;

    private static void Enable()
    {
      player whichPlayer = ScourgeSetup.FactionScourge.Player;
      var i = 0;
      _scourgeFogModifiers[0] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.StormPeaks.Rect, true, true);
      _scourgeFogModifiers[1] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.CentralNorthrend.Rect, true, true);
      _scourgeFogModifiers[2] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.TheBasin.Rect, true, true);
      _scourgeFogModifiers[3] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.IceCrown.Rect, true, true);
      _scourgeFogModifiers[4] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.Fjord.Rect, true, true);
      _scourgeFogModifiers[5] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.EasternNorthrend.Rect, true, true);
      _scourgeFogModifiers[6] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.FarEasternNorthrend.Rect, true, true);
      _scourgeFogModifiers[7] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.Coldarra.Rect, true, true);
      _scourgeFogModifiers[8] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.BoreanTundra.Rect, true, true);
      _scourgeFogModifiers[9] =
        CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, Regions.IcecrownShipyard.Rect, true, true);

      foreach (var modifier in _scourgeFogModifiers) FogModifierStart(modifier);
    }

    private static void Disable()
    {
      foreach (var modifier in _scourgeFogModifiers) DestroyFogModifier(modifier);
    }

    private static void PersonChangesFaction()
    {
      player triggerPlayer;
      var i = 0;
      if (GetTriggerPerson().Faction == FACTION_SCOURGE)
        Enable();
      else if (GetChangingPersonPrevFaction() == FACTION_SCOURGE) Disable();
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      OnPersonFactionChange.register(trig);
      TriggerAddCondition(trig, PersonChangesFaction);

      if (FACTION_SCOURGE.Person != 0) Enable();
    }
  }
}