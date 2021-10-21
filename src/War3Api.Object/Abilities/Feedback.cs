using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Feedback : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMaxManaDrainedUnits;
        private readonly Lazy<ObjectProperty<float>> _dataDamageRatioUnits;
        private readonly Lazy<ObjectProperty<float>> _dataMaxManaDrainedHeros;
        private readonly Lazy<ObjectProperty<float>> _dataDamageRatioHeros;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedDamage;
        public Feedback(): base(1801610817)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public Feedback(int newId): base(1801610817, newId)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public Feedback(string newRawcode): base(1801610817, newRawcode)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public Feedback(ObjectDatabase db): base(1801610817, db)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public Feedback(int newId, ObjectDatabase db): base(1801610817, newId, db)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public Feedback(string newRawcode, ObjectDatabase db): base(1801610817, newRawcode, db)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
        }

        public ObjectProperty<float> DataMaxManaDrainedUnits => _dataMaxManaDrainedUnits.Value;
        public ObjectProperty<float> DataDamageRatioUnits => _dataDamageRatioUnits.Value;
        public ObjectProperty<float> DataMaxManaDrainedHeros => _dataMaxManaDrainedHeros.Value;
        public ObjectProperty<float> DataDamageRatioHeros => _dataDamageRatioHeros.Value;
        public ObjectProperty<float> DataSummonedDamage => _dataSummonedDamage.Value;
        private float GetDataMaxManaDrainedUnits(int level)
        {
            return _modifications[829121126, level].ValueAsFloat;
        }

        private void SetDataMaxManaDrainedUnits(int level, float value)
        {
            _modifications[829121126, level] = new LevelObjectDataModification{Id = 829121126, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageRatioUnits(int level)
        {
            return _modifications[845898342, level].ValueAsFloat;
        }

        private void SetDataDamageRatioUnits(int level, float value)
        {
            _modifications[845898342, level] = new LevelObjectDataModification{Id = 845898342, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataMaxManaDrainedHeros(int level)
        {
            return _modifications[862675558, level].ValueAsFloat;
        }

        private void SetDataMaxManaDrainedHeros(int level, float value)
        {
            _modifications[862675558, level] = new LevelObjectDataModification{Id = 862675558, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataDamageRatioHeros(int level)
        {
            return _modifications[879452774, level].ValueAsFloat;
        }

        private void SetDataDamageRatioHeros(int level, float value)
        {
            _modifications[879452774, level] = new LevelObjectDataModification{Id = 879452774, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

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