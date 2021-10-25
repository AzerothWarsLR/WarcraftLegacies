using System.Collections.Generic;
using System.Text;
using War3Net.Build.Object;

namespace AzerothWarsCSharp.DataExtractor
{
  public class UnitFactoryGenerator
  {
    private static readonly Dictionary<int, (string propertyName, PropertyValueType type)> _idToPropertyMetadata = new()
    {
      { 1651864693, ("Flavour", PropertyValueType.String) },
      { 1868786037, ("Icon", PropertyValueType.String) },
      { 1835101813, ("Name", PropertyValueType.String) },
      { 1718840949, ("EditorSuffix", PropertyValueType.String) },
      { 1952542837, ("PathTexture", PropertyValueType.String) },
      { 1885433973, ("PlacementRequires", PropertyValueType.String) },
      { 1768055157, ("AbilitiesNormal", PropertyValueType.String) },
      { 1949458805, ("AttackType2", PropertyValueType.String) },
      { 1633907573, ("ModelScale", PropertyValueType.String) },
      { 1832018293, ("Missile2", PropertyValueType.String) },
      { 1885959285, ("TooltipBasic", PropertyValueType.String) },
      { 1919381621, ("ResearchesUsed", PropertyValueType.String) },
      { 1953458293, ("Hotkey", PropertyValueType.String) },
      { 1835098997, ("Campaign", PropertyValueType.String) },
      { 1819239285, ("CollisionSize", PropertyValueType.String) },
      { 1915838837, ("Range1", PropertyValueType.String) },
      { 1915904373, ("Range2", PropertyValueType.String) },
      { 2037671029, ("DefenseType", PropertyValueType.String) },
      { 1882284405, ("AreaOfEffectTargets", PropertyValueType.String) },
      { 1731289461, ("Targets1", PropertyValueType.String) },
      { 1731354997, ("Targets2", PropertyValueType.String) },
      { 1684824693, ("BuildTime", PropertyValueType.String) },
      { 2020631157, ("ButtonPositionX", PropertyValueType.String) },
      { 1717920885, ("Armor", PropertyValueType.String) },
      { 1819240309, ("GoldCost", PropertyValueType.String) },
      { 1919903605, ("RepairGoldCost", PropertyValueType.String) },
      { 1836083317, ("HitPoints", PropertyValueType.String) },
      { 1836412021, ("LumberCost", PropertyValueType.String) },
      { 1936028277, ("Researches", PropertyValueType.String) },
      { 1634890869, ("Trains", PropertyValueType.String) },
      { 1887007861, ("Classification", PropertyValueType.String) },
      { 1902338421, ("AcquisitionRange", PropertyValueType.String) },
      { 1668510581, ("SelectionScale", PropertyValueType.String) },
      { 1949393269, ("DamageType1", PropertyValueType.String) },
      { 1919705973, ("TintRed", PropertyValueType.String) },
      { 1651270517, ("TintGreen", PropertyValueType.String) },
      { 1735156597, ("TintBlue", PropertyValueType.String) },
      { 1986358389, ("Level", PropertyValueType.String) },
      { 1768975733, ("StartingMana", PropertyValueType.String) },
      { 1836084597, ("Mana", PropertyValueType.String) },
      { 1831952757, ("MissileArt", PropertyValueType.String) },
      { 829645429, ("AnimationBackswingPoint", PropertyValueType.String) },
      { 1664180597, ("AttackCooldown1", PropertyValueType.String) },
      { 1634034805, ("DamageNumberOfDice1", PropertyValueType.String) },
      { 1647403381, ("DamageBase1", PropertyValueType.String) },
      { 829449333, ("AnimationDamagePoint", PropertyValueType.String) },
      { 1769107573, ("CollisionSize", PropertyValueType.String) },
      { 1919970677, ("ManaRegeneration", PropertyValueType.String) },
      { 1953654901, ("RegenType", PropertyValueType.String) },
      { 1836348021, ("RepairTime", PropertyValueType.String) },
      { 1937141109, ("MovementSpeed", PropertyValueType.String) },
      { 1650550901, ("AbilitiesHero", PropertyValueType.String) },
      { 1869770869, ("ProperNames", PropertyValueType.String) },
      { 1684960117, ("SoundSet", PropertyValueType.String) },
      { 1853190773, ("AnimationRunSpeed", PropertyValueType.String) },
      { 1818326901, ("AnimationWalkSpeed", PropertyValueType.String) },
      { 1818520949, ("Model", PropertyValueType.String) },
      { 1953980789, ("AwakenTooltip", PropertyValueType.String) },
      { 1919972469, ("ReviveTooltip", PropertyValueType.String) },
      { 1634889845, ("PrimaryAttribute", PropertyValueType.String) },
      { 1886284149, ("IntelligencePerLevel", PropertyValueType.String) },
      { 1885823349, ("AgilityPerLevel", PropertyValueType.String) },
      { 1768382837, ("Agility", PropertyValueType.String) },
      { 1953393013, ("Intelligence", PropertyValueType.String) },
      { 1769173877, ("ScoreScreenIcon", PropertyValueType.String) },
      { 2050056565, ("MissileSpeed", PropertyValueType.String) },
      { 1634559605, ("FoodProduced", PropertyValueType.String) },
      { 1633772661, ("DefaultActiveAbility", PropertyValueType.String) },
      { 1836017781, ("HideOnMinimap", PropertyValueType.String) },
      { 1919969397, ("HitPointRegeneration", PropertyValueType.String) },
      { 1684632437, ("SightRadius", PropertyValueType.String) },
      { 1667330677, ("Race", PropertyValueType.String) },
      { 1936681077, ("Priority", PropertyValueType.String) },
      { 1868720501, ("RevivesDeadHeroes", PropertyValueType.String) },
      { 1635083125, ("CasterUpgradeArt", PropertyValueType.String) },
      { 1853186933, ("CasterUpgradeNames", PropertyValueType.String) },
      { 1953850229, ("CasterUpgradeTooltip", PropertyValueType.String) },
      { 2020633717, ("ProjectileLaunchX", PropertyValueType.String) },
      { 2037410933, ("ProjectileLaunchY", PropertyValueType.String) },
      { 2054188149, ("ProjectileLaunchZ", PropertyValueType.String) },
      { 1999724917, ("WeaponType1", PropertyValueType.String) },
      { 1768186485, ("BountyDice", PropertyValueType.String) },
      { 1633837685, ("BountyPlus", PropertyValueType.String) },
      { 1769169525, ("BountySides", PropertyValueType.String) },
      { 2037408373, ("ButtonPositionY", PropertyValueType.String) },
      { 1869571701, ("FoodCost", PropertyValueType.String) },
      { 1920363893, ("TurnRate", PropertyValueType.String) },
      { 1634562933, ("StockMaximum", PropertyValueType.String) },
      { 1920298101, ("LumberRepairCost", PropertyValueType.String) },
      { 1714512245, ("SplashAreaFull1", PropertyValueType.String) },
      { 1902473845, ("Requires", PropertyValueType.String) },
      { 1932681589, ("DamageSidesPerDie2", PropertyValueType.String) },
      { 1932616053, ("DamageSidesPerDie1", PropertyValueType.String) },
      { 1868788853, ("TeamColor", PropertyValueType.String) },
      { 829645685, ("WeaponType1", PropertyValueType.String) },
      { 1886679925, ("StrengthPerLevel", PropertyValueType.String) },
      { 1920234357, ("Strength", PropertyValueType.String) },
      { 829187189, ("DamageLossFactor", PropertyValueType.String) },
      { 828468597, ("MissileArc", PropertyValueType.String) },
      { 828601461, ("MaximumAttackTargets1", PropertyValueType.String) },
      { 1953918325, ("MovementType", PropertyValueType.String) },
      { 1752591733, ("MovementHeight", PropertyValueType.String) },
      { 1719037301, ("MovementHeightMinimum", PropertyValueType.String) },
    };
    private readonly List<IPropertyAssignment> _propertyAssignments = new();
    private readonly SimpleObjectModification _unit;

    private void CreatePropertyAssignment(SimpleObjectDataModification mod)
    {
      if (_idToPropertyMetadata.ContainsKey(mod.Id))
      {
        var (propertyName, type) = _idToPropertyMetadata[mod.Id];
        switch (type)
        {
          case PropertyValueType.Int:
            _propertyAssignments.Add(new PropertyAssignmentInt()
            {
              Value = (int)mod.Value,
              PropertyName = propertyName
            });
            break;
          case PropertyValueType.String:
            _propertyAssignments.Add(new PropertyAssignmentString()
            {
              Value = mod.Value.ToString(),
              PropertyName = propertyName
            });
            break;
        }
      } else
      {
        _propertyAssignments.Add(new PropertyAssignmentString()
        {
          Value = mod.Value.ToString(),
          PropertyName = mod.Id.ToString()
        });
      }
    }

    public void Generate()
    {
      foreach (var mod in _unit.Modifications)
      {
        if (!string.IsNullOrEmpty(mod.Value.ToString()))
        {
          CreatePropertyAssignment(mod);
        }
      }
    }

    public string ToCode()
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.AppendLine(@"      //UnitName");
      stringBuilder.AppendLine(@"      new UnitFactory(UnitType.Peasant_hpea)");
      stringBuilder.AppendLine(@"      {");
      foreach (var propertyAssignment in _propertyAssignments)
      {
        stringBuilder.AppendLine($"        {propertyAssignment.ToCode()},");
      }
      stringBuilder.AppendLine($"      }}.Generate(\"UnitCode\", (objectDatabase);");
      stringBuilder.AppendLine();
      stringBuilder.AppendLine("    }");
      return stringBuilder.ToString();
    }

    public static string ToCodeAll(ObjectData objectData)
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
        var generator = new UnitFactoryGenerator(unit);
        generator.Generate();
        stringBuilder.Append(generator.ToCode());
      }
      stringBuilder.AppendLine("  }");
      stringBuilder.AppendLine("}");
      return stringBuilder.ToString();
    }

    public UnitFactoryGenerator(SimpleObjectModification unit)
    {
      _unit = unit;
    }
  }
}
