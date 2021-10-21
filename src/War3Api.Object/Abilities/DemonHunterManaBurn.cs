using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DemonHunterManaBurn : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMaxManaDrained;
        private readonly Lazy<ObjectProperty<float>> _dataBoltDelay;
        private readonly Lazy<ObjectProperty<float>> _dataBoltLifetime;
        public DemonHunterManaBurn(): base(1651328321)
        {
            _dataMaxManaDrained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrained, SetDataMaxManaDrained));
            _dataBoltDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltDelay, SetDataBoltDelay));
            _dataBoltLifetime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltLifetime, SetDataBoltLifetime));
        }

        public DemonHunterManaBurn(int newId): base(1651328321, newId)
        {
            _dataMaxManaDrained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrained, SetDataMaxManaDrained));
            _dataBoltDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltDelay, SetDataBoltDelay));
            _dataBoltLifetime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltLifetime, SetDataBoltLifetime));
        }

        public DemonHunterManaBurn(string newRawcode): base(1651328321, newRawcode)
        {
            _dataMaxManaDrained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrained, SetDataMaxManaDrained));
            _dataBoltDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltDelay, SetDataBoltDelay));
            _dataBoltLifetime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltLifetime, SetDataBoltLifetime));
        }

        public DemonHunterManaBurn(ObjectDatabase db): base(1651328321, db)
        {
            _dataMaxManaDrained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrained, SetDataMaxManaDrained));
            _dataBoltDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltDelay, SetDataBoltDelay));
            _dataBoltLifetime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltLifetime, SetDataBoltLifetime));
        }

        public DemonHunterManaBurn(int newId, ObjectDatabase db): base(1651328321, newId, db)
        {
            _dataMaxManaDrained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrained, SetDataMaxManaDrained));
            _dataBoltDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltDelay, SetDataBoltDelay));
            _dataBoltLifetime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltLifetime, SetDataBoltLifetime));
        }

        public DemonHunterManaBurn(string newRawcode, ObjectDatabase db): base(1651328321, newRawcode, db)
        {
            _dataMaxManaDrained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrained, SetDataMaxManaDrained));
            _dataBoltDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltDelay, SetDataBoltDelay));
            _dataBoltLifetime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltLifetime, SetDataBoltLifetime));
        }

        public ObjectProperty<float> DataMaxManaDrained => _dataMaxManaDrained.Value;
        public ObjectProperty<float> DataBoltDelay => _dataBoltDelay.Value;
        public ObjectProperty<float> DataBoltLifetime => _dataBoltLifetime.Value;
        private float GetDataMaxManaDrained(int level)
        {
            return _modifications[828534085, level].ValueAsFloat;
        }

        private void SetDataMaxManaDrained(int level, float value)
        {
            _modifications[828534085, level] = new LevelObjectDataModification{Id = 828534085, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataBoltDelay(int level)
        {
            return _modifications[845311301, level].ValueAsFloat;
        }

        private void SetDataBoltDelay(int level, float value)
        {
            _modifications[845311301, level] = new LevelObjectDataModification{Id = 845311301, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataBoltLifetime(int level)
        {
            return _modifications[862088517, level].ValueAsFloat;
        }

        private void SetDataBoltLifetime(int level, float value)
        {
            _modifications[862088517, level] = new LevelObjectDataModification{Id = 862088517, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}