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
    public sealed class Sanctuary : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataBuildingTypesAllowedRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBuildingTypesAllowedModified;
        private readonly Lazy<ObjectProperty<PickFlags>> _dataBuildingTypesAllowed;
        private readonly Lazy<ObjectProperty<float>> _dataHeroRegenerationDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHeroRegenerationDelayModified;
        private readonly Lazy<ObjectProperty<float>> _dataUnitRegenerationDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitRegenerationDelayModified;
        private readonly Lazy<ObjectProperty<float>> _dataMagicDamageReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMagicDamageReductionModified;
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsPerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointsPerSecondModified;
        public Sanctuary(): base(1634946625)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _isDataHeroRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroRegenerationDelayModified));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _isDataUnitRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitRegenerationDelayModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _isDataHitPointsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsPerSecondModified));
        }

        public Sanctuary(int newId): base(1634946625, newId)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _isDataHeroRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroRegenerationDelayModified));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _isDataUnitRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitRegenerationDelayModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _isDataHitPointsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsPerSecondModified));
        }

        public Sanctuary(string newRawcode): base(1634946625, newRawcode)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _isDataHeroRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroRegenerationDelayModified));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _isDataUnitRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitRegenerationDelayModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _isDataHitPointsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsPerSecondModified));
        }

        public Sanctuary(ObjectDatabaseBase db): base(1634946625, db)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _isDataHeroRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroRegenerationDelayModified));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _isDataUnitRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitRegenerationDelayModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _isDataHitPointsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsPerSecondModified));
        }

        public Sanctuary(int newId, ObjectDatabaseBase db): base(1634946625, newId, db)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _isDataHeroRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroRegenerationDelayModified));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _isDataUnitRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitRegenerationDelayModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _isDataHitPointsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsPerSecondModified));
        }

        public Sanctuary(string newRawcode, ObjectDatabaseBase db): base(1634946625, newRawcode, db)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _isDataBuildingTypesAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingTypesAllowedModified));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _isDataHeroRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroRegenerationDelayModified));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _isDataUnitRegenerationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitRegenerationDelayModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
            _isDataHitPointsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsPerSecondModified));
        }

        public ObjectProperty<int> DataBuildingTypesAllowedRaw => _dataBuildingTypesAllowedRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataBuildingTypesAllowedModified => _isDataBuildingTypesAllowedModified.Value;
        public ObjectProperty<PickFlags> DataBuildingTypesAllowed => _dataBuildingTypesAllowed.Value;
        public ObjectProperty<float> DataHeroRegenerationDelay => _dataHeroRegenerationDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataHeroRegenerationDelayModified => _isDataHeroRegenerationDelayModified.Value;
        public ObjectProperty<float> DataUnitRegenerationDelay => _dataUnitRegenerationDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitRegenerationDelayModified => _isDataUnitRegenerationDelayModified.Value;
        public ObjectProperty<float> DataMagicDamageReduction => _dataMagicDamageReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataMagicDamageReductionModified => _isDataMagicDamageReductionModified.Value;
        public ObjectProperty<float> DataHitPointsPerSecond => _dataHitPointsPerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataHitPointsPerSecondModified => _isDataHitPointsPerSecondModified.Value;
        private int GetDataBuildingTypesAllowedRaw(int level)
        {
            return _modifications.GetModification(828470094, level).ValueAsInt;
        }

        private void SetDataBuildingTypesAllowedRaw(int level, int value)
        {
            _modifications[828470094, level] = new LevelObjectDataModification{Id = 828470094, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataBuildingTypesAllowedModified(int level)
        {
            return _modifications.ContainsKey(828470094, level);
        }

        private PickFlags GetDataBuildingTypesAllowed(int level)
        {
            return GetDataBuildingTypesAllowedRaw(level).ToPickFlags(this);
        }

        private void SetDataBuildingTypesAllowed(int level, PickFlags value)
        {
            SetDataBuildingTypesAllowedRaw(level, value.ToRaw(null, null));
        }

        private float GetDataHeroRegenerationDelay(int level)
        {
            return _modifications.GetModification(845247310, level).ValueAsFloat;
        }

        private void SetDataHeroRegenerationDelay(int level, float value)
        {
            _modifications[845247310, level] = new LevelObjectDataModification{Id = 845247310, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataHeroRegenerationDelayModified(int level)
        {
            return _modifications.ContainsKey(845247310, level);
        }

        private float GetDataUnitRegenerationDelay(int level)
        {
            return _modifications.GetModification(862024526, level).ValueAsFloat;
        }

        private void SetDataUnitRegenerationDelay(int level, float value)
        {
            _modifications[862024526, level] = new LevelObjectDataModification{Id = 862024526, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataUnitRegenerationDelayModified(int level)
        {
            return _modifications.ContainsKey(862024526, level);
        }

        private float GetDataMagicDamageReduction(int level)
        {
            return _modifications.GetModification(878801742, level).ValueAsFloat;
        }

        private void SetDataMagicDamageReduction(int level, float value)
        {
            _modifications[878801742, level] = new LevelObjectDataModification{Id = 878801742, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataMagicDamageReductionModified(int level)
        {
            return _modifications.ContainsKey(878801742, level);
        }

        private float GetDataHitPointsPerSecond(int level)
        {
            return _modifications.GetModification(895578958, level).ValueAsFloat;
        }

        private void SetDataHitPointsPerSecond(int level, float value)
        {
            _modifications[895578958, level] = new LevelObjectDataModification{Id = 895578958, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataHitPointsPerSecondModified(int level)
        {
            return _modifications.ContainsKey(895578958, level);
        }
    }
}