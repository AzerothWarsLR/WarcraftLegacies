using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AbsorbMana : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMaximumLifeAbsorbed;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumLifeAbsorbedModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumManaAbsorbed;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumManaAbsorbedModified;
        public AbsorbMana(): base(1935827265)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _isDataMaximumLifeAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumLifeAbsorbedModified));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
            _isDataMaximumManaAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumManaAbsorbedModified));
        }

        public AbsorbMana(int newId): base(1935827265, newId)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _isDataMaximumLifeAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumLifeAbsorbedModified));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
            _isDataMaximumManaAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumManaAbsorbedModified));
        }

        public AbsorbMana(string newRawcode): base(1935827265, newRawcode)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _isDataMaximumLifeAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumLifeAbsorbedModified));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
            _isDataMaximumManaAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumManaAbsorbedModified));
        }

        public AbsorbMana(ObjectDatabaseBase db): base(1935827265, db)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _isDataMaximumLifeAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumLifeAbsorbedModified));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
            _isDataMaximumManaAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumManaAbsorbedModified));
        }

        public AbsorbMana(int newId, ObjectDatabaseBase db): base(1935827265, newId, db)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _isDataMaximumLifeAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumLifeAbsorbedModified));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
            _isDataMaximumManaAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumManaAbsorbedModified));
        }

        public AbsorbMana(string newRawcode, ObjectDatabaseBase db): base(1935827265, newRawcode, db)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _isDataMaximumLifeAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumLifeAbsorbedModified));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
            _isDataMaximumManaAbsorbedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumManaAbsorbedModified));
        }

        public ObjectProperty<float> DataMaximumLifeAbsorbed => _dataMaximumLifeAbsorbed.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumLifeAbsorbedModified => _isDataMaximumLifeAbsorbedModified.Value;
        public ObjectProperty<float> DataMaximumManaAbsorbed => _dataMaximumManaAbsorbed.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumManaAbsorbedModified => _isDataMaximumManaAbsorbedModified.Value;
        private float GetDataMaximumLifeAbsorbed(int level)
        {
            return _modifications.GetModification(829645409, level).ValueAsFloat;
        }

        private void SetDataMaximumLifeAbsorbed(int level, float value)
        {
            _modifications[829645409, level] = new LevelObjectDataModification{Id = 829645409, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaximumLifeAbsorbedModified(int level)
        {
            return _modifications.ContainsKey(829645409, level);
        }

        private float GetDataMaximumManaAbsorbed(int level)
        {
            return _modifications.GetModification(846422625, level).ValueAsFloat;
        }

        private void SetDataMaximumManaAbsorbed(int level, float value)
        {
            _modifications[846422625, level] = new LevelObjectDataModification{Id = 846422625, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMaximumManaAbsorbedModified(int level)
        {
            return _modifications.ContainsKey(846422625, level);
        }
    }
}