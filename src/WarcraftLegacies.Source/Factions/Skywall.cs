﻿using MacroTools.FactionSystem;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public sealed class Skywall : Faction
  {
    /// <inheritdoc />
    public Skywall() : base("Elemental Lords", PLAYER_COLOR_SNOW, "|cffffffff",
      @"ReplaceableTextures\CommandButtons\BTNFrostRevenant2.blp")
    {
      ControlPointDefenderUnitTypeId = Constants.UNIT_U02T_CONTROL_POINT_DEFENDER_NAZJATAR;
      TraditionalTeam = TeamSetup.OldGods;
    }

    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      SharedFactionConfigSetup.AddSharedFactionConfig(this);
    }

    private void RegisterObjectLimits()
    {
      foreach (var (objectTypeId, objectLimit) in SkywallObjectLimitData.GetAllObjectLimits())
        ModObjectLimit(FourCC(objectTypeId), objectLimit);
    }
  }
}