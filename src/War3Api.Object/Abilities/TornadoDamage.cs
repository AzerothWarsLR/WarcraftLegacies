using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TornadoDamage : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataMediumDamageRadius;
        private readonly Lazy<ObjectProperty<float>> _dataMediumDamagePerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataSmallDamageRadius;
        private readonly Lazy<ObjectProperty<float>> _dataSmallDamagePerSecond;
        public TornadoDamage(): base(1734636609)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
        }

        public TornadoDamage(int newId): base(1734636609, newId)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
        }

        public TornadoDamage(string newRawcode): base(1734636609, newRawcode)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
        }

        public TornadoDamage(ObjectDatabase db): base(1734636609, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
        }

        public TornadoDamage(int newId, ObjectDatabase db): base(1734636609, newId, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
        }

        public TornadoDamage(string newRawcode, ObjectDatabase db): base(1734636609, newRawcode, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
        }

        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ObjectProperty<float> DataMediumDamageRadius => _dataMediumDamageRadius.Value;
        public ObjectProperty<float> DataMediumDamagePerSecond => _dataMediumDamagePerSecond.Value;
        public ObjectProperty<float> DataSmallDamageRadius => _dataSmallDamageRadius.Value;
        public ObjectProperty<float> DataSmallDamagePerSecond => _dataSmallDamagePerSecond.Value;
        private float GetDataDamagePerSecond(int level)
        {
            return _modifications[828859476, level].ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[828859476, level] = new LevelObjectDataModification{Id = 828859476, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMediumDamageRadius(int level)
        {
            return _modifications[845636692, level].ValueAsFloat;
        }

        private void SetDataMediumDamageRadius(int level, float value)
        {
            _modifications[845636692, level] = new LevelObjectDataModification{Id = 845636692, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataMediumDamagePerSecond(int level)
        {
            return _modifications[862413908, level].ValueAsFloat;
        }

        private void SetDataMediumDamagePerSecond(int level, float value)
        {
            _modifications[862413908, level] = new LevelObjectDataModification{Id = 862413908, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataSmallDamageRadius(int level)
        {
            return _modifications[879191124, level].ValueAsFloat;
        }

        private void SetDataSmallDamageRadius(int level, float value)
        {
            _modifications[879191124, level] = new LevelObjectDataModification{Id = 879191124, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataSmallDamagePerSecond(int level)
        {
            return _modifications[895968340, level].ValueAsFloat;
        }

        private void SetDataSmallDamagePerSecond(int level, float value)
        {
            _modifications[895968340, level] = new LevelObjectDataModification{Id = 895968340, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}