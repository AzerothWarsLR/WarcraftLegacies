using System.Collections.Generic;
using System.Text;
using War3Net.Build.Object;

namespace AzerothWarsCSharp.DataExtractor
{
  public class UnitFactoryGenerator
  {
    private static readonly Dictionary<int, string> _idToPropertyName = new()
    {
      { 1651864693, "Flavor"},
      { 1868786037, "Icon" },
      { 1835101813, "Name" },
      { 1718840949, "EditorSuffix" },
      { 1952542837, "PathTexture" },
      { 1885433973, "PlacementRequires" },
      { 1768055157, "AbilitiesNormal" },
      { 1949458805, "AttackType2" },
      { 1633907573, "ModelScale" },
      { 1832018293, "Missile2" },
      { 1885959285, "TooltipBasic" },
      { 1919381621, "Upgrades" },
      { 1953458293, "Hotkey" },
      { 1835098997, "Campaign" },
      { 1819239285, "CollisionSize" },
      { 1915838837, "Range1" },
      { 1915904373, "Range2" },
      { 2037671029, "DefenseType" },
      { 1882284405, "AreaOfEffectTargets" },
      { 1731289461, "Targets1" },
      { 1731354997, "Targets2" },
      { 1684824693, "BuildTime" },
      { 2020631157, "ButtonPositionX" },
      { 1717920885, "Armor" },
      { 1819240309, "GoldCost" },
      { 1919903605, "RepairGoldCost" },
      { 1836083317, "HitPoints" },
      { 1836412021, "LumberCost" },
      { 1936028277, "Researches" },
      { 1634890869, "Trains" },
      { 1887007861, "Classification" },
      { 1902338421, "AcquisitionRange" },
      { 1668510581, "SelectionScale" },
      { 1949393269, "DamageType1" },
      { 1919705973, "TintRed" },
      { 1651270517, "TintGreen" },
      { 1735156597, "TintBlue" },
      { 1986358389, "Level" },
      { 1768975733, "StartingMana" },
      { 1836084597, "Mana" },
      { 1831952757, "MissileArt" },
      { 829645429, "AnimationBackswingPoint" },
      { 1664180597, "AttackCooldown1" },
      { 1634034805, "DamageNumberOfDice1" },
      { 1647403381, "DamageBase1" },
      { 829449333, "AnimationDamagePoint" },
      { 1769107573, "CollisionSize" },
      { 1919970677, "ManaRegeneration" },
      { 1953654901, "RegenType" },
      { 1836348021, "RepairTime" },
      { 1937141109, "MovementSpeed" },
      { 1650550901, "AbilitiesHero" },
      { 1869770869, "ProperNames" },
      { 1684960117, "SoundSet" },
      { 1853190773, "AnimationRunSpeed" },
      { 1818326901, "AnimationWalkSpeed" },
      { 1818520949, "Model" },
      { 1953980789, "AwakenTooltip" },
      { 1919972469, "ReviveTooltip" },
      { 1634889845, "PrimaryAttribute" },
      { 1886284149, "IntelligencePerLevel" },
      { 1885823349, "AgilityPerLevel" },
      { 1768382837, "Agility" },
      { 1953393013, "Intelligence" },
      { 1769173877, "ScoreScreenIcon" },
      { 2050056565, "MissileSpeed" },
      { 1634559605, "FoodProduced" },
      { 1633772661, "DefaultActiveAbility" },
      { 1836017781, "HideOnMinimap" },
      { 1919969397, "HitPointRegeneration" },
      { 1684632437, "SightRadius" },
      { 1667330677, "Race" },
      { 1936681077, "Priority" },
      { 1868720501, "RevivesDeadHeroes" },
      { 1635083125, "CasterUpgradeArt" },
      { 1853186933, "CasterUpgradeNames" },
      { 1953850229, "CasterUpgradeTooltip" },
      { 2020633717, "ProjectileLaunchX" },
      { 2037410933, "ProjectileLaunchY" },
      { 2054188149, "ProjectileLaunchZ" },
      { 1999724917, "WeaponType1" },
      { 1768186485, "BountyDice" },
      { 1633837685, "BountyPlus" },
      { 1769169525, "BountySides" },
      { 2037408373, "ButtonPositionY" },
      { 1869571701, "FoodCost" },
      { 1920363893, "TurnRate" },
      { 1634562933, "StockMaximum" },
      { 1920298101, "LumberRepairCost" },
      { 1714512245, "SplashAreaFull1" },
      { 1902473845, "Requires" },
      { 1932681589, "DamageSidesPerDie2" },
      { 1932616053, "DamageSidesPerDie1" },
      { 1868788853, "TeamColor" },
      { 829645685, "WeaponType1" },
      { 1886679925, "StrengthPerLevel" },
      { 1920234357, "Strength" },
      { 829187189, "DamageLossFactor" },
      { 828468597, "MissileArc" },
      { 828601461, "MaximumAttackTargets1" },
      { 1953918325, "MovementType" },
      { 1752591733, "MovementHeight" },
      { 1719037301, "MovementHeightMinimum" },
    };

    private static string IdToPropertyName(int id)
    {
      if (_idToPropertyName.ContainsKey(id))
      {
        return _idToPropertyName[id];
      }
      return $"//{id}";
    }

    private string Generate(SimpleObjectModification unit)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.AppendLine(@"      //UnitName");
      stringBuilder.AppendLine(@"      new UnitFactory(UnitType.OriginUnit)");
      stringBuilder.AppendLine(@"      {");
      foreach (var mod in unit.Modifications)
      {
        stringBuilder.AppendLine($"        {IdToPropertyName(mod.Id)} = {mod.Value},");
      }
      stringBuilder.AppendLine($"      }}.Generate(\"UnitCode\", objectDatabase);");
      stringBuilder.AppendLine();
      return stringBuilder.ToString();
    }

    public string GenerateAll(ObjectData objectData)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.AppendLine("using AzerothWarsCSharp.Launcher.ObjectFactory.Units;");
      stringBuilder.AppendLine("using System.Drawing;");
      stringBuilder.AppendLine("using War3Api.Object;");
      stringBuilder.AppendLine();
      stringBuilder.AppendLine("namespace AzerothWarsCSharp.Launcher.ObjectFactory");
      stringBuilder.AppendLine("{");
      stringBuilder.AppendLine("  public static class Generated");
      stringBuilder.AppendLine("  {");
      stringBuilder.AppendLine("    public static void GenerateObjectData(ObjectDatabase objectDatabase)");
      stringBuilder.AppendLine("    {");
      foreach (var unit in objectData.GetAllUnits())
      {
        stringBuilder.Append(Generate(unit));
      }
      stringBuilder.AppendLine("    }");
      stringBuilder.AppendLine("  }");
      stringBuilder.AppendLine("}");
      return stringBuilder.ToString();
      
    }
  }
}
