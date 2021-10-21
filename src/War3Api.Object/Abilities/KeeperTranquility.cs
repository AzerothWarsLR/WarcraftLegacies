using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class KeeperTranquility : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeHealed;
        private readonly Lazy<ObjectProperty<float>> _dataHealInterval;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingReduction;
        private readonly Lazy<ObjectProperty<float>> _dataInitialImmunityDuration;
        public KeeperTranquility(): base(1903445313)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
        }

        public KeeperTranquility(int newId): base(1903445313, newId)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
        }

        public KeeperTranquility(string newRawcode): base(1903445313, newRawcode)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
        }

        public KeeperTranquility(ObjectDatabase db): base(1903445313, db)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
        }

        public KeeperTranquility(int newId, ObjectDatabase db): base(1903445313, newId, db)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
        }

        public KeeperTranquility(string newRawcode, ObjectDatabase db): base(1903445313, newRawcode, db)
        {
            _dataLifeHealed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeHealed, SetDataLifeHealed));
            _dataHealInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHealInterval, SetDataHealInterval));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _dataInitialImmunityDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialImmunityDuration, SetDataInitialImmunityDuration));
        }

        public ObjectProperty<float> DataLifeHealed => _dataLifeHealed.Value;
        public ObjectProperty<float> DataHealInterval => _dataHealInterval.Value;
        public ObjectProperty<float> DataBuildingReduction => _dataBuildingReduction.Value;
        public ObjectProperty<float> DataInitialImmunityDuration => _dataInitialImmunityDuration.Value;
        private float GetDataLifeHealed(int level)
        {
            return _modifications[829518917, level].ValueAsFloat;
        }

        private void SetDataLifeHealed(int level, float value)
        {
            _modifications[829518917, level] = new LevelObjectDataModification{Id = 829518917, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataHealInterval(int level)
        {
            return _modifications[846296133, level].ValueAsFloat;
        }

        private void SetDataHealInterval(int level, float value)
        {
            _modifications[846296133, level] = new LevelObjectDataModification{Id = 846296133, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataBuildingReduction(int level)
        {
            return _modifications[863073349, level].ValueAsFloat;
        }

        private void SetDataBuildingReduction(int level, float value)
        {
            _modifications[863073349, level] = new LevelObjectDataModification{Id = 863073349, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataInitialImmunityDuration(int level)
        {
            return _modifications[879850565, level].ValueAsFloat;
        }

        private void SetDataInitialImmunityDuration(int level, float value)
        {
            _modifications[879850565, level] = new LevelObjectDataModification{Id = 879850565, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }
    }
}