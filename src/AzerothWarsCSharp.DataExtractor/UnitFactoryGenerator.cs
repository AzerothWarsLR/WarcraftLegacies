using System.Collections.Generic;
using System.Text;
using War3Net.Build.Object;

namespace AzerothWarsCSharp.DataExtractor
{
  public class UnitFactoryGenerator
  {
    private static readonly Dictionary<int, PropertyMetadata> _idToPropertyMetadata = new()
    {
      { 1651864693, new PropertyMetadata("Flavour", PropertyValueType.String) },
      { 1868786037, new PropertyMetadata("Icon", PropertyValueType.String) },
      { 1835101813, new PropertyMetadata("Name", PropertyValueType.String) },
      { 1718840949, new PropertyMetadata("EditorSuffix", PropertyValueType.String, false) },
      { 1952542837, new PropertyMetadata("PathTexture", PropertyValueType.String) },
      { 1885433973, new PropertyMetadata("PlacementRequires", PropertyValueType.PathingPrevent) },
      { 1768055157, new PropertyMetadata("AbilitiesNormal", PropertyValueType.String) },
      { 1949458805, new PropertyMetadata("AttackType2", PropertyValueType.String) },
      { 1633907573, new PropertyMetadata("ModelScale", PropertyValueType.Float) },
      { 1832018293, new PropertyMetadata("Missile2", PropertyValueType.String) },
      { 1885959285, new PropertyMetadata("TooltipBasic", PropertyValueType.String, false) },
      { 1919381621, new PropertyMetadata("ResearchesUsedRaw", PropertyValueType.String) },
      { 1953458293, new PropertyMetadata("Hotkey", PropertyValueType.String, false) },
      { 1835098997, new PropertyMetadata("Campaign", PropertyValueType.String, false) },
      { 1819239285, new PropertyMetadata("CollisionSize", PropertyValueType.Float) },
      { 1915838837, new PropertyMetadata("Range1", PropertyValueType.Float) },
      { 1915904373, new PropertyMetadata("Range2", PropertyValueType.Float) },
      { 2037671029, new PropertyMetadata("DefenseType", PropertyValueType.String) },
      { 1882284405, new PropertyMetadata("AreaOfEffectTargets", PropertyValueType.String) },
      { 1731289461, new PropertyMetadata("Targets1", PropertyValueType.String) },
      { 1731354997, new PropertyMetadata("Targets2", PropertyValueType.String) },
      { 1684824693, new PropertyMetadata("BuildTime", PropertyValueType.Int) },
      { 2020631157, new PropertyMetadata("ButtonPositionX", PropertyValueType.Int) },
      { 1717920885, new PropertyMetadata("Armor", PropertyValueType.Int) },
      { 1819240309, new PropertyMetadata("GoldCost", PropertyValueType.Int) },
      { 1919903605, new PropertyMetadata("RepairGoldCost", PropertyValueType.Int, false) },
      { 1836083317, new PropertyMetadata("HitPoints", PropertyValueType.Int) },
      { 1836412021, new PropertyMetadata("LumberCost", PropertyValueType.Int) },
      { 1936028277, new PropertyMetadata("Researches", PropertyValueType.String) },
      { 1634890869, new PropertyMetadata("Trains", PropertyValueType.String) },
      { 1887007861, new PropertyMetadata("ClassificationRaw", PropertyValueType.String) },
      { 1902338421, new PropertyMetadata("AcquisitionRange", PropertyValueType.Float) },
      { 1668510581, new PropertyMetadata("SelectionScale", PropertyValueType.Float) },
      { 1949393269, new PropertyMetadata("DamageType1", PropertyValueType.String) },
      { 1919705973, new PropertyMetadata("TintRed", PropertyValueType.Int) },
      { 1651270517, new PropertyMetadata("TintGreen", PropertyValueType.Int) },
      { 1735156597, new PropertyMetadata("TintBlue", PropertyValueType.Int) },
      { 1986358389, new PropertyMetadata("Level", PropertyValueType.Int) },
      { 1768975733, new PropertyMetadata("StartingMana", PropertyValueType.Int) },
      { 1836084597, new PropertyMetadata("Mana", PropertyValueType.Int) },
      { 1831952757, new PropertyMetadata("MissileArt", PropertyValueType.String) },
      { 829645429, new PropertyMetadata("AnimationBackswingPoint", PropertyValueType.Float) },
      { 1664180597, new PropertyMetadata("AttackCooldown1", PropertyValueType.Float) },
      { 1634034805, new PropertyMetadata("DamageNumberOfDice1", PropertyValueType.Int) },
      { 1647403381, new PropertyMetadata("DamageBase1", PropertyValueType.Int) },
      { 829449333, new PropertyMetadata("AnimationDamagePoint", PropertyValueType.Float) },
      { 1769107573, new PropertyMetadata("CollisionSize", PropertyValueType.Float) },
      { 1919970677, new PropertyMetadata("ManaRegeneration", PropertyValueType.Float) },
      { 1953654901, new PropertyMetadata("RegenType", PropertyValueType.String) },
      { 1836348021, new PropertyMetadata("RepairTime", PropertyValueType.Int, false) },
      { 1937141109, new PropertyMetadata("MovementSpeed", PropertyValueType.String) },
      { 1650550901, new PropertyMetadata("AbilitiesHero", PropertyValueType.String) },
      { 1869770869, new PropertyMetadata("ProperNames", PropertyValueType.String) },
      { 1684960117, new PropertyMetadata("SoundSet", PropertyValueType.String) },
      { 1853190773, new PropertyMetadata("AnimationRunSpeed", PropertyValueType.String) },
      { 1818326901, new PropertyMetadata("AnimationWalkSpeed", PropertyValueType.String) },
      { 1818520949, new PropertyMetadata("Model", PropertyValueType.String) },
      { 1953980789, new PropertyMetadata("AwakenTooltip", PropertyValueType.String, false) },
      { 1919972469, new PropertyMetadata("ReviveTooltip", PropertyValueType.String, false) },
      { 1634889845, new PropertyMetadata("PrimaryAttribute", PropertyValueType.String) },
      { 1886284149, new PropertyMetadata("IntelligencePerLevel", PropertyValueType.Float) },
      { 1885823349, new PropertyMetadata("AgilityPerLevel", PropertyValueType.Float) },
      { 1768382837, new PropertyMetadata("Agility", PropertyValueType.String) },
      { 1953393013, new PropertyMetadata("Intelligence", PropertyValueType.String) },
      { 1769173877, new PropertyMetadata("ScoreScreenIcon", PropertyValueType.String) },
      { 2050056565, new PropertyMetadata("MissileSpeed", PropertyValueType.Float) },
      { 1634559605, new PropertyMetadata("FoodProduced", PropertyValueType.Int) },
      { 1633772661, new PropertyMetadata("DefaultActiveAbility", PropertyValueType.String) },
      { 1836017781, new PropertyMetadata("HideOnMinimap", PropertyValueType.Int) },
      { 1919969397, new PropertyMetadata("HitPointRegeneration", PropertyValueType.Float) },
      { 1684632437, new PropertyMetadata("SightRadius", PropertyValueType.Int) },
      { 1667330677, new PropertyMetadata("Race", PropertyValueType.String, false) },
      { 1936681077, new PropertyMetadata("Priority", PropertyValueType.Int) },
      { 1868720501, new PropertyMetadata("RevivesDeadHeroes", PropertyValueType.Int) },
      { 1635083125, new PropertyMetadata("CasterUpgradeArt", PropertyValueType.String) },
      { 1853186933, new PropertyMetadata("CasterUpgradeNames", PropertyValueType.String, false) },
      { 1953850229, new PropertyMetadata("CasterUpgradeTooltip", PropertyValueType.String, false) },
      { 2020633717, new PropertyMetadata("ProjectileLaunchX", PropertyValueType.Float) },
      { 2037410933, new PropertyMetadata("ProjectileLaunchY", PropertyValueType.Float) },
      { 2054188149, new PropertyMetadata("ProjectileLaunchZ", PropertyValueType.Float) },
      { 1999724917, new PropertyMetadata("WeaponType1", PropertyValueType.String) },
      { 1768186485, new PropertyMetadata("BountyDice", PropertyValueType.Int, false) },
      { 1633837685, new PropertyMetadata("BountyPlus", PropertyValueType.Int, false) },
      { 1769169525, new PropertyMetadata("BountySides", PropertyValueType.Int, false) },
      { 2037408373, new PropertyMetadata("ButtonPositionY", PropertyValueType.Int) },
      { 1869571701, new PropertyMetadata("FoodCost", PropertyValueType.Int) },
      { 1920363893, new PropertyMetadata("TurnRate", PropertyValueType.Float) },
      { 1634562933, new PropertyMetadata("StockMaximum", PropertyValueType.Int) },
      { 1920298101, new PropertyMetadata("LumberRepairCost", PropertyValueType.Int, false) },
      { 1714512245, new PropertyMetadata("SplashAreaFull1", PropertyValueType.Float) },
      { 1902473845, new PropertyMetadata("Requires", PropertyValueType.String) },
      { 1932681589, new PropertyMetadata("DamageSidesPerDie2", PropertyValueType.Int) },
      { 1932616053, new PropertyMetadata("DamageSidesPerDie1", PropertyValueType.Int) },
      { 1868788853, new PropertyMetadata("TeamColor", PropertyValueType.String) },
      { 829645685, new PropertyMetadata("WeaponType1", PropertyValueType.String) },
      { 1886679925, new PropertyMetadata("StrengthPerLevel", PropertyValueType.Float) },
      { 1920234357, new PropertyMetadata("Strength", PropertyValueType.Int) },
      { 829187189, new PropertyMetadata("DamageLossFactor", PropertyValueType.Float) },
      { 828468597, new PropertyMetadata("MissileArc", PropertyValueType.Float) },
      { 828601461, new PropertyMetadata("MaximumAttackTargets1", PropertyValueType.String) },
      { 1953918325, new PropertyMetadata("MovementType", PropertyValueType.String) },
      { 1752591733, new PropertyMetadata("MovementHeight", PropertyValueType.Float) },
      { 1719037301, new PropertyMetadata("MovementHeightMinimum", PropertyValueType.Float) },
    };
    private readonly List<IPropertyAssignment> _propertyAssignments = new();
    private readonly SimpleObjectModification _unit;

    private void CreatePropertyAssignment(SimpleObjectDataModification mod)
    {
      if (_idToPropertyMetadata.ContainsKey(mod.Id))
      {
        var propertyMetadata = _idToPropertyMetadata[mod.Id];
        if (propertyMetadata.Show)
        {
          switch (propertyMetadata.Type)
          {
            case PropertyValueType.Int:
              _propertyAssignments.Add(new PropertyAssignmentInt()
              {
                Value = (int)mod.Value,
                PropertyName = propertyMetadata.Name
              });
              break;
            case PropertyValueType.String:
              _propertyAssignments.Add(new PropertyAssignmentString()
              {
                Value = mod.Value.ToString(),
                PropertyName = propertyMetadata.Name
              });
              break;
            case PropertyValueType.PathingPrevent:
              _propertyAssignments.Add(new PropertyAssignmentPathingPrevent()
              {
                Value = mod.Value.ToString(),
                PropertyName = propertyMetadata.Name
              });
              break;
          }
        }
      }
      else
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
      stringBuilder.AppendLine($"      }}.Generate(\"UnitCode\", objectDatabase);");
      stringBuilder.AppendLine();
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
      stringBuilder.AppendLine("    }");
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
