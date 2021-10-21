using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Sanctuary : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataBuildingTypesAllowedRaw;
        private readonly Lazy<ObjectProperty<PickFlags>> _dataBuildingTypesAllowed;
        private readonly Lazy<ObjectProperty<float>> _dataHeroRegenerationDelay;
        private readonly Lazy<ObjectProperty<float>> _dataUnitRegenerationDelay;
        private readonly Lazy<ObjectProperty<float>> _dataMagicDamageReduction;
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsPerSecond;
        public Sanctuary(): base(1634946625)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
        }

        public Sanctuary(int newId): base(1634946625, newId)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
        }

        public Sanctuary(string newRawcode): base(1634946625, newRawcode)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
        }

        public Sanctuary(ObjectDatabase db): base(1634946625, db)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
        }

        public Sanctuary(int newId, ObjectDatabase db): base(1634946625, newId, db)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
        }

        public Sanctuary(string newRawcode, ObjectDatabase db): base(1634946625, newRawcode, db)
        {
            _dataBuildingTypesAllowedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBuildingTypesAllowedRaw, SetDataBuildingTypesAllowedRaw));
            _dataBuildingTypesAllowed = new Lazy<ObjectProperty<PickFlags>>(() => new ObjectProperty<PickFlags>(GetDataBuildingTypesAllowed, SetDataBuildingTypesAllowed));
            _dataHeroRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroRegenerationDelay, SetDataHeroRegenerationDelay));
            _dataUnitRegenerationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitRegenerationDelay, SetDataUnitRegenerationDelay));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataHitPointsPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsPerSecond, SetDataHitPointsPerSecond));
        }

        public ObjectProperty<int> DataBuildingTypesAllowedRaw => _dataBuildingTypesAllowedRaw.Value;
        public ObjectProperty<PickFlags> DataBuildingTypesAllowed => _dataBuildingTypesAllowed.Value;
        public ObjectProperty<float> DataHeroRegenerationDelay => _dataHeroRegenerationDelay.Value;
        public ObjectProperty<float> DataUnitRegenerationDelay => _dataUnitRegenerationDelay.Value;
        public ObjectProperty<float> DataMagicDamageReduction => _dataMagicDamageReduction.Value;
        public ObjectProperty<float> DataHitPointsPerSecond => _dataHitPointsPerSecond.Value;
        private int GetDataBuildingTypesAllowedRaw(int level)
        {
            return _modifications[828470094, level].ValueAsInt;
        }

        private void SetDataBuildingTypesAllowedRaw(int level, int value)
        {
            _modifications[828470094, level] = new LevelObjectDataModification{Id = 828470094, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
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
            return _modifications[845247310, level].ValueAsFloat;
        }

        private void SetDataHeroRegenerationDelay(int level, float value)
        {
            _modifications[845247310, level] = new LevelObjectDataModification{Id = 845247310, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataUnitRegenerationDelay(int level)
        {
            return _modifications[862024526, level].ValueAsFloat;
        }

        private void SetDataUnitRegenerationDelay(int level, float value)
        {
            _modifications[862024526, level] = new LevelObjectDataModification{Id = 862024526, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataMagicDamageReduction(int level)
        {
            return _modifications[878801742, level].ValueAsFloat;
        }

        private void SetDataMagicDamageReduction(int level, float value)
        {
            _modifications[878801742, level] = new LevelObjectDataModification{Id = 878801742, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataHitPointsPerSecond(int level)
        {
            return _modifications[895578958, level].ValueAsFloat;
        }

        private void SetDataHitPointsPerSecond(int level, float value)
        {
            _modifications[895578958, level] = new LevelObjectDataModification{Id = 895578958, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}