using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class UltraVisionGlyph : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataUpgradeLevels;
        private readonly Lazy<ObjectProperty<string>> _dataUpgradeTypeRaw;
        private readonly Lazy<ObjectProperty<Upgrade>> _dataUpgradeType;
        public UltraVisionGlyph(): base(1969703233)
        {
            _dataUpgradeLevels = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUpgradeLevels, SetDataUpgradeLevels));
            _dataUpgradeTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUpgradeTypeRaw, SetDataUpgradeTypeRaw));
            _dataUpgradeType = new Lazy<ObjectProperty<Upgrade>>(() => new ObjectProperty<Upgrade>(GetDataUpgradeType, SetDataUpgradeType));
        }

        public UltraVisionGlyph(int newId): base(1969703233, newId)
        {
            _dataUpgradeLevels = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUpgradeLevels, SetDataUpgradeLevels));
            _dataUpgradeTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUpgradeTypeRaw, SetDataUpgradeTypeRaw));
            _dataUpgradeType = new Lazy<ObjectProperty<Upgrade>>(() => new ObjectProperty<Upgrade>(GetDataUpgradeType, SetDataUpgradeType));
        }

        public UltraVisionGlyph(string newRawcode): base(1969703233, newRawcode)
        {
            _dataUpgradeLevels = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUpgradeLevels, SetDataUpgradeLevels));
            _dataUpgradeTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUpgradeTypeRaw, SetDataUpgradeTypeRaw));
            _dataUpgradeType = new Lazy<ObjectProperty<Upgrade>>(() => new ObjectProperty<Upgrade>(GetDataUpgradeType, SetDataUpgradeType));
        }

        public UltraVisionGlyph(ObjectDatabase db): base(1969703233, db)
        {
            _dataUpgradeLevels = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUpgradeLevels, SetDataUpgradeLevels));
            _dataUpgradeTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUpgradeTypeRaw, SetDataUpgradeTypeRaw));
            _dataUpgradeType = new Lazy<ObjectProperty<Upgrade>>(() => new ObjectProperty<Upgrade>(GetDataUpgradeType, SetDataUpgradeType));
        }

        public UltraVisionGlyph(int newId, ObjectDatabase db): base(1969703233, newId, db)
        {
            _dataUpgradeLevels = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUpgradeLevels, SetDataUpgradeLevels));
            _dataUpgradeTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUpgradeTypeRaw, SetDataUpgradeTypeRaw));
            _dataUpgradeType = new Lazy<ObjectProperty<Upgrade>>(() => new ObjectProperty<Upgrade>(GetDataUpgradeType, SetDataUpgradeType));
        }

        public UltraVisionGlyph(string newRawcode, ObjectDatabase db): base(1969703233, newRawcode, db)
        {
            _dataUpgradeLevels = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUpgradeLevels, SetDataUpgradeLevels));
            _dataUpgradeTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUpgradeTypeRaw, SetDataUpgradeTypeRaw));
            _dataUpgradeType = new Lazy<ObjectProperty<Upgrade>>(() => new ObjectProperty<Upgrade>(GetDataUpgradeType, SetDataUpgradeType));
        }

        public ObjectProperty<int> DataUpgradeLevels => _dataUpgradeLevels.Value;
        public ObjectProperty<string> DataUpgradeTypeRaw => _dataUpgradeTypeRaw.Value;
        public ObjectProperty<Upgrade> DataUpgradeType => _dataUpgradeType.Value;
        private int GetDataUpgradeLevels(int level)
        {
            return _modifications[829187913, level].ValueAsInt;
        }

        private void SetDataUpgradeLevels(int level, int value)
        {
            _modifications[829187913, level] = new LevelObjectDataModification{Id = 829187913, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private string GetDataUpgradeTypeRaw(int level)
        {
            return _modifications[1970038601, level].ValueAsString;
        }

        private void SetDataUpgradeTypeRaw(int level, string value)
        {
            _modifications[1970038601, level] = new LevelObjectDataModification{Id = 1970038601, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private Upgrade GetDataUpgradeType(int level)
        {
            return GetDataUpgradeTypeRaw(level).ToUpgrade(this);
        }

        private void SetDataUpgradeType(int level, Upgrade value)
        {
            SetDataUpgradeTypeRaw(level, value.ToRaw(null, null));
        }
    }
}