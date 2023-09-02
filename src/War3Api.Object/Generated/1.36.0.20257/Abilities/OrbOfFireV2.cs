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
    public sealed class OrbOfFireV2 : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataHealingMultiplier;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHealingMultiplierModified;
        public OrbOfFireV2(): base(845564225)
        {
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public OrbOfFireV2(int newId): base(845564225, newId)
        {
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public OrbOfFireV2(string newRawcode): base(845564225, newRawcode)
        {
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public OrbOfFireV2(ObjectDatabaseBase db): base(845564225, db)
        {
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public OrbOfFireV2(int newId, ObjectDatabaseBase db): base(845564225, newId, db)
        {
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public OrbOfFireV2(string newRawcode, ObjectDatabaseBase db): base(845564225, newRawcode, db)
        {
            _dataHealingMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealingMultiplier, SetDataHealingMultiplier));
            _isDataHealingMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealingMultiplierModified));
        }

        public ObjectProperty<float> DataHealingMultiplier => _dataHealingMultiplier.Value;
        public ReadOnlyObjectProperty<bool> IsDataHealingMultiplierModified => _isDataHealingMultiplierModified.Value;
        private float GetDataHealingMultiplier(int level)
        {
            return _modifications.GetModification(1919315785, level).ValueAsFloat;
        }

        private void SetDataHealingMultiplier(int level, float value)
        {
            _modifications[1919315785, level] = new LevelObjectDataModification{Id = 1919315785, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataHealingMultiplierModified(int level)
        {
            return _modifications.ContainsKey(1919315785, level);
        }
    }
}