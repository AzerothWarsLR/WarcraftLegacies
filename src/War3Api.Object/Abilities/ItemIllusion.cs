using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemIllusion : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealtOfNormal;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReceivedMultiplier;
        public ItemIllusion(): base(1818839361)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
        }

        public ItemIllusion(int newId): base(1818839361, newId)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
        }

        public ItemIllusion(string newRawcode): base(1818839361, newRawcode)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
        }

        public ItemIllusion(ObjectDatabase db): base(1818839361, db)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
        }

        public ItemIllusion(int newId, ObjectDatabase db): base(1818839361, newId, db)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
        }

        public ItemIllusion(string newRawcode, ObjectDatabase db): base(1818839361, newRawcode, db)
        {
            _dataDamageDealtOfNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtOfNormal, SetDataDamageDealtOfNormal));
            _dataDamageReceivedMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReceivedMultiplier, SetDataDamageReceivedMultiplier));
        }

        public ObjectProperty<float> DataDamageDealtOfNormal => _dataDamageDealtOfNormal.Value;
        public ObjectProperty<float> DataDamageReceivedMultiplier => _dataDamageReceivedMultiplier.Value;
        private float GetDataDamageDealtOfNormal(int level)
        {
            return _modifications[1684826441, level].ValueAsFloat;
        }

        private void SetDataDamageDealtOfNormal(int level, float value)
        {
            _modifications[1684826441, level] = new LevelObjectDataModification{Id = 1684826441, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageReceivedMultiplier(int level)
        {
            return _modifications[2003593545, level].ValueAsFloat;
        }

        private void SetDataDamageReceivedMultiplier(int level, float value)
        {
            _modifications[2003593545, level] = new LevelObjectDataModification{Id = 2003593545, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}