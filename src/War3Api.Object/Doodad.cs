using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public sealed class Doodad : BaseObject
    {
        private readonly VariationObjectDataModifications _modifications = new VariationObjectDataModifications();
        private readonly Lazy<ObjectProperty<int>> _artTintingColor1Red;
        private readonly Lazy<ObjectProperty<int>> _artTintingColor2Green;
        private readonly Lazy<ObjectProperty<int>> _artTintingColor3Blue;
        public Doodad(DoodadType baseDoodadType): this((int)baseDoodadType)
        {
        }

        public Doodad(DoodadType baseDoodadType, int newId): this((int)baseDoodadType, newId)
        {
        }

        public Doodad(DoodadType baseDoodadType, string newRawcode): this((int)baseDoodadType, newRawcode)
        {
        }

        public Doodad(DoodadType baseDoodadType, ObjectDatabase db): this((int)baseDoodadType, db)
        {
        }

        public Doodad(DoodadType baseDoodadType, int newId, ObjectDatabase db): this((int)baseDoodadType, newId, db)
        {
        }

        public Doodad(DoodadType baseDoodadType, string newRawcode, ObjectDatabase db): this((int)baseDoodadType, newRawcode, db)
        {
        }

        private Doodad(int oldId): base(oldId)
        {
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
        }

        private Doodad(int oldId, int newId): base(oldId, newId)
        {
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
        }

        private Doodad(int oldId, string newRawcode): base(oldId, newRawcode)
        {
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
        }

        private Doodad(int oldId, ObjectDatabase db): base(oldId, db)
        {
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
        }

        private Doodad(int oldId, int newId, ObjectDatabase db): base(oldId, newId, db)
        {
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
        }

        private Doodad(int oldId, string newRawcode, ObjectDatabase db): base(oldId, newRawcode, db)
        {
            _artTintingColor1Red = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor1Red, SetArtTintingColor1Red));
            _artTintingColor2Green = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor2Green, SetArtTintingColor2Green));
            _artTintingColor3Blue = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetArtTintingColor3Blue, SetArtTintingColor3Blue));
        }

        public VariationObjectDataModifications Modifications => _modifications;
        public string TextName
        {
            get => _modifications[1835101796].ValueAsString;
            set => _modifications[1835101796] = new VariationObjectDataModification{Id = 1835101796, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public string EditorCategoryRaw
        {
            get => _modifications[1952539492].ValueAsString;
            set => _modifications[1952539492] = new VariationObjectDataModification{Id = 1952539492, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public DoodadCategory EditorCategory
        {
            get => EditorCategoryRaw.ToDoodadCategory(this);
            set => EditorCategoryRaw = value.ToRaw(null, null);
        }

        public string EditorTilesetsRaw
        {
            get => _modifications[1818850404].ValueAsString;
            set => _modifications[1818850404] = new VariationObjectDataModification{Id = 1818850404, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public IEnumerable<Tileset> EditorTilesets
        {
            get => EditorTilesetsRaw.ToIEnumerableTileset(this);
            set => EditorTilesetsRaw = value.ToRaw(null, null);
        }

        public bool EditorHasTilesetSpecificData
        {
            get => _modifications[1886614628].ValueAsBool;
            set => _modifications[1886614628] = new VariationObjectDataModification{Id = 1886614628, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public string ArtModelFileRaw
        {
            get => _modifications[1818846820].ValueAsString;
            set => _modifications[1818846820] = new VariationObjectDataModification{Id = 1818846820, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public string ArtModelFile
        {
            get => ArtModelFileRaw.ToString(this);
            set => ArtModelFileRaw = value.ToRaw(null, null);
        }

        public string SoundLoopingSoundRaw
        {
            get => _modifications[1684960100].ValueAsString;
            set => _modifications[1684960100] = new VariationObjectDataModification{Id = 1684960100, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public string SoundLoopingSound
        {
            get => SoundLoopingSoundRaw.ToString(this);
            set => SoundLoopingSoundRaw = value.ToRaw(null, null);
        }

        public float ArtSelectionSize
        {
            get => _modifications[1818588004].ValueAsFloat;
            set => _modifications[1818588004] = new VariationObjectDataModification{Id = 1818588004, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public float ArtDefaultScale
        {
            get => _modifications[1936024676].ValueAsFloat;
            set => _modifications[1936024676] = new VariationObjectDataModification{Id = 1936024676, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public float EditorMinimumScale
        {
            get => _modifications[1936289124].ValueAsFloat;
            set => _modifications[1936289124] = new VariationObjectDataModification{Id = 1936289124, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public float EditorMaximumScale
        {
            get => _modifications[1935764836].ValueAsFloat;
            set => _modifications[1935764836] = new VariationObjectDataModification{Id = 1935764836, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public bool EditorCanPlaceRandomScale
        {
            get => _modifications[1919968100].ValueAsBool;
            set => _modifications[1919968100] = new VariationObjectDataModification{Id = 1919968100, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public bool EditorUseClickHelper
        {
            get => _modifications[1751348580].ValueAsBool;
            set => _modifications[1751348580] = new VariationObjectDataModification{Id = 1751348580, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public bool EditorIgnoreModelClicks
        {
            get => _modifications[1668114788].ValueAsBool;
            set => _modifications[1668114788] = new VariationObjectDataModification{Id = 1668114788, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public float ArtMaximumPitchAngleDegrees
        {
            get => _modifications[1885433188].ValueAsFloat;
            set => _modifications[1885433188] = new VariationObjectDataModification{Id = 1885433188, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public float ArtMaxRollAngleDegrees
        {
            get => _modifications[1918987620].ValueAsFloat;
            set => _modifications[1918987620] = new VariationObjectDataModification{Id = 1918987620, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public float ArtVisibilityRadius
        {
            get => _modifications[1936291428].ValueAsFloat;
            set => _modifications[1936291428] = new VariationObjectDataModification{Id = 1936291428, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public bool PathingWalkable
        {
            get => _modifications[1802270564].ValueAsBool;
            set => _modifications[1802270564] = new VariationObjectDataModification{Id = 1802270564, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public int ArtVariations
        {
            get => _modifications[1918989924].ValueAsInt;
            set => _modifications[1918989924] = new VariationObjectDataModification{Id = 1918989924, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public bool EditorPlaceableOnCliffs
        {
            get => _modifications[1668181860].ValueAsBool;
            set => _modifications[1668181860] = new VariationObjectDataModification{Id = 1668181860, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public bool EditorPlaceableOnWater
        {
            get => _modifications[2003726180].ValueAsBool;
            set => _modifications[2003726180] = new VariationObjectDataModification{Id = 2003726180, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public bool ArtFloats
        {
            get => _modifications[1953261156].ValueAsBool;
            set => _modifications[1953261156] = new VariationObjectDataModification{Id = 1953261156, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public bool ArtHasAShadow
        {
            get => _modifications[1684566884].ValueAsBool;
            set => _modifications[1684566884] = new VariationObjectDataModification{Id = 1684566884, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public bool ArtShowInFog
        {
            get => _modifications[1718121316].ValueAsBool;
            set => _modifications[1718121316] = new VariationObjectDataModification{Id = 1718121316, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public bool ArtAnimateInFog
        {
            get => _modifications[1718509924].ValueAsBool;
            set => _modifications[1718509924] = new VariationObjectDataModification{Id = 1718509924, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public float ArtFixedRotation
        {
            get => _modifications[1920493156].ValueAsFloat;
            set => _modifications[1920493156] = new VariationObjectDataModification{Id = 1920493156, Type = ObjectDataType.Unreal, Value = value, Variation = 0};
        }

        public string PathingPathingTextureRaw
        {
            get => _modifications[2020896868].ValueAsString;
            set => _modifications[2020896868] = new VariationObjectDataModification{Id = 2020896868, Type = ObjectDataType.String, Value = value, Variation = 0};
        }

        public string PathingPathingTexture
        {
            get => PathingPathingTextureRaw.ToString(this);
            set => PathingPathingTextureRaw = value.ToRaw(null, null);
        }

        public bool ArtMinimapShow
        {
            get => _modifications[1835889508].ValueAsBool;
            set => _modifications[1835889508] = new VariationObjectDataModification{Id = 1835889508, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public bool ArtMinimapUseCustomColor
        {
            get => _modifications[1668117860].ValueAsBool;
            set => _modifications[1668117860] = new VariationObjectDataModification{Id = 1668117860, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public int ArtMinimapColor1Red
        {
            get => _modifications[1919774052].ValueAsInt;
            set => _modifications[1919774052] = new VariationObjectDataModification{Id = 1919774052, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public int ArtMinimapColor2Green
        {
            get => _modifications[1735224676].ValueAsInt;
            set => _modifications[1735224676] = new VariationObjectDataModification{Id = 1735224676, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public int ArtMinimapColor3Blue
        {
            get => _modifications[1651338596].ValueAsInt;
            set => _modifications[1651338596] = new VariationObjectDataModification{Id = 1651338596, Type = ObjectDataType.Int, Value = value, Variation = 0};
        }

        public ObjectProperty<int> ArtTintingColor1Red => _artTintingColor1Red.Value;
        public ObjectProperty<int> ArtTintingColor2Green => _artTintingColor2Green.Value;
        public ObjectProperty<int> ArtTintingColor3Blue => _artTintingColor3Blue.Value;
        public bool EditorOnUserSpecifiedList
        {
            get => _modifications[1920169316].ValueAsBool;
            set => _modifications[1920169316] = new VariationObjectDataModification{Id = 1920169316, Type = ObjectDataType.Bool, Value = value, Variation = 0};
        }

        public static explicit operator VariationObjectModification(Doodad doodad) => new VariationObjectModification{OldId = doodad.OldId, NewId = doodad.NewId, Modifications = doodad.Modifications.ToList()};
        private int GetArtTintingColor1Red(int variation)
        {
            return _modifications[829584996, variation].ValueAsInt;
        }

        private void SetArtTintingColor1Red(int variation, int value)
        {
            _modifications[829584996, variation] = new VariationObjectDataModification{Id = 829584996, Type = ObjectDataType.Int, Value = value, Variation = variation};
        }

        private int GetArtTintingColor2Green(int variation)
        {
            return _modifications[828864100, variation].ValueAsInt;
        }

        private void SetArtTintingColor2Green(int variation, int value)
        {
            _modifications[828864100, variation] = new VariationObjectDataModification{Id = 828864100, Type = ObjectDataType.Int, Value = value, Variation = variation};
        }

        private int GetArtTintingColor3Blue(int variation)
        {
            return _modifications[828536420, variation].ValueAsInt;
        }

        private void SetArtTintingColor3Blue(int variation, int value)
        {
            _modifications[828536420, variation] = new VariationObjectDataModification{Id = 828536420, Type = ObjectDataType.Int, Value = value, Variation = variation};
        }
    }
}