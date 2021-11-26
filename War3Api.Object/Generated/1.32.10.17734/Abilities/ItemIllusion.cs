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
    public sealed class ItemIllusion : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealtOfNormal;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageDealtOfNormalModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReceivedMultiplier;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageReceivedMultiplierModified;
        public ItemIllusion(): base(1818839361)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _isDataDamageDealtOfNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtOfNormalModified));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
            _isDataDamageReceivedMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReceivedMultiplierModified));
        }

        public ItemIllusion(int newId): base(1818839361, newId)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _isDataDamageDealtOfNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtOfNormalModified));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
            _isDataDamageReceivedMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReceivedMultiplierModified));
        }

        public ItemIllusion(string newRawcode): base(1818839361, newRawcode)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _isDataDamageDealtOfNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtOfNormalModified));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
            _isDataDamageReceivedMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReceivedMultiplierModified));
        }

        public ItemIllusion(ObjectDatabaseBase db): base(1818839361, db)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _isDataDamageDealtOfNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtOfNormalModified));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
            _isDataDamageReceivedMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReceivedMultiplierModified));
        }

        public ItemIllusion(int newId, ObjectDatabaseBase db): base(1818839361, newId, db)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _isDataDamageDealtOfNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtOfNormalModified));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
            _isDataDamageReceivedMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReceivedMultiplierModified));
        }

        public ItemIllusion(string newRawcode, ObjectDatabaseBase db): base(1818839361, newRawcode, db)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _isDataDamageDealtOfNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtOfNormalModified));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
            _isDataDamageReceivedMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReceivedMultiplierModified));
        }

        public ObjectProperty<float> DataDamageDealtOfNormal => _dataDamageDealtOfNormal.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageDealtOfNormalModified => _isDataDamageDealtOfNormalModified.Value;
        public ObjectProperty<float> DataDamageReceivedMultiplier => _dataDamageReceivedMultiplier.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageReceivedMultiplierModified => _isDataDamageReceivedMultiplierModified.Value;
        private float GetDataDamageDealtOfNormal(int level)
        {
            return _modifications.GetModification(1684826441, level).ValueAsFloat;
        }

        private void SetDataDamageDealtOfNormal(int level, float value)
        {
            _modifications[1684826441, level] = new LevelObjectDataModification{Id = 1684826441, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageDealtOfNormalModified(int level)
        {
            return _modifications.ContainsKey(1684826441, level);
        }

        private float GetDataDamageReceivedMultiplier(int level)
        {
            return _modifications.GetModification(2003593545, level).ValueAsFloat;
        }

        private void SetDataDamageReceivedMultiplier(int level, float value)
        {
            _modifications[2003593545, level] = new LevelObjectDataModification{Id = 2003593545, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageReceivedMultiplierModified(int level)
        {
            return _modifications.ContainsKey(2003593545, level);
        }
    }
}