using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FeedbackArcaneTower : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataSummonedDamage;
        public FeedbackArcaneTower(): base(1952605761)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public FeedbackArcaneTower(int newId): base(1952605761, newId)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public FeedbackArcaneTower(string newRawcode): base(1952605761, newRawcode)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public FeedbackArcaneTower(ObjectDatabase db): base(1952605761, db)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public FeedbackArcaneTower(int newId, ObjectDatabase db): base(1952605761, newId, db)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public FeedbackArcaneTower(string newRawcode, ObjectDatabase db): base(1952605761, newRawcode, db)
        {
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public ObjectProperty<float> DataSummonedDamage => _dataSummonedDamage.Value;
        private float GetDataSummonedDamage(int level)
        {
            return _modifications[896229990, level].ValueAsFloat;
        }

        private void SetDataSummonedDamage(int level, float value)
        {
            _modifications[896229990, level] = new LevelObjectDataModification{Id = 896229990, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}