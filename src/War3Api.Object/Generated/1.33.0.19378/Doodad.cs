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
    public sealed class Doodad : BaseObject
    {
        private readonly VariationObjectDataModifications _modifications;
        private readonly Lazy<ObjectProperty<int>> _artTintingColor1Red;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isArtTintingColor1RedModified;
        private readonly Lazy<ObjectProperty<int>> _artTintingColor2Green;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isArtTintingColor2GreenModified;
        private readonly Lazy<ObjectProperty<int>> _artTintingColor3Blue;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isArtTintingColor3BlueModified;
        public Doodad(DoodadType doodadType): this((int)doodadType)
        {
        }

        public Doodad(DoodadType doodadType, int newId): this((int)doodadType, newId)
        {
        }

        public Doodad(DoodadType doodadType, string newRawcode): this((int)doodadType, newRawcode)
        {
        }

        public Doodad(DoodadType doodadType, ObjectDatabaseBase db): this((int)doodadType, db)
        {
        }

        public Doodad(DoodadType doodadType, int newId, ObjectDatabaseBase db): this((int)doodadType, newId, db)
        {
        }

        public Doodad(DoodadType doodadType, string newRawcode, ObjectDatabaseBase db): this((int)doodadType, newRawcode, db)
        {
        }

        private Doodad(int oldId): base(oldId)
        {
            _modifications = new(this);
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _isArtTintingColor1RedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor1RedModified));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _isArtTintingColor2GreenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor2GreenModified));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
            _isArtTintingColor3BlueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor3BlueModified));
        }

        private Doodad(int oldId, int newId): base(oldId, newId)
        {
            _modifications = new(this);
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _isArtTintingColor1RedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor1RedModified));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _isArtTintingColor2GreenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor2GreenModified));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
            _isArtTintingColor3BlueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor3BlueModified));
        }

        private Doodad(int oldId, string newRawcode): base(oldId, newRawcode)
        {
            _modifications = new(this);
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _isArtTintingColor1RedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor1RedModified));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _isArtTintingColor2GreenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor2GreenModified));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
            _isArtTintingColor3BlueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor3BlueModified));
        }

        private Doodad(int oldId, ObjectDatabaseBase db): base(oldId, db)
        {
            _modifications = new(this);
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _isArtTintingColor1RedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor1RedModified));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _isArtTintingColor2GreenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor2GreenModified));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
            _isArtTintingColor3BlueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor3BlueModified));
        }

        private Doodad(int oldId, int newId, ObjectDatabaseBase db): base(oldId, newId, db)
        {
            _modifications = new(this);
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _isArtTintingColor1RedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor1RedModified));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _isArtTintingColor2GreenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor2GreenModified));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
            _isArtTintingColor3BlueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor3BlueModified));
        }

        private Doodad(int oldId, string newRawcode, ObjectDatabaseBase db): base(oldId, newRawcode, db)
        {
            _modifications = new(this);
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _isArtTintingColor1RedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor1RedModified));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _isArtTintingColor2GreenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor2GreenModified));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
            _isArtTintingColor3BlueModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtTintingColor3BlueModified));
        }

        public VariationObjectDataModifications Modifications => _modifications;
        public string TextName
        {
            get => _modifications.GetModification(1835101796).ValueAsString;
            set => _modifications[1835101796] = new VariationObjectDataModification{Id = 1835101796, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public bool IsTextNameModified => _modifications.ContainsKey(1835101796);
        public string EditorCategoryRaw
        {
            get => _modifications.GetModification(1952539492).ValueAsString;
            set => _modifications[1952539492] = new VariationObjectDataModification{Id = 1952539492, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public bool IsEditorCategoryModified => _modifications.ContainsKey(1952539492);
        public DoodadCategory EditorCategory
        {
            get => EditorCategoryRaw.ToDoodadCategory(this);
            set => EditorCategoryRaw = value.ToRaw(null, null);
        }

        public string EditorTilesetsRaw
        {
            get => _modifications.GetModification(1818850404).ValueAsString;
            set => _modifications[1818850404] = new VariationObjectDataModification{Id = 1818850404, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public bool IsEditorTilesetsModified => _modifications.ContainsKey(1818850404);
        public IEnumerable<Tileset> EditorTilesets
        {
            get => EditorTilesetsRaw.ToIEnumerableTileset(this);
            set => EditorTilesetsRaw = value.ToRaw(null, null);
        }

        public int EditorHasTilesetSpecificDataRaw
        {
            get => _modifications.GetModification(1886614628).ValueAsInt;
            set => _modifications[1886614628] = new VariationObjectDataModification{Id = 1886614628, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsEditorHasTilesetSpecificDataModified => _modifications.ContainsKey(1886614628);
        public bool EditorHasTilesetSpecificData
        {
            get => EditorHasTilesetSpecificDataRaw.ToBool(this);
            set => EditorHasTilesetSpecificDataRaw = value.ToRaw(null, null);
        }

        public string ArtModelFileRaw
        {
            get => _modifications.GetModification(1818846820).ValueAsString;
            set => _modifications[1818846820] = new VariationObjectDataModification{Id = 1818846820, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public bool IsArtModelFileModified => _modifications.ContainsKey(1818846820);
        public string ArtModelFile
        {
            get => ArtModelFileRaw.ToString(this);
            set => ArtModelFileRaw = value.ToRaw(null, null);
        }

        public string SoundLoopingSoundRaw
        {
            get => _modifications.GetModification(1684960100).ValueAsString;
            set => _modifications[1684960100] = new VariationObjectDataModification{Id = 1684960100, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public bool IsSoundLoopingSoundModified => _modifications.ContainsKey(1684960100);
        public string SoundLoopingSound
        {
            get => SoundLoopingSoundRaw.ToString(this);
            set => SoundLoopingSoundRaw = value.ToRaw(null, null);
        }

        public float ArtSelectionSize
        {
            get => _modifications.GetModification(1818588004).ValueAsFloat;
            set => _modifications[1818588004] = new VariationObjectDataModification{Id = 1818588004, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public bool IsArtSelectionSizeModified => _modifications.ContainsKey(1818588004);
        public float ArtDefaultScale
        {
            get => _modifications.GetModification(1936024676).ValueAsFloat;
            set => _modifications[1936024676] = new VariationObjectDataModification{Id = 1936024676, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public bool IsArtDefaultScaleModified => _modifications.ContainsKey(1936024676);
        public float EditorMinimumScale
        {
            get => _modifications.GetModification(1936289124).ValueAsFloat;
            set => _modifications[1936289124] = new VariationObjectDataModification{Id = 1936289124, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public bool IsEditorMinimumScaleModified => _modifications.ContainsKey(1936289124);
        public float EditorMaximumScale
        {
            get => _modifications.GetModification(1935764836).ValueAsFloat;
            set => _modifications[1935764836] = new VariationObjectDataModification{Id = 1935764836, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public bool IsEditorMaximumScaleModified => _modifications.ContainsKey(1935764836);
        public int EditorCanPlaceRandomScaleRaw
        {
            get => _modifications.GetModification(1919968100).ValueAsInt;
            set => _modifications[1919968100] = new VariationObjectDataModification{Id = 1919968100, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsEditorCanPlaceRandomScaleModified => _modifications.ContainsKey(1919968100);
        public bool EditorCanPlaceRandomScale
        {
            get => EditorCanPlaceRandomScaleRaw.ToBool(this);
            set => EditorCanPlaceRandomScaleRaw = value.ToRaw(null, null);
        }

        public int EditorUseClickHelperRaw
        {
            get => _modifications.GetModification(1751348580).ValueAsInt;
            set => _modifications[1751348580] = new VariationObjectDataModification{Id = 1751348580, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsEditorUseClickHelperModified => _modifications.ContainsKey(1751348580);
        public bool EditorUseClickHelper
        {
            get => EditorUseClickHelperRaw.ToBool(this);
            set => EditorUseClickHelperRaw = value.ToRaw(null, null);
        }

        public int EditorIgnoreModelClicksRaw
        {
            get => _modifications.GetModification(1668114788).ValueAsInt;
            set => _modifications[1668114788] = new VariationObjectDataModification{Id = 1668114788, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsEditorIgnoreModelClicksModified => _modifications.ContainsKey(1668114788);
        public bool EditorIgnoreModelClicks
        {
            get => EditorIgnoreModelClicksRaw.ToBool(this);
            set => EditorIgnoreModelClicksRaw = value.ToRaw(null, null);
        }

        public float ArtMaximumPitchAngledegrees
        {
            get => _modifications.GetModification(1885433188).ValueAsFloat;
            set => _modifications[1885433188] = new VariationObjectDataModification{Id = 1885433188, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public bool IsArtMaximumPitchAngledegreesModified => _modifications.ContainsKey(1885433188);
        public float ArtMaxRollAngledegrees
        {
            get => _modifications.GetModification(1918987620).ValueAsFloat;
            set => _modifications[1918987620] = new VariationObjectDataModification{Id = 1918987620, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public bool IsArtMaxRollAngledegreesModified => _modifications.ContainsKey(1918987620);
        public float ArtVisibilityRadius
        {
            get => _modifications.GetModification(1936291428).ValueAsFloat;
            set => _modifications[1936291428] = new VariationObjectDataModification{Id = 1936291428, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public bool IsArtVisibilityRadiusModified => _modifications.ContainsKey(1936291428);
        public int PathingWalkableRaw
        {
            get => _modifications.GetModification(1802270564).ValueAsInt;
            set => _modifications[1802270564] = new VariationObjectDataModification{Id = 1802270564, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsPathingWalkableModified => _modifications.ContainsKey(1802270564);
        public bool PathingWalkable
        {
            get => PathingWalkableRaw.ToBool(this);
            set => PathingWalkableRaw = value.ToRaw(null, null);
        }

        public int ArtVariations
        {
            get => _modifications.GetModification(1918989924).ValueAsInt;
            set => _modifications[1918989924] = new VariationObjectDataModification{Id = 1918989924, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsArtVariationsModified => _modifications.ContainsKey(1918989924);
        public int EditorPlaceableOnCliffsRaw
        {
            get => _modifications.GetModification(1668181860).ValueAsInt;
            set => _modifications[1668181860] = new VariationObjectDataModification{Id = 1668181860, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsEditorPlaceableOnCliffsModified => _modifications.ContainsKey(1668181860);
        public bool EditorPlaceableOnCliffs
        {
            get => EditorPlaceableOnCliffsRaw.ToBool(this);
            set => EditorPlaceableOnCliffsRaw = value.ToRaw(null, null);
        }

        public int EditorPlaceableOnWaterRaw
        {
            get => _modifications.GetModification(2003726180).ValueAsInt;
            set => _modifications[2003726180] = new VariationObjectDataModification{Id = 2003726180, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsEditorPlaceableOnWaterModified => _modifications.ContainsKey(2003726180);
        public bool EditorPlaceableOnWater
        {
            get => EditorPlaceableOnWaterRaw.ToBool(this);
            set => EditorPlaceableOnWaterRaw = value.ToRaw(null, null);
        }

        public int ArtFloatsRaw
        {
            get => _modifications.GetModification(1953261156).ValueAsInt;
            set => _modifications[1953261156] = new VariationObjectDataModification{Id = 1953261156, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsArtFloatsModified => _modifications.ContainsKey(1953261156);
        public bool ArtFloats
        {
            get => ArtFloatsRaw.ToBool(this);
            set => ArtFloatsRaw = value.ToRaw(null, null);
        }

        public int ArtHasAShadowRaw
        {
            get => _modifications.GetModification(1684566884).ValueAsInt;
            set => _modifications[1684566884] = new VariationObjectDataModification{Id = 1684566884, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsArtHasAShadowModified => _modifications.ContainsKey(1684566884);
        public bool ArtHasAShadow
        {
            get => ArtHasAShadowRaw.ToBool(this);
            set => ArtHasAShadowRaw = value.ToRaw(null, null);
        }

        public int ArtShowInFogRaw
        {
            get => _modifications.GetModification(1718121316).ValueAsInt;
            set => _modifications[1718121316] = new VariationObjectDataModification{Id = 1718121316, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsArtShowInFogModified => _modifications.ContainsKey(1718121316);
        public bool ArtShowInFog
        {
            get => ArtShowInFogRaw.ToBool(this);
            set => ArtShowInFogRaw = value.ToRaw(null, null);
        }

        public int ArtAnimateInFogRaw
        {
            get => _modifications.GetModification(1718509924).ValueAsInt;
            set => _modifications[1718509924] = new VariationObjectDataModification{Id = 1718509924, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsArtAnimateInFogModified => _modifications.ContainsKey(1718509924);
        public bool ArtAnimateInFog
        {
            get => ArtAnimateInFogRaw.ToBool(this);
            set => ArtAnimateInFogRaw = value.ToRaw(null, null);
        }

        public float ArtFixedRotation
        {
            get => _modifications.GetModification(1920493156).ValueAsFloat;
            set => _modifications[1920493156] = new VariationObjectDataModification{Id = 1920493156, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public bool IsArtFixedRotationModified => _modifications.ContainsKey(1920493156);
        public string PathingPathingTextureRaw
        {
            get => _modifications.GetModification(2020896868).ValueAsString;
            set => _modifications[2020896868] = new VariationObjectDataModification{Id = 2020896868, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public bool IsPathingPathingTextureModified => _modifications.ContainsKey(2020896868);
        public string PathingPathingTexture
        {
            get => PathingPathingTextureRaw.ToString(this);
            set => PathingPathingTextureRaw = value.ToRaw(null, null);
        }

        public int ArtMinimapShowRaw
        {
            get => _modifications.GetModification(1835889508).ValueAsInt;
            set => _modifications[1835889508] = new VariationObjectDataModification{Id = 1835889508, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsArtMinimapShowModified => _modifications.ContainsKey(1835889508);
        public bool ArtMinimapShow
        {
            get => ArtMinimapShowRaw.ToBool(this);
            set => ArtMinimapShowRaw = value.ToRaw(null, null);
        }

        public int ArtMinimapUseCustomColorRaw
        {
            get => _modifications.GetModification(1668117860).ValueAsInt;
            set => _modifications[1668117860] = new VariationObjectDataModification{Id = 1668117860, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsArtMinimapUseCustomColorModified => _modifications.ContainsKey(1668117860);
        public bool ArtMinimapUseCustomColor
        {
            get => ArtMinimapUseCustomColorRaw.ToBool(this);
            set => ArtMinimapUseCustomColorRaw = value.ToRaw(null, null);
        }

        public int ArtMinimapColor1Red
        {
            get => _modifications.GetModification(1919774052).ValueAsInt;
            set => _modifications[1919774052] = new VariationObjectDataModification{Id = 1919774052, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsArtMinimapColor1RedModified => _modifications.ContainsKey(1919774052);
        public int ArtMinimapColor2Green
        {
            get => _modifications.GetModification(1735224676).ValueAsInt;
            set => _modifications[1735224676] = new VariationObjectDataModification{Id = 1735224676, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsArtMinimapColor2GreenModified => _modifications.ContainsKey(1735224676);
        public int ArtMinimapColor3Blue
        {
            get => _modifications.GetModification(1651338596).ValueAsInt;
            set => _modifications[1651338596] = new VariationObjectDataModification{Id = 1651338596, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsArtMinimapColor3BlueModified => _modifications.ContainsKey(1651338596);
        public ObjectProperty<int> ArtTintingColor1Red => _artTintingColor1Red.Value;
        public ReadOnlyObjectProperty<bool> IsArtTintingColor1RedModified => _isArtTintingColor1RedModified.Value;
        public ObjectProperty<int> ArtTintingColor2Green => _artTintingColor2Green.Value;
        public ReadOnlyObjectProperty<bool> IsArtTintingColor2GreenModified => _isArtTintingColor2GreenModified.Value;
        public ObjectProperty<int> ArtTintingColor3Blue => _artTintingColor3Blue.Value;
        public ReadOnlyObjectProperty<bool> IsArtTintingColor3BlueModified => _isArtTintingColor3BlueModified.Value;
        public int EditorOnUserSpecifiedListRaw
        {
            get => _modifications.GetModification(1920169316).ValueAsInt;
            set => _modifications[1920169316] = new VariationObjectDataModification{Id = 1920169316, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool IsEditorOnUserSpecifiedListModified => _modifications.ContainsKey(1920169316);
        public bool EditorOnUserSpecifiedList
        {
            get => EditorOnUserSpecifiedListRaw.ToBool(this);
            set => EditorOnUserSpecifiedListRaw = value.ToRaw(null, null);
        }

        public static explicit operator VariationObjectModification(Doodad doodad) => new VariationObjectModification{OldId = doodad.OldId, NewId = doodad.NewId, Modifications = doodad.Modifications.ToList()};
        internal override bool TryGetVariationModifications([NotNullWhen(true)] out VariationObjectDataModifications? modifications)
        {
            modifications = _modifications;
            return true;
        }

        public void AddModifications(List<VariationObjectDataModification> modifications)
        {
            foreach (var modification in modifications)
                _modifications[modification.Id] = modification;
        }

        private int GetArtTintingColor1Red(int variation)
        {
            return _modifications.GetModification(829584996, variation).ValueAsInt;
        }

        private void SetArtTintingColor1Red(int variation, int value)
        {
            _modifications[829584996, variation] = new VariationObjectDataModification{Id = 829584996, Type = ObjectDataType.Int, Value = value, Variation = variation};
        }

        private bool GetIsArtTintingColor1RedModified(int variation)
        {
            return _modifications.ContainsKey(829584996, variation);
        }

        private int GetArtTintingColor2Green(int variation)
        {
            return _modifications.GetModification(828864100, variation).ValueAsInt;
        }

        private void SetArtTintingColor2Green(int variation, int value)
        {
            _modifications[828864100, variation] = new VariationObjectDataModification{Id = 828864100, Type = ObjectDataType.Int, Value = value, Variation = variation};
        }

        private bool GetIsArtTintingColor2GreenModified(int variation)
        {
            return _modifications.ContainsKey(828864100, variation);
        }

        private int GetArtTintingColor3Blue(int variation)
        {
            return _modifications.GetModification(828536420, variation).ValueAsInt;
        }

        private void SetArtTintingColor3Blue(int variation, int value)
        {
            _modifications[828536420, variation] = new VariationObjectDataModification{Id = 828536420, Type = ObjectDataType.Int, Value = value, Variation = variation};
        }

        private bool GetIsArtTintingColor3BlueModified(int variation)
        {
            return _modifications.ContainsKey(828536420, variation);
        }
    }
}