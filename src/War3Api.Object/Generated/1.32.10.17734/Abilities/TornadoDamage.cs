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
    public sealed class TornadoDamage : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerSecondModified;
        private readonly Lazy<ObjectProperty<float>> _dataMediumDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMediumDamageRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataMediumDamagePerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMediumDamagePerSecondModified;
        private readonly Lazy<ObjectProperty<float>> _dataSmallDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSmallDamageRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataSmallDamagePerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSmallDamagePerSecondModified;
        public TornadoDamage(): base(1734636609)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _isDataMediumDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamagePerSecondModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
            _isDataSmallDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamagePerSecondModified));
        }

        public TornadoDamage(int newId): base(1734636609, newId)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _isDataMediumDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamagePerSecondModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
            _isDataSmallDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamagePerSecondModified));
        }

        public TornadoDamage(string newRawcode): base(1734636609, newRawcode)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _isDataMediumDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamagePerSecondModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
            _isDataSmallDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamagePerSecondModified));
        }

        public TornadoDamage(ObjectDatabaseBase db): base(1734636609, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _isDataMediumDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamagePerSecondModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
            _isDataSmallDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamagePerSecondModified));
        }

        public TornadoDamage(int newId, ObjectDatabaseBase db): base(1734636609, newId, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _isDataMediumDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamagePerSecondModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
            _isDataSmallDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamagePerSecondModified));
        }

        public TornadoDamage(string newRawcode, ObjectDatabaseBase db): base(1734636609, newRawcode, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataMediumDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamagePerSecond, SetDataMediumDamagePerSecond));
            _isDataMediumDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamagePerSecondModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataSmallDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamagePerSecond, SetDataSmallDamagePerSecond));
            _isDataSmallDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamagePerSecondModified));
        }

        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerSecondModified => _isDataDamagePerSecondModified.Value;
        public ObjectProperty<float> DataMediumDamageRadius => _dataMediumDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataMediumDamageRadiusModified => _isDataMediumDamageRadiusModified.Value;
        public ObjectProperty<float> DataMediumDamagePerSecond => _dataMediumDamagePerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataMediumDamagePerSecondModified => _isDataMediumDamagePerSecondModified.Value;
        public ObjectProperty<float> DataSmallDamageRadius => _dataSmallDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataSmallDamageRadiusModified => _isDataSmallDamageRadiusModified.Value;
        public ObjectProperty<float> DataSmallDamagePerSecond => _dataSmallDamagePerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataSmallDamagePerSecondModified => _isDataSmallDamagePerSecondModified.Value;
        private float GetDataDamagePerSecond(int level)
        {
            return _modifications.GetModification(828859476, level).ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[828859476, level] = new LevelObjectDataModification{Id = 828859476, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamagePerSecondModified(int level)
        {
            return _modifications.ContainsKey(828859476, level);
        }

        private float GetDataMediumDamageRadius(int level)
        {
            return _modifications.GetModification(845636692, level).ValueAsFloat;
        }

        private void SetDataMediumDamageRadius(int level, float value)
        {
            _modifications[845636692, level] = new LevelObjectDataModification{Id = 845636692, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMediumDamageRadiusModified(int level)
        {
            return _modifications.ContainsKey(845636692, level);
        }

        private float GetDataMediumDamagePerSecond(int level)
        {
            return _modifications.GetModification(862413908, level).ValueAsFloat;
        }

        private void SetDataMediumDamagePerSecond(int level, float value)
        {
            _modifications[862413908, level] = new LevelObjectDataModification{Id = 862413908, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMediumDamagePerSecondModified(int level)
        {
            return _modifications.ContainsKey(862413908, level);
        }

        private float GetDataSmallDamageRadius(int level)
        {
            return _modifications.GetModification(879191124, level).ValueAsFloat;
        }

        private void SetDataSmallDamageRadius(int level, float value)
        {
            _modifications[879191124, level] = new LevelObjectDataModification{Id = 879191124, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataSmallDamageRadiusModified(int level)
        {
            return _modifications.ContainsKey(879191124, level);
        }

        private float GetDataSmallDamagePerSecond(int level)
        {
            return _modifications.GetModification(895968340, level).ValueAsFloat;
        }

        private void SetDataSmallDamagePerSecond(int level, float value)
        {
            _modifications[895968340, level] = new LevelObjectDataModification{Id = 895968340, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataSmallDamagePerSecondModified(int level)
        {
            return _modifications.ContainsKey(895968340, level);
        }
    }
}