using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ManaBatteryObsidianStatue : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaGainedModified;
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointsGainedModified;
        private readonly Lazy<ObjectProperty<float>> _dataAutocastRequirement;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAutocastRequirementModified;
        private readonly Lazy<ObjectProperty<float>> _dataWaterHeight;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataWaterHeightModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRegenerateOnlyAtNight;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRegenerateOnlyAtNightModified;
        public ManaBatteryObsidianStatue(): base(845311297)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _isDataManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaGainedModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _isDataAutocastRequirementModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutocastRequirementModified));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _isDataWaterHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaterHeightModified));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
            _isDataRegenerateOnlyAtNightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRegenerateOnlyAtNightModified));
        }

        public ManaBatteryObsidianStatue(int newId): base(845311297, newId)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _isDataManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaGainedModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _isDataAutocastRequirementModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutocastRequirementModified));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _isDataWaterHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaterHeightModified));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
            _isDataRegenerateOnlyAtNightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRegenerateOnlyAtNightModified));
        }

        public ManaBatteryObsidianStatue(string newRawcode): base(845311297, newRawcode)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _isDataManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaGainedModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _isDataAutocastRequirementModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutocastRequirementModified));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _isDataWaterHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaterHeightModified));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
            _isDataRegenerateOnlyAtNightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRegenerateOnlyAtNightModified));
        }

        public ManaBatteryObsidianStatue(ObjectDatabase db): base(845311297, db)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _isDataManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaGainedModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _isDataAutocastRequirementModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutocastRequirementModified));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _isDataWaterHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaterHeightModified));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
            _isDataRegenerateOnlyAtNightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRegenerateOnlyAtNightModified));
        }

        public ManaBatteryObsidianStatue(int newId, ObjectDatabase db): base(845311297, newId, db)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _isDataManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaGainedModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _isDataAutocastRequirementModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutocastRequirementModified));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _isDataWaterHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaterHeightModified));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
            _isDataRegenerateOnlyAtNightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRegenerateOnlyAtNightModified));
        }

        public ManaBatteryObsidianStatue(string newRawcode, ObjectDatabase db): base(845311297, newRawcode, db)
        {
            _dataManaGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaGained, SetDataManaGained));
            _isDataManaGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaGainedModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataAutocastRequirement = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAutocastRequirement, SetDataAutocastRequirement));
            _isDataAutocastRequirementModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutocastRequirementModified));
            _dataWaterHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaterHeight, SetDataWaterHeight));
            _isDataWaterHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaterHeightModified));
            _dataRegenerateOnlyAtNight = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRegenerateOnlyAtNight, SetDataRegenerateOnlyAtNight));
            _isDataRegenerateOnlyAtNightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRegenerateOnlyAtNightModified));
        }

        public ObjectProperty<float> DataManaGained => _dataManaGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaGainedModified => _isDataManaGainedModified.Value;
        public ObjectProperty<float> DataHitPointsGained => _dataHitPointsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataHitPointsGainedModified => _isDataHitPointsGainedModified.Value;
        public ObjectProperty<float> DataAutocastRequirement => _dataAutocastRequirement.Value;
        public ReadOnlyObjectProperty<bool> IsDataAutocastRequirementModified => _isDataAutocastRequirementModified.Value;
        public ObjectProperty<float> DataWaterHeight => _dataWaterHeight.Value;
        public ReadOnlyObjectProperty<bool> IsDataWaterHeightModified => _isDataWaterHeightModified.Value;
        public ObjectProperty<bool> DataRegenerateOnlyAtNight => _dataRegenerateOnlyAtNight.Value;
        public ReadOnlyObjectProperty<bool> IsDataRegenerateOnlyAtNightModified => _isDataRegenerateOnlyAtNightModified.Value;
        private float GetDataManaGained(int level)
        {
            return _modifications[829710925, level].ValueAsFloat;
        }

        private void SetDataManaGained(int level, float value)
        {
            _modifications[829710925, level] = new LevelObjectDataModification{Id = 829710925, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataManaGainedModified(int level)
        {
            return _modifications.ContainsKey(829710925, level);
        }

        private float GetDataHitPointsGained(int level)
        {
            return _modifications[846488141, level].ValueAsFloat;
        }

        private void SetDataHitPointsGained(int level, float value)
        {
            _modifications[846488141, level] = new LevelObjectDataModification{Id = 846488141, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataHitPointsGainedModified(int level)
        {
            return _modifications.ContainsKey(846488141, level);
        }

        private float GetDataAutocastRequirement(int level)
        {
            return _modifications[863265357, level].ValueAsFloat;
        }

        private void SetDataAutocastRequirement(int level, float value)
        {
            _modifications[863265357, level] = new LevelObjectDataModification{Id = 863265357, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataAutocastRequirementModified(int level)
        {
            return _modifications.ContainsKey(863265357, level);
        }

        private float GetDataWaterHeight(int level)
        {
            return _modifications[880042573, level].ValueAsFloat;
        }

        private void SetDataWaterHeight(int level, float value)
        {
            _modifications[880042573, level] = new LevelObjectDataModification{Id = 880042573, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataWaterHeightModified(int level)
        {
            return _modifications.ContainsKey(880042573, level);
        }

        private bool GetDataRegenerateOnlyAtNight(int level)
        {
            return _modifications[896819789, level].ValueAsBool;
        }

        private void SetDataRegenerateOnlyAtNight(int level, bool value)
        {
            _modifications[896819789, level] = new LevelObjectDataModification{Id = 896819789, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataRegenerateOnlyAtNightModified(int level)
        {
            return _modifications.ContainsKey(896819789, level);
        }
    }
}