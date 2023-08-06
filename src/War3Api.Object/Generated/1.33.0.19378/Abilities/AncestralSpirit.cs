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
    public sealed class AncestralSpirit : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeRestoredFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeRestoredFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataManaRestoredFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaRestoredFactorModified;
        public AncestralSpirit(): base(1953718593)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _isDataLifeRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRestoredFactorModified));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
            _isDataManaRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRestoredFactorModified));
        }

        public AncestralSpirit(int newId): base(1953718593, newId)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _isDataLifeRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRestoredFactorModified));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
            _isDataManaRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRestoredFactorModified));
        }

        public AncestralSpirit(string newRawcode): base(1953718593, newRawcode)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _isDataLifeRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRestoredFactorModified));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
            _isDataManaRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRestoredFactorModified));
        }

        public AncestralSpirit(ObjectDatabaseBase db): base(1953718593, db)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _isDataLifeRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRestoredFactorModified));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
            _isDataManaRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRestoredFactorModified));
        }

        public AncestralSpirit(int newId, ObjectDatabaseBase db): base(1953718593, newId, db)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _isDataLifeRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRestoredFactorModified));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
            _isDataManaRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRestoredFactorModified));
        }

        public AncestralSpirit(string newRawcode, ObjectDatabaseBase db): base(1953718593, newRawcode, db)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _isDataLifeRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRestoredFactorModified));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
            _isDataManaRestoredFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRestoredFactorModified));
        }

        public ObjectProperty<float> DataLifeRestoredFactor => _dataLifeRestoredFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeRestoredFactorModified => _isDataLifeRestoredFactorModified.Value;
        public ObjectProperty<float> DataManaRestoredFactor => _dataManaRestoredFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaRestoredFactorModified => _isDataManaRestoredFactorModified.Value;
        private float GetDataLifeRestoredFactor(int level)
        {
            return _modifications.GetModification(829715297, level).ValueAsFloat;
        }

        private void SetDataLifeRestoredFactor(int level, float value)
        {
            _modifications[829715297, level] = new LevelObjectDataModification{Id = 829715297, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataLifeRestoredFactorModified(int level)
        {
            return _modifications.ContainsKey(829715297, level);
        }

        private float GetDataManaRestoredFactor(int level)
        {
            return _modifications.GetModification(846492513, level).ValueAsFloat;
        }

        private void SetDataManaRestoredFactor(int level, float value)
        {
            _modifications[846492513, level] = new LevelObjectDataModification{Id = 846492513, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataManaRestoredFactorModified(int level)
        {
            return _modifications.ContainsKey(846492513, level);
        }
    }
}