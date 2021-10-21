using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ManaBurnDemon_Amnb : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMaxManaDrained;
        private readonly Lazy<ObjectProperty<float>> _dataBoltDelay;
        private readonly Lazy<ObjectProperty<float>> _dataBoltLifetime;
        public ManaBurnDemon_Amnb(): base(1651404097)
        {
            _dataMaxManaDrained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrained, SetDataMaxManaDrained));
            _dataBoltDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltDelay, SetDataBoltDelay));
            _dataBoltLifetime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltLifetime, SetDataBoltLifetime));
        }

        public ManaBurnDemon_Amnb(int newId): base(1651404097, newId)
        {
            _dataMaxManaDrained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrained, SetDataMaxManaDrained));
            _dataBoltDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltDelay, SetDataBoltDelay));
            _dataBoltLifetime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltLifetime, SetDataBoltLifetime));
        }

        public ManaBurnDemon_Amnb(string newRawcode): base(1651404097, newRawcode)
        {
            _dataMaxManaDrained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrained, SetDataMaxManaDrained));
            _dataBoltDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltDelay, SetDataBoltDelay));
            _dataBoltLifetime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltLifetime, SetDataBoltLifetime));
        }

        public ManaBurnDemon_Amnb(ObjectDatabase db): base(1651404097, db)
        {
            _dataMaxManaDrained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrained, SetDataMaxManaDrained));
            _dataBoltDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltDelay, SetDataBoltDelay));
            _dataBoltLifetime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltLifetime, SetDataBoltLifetime));
        }

        public ManaBurnDemon_Amnb(int newId, ObjectDatabase db): base(1651404097, newId, db)
        {
            _dataMaxManaDrained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrained, SetDataMaxManaDrained));
            _dataBoltDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltDelay, SetDataBoltDelay));
            _dataBoltLifetime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBoltLifetime, SetDataBoltLifetime));
        }

        public ManaBurnDemon_Amnb(string newRawcode, ObjectDatabase db): base(1651404097, newRawcode, db)
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