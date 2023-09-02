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
    public sealed class KeeperTranquility : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeHealed;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeHealedModified;
        private readonly Lazy<ObjectProperty<float>> _dataHealInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHealIntervalModified;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBuildingReductionModified;
        private readonly Lazy<ObjectProperty<float>> _dataInitialImmunityDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataInitialImmunityDurationModified;
        public KeeperTranquility(): base(1903445313)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _isDataLifeHealedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeHealedModified));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _isDataHealIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
            _isDataInitialImmunityDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialImmunityDurationModified));
        }

        public KeeperTranquility(int newId): base(1903445313, newId)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _isDataLifeHealedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeHealedModified));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _isDataHealIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
            _isDataInitialImmunityDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialImmunityDurationModified));
        }

        public KeeperTranquility(string newRawcode): base(1903445313, newRawcode)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _isDataLifeHealedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeHealedModified));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _isDataHealIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
            _isDataInitialImmunityDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialImmunityDurationModified));
        }

        public KeeperTranquility(ObjectDatabaseBase db): base(1903445313, db)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _isDataLifeHealedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeHealedModified));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _isDataHealIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
            _isDataInitialImmunityDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialImmunityDurationModified));
        }

        public KeeperTranquility(int newId, ObjectDatabaseBase db): base(1903445313, newId, db)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _isDataLifeHealedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeHealedModified));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _isDataHealIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
            _isDataInitialImmunityDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialImmunityDurationModified));
        }

        public KeeperTranquility(string newRawcode, ObjectDatabaseBase db): base(1903445313, newRawcode, db)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _isDataLifeHealedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeHealedModified));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _isDataHealIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHealIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
            _isDataInitialImmunityDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialImmunityDurationModified));
        }

        public ObjectProperty<float> DataLifeHealed => _dataLifeHealed.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeHealedModified => _isDataLifeHealedModified.Value;
        public ObjectProperty<float> DataHealInterval => _dataHealInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataHealIntervalModified => _isDataHealIntervalModified.Value;
        public ObjectProperty<float> DataBuildingReduction => _dataBuildingReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataBuildingReductionModified => _isDataBuildingReductionModified.Value;
        public ObjectProperty<float> DataInitialImmunityDuration => _dataInitialImmunityDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataInitialImmunityDurationModified => _isDataInitialImmunityDurationModified.Value;
        private float GetDataLifeHealed(int level)
        {
            return _modifications.GetModification(829518917, level).ValueAsFloat;
        }

        private void SetDataLifeHealed(int level, float value)
        {
            _modifications[829518917, level] = new LevelObjectDataModification{Id = 829518917, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataLifeHealedModified(int level)
        {
            return _modifications.ContainsKey(829518917, level);
        }

        private float GetDataHealInterval(int level)
        {
            return _modifications.GetModification(846296133, level).ValueAsFloat;
        }

        private void SetDataHealInterval(int level, float value)
        {
            _modifications[846296133, level] = new LevelObjectDataModification{Id = 846296133, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataHealIntervalModified(int level)
        {
            return _modifications.ContainsKey(846296133, level);
        }

        private float GetDataBuildingReduction(int level)
        {
            return _modifications.GetModification(863073349, level).ValueAsFloat;
        }

        private void SetDataBuildingReduction(int level, float value)
        {
            _modifications[863073349, level] = new LevelObjectDataModification{Id = 863073349, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataBuildingReductionModified(int level)
        {
            return _modifications.ContainsKey(863073349, level);
        }

        private float GetDataInitialImmunityDuration(int level)
        {
            return _modifications.GetModification(879850565, level).ValueAsFloat;
        }

        private void SetDataInitialImmunityDuration(int level, float value)
        {
            _modifications[879850565, level] = new LevelObjectDataModification{Id = 879850565, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataInitialImmunityDurationModified(int level)
        {
            return _modifications.ContainsKey(879850565, level);
        }
    }
}