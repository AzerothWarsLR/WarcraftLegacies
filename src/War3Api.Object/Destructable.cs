using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public sealed class Destructable : BaseObject
    {
        private readonly SimpleObjectDataModifications _modifications = new SimpleObjectDataModifications();
        public Destructable(DestructableType baseDestructableType): this((int)baseDestructableType)
        {
        }

        public Destructable(DestructableType baseDestructableType, int newId): this((int)baseDestructableType, newId)
        {
        }

        public Destructable(DestructableType baseDestructableType, string newRawcode): this((int)baseDestructableType, newRawcode)
        {
        }

        public Destructable(DestructableType baseDestructableType, ObjectDatabase db): this((int)baseDestructableType, db)
        {
        }

        public Destructable(DestructableType baseDestructableType, int newId, ObjectDatabase db): this((int)baseDestructableType, newId, db)
        {
        }

        public Destructable(DestructableType baseDestructableType, string newRawcode, ObjectDatabase db): this((int)baseDestructableType, newRawcode, db)
        {
        }

        private Destructable(int oldId): base(oldId)
        {
        }

        private Destructable(int oldId, int newId): base(oldId, newId)
        {
        }

        private Destructable(int oldId, string newRawcode): base(oldId, newRawcode)
        {
        }

        private Destructable(int oldId, ObjectDatabase db): base(oldId, db)
        {
        }

        private Destructable(int oldId, int newId, ObjectDatabase db): base(oldId, newId, db)
        {
        }

        private Destructable(int oldId, string newRawcode, ObjectDatabase db): base(oldId, newRawcode, db)
        {
        }

        public SimpleObjectDataModifications Modifications => _modifications;
        public string TextName
        {
            get => _modifications[1835101794].ValueAsString;
            set => _modifications[1835101794] = new SimpleObjectDataModification{Id = 1835101794, Type = ObjectDataType.String, Value = value};
        }

        public string TextEditorSuffix
        {
            get => _modifications[1718973282].ValueAsString;
            set => _modifications[1718973282] = new SimpleObjectDataModification{Id = 1718973282, Type = ObjectDataType.String, Value = value};
        }

        public string EditorCategoryRaw
        {
            get => _modifications[1952539490].ValueAsString;
            set => _modifications[1952539490] = new SimpleObjectDataModification{Id = 1952539490, Type = ObjectDataType.String, Value = value};
        }

        public DestructableCategory EditorCategory
        {
            get => EditorCategoryRaw.ToDestructableCategory(this);
            set => EditorCategoryRaw = value.ToRaw(null, null);
        }

        public string EditorTilesetsRaw
        {
            get => _modifications[1818850402].ValueAsString;
            set => _modifications[1818850402] = new SimpleObjectDataModification{Id = 1818850402, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Tileset> EditorTilesets
        {
            get => EditorTilesetsRaw.ToIEnumerableTileset(this);
            set => EditorTilesetsRaw = value.ToRaw(null, null);
        }

        public bool EditorHasTilesetSpecificData
        {
            get => _modifications[1886614626].ValueAsBool;
            set => _modifications[1886614626] = new SimpleObjectDataModification{Id = 1886614626, Type = ObjectDataType.Bool, Value = value};
        }

        public string ArtModelFileRaw
        {
            get => _modifications[1818846818].ValueAsString;
            set => _modifications[1818846818] = new SimpleObjectDataModification{Id = 1818846818, Type = ObjectDataType.String, Value = value};
        }

        public string ArtModelFile
        {
            get => ArtModelFileRaw.ToString(this);
            set => ArtModelFileRaw = value.ToRaw(null, null);
        }

        public bool ArtModelFileHasLightweightModel
        {
            get => _modifications[1953066082].ValueAsBool;
            set => _modifications[1953066082] = new SimpleObjectDataModification{Id = 1953066082, Type = ObjectDataType.Bool, Value = value};
        }

        public bool ArtFatLineOfSight
        {
            get => _modifications[1869375074].ValueAsBool;
            set => _modifications[1869375074] = new SimpleObjectDataModification{Id = 1869375074, Type = ObjectDataType.Bool, Value = value};
        }

        public int ArtReplaceableTextureID
        {
            get => _modifications[1769501794].ValueAsInt;
            set => _modifications[1769501794] = new SimpleObjectDataModification{Id = 1769501794, Type = ObjectDataType.Int, Value = value};
        }

        public string ArtReplaceableTextureFileRaw
        {
            get => _modifications[1719170146].ValueAsString;
            set => _modifications[1719170146] = new SimpleObjectDataModification{Id = 1719170146, Type = ObjectDataType.String, Value = value};
        }

        public string ArtReplaceableTextureFile
        {
            get => ArtReplaceableTextureFileRaw.ToString(this);
            set => ArtReplaceableTextureFileRaw = value.ToRaw(null, null);
        }

        public bool EditorShowHelperObjectForSelection
        {
            get => _modifications[1751348578].ValueAsBool;
            set => _modifications[1751348578] = new SimpleObjectDataModification{Id = 1751348578, Type = ObjectDataType.Bool, Value = value};
        }

        public bool EditorPlaceableOnCliffs
        {
            get => _modifications[1668181858].ValueAsBool;
            set => _modifications[1668181858] = new SimpleObjectDataModification{Id = 1668181858, Type = ObjectDataType.Bool, Value = value};
        }

        public bool EditorPlaceableOnWater
        {
            get => _modifications[2003726178].ValueAsBool;
            set => _modifications[2003726178] = new SimpleObjectDataModification{Id = 2003726178, Type = ObjectDataType.Bool, Value = value};
        }

        public bool EditorShowDeadVersionInPalette
        {
            get => _modifications[1685087074].ValueAsBool;
            set => _modifications[1685087074] = new SimpleObjectDataModification{Id = 1685087074, Type = ObjectDataType.Bool, Value = value};
        }

        public bool PathingIsWalkable
        {
            get => _modifications[1818326882].ValueAsBool;
            set => _modifications[1818326882] = new SimpleObjectDataModification{Id = 1818326882, Type = ObjectDataType.Bool, Value = value};
        }

        public int PathingCliffHeight
        {
            get => _modifications[1751933794].ValueAsInt;
            set => _modifications[1751933794] = new SimpleObjectDataModification{Id = 1751933794, Type = ObjectDataType.Int, Value = value};
        }

        public string CombatTargetedAsRaw
        {
            get => _modifications[1918989410].ValueAsString;
            set => _modifications[1918989410] = new SimpleObjectDataModification{Id = 1918989410, Type = ObjectDataType.String, Value = value};
        }

        public IEnumerable<Target> CombatTargetedAs
        {
            get => CombatTargetedAsRaw.ToIEnumerableTarget(this);
            set => CombatTargetedAsRaw = value.ToRaw(null, null);
        }

        public string CombatArmorTypeRaw
        {
            get => _modifications[1836212578].ValueAsString;
            set => _modifications[1836212578] = new SimpleObjectDataModification{Id = 1836212578, Type = ObjectDataType.String, Value = value};
        }

        public ArmorType CombatArmorType
        {
            get => CombatArmorTypeRaw.ToArmorType(this);
            set => CombatArmorTypeRaw = value.ToRaw(null, null);
        }

        public int ArtModelFileVariations
        {
            get => _modifications[1918989922].ValueAsInt;
            set => _modifications[1918989922] = new SimpleObjectDataModification{Id = 1918989922, Type = ObjectDataType.Int, Value = value};
        }

        public float StatsHitPoints
        {
            get => _modifications[1936746594].ValueAsFloat;
            set => _modifications[1936746594] = new SimpleObjectDataModification{Id = 1936746594, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtOcclusionHeight
        {
            get => _modifications[1751347042].ValueAsFloat;
            set => _modifications[1751347042] = new SimpleObjectDataModification{Id = 1751347042, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtFlyOverHeight
        {
            get => _modifications[1751934562].ValueAsFloat;
            set => _modifications[1751934562] = new SimpleObjectDataModification{Id = 1751934562, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtFixedRotation
        {
            get => _modifications[1920493154].ValueAsFloat;
            set => _modifications[1920493154] = new SimpleObjectDataModification{Id = 1920493154, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtSelectionSizeEditor
        {
            get => _modifications[1818588002].ValueAsFloat;
            set => _modifications[1818588002] = new SimpleObjectDataModification{Id = 1818588002, Type = ObjectDataType.Unreal, Value = value};
        }

        public float EditorMinimumScale
        {
            get => _modifications[1936289122].ValueAsFloat;
            set => _modifications[1936289122] = new SimpleObjectDataModification{Id = 1936289122, Type = ObjectDataType.Unreal, Value = value};
        }

        public float EditorMaximumScale
        {
            get => _modifications[1935764834].ValueAsFloat;
            set => _modifications[1935764834] = new SimpleObjectDataModification{Id = 1935764834, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool EditorCanPlaceRandomScale
        {
            get => _modifications[1919968098].ValueAsBool;
            set => _modifications[1919968098] = new SimpleObjectDataModification{Id = 1919968098, Type = ObjectDataType.Bool, Value = value};
        }

        public float ArtMaximumPitchAngleDegrees
        {
            get => _modifications[1885433186].ValueAsFloat;
            set => _modifications[1885433186] = new SimpleObjectDataModification{Id = 1885433186, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtMaxRollAngleDegrees
        {
            get => _modifications[1918987618].ValueAsFloat;
            set => _modifications[1918987618] = new SimpleObjectDataModification{Id = 1918987618, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtElevationSampleRadius
        {
            get => _modifications[1684107874].ValueAsFloat;
            set => _modifications[1684107874] = new SimpleObjectDataModification{Id = 1684107874, Type = ObjectDataType.Unreal, Value = value};
        }

        public float ArtFogRadius
        {
            get => _modifications[1634887266].ValueAsFloat;
            set => _modifications[1634887266] = new SimpleObjectDataModification{Id = 1634887266, Type = ObjectDataType.Unreal, Value = value};
        }

        public bool ArtFogVisibility
        {
            get => _modifications[1769367138].ValueAsBool;
            set => _modifications[1769367138] = new SimpleObjectDataModification{Id = 1769367138, Type = ObjectDataType.Bool, Value = value};
        }

        public string PathingPathingTextureRaw
        {
            get => _modifications[2020896866].ValueAsString;
            set => _modifications[2020896866] = new SimpleObjectDataModification{Id = 2020896866, Type = ObjectDataType.String, Value = value};
        }

        public string PathingPathingTexture
        {
            get => PathingPathingTextureRaw.ToString(this);
            set => PathingPathingTextureRaw = value.ToRaw(null, null);
        }

        public string PathingPathingTextureDeadRaw
        {
            get => _modifications[1685352546].ValueAsString;
            set => _modifications[1685352546] = new SimpleObjectDataModification{Id = 1685352546, Type = ObjectDataType.String, Value = value};
        }

        public string PathingPathingTextureDead
        {
            get => PathingPathingTextureDeadRaw.ToString(this);
            set => PathingPathingTextureDeadRaw = value.ToRaw(null, null);
        }

        public string SoundDeathRaw
        {
            get => _modifications[1853056098].ValueAsString;
            set => _modifications[1853056098] = new SimpleObjectDataModification{Id = 1853056098, Type = ObjectDataType.String, Value = value};
        }

        public string SoundDeath
        {
            get => SoundDeathRaw.ToString(this);
            set => SoundDeathRaw = value.ToRaw(null, null);
        }

        public string ArtShadowRaw
        {
            get => _modifications[1684566882].ValueAsString;
            set => _modifications[1684566882] = new SimpleObjectDataModification{Id = 1684566882, Type = ObjectDataType.String, Value = value};
        }

        public string ArtShadow
        {
            get => ArtShadowRaw.ToString(this);
            set => ArtShadowRaw = value.ToRaw(null, null);
        }

        public bool ArtMinimapShow
        {
            get => _modifications[1835889506].ValueAsBool;
            set => _modifications[1835889506] = new SimpleObjectDataModification{Id = 1835889506, Type = ObjectDataType.Bool, Value = value};
        }

        public int ArtMinimapColor1Red
        {
            get => _modifications[1919774050].ValueAsInt;
            set => _modifications[1919774050] = new SimpleObjectDataModification{Id = 1919774050, Type = ObjectDataType.Int, Value = value};
        }

        public int ArtMinimapColor2Green
        {
            get => _modifications[1735224674].ValueAsInt;
            set => _modifications[1735224674] = new SimpleObjectDataModification{Id = 1735224674, Type = ObjectDataType.Int, Value = value};
        }

        public int ArtMinimapColor3Blue
        {
            get => _modifications[1651338594].ValueAsInt;
            set => _modifications[1651338594] = new SimpleObjectDataModification{Id = 1651338594, Type = ObjectDataType.Int, Value = value};
        }

        public bool ArtMinimapUseCustomColor
        {
            get => _modifications[1835890018].ValueAsBool;
            set => _modifications[1835890018] = new SimpleObjectDataModification{Id = 1835890018, Type = ObjectDataType.Bool, Value = value};
        }

        public int StatsBuildTime
        {
            get => _modifications[1953849954].ValueAsInt;
            set => _modifications[1953849954] = new SimpleObjectDataModification{Id = 1953849954, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsRepairTime
        {
            get => _modifications[1952805474].ValueAsInt;
            set => _modifications[1952805474] = new SimpleObjectDataModification{Id = 1952805474, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsRepairGoldCost
        {
            get => _modifications[1734701666].ValueAsInt;
            set => _modifications[1734701666] = new SimpleObjectDataModification{Id = 1734701666, Type = ObjectDataType.Int, Value = value};
        }

        public int StatsRepairLumberCost
        {
            get => _modifications[1818587746].ValueAsInt;
            set => _modifications[1818587746] = new SimpleObjectDataModification{Id = 1818587746, Type = ObjectDataType.Int, Value = value};
        }

        public bool EditorOnUserSpecifiedList
        {
            get => _modifications[1920169314].ValueAsBool;
            set => _modifications[1920169314] = new SimpleObjectDataModification{Id = 1920169314, Type = ObjectDataType.Bool, Value = value};
        }

        public int ArtTintingColor1Red
        {
            get => _modifications[1919120994].ValueAsInt;
            set => _modifications[1919120994] = new SimpleObjectDataModification{Id = 1919120994, Type = ObjectDataType.Int, Value = value};
        }

        public int ArtTintingColor2Green
        {
            get => _modifications[1734571618].ValueAsInt;
            set => _modifications[1734571618] = new SimpleObjectDataModification{Id = 1734571618, Type = ObjectDataType.Int, Value = value};
        }

        public int ArtTintingColor3Blue
        {
            get => _modifications[1650685538].ValueAsInt;
            set => _modifications[1650685538] = new SimpleObjectDataModification{Id = 1650685538, Type = ObjectDataType.Int, Value = value};
        }

        public bool ArtSelectableInGame
        {
            get => _modifications[1702061922].ValueAsBool;
            set => _modifications[1702061922] = new SimpleObjectDataModification{Id = 1702061922, Type = ObjectDataType.Bool, Value = value};
        }

        public float ArtSelectionSizeGame
        {
            get => _modifications[1668507490].ValueAsFloat;
            set => _modifications[1668507490] = new SimpleObjectDataModification{Id = 1668507490, Type = ObjectDataType.Real, Value = value};
        }

        public string ArtModelFilePortraitRaw
        {
            get => _modifications[1836083042].ValueAsString;
            set => _modifications[1836083042] = new SimpleObjectDataModification{Id = 1836083042, Type = ObjectDataType.String, Value = value};
        }

        public string ArtModelFilePortrait
        {
            get => ArtModelFilePortraitRaw.ToString(this);
            set => ArtModelFilePortraitRaw = value.ToRaw(null, null);
        }

        public static explicit operator SimpleObjectModification(Destructable destructable) => new SimpleObjectModification{OldId = destructable.OldId, NewId = destructable.NewId, Modifications = destructable.Modifications.ToList()};
    }
}