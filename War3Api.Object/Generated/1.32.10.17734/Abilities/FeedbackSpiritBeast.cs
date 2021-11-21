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
    public sealed class FeedbackSpiritBeast : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataSummonedDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedDamageModified;
        public FeedbackSpiritBeast(): base(1650615873)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public FeedbackSpiritBeast(int newId): base(1650615873, newId)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public FeedbackSpiritBeast(string newRawcode): base(1650615873, newRawcode)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public FeedbackSpiritBeast(ObjectDatabaseBase db): base(1650615873, db)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public FeedbackSpiritBeast(int newId, ObjectDatabaseBase db): base(1650615873, newId, db)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public FeedbackSpiritBeast(string newRawcode, ObjectDatabaseBase db): base(1650615873, newRawcode, db)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public ObjectProperty<float> DataSummonedDamage => _dataSummonedDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedDamageModified => _isDataSummonedDamageModified.Value;
        private float GetDataSummonedDamage(int level)
        {
            return _modifications.GetModification(896229990, level).ValueAsFloat;
        }

        private void SetDataSummonedDamage(int level, float value)
        {
            _modifications[896229990, level] = new LevelObjectDataModification{Id = 896229990, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataSummonedDamageModified(int level)
        {
            return _modifications.ContainsKey(896229990, level);
        }
    }
}