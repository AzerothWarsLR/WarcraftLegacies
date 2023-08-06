using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public sealed class Destructable : BaseObject
    {
        private readonly SimpleObjectDataModifications _modifications;
        public Destructable(DestructableType destructableType): this((int)destructableType)
        {
        }

        public Destructable(DestructableType destructableType, int newId): this((int)destructableType, newId)
        {
        }

        public Destructable(DestructableType destructableType, string newRawcode): this((int)destructableType, newRawcode)
        {
        }

        public Destructable(DestructableType destructableType, ObjectDatabaseBase db): this((int)destructableType, db)
        {
        }

        public Destructable(DestructableType destructableType, int newId, ObjectDatabaseBase db): this((int)destructableType, newId, db)
        {
        }

        public Destructable(DestructableType destructableType, string newRawcode, ObjectDatabaseBase db): this((int)destructableType, newRawcode, db)
        {
        }

        private Destructable(int oldId): base(oldId)
        {
            _modifications = new(this);
        }

        private Destructable(int oldId, int newId): base(oldId, newId)
        {
            _modifications = new(this);
        }

        private Destructable(int oldId, string newRawcode): base(oldId, newRawcode)
        {
            _modifications = new(this);
        }

        private Destructable(int oldId, ObjectDatabaseBase db): base(oldId, db)
        {
            _modifications = new(this);
        }

        private Destructable(int oldId, int newId, ObjectDatabaseBase db): base(oldId, newId, db)
        {
            _modifications = new(this);
        }

        private Destructable(int oldId, string newRawcode, ObjectDatabaseBase db): base(oldId, newRawcode, db)
        {
            _modifications = new(this);
        }

        public SimpleObjectDataModifications Modifications => _modifications;
        public string TextName
        {
            get => _modifications.GetModification(1835101794).ValueAsString;
            set => _modifications[1835101794] = new SimpleObjectDataModification{Id = 1835101794, Type = ObjectDataType.String, Value = value};
        }

        public bool IsTextNameModified => _modifications.ContainsKey(1835101794);
        public string TextEditorSuffix
        {
            get => _modifications.GetModification(1718973282).ValueAsString;
            set => _modifications[1718973282] = new SimpleObjectDataModification{Id = 1718973282, Type = ObjectDataType.String, Value = value};
        }

        public bool IsTextEditorSuffixModified => _modifications.ContainsKey(1718973282);
        public string EditorCategoryRaw
        {
            get => _modifications.GetModification(1952539490).ValueAsString;
            set => _modifications[1952539490] = new SimpleObjectDataModification{Id = 1952539490, Type = ObjectDataType.String, Value = value};
        }

        public bool IsEditorCategoryModified => _modifications.ContainsKey(1952539490);
        public DestructableCategory EditorCategory
        {
            get => EditorCategoryRaw.ToDestructableCategory(this);
            set => EditorCategoryRaw = value.ToRaw(null, null);
        }

        public string EditorTilesetsRaw
        {
            get => _modifications.GetModification(1818850402).ValueAsString;
            set => _modifications[1818850402] = new SimpleObjectDataModification{Id = 1818850402, Type = ObjectDataType.String, Value = value};
        }

        public bool IsEditorTilesetsModified => _modifications.ContainsKey(1818850402);
        public IEnumerable<Tileset> EditorTilesets
        {
            get => EditorTilesetsRaw.ToIEnumerableTileset(this);
            set => EditorTilesetsRaw = value.ToRaw(null, null);
        }

        public int EditorHasTilesetSpecificDataRaw
        {
            get => _modifications.GetModification(1886614626).ValueAsInt;
            set => _modifications[1886614626] = new SimpleObjectDataModification{Id = 1886614626, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsEditorHasTilesetSpecificDataModified => _modifications.ContainsKey(1886614626);
        public bool EditorHasTilesetSpecificData
        {
            get => EditorHasTilesetSpecificDataRaw.ToBool(this);
            set => EditorHasTilesetSpecificDataRaw = value.ToRaw(null, null);
        }

        public string ArtModelFileRaw
        {
            get => _modifications.GetModification(1818846818).ValueAsString;
            set => _modifications[1818846818] = new SimpleObjectDataModification{Id = 1818846818, Type = ObjectDataType.String, Value = value};
        }

        public bool IsArtModelFileModified => _modifications.ContainsKey(1818846818);
        public string ArtModelFile
        {
            get => ArtModelFileRaw.ToString(this);
            set => ArtModelFileRaw = value.ToRaw(null, null);
        }

        public int ArtModelFileHasLightweightModelRaw
        {
            get => _modifications.GetModification(1953066082).ValueAsInt;
            set => _modifications[1953066082] = new SimpleObjectDataModification{Id = 1953066082, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtModelFileHasLightweightModelModified => _modifications.ContainsKey(1953066082);
        public bool ArtModelFileHasLightweightModel
        {
            get => ArtModelFileHasLightweightModelRaw.ToBool(this);
            set => ArtModelFileHasLightweightModelRaw = value.ToRaw(null, null);
        }

        public int ArtFatLineOfSightRaw
        {
            get => _modifications.GetModification(1869375074).ValueAsInt;
            set => _modifications[1869375074] = new SimpleObjectDataModification{Id = 1869375074, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtFatLineOfSightModified => _modifications.ContainsKey(1869375074);
        public bool ArtFatLineOfSight
        {
            get => ArtFatLineOfSightRaw.ToBool(this);
            set => ArtFatLineOfSightRaw = value.ToRaw(null, null);
        }

        public int ArtReplaceableTextureID
        {
            get => _modifications.GetModification(1769501794).ValueAsInt;
            set => _modifications[1769501794] = new SimpleObjectDataModification{Id = 1769501794, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtReplaceableTextureIDModified => _modifications.ContainsKey(1769501794);
        public string ArtReplaceableTextureFileRaw
        {
            get => _modifications.GetModification(1719170146).ValueAsString;
            set => _modifications[1719170146] = new SimpleObjectDataModification{Id = 1719170146, Type = ObjectDataType.String, Value = value};
        }

        public bool IsArtReplaceableTextureFileModified => _modifications.ContainsKey(1719170146);
        public string ArtReplaceableTextureFile
        {
            get => ArtReplaceableTextureFileRaw.ToString(this);
            set => ArtReplaceableTextureFileRaw = value.ToRaw(null, null);
        }

        public int EditorShowHelperObjectForSelectionRaw
        {
            get => _modifications.GetModification(1751348578).ValueAsInt;
            set => _modifications[1751348578] = new SimpleObjectDataModification{Id = 1751348578, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsEditorShowHelperObjectForSelectionModified => _modifications.ContainsKey(1751348578);
        public bool EditorShowHelperObjectForSelection
        {
            get => EditorShowHelperObjectForSelectionRaw.ToBool(this);
            set => EditorShowHelperObjectForSelectionRaw = value.ToRaw(null, null);
        }

        public int EditorPlaceableOnCliffsRaw
        {
            get => _modifications.GetModification(1668181858).ValueAsInt;
            set => _modifications[1668181858] = new SimpleObjectDataModification{Id = 1668181858, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsEditorPlaceableOnCliffsModified => _modifications.ContainsKey(1668181858);
        public bool EditorPlaceableOnCliffs
        {
            get => EditorPlaceableOnCliffsRaw.ToBool(this);
            set => EditorPlaceableOnCliffsRaw = value.ToRaw(null, null);
        }

        public int EditorPlaceableOnWaterRaw
        {
            get => _modifications.GetModification(2003726178).ValueAsInt;
            set => _modifications[2003726178] = new SimpleObjectDataModification{Id = 2003726178, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsEditorPlaceableOnWaterModified => _modifications.ContainsKey(2003726178);
        public bool EditorPlaceableOnWater
        {
            get => EditorPlaceableOnWaterRaw.ToBool(this);
            set => EditorPlaceableOnWaterRaw = value.ToRaw(null, null);
        }

        public int EditorShowDeadVersionInPaletteRaw
        {
            get => _modifications.GetModification(1685087074).ValueAsInt;
            set => _modifications[1685087074] = new SimpleObjectDataModification{Id = 1685087074, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsEditorShowDeadVersionInPaletteModified => _modifications.ContainsKey(1685087074);
        public bool EditorShowDeadVersionInPalette
        {
            get => EditorShowDeadVersionInPaletteRaw.ToBool(this);
            set => EditorShowDeadVersionInPaletteRaw = value.ToRaw(null, null);
        }

        public int PathingIsWalkableRaw
        {
            get => _modifications.GetModification(1818326882).ValueAsInt;
            set => _modifications[1818326882] = new SimpleObjectDataModification{Id = 1818326882, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsPathingIsWalkableModified => _modifications.ContainsKey(1818326882);
        public bool PathingIsWalkable
        {
            get => PathingIsWalkableRaw.ToBool(this);
            set => PathingIsWalkableRaw = value.ToRaw(null, null);
        }

        public int PathingCliffHeight
        {
            get => _modifications.GetModification(1751933794).ValueAsInt;
            set => _modifications[1751933794] = new SimpleObjectDataModification{Id = 1751933794, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsPathingCliffHeightModified => _modifications.ContainsKey(1751933794);
        public string CombatTargetedAsRaw
        {
            get => _modifications.GetModification(1918989410).ValueAsString;
            set => _modifications[1918989410] = new SimpleObjectDataModification{Id = 1918989410, Type = ObjectDataType.String, Value = value};
        }

        public bool IsCombatTargetedAsModified => _modifications.ContainsKey(1918989410);
        public IEnumerable<Target> CombatTargetedAs
        {
            get => CombatTargetedAsRaw.ToIEnumerableTarget(this);
            set => CombatTargetedAsRaw = value.ToRaw(null, null);
        }

        public string CombatArmorTypeRaw
        {
            get => _modifications.GetModification(1836212578).ValueAsString;
            set => _modifications[1836212578] = new SimpleObjectDataModification{Id = 1836212578, Type = ObjectDataType.String, Value = value};
        }

        public bool IsCombatArmorTypeModified => _modifications.ContainsKey(1836212578);
        public ArmorType CombatArmorType
        {
            get => CombatArmorTypeRaw.ToArmorType(this);
            set => CombatArmorTypeRaw = value.ToRaw(null, null);
        }

        public int ArtModelFileVariations
        {
            get => _modifications.GetModification(1918989922).ValueAsInt;
            set => _modifications[1918989922] = new SimpleObjectDataModification{Id = 1918989922, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtModelFileVariationsModified => _modifications.ContainsKey(1918989922);
        public float StatsHitPoints
        {
            get => _modifications.GetModification(1936746594).ValueAsFloat;
            set => _modifications[1936746594] = new SimpleObjectDataModification{Id = 1936746594, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool IsStatsHitPointsModified => _modifications.ContainsKey(1936746594);
        public float ArtOcclusionHeight
        {
            get => _modifications.GetModification(1751347042).ValueAsFloat;
            set => _modifications[1751347042] = new SimpleObjectDataModification{Id = 1751347042, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool IsArtOcclusionHeightModified => _modifications.ContainsKey(1751347042);
        public float ArtFlyOverHeight
        {
            get => _modifications.GetModification(1751934562).ValueAsFloat;
            set => _modifications[1751934562] = new SimpleObjectDataModification{Id = 1751934562, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool IsArtFlyOverHeightModified => _modifications.ContainsKey(1751934562);
        public float ArtFixedRotation
        {
            get => _modifications.GetModification(1920493154).ValueAsFloat;
            set => _modifications[1920493154] = new SimpleObjectDataModification{Id = 1920493154, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool IsArtFixedRotationModified => _modifications.ContainsKey(1920493154);
        public float ArtSelectionSizeEditor
        {
            get => _modifications.GetModification(1818588002).ValueAsFloat;
            set => _modifications[1818588002] = new SimpleObjectDataModification{Id = 1818588002, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool IsArtSelectionSizeEditorModified => _modifications.ContainsKey(1818588002);
        public float EditorMinimumScale
        {
            get => _modifications.GetModification(1936289122).ValueAsFloat;
            set => _modifications[1936289122] = new SimpleObjectDataModification{Id = 1936289122, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool IsEditorMinimumScaleModified => _modifications.ContainsKey(1936289122);
        public float EditorMaximumScale
        {
            get => _modifications.GetModification(1935764834).ValueAsFloat;
            set => _modifications[1935764834] = new SimpleObjectDataModification{Id = 1935764834, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool IsEditorMaximumScaleModified => _modifications.ContainsKey(1935764834);
        public int EditorCanPlaceRandomScaleRaw
        {
            get => _modifications.GetModification(1919968098).ValueAsInt;
            set => _modifications[1919968098] = new SimpleObjectDataModification{Id = 1919968098, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsEditorCanPlaceRandomScaleModified => _modifications.ContainsKey(1919968098);
        public bool EditorCanPlaceRandomScale
        {
            get => EditorCanPlaceRandomScaleRaw.ToBool(this);
            set => EditorCanPlaceRandomScaleRaw = value.ToRaw(null, null);
        }

        public float ArtMaximumPitchAngledegrees
        {
            get => _modifications.GetModification(1885433186).ValueAsFloat;
            set => _modifications[1885433186] = new SimpleObjectDataModification{Id = 1885433186, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool IsArtMaximumPitchAngledegreesModified => _modifications.ContainsKey(1885433186);
        public float ArtMaxRollAngledegrees
        {
            get => _modifications.GetModification(1918987618).ValueAsFloat;
            set => _modifications[1918987618] = new SimpleObjectDataModification{Id = 1918987618, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool IsArtMaxRollAngledegreesModified => _modifications.ContainsKey(1918987618);
        public float ArtElevationSampleRadius
        {
            get => _modifications.GetModification(1684107874).ValueAsFloat;
            set => _modifications[1684107874] = new SimpleObjectDataModification{Id = 1684107874, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool IsArtElevationSampleRadiusModified => _modifications.ContainsKey(1684107874);
        public float ArtFogRadius
        {
            get => _modifications.GetModification(1634887266).ValueAsFloat;
            set => _modifications[1634887266] = new SimpleObjectDataModification{Id = 1634887266, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool IsArtFogRadiusModified => _modifications.ContainsKey(1634887266);
        public int ArtFogVisibilityRaw
        {
            get => _modifications.GetModification(1769367138).ValueAsInt;
            set => _modifications[1769367138] = new SimpleObjectDataModification{Id = 1769367138, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtFogVisibilityModified => _modifications.ContainsKey(1769367138);
        public bool ArtFogVisibility
        {
            get => ArtFogVisibilityRaw.ToBool(this);
            set => ArtFogVisibilityRaw = value.ToRaw(null, null);
        }

        public string PathingPathingTextureRaw
        {
            get => _modifications.GetModification(2020896866).ValueAsString;
            set => _modifications[2020896866] = new SimpleObjectDataModification{Id = 2020896866, Type = ObjectDataType.String, Value = value};
        }

        public bool IsPathingPathingTextureModified => _modifications.ContainsKey(2020896866);
        public string PathingPathingTexture
        {
            get => PathingPathingTextureRaw.ToString(this);
            set => PathingPathingTextureRaw = value.ToRaw(null, null);
        }

        public string PathingPathingTextureDeadRaw
        {
            get => _modifications.GetModification(1685352546).ValueAsString;
            set => _modifications[1685352546] = new SimpleObjectDataModification{Id = 1685352546, Type = ObjectDataType.String, Value = value};
        }

        public bool IsPathingPathingTextureDeadModified => _modifications.ContainsKey(1685352546);
        public string PathingPathingTextureDead
        {
            get => PathingPathingTextureDeadRaw.ToString(this);
            set => PathingPathingTextureDeadRaw = value.ToRaw(null, null);
        }

        public string SoundDeathRaw
        {
            get => _modifications.GetModification(1853056098).ValueAsString;
            set => _modifications[1853056098] = new SimpleObjectDataModification{Id = 1853056098, Type = ObjectDataType.String, Value = value};
        }

        public bool IsSoundDeathModified => _modifications.ContainsKey(1853056098);
        public string SoundDeath
        {
            get => SoundDeathRaw.ToString(this);
            set => SoundDeathRaw = value.ToRaw(null, null);
        }

        public string SoundLoopingSoundRaw
        {
            get => _modifications.GetModification(1684960098).ValueAsString;
            set => _modifications[1684960098] = new SimpleObjectDataModification{Id = 1684960098, Type = ObjectDataType.String, Value = value};
        }

        public bool IsSoundLoopingSoundModified => _modifications.ContainsKey(1684960098);
        public string SoundLoopingSound
        {
            get => SoundLoopingSoundRaw.ToString(this);
            set => SoundLoopingSoundRaw = value.ToRaw(null, null);
        }

        public string ArtShadowRaw
        {
            get => _modifications.GetModification(1684566882).ValueAsString;
            set => _modifications[1684566882] = new SimpleObjectDataModification{Id = 1684566882, Type = ObjectDataType.String, Value = value};
        }

        public bool IsArtShadowModified => _modifications.ContainsKey(1684566882);
        public string ArtShadow
        {
            get => ArtShadowRaw.ToString(this);
            set => ArtShadowRaw = value.ToRaw(null, null);
        }

        public int ArtMinimapShowRaw
        {
            get => _modifications.GetModification(1835889506).ValueAsInt;
            set => _modifications[1835889506] = new SimpleObjectDataModification{Id = 1835889506, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtMinimapShowModified => _modifications.ContainsKey(1835889506);
        public bool ArtMinimapShow
        {
            get => ArtMinimapShowRaw.ToBool(this);
            set => ArtMinimapShowRaw = value.ToRaw(null, null);
        }

        public int ArtMinimapColor1Red
        {
            get => _modifications.GetModification(1919774050).ValueAsInt;
            set => _modifications[1919774050] = new SimpleObjectDataModification{Id = 1919774050, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtMinimapColor1RedModified => _modifications.ContainsKey(1919774050);
        public int ArtMinimapColor2Green
        {
            get => _modifications.GetModification(1735224674).ValueAsInt;
            set => _modifications[1735224674] = new SimpleObjectDataModification{Id = 1735224674, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtMinimapColor2GreenModified => _modifications.ContainsKey(1735224674);
        public int ArtMinimapColor3Blue
        {
            get => _modifications.GetModification(1651338594).ValueAsInt;
            set => _modifications[1651338594] = new SimpleObjectDataModification{Id = 1651338594, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtMinimapColor3BlueModified => _modifications.ContainsKey(1651338594);
        public int ArtMinimapUseCustomColorRaw
        {
            get => _modifications.GetModification(1835890018).ValueAsInt;
            set => _modifications[1835890018] = new SimpleObjectDataModification{Id = 1835890018, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtMinimapUseCustomColorModified => _modifications.ContainsKey(1835890018);
        public bool ArtMinimapUseCustomColor
        {
            get => ArtMinimapUseCustomColorRaw.ToBool(this);
            set => ArtMinimapUseCustomColorRaw = value.ToRaw(null, null);
        }

        public int StatsBuildTime
        {
            get => _modifications.GetModification(1953849954).ValueAsInt;
            set => _modifications[1953849954] = new SimpleObjectDataModification{Id = 1953849954, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsBuildTimeModified => _modifications.ContainsKey(1953849954);
        public int StatsRepairTime
        {
            get => _modifications.GetModification(1952805474).ValueAsInt;
            set => _modifications[1952805474] = new SimpleObjectDataModification{Id = 1952805474, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsRepairTimeModified => _modifications.ContainsKey(1952805474);
        public int StatsRepairGoldCost
        {
            get => _modifications.GetModification(1734701666).ValueAsInt;
            set => _modifications[1734701666] = new SimpleObjectDataModification{Id = 1734701666, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsRepairGoldCostModified => _modifications.ContainsKey(1734701666);
        public int StatsRepairLumberCost
        {
            get => _modifications.GetModification(1818587746).ValueAsInt;
            set => _modifications[1818587746] = new SimpleObjectDataModification{Id = 1818587746, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsStatsRepairLumberCostModified => _modifications.ContainsKey(1818587746);
        public int EditorOnUserSpecifiedListRaw
        {
            get => _modifications.GetModification(1920169314).ValueAsInt;
            set => _modifications[1920169314] = new SimpleObjectDataModification{Id = 1920169314, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsEditorOnUserSpecifiedListModified => _modifications.ContainsKey(1920169314);
        public bool EditorOnUserSpecifiedList
        {
            get => EditorOnUserSpecifiedListRaw.ToBool(this);
            set => EditorOnUserSpecifiedListRaw = value.ToRaw(null, null);
        }

        public int ArtTintingColor1Red
        {
            get => _modifications.GetModification(1919120994).ValueAsInt;
            set => _modifications[1919120994] = new SimpleObjectDataModification{Id = 1919120994, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtTintingColor1RedModified => _modifications.ContainsKey(1919120994);
        public int ArtTintingColor2Green
        {
            get => _modifications.GetModification(1734571618).ValueAsInt;
            set => _modifications[1734571618] = new SimpleObjectDataModification{Id = 1734571618, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtTintingColor2GreenModified => _modifications.ContainsKey(1734571618);
        public int ArtTintingColor3Blue
        {
            get => _modifications.GetModification(1650685538).ValueAsInt;
            set => _modifications[1650685538] = new SimpleObjectDataModification{Id = 1650685538, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtTintingColor3BlueModified => _modifications.ContainsKey(1650685538);
        public int ArtSelectableInGameRaw
        {
            get => _modifications.GetModification(1702061922).ValueAsInt;
            set => _modifications[1702061922] = new SimpleObjectDataModification{Id = 1702061922, Type = ObjectDataType.Int, Value = value};
        }

        public bool IsArtSelectableInGameModified => _modifications.ContainsKey(1702061922);
        public bool ArtSelectableInGame
        {
            get => ArtSelectableInGameRaw.ToBool(this);
            set => ArtSelectableInGameRaw = value.ToRaw(null, null);
        }

        public float ArtSelectionSizeGame
        {
            get => _modifications.GetModification(1668507490).ValueAsFloat;
            set => _modifications[1668507490] = new SimpleObjectDataModification{Id = 1668507490, Type = ObjectDataType.Real, Value = value};
        }

        public bool IsArtSelectionSizeGameModified => _modifications.ContainsKey(1668507490);
        public string ArtModelFilePortraitRaw
        {
            get => _modifications.GetModification(1836083042).ValueAsString;
            set => _modifications[1836083042] = new SimpleObjectDataModification{Id = 1836083042, Type = ObjectDataType.String, Value = value};
        }

        public bool IsArtModelFilePortraitModified => _modifications.ContainsKey(1836083042);
        public string ArtModelFilePortrait
        {
            get => ArtModelFilePortraitRaw.ToString(this);
            set => ArtModelFilePortraitRaw = value.ToRaw(null, null);
        }

        public static explicit operator SimpleObjectModification(Destructable destructable) => new SimpleObjectModification{OldId = destructable.OldId, NewId = destructable.NewId, Modifications = destructable.Modifications.ToList()};
        internal override bool TryGetSimpleModifications([NotNullWhen(true)] out SimpleObjectDataModifications? modifications)
        {
            modifications = _modifications;
            return true;
        }

        public void AddModifications(List<SimpleObjectDataModification> modifications)
        {
            foreach (var modification in modifications)
                _modifications[modification.Id] = modification;
        }
    }
}