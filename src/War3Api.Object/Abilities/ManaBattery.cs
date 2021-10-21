using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ManaBattery : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaGained;
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        private readonly Lazy<ObjectProperty<float>> _dataAutocastRequirement;
        private readonly Lazy<ObjectProperty<float>> _dataWaterHeight;
        private readonly Lazy<ObjectProperty<bool>> _dataRegenerateOnlyAtNight;
        public ManaBattery(): base(1952607553)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
        }

        public ManaBattery(int newId): base(1952607553, newId)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
        }

        public ManaBattery(string newRawcode): base(1952607553, newRawcode)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
        }

        public ManaBattery(ObjectDatabase db): base(1952607553, db)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
        }

        public ManaBattery(int newId, ObjectDatabase db): base(1952607553, newId, db)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
        }

        public ManaBattery(string newRawcode, ObjectDatabase db): base(1952607553, newRawcode, db)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
        }

        public ObjectProperty<float> DataManaGained => _dataManaGained.Value;
        public ObjectProperty<float> DataHitPointsGained => _dataHitPointsGained.Value;
        public ObjectProperty<float> DataAutocastRequirement => _dataAutocastRequirement.Value;
        public ObjectProperty<float> DataWaterHeight => _dataWaterHeight.Value;
        public ObjectProperty<bool> DataRegenerateOnlyAtNight => _dataRegenerateOnlyAtNight.Value;
        private float GetDataManaGained(int level)
        {
            return _modifications[829710925, level].ValueAsFloat;
        }

        private void SetDataManaGained(int level, float value)
        {
            _modifications[829710925, level] = new LevelObjectDataModification{Id = 829710925, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataHitPointsGained(int level)
        {
            return _modifications[846488141, level].ValueAsFloat;
        }

        private void SetDataHitPointsGained(int level, float value)
        {
            _modifications[846488141, level] = new LevelObjectDataModification{Id = 846488141, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataAutocastRequirement(int level)
        {
            return _modifications[863265357, level].ValueAsFloat;
        }

        private void SetDataAutocastRequirement(int level, float value)
        {
            _modifications[863265357, level] = new LevelObjectDataModification{Id = 863265357, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataWaterHeight(int level)
        {
            return _modifications[880042573, level].ValueAsFloat;
        }

        private void SetDataWaterHeight(int level, float value)
        {
            _modifications[880042573, level] = new LevelObjectDataModification{Id = 880042573, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetDataRegenerateOnlyAtNight(int level)
        {
            return _modifications[896819789, level].ValueAsBool;
        }

        private void SetDataRegenerateOnlyAtNight(int level, bool value)
        {
            _modifications[896819789, level] = new LevelObjectDataModification{Id = 896819789, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }
    }
}