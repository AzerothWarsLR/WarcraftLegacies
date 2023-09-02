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
    public sealed class CenariusBeefyStarfall : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealt;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageDealtModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageIntervalModified;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBuildingReductionModified;
        public CenariusBeefyStarfall(): base(1651721537)
        {
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public CenariusBeefyStarfall(int newId): base(1651721537, newId)
        {
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public CenariusBeefyStarfall(string newRawcode): base(1651721537, newRawcode)
        {
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public CenariusBeefyStarfall(ObjectDatabaseBase db): base(1651721537, db)
        {
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public CenariusBeefyStarfall(int newId, ObjectDatabaseBase db): base(1651721537, newId, db)
        {
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public CenariusBeefyStarfall(string newRawcode, ObjectDatabaseBase db): base(1651721537, newRawcode, db)
        {
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageInterval, SetDataDamageInterval));
            _isDataDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
        }

        public ObjectProperty<float> DataDamageDealt => _dataDamageDealt.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageDealtModified => _isDataDamageDealtModified.Value;
        public ObjectProperty<float> DataDamageInterval => _dataDamageInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageIntervalModified => _isDataDamageIntervalModified.Value;
        public ObjectProperty<float> DataBuildingReduction => _dataBuildingReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataBuildingReductionModified => _isDataBuildingReductionModified.Value;
        private float GetDataDamageDealt(int level)
        {
            return _modifications.GetModification(828797765, level).ValueAsFloat;
        }

        private void SetDataDamageDealt(int level, float value)
        {
            _modifications[828797765, level] = new LevelObjectDataModification{Id = 828797765, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageDealtModified(int level)
        {
            return _modifications.ContainsKey(828797765, level);
        }

        private float GetDataDamageInterval(int level)
        {
            return _modifications.GetModification(845574981, level).ValueAsFloat;
        }

        private void SetDataDamageInterval(int level, float value)
        {
            _modifications[845574981, level] = new LevelObjectDataModification{Id = 845574981, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageIntervalModified(int level)
        {
            return _modifications.ContainsKey(845574981, level);
        }

        private float GetDataBuildingReduction(int level)
        {
            return _modifications.GetModification(862352197, level).ValueAsFloat;
        }

        private void SetDataBuildingReduction(int level, float value)
        {
            _modifications[862352197, level] = new LevelObjectDataModification{Id = 862352197, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataBuildingReductionModified(int level)
        {
            return _modifications.ContainsKey(862352197, level);
        }
    }
}