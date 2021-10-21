using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TinkererRoboGoblinLevel0 : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataNormalFormUnitRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataNormalFormUnit;
        private readonly Lazy<ObjectProperty<int>> _dataMorphingFlagsRaw;
        private readonly Lazy<ObjectProperty<MorphFlags>> _dataMorphingFlags;
        private readonly Lazy<ObjectProperty<float>> _dataAltitudeAdjustmentDuration;
        private readonly Lazy<ObjectProperty<float>> _dataLandingDelayTime;
        private readonly Lazy<ObjectProperty<int>> _dataStrengthBonus;
        private readonly Lazy<ObjectProperty<int>> _dataDefenseBonus;
        private readonly Lazy<ObjectProperty<string>> _dataAlternateFormUnitRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataAlternateFormUnit;
        public TinkererRoboGoblinLevel0(): base(1735544385)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public TinkererRoboGoblinLevel0(int newId): base(1735544385, newId)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public TinkererRoboGoblinLevel0(string newRawcode): base(1735544385, newRawcode)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public TinkererRoboGoblinLevel0(ObjectDatabase db): base(1735544385, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public TinkererRoboGoblinLevel0(int newId, ObjectDatabase db): base(1735544385, newId, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public TinkererRoboGoblinLevel0(string newRawcode, ObjectDatabase db): base(1735544385, newRawcode, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public ObjectProperty<string> DataNormalFormUnitRaw => _dataNormalFormUnitRaw.Value;
        public ObjectProperty<Unit> DataNormalFormUnit => _dataNormalFormUnit.Value;
        public ObjectProperty<int> DataMorphingFlagsRaw => _dataMorphingFlagsRaw.Value;
        public ObjectProperty<MorphFlags> DataMorphingFlags => _dataMorphingFlags.Value;
        public ObjectProperty<float> DataAltitudeAdjustmentDuration => _dataAltitudeAdjustmentDuration.Value;
        public ObjectProperty<float> DataLandingDelayTime => _dataLandingDelayTime.Value;
        public ObjectProperty<int> DataStrengthBonus => _dataStrengthBonus.Value;
        public ObjectProperty<int> DataDefenseBonus => _dataDefenseBonus.Value;
        public ObjectProperty<string> DataAlternateFormUnitRaw => _dataAlternateFormUnitRaw.Value;
        public ObjectProperty<Unit> DataAlternateFormUnit => _dataAlternateFormUnit.Value;
        private string GetDataNormalFormUnitRaw(int level)
        {
            return _modifications[828730693, level].ValueAsString;
        }

        private void SetDataNormalFormUnitRaw(int level, string value)
        {
            _modifications[828730693, level] = new LevelObjectDataModification{Id = 828730693, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 1};
        }

        private Unit GetDataNormalFormUnit(int level)
        {
            return GetDataNormalFormUnitRaw(level).ToUnit(this);
        }

        private void SetDataNormalFormUnit(int level, Unit value)
        {
            SetDataNormalFormUnitRaw(level, value.ToRaw(null, null));
        }

        private int GetDataMorphingFlagsRaw(int level)
        {
            return _modifications[845507909, level].ValueAsInt;
        }

        private void SetDataMorphingFlagsRaw(int level, int value)
        {
            _modifications[845507909, level] = new LevelObjectDataModification{Id = 845507909, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private MorphFlags GetDataMorphingFlags(int level)
        {
            return GetDataMorphingFlagsRaw(level).ToMorphFlags(this);
        }

        private void SetDataMorphingFlags(int level, MorphFlags value)
        {
            SetDataMorphingFlagsRaw(level, value.ToRaw(0, 99999));
        }

        private float GetDataAltitudeAdjustmentDuration(int level)
        {
            return _modifications[862285125, level].ValueAsFloat;
        }

        private void SetDataAltitudeAdjustmentDuration(int level, float value)
        {
            _modifications[862285125, level] = new LevelObjectDataModification{Id = 862285125, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataLandingDelayTime(int level)
        {
            return _modifications[879062341, level].ValueAsFloat;
        }

        private void SetDataLandingDelayTime(int level, float value)
        {
            _modifications[879062341, level] = new LevelObjectDataModification{Id = 879062341, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private int GetDataStrengthBonus(int level)
        {
            return _modifications[895971918, level].ValueAsInt;
        }

        private void SetDataStrengthBonus(int level, int value)
        {
            _modifications[895971918, level] = new LevelObjectDataModification{Id = 895971918, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private int GetDataDefenseBonus(int level)
        {
            return _modifications[912749134, level].ValueAsInt;
        }

        private void SetDataDefenseBonus(int level, int value)
        {
            _modifications[912749134, level] = new LevelObjectDataModification{Id = 912749134, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private string GetDataAlternateFormUnitRaw(int level)
        {
            return _modifications[1969581381, level].ValueAsString;
        }

        private void SetDataAlternateFormUnitRaw(int level, string value)
        {
            _modifications[1969581381, level] = new LevelObjectDataModification{Id = 1969581381, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private Unit GetDataAlternateFormUnit(int level)
        {
            return GetDataAlternateFormUnitRaw(level).ToUnit(this);
        }

        private void SetDataAlternateFormUnit(int level, Unit value)
        {
            SetDataAlternateFormUnitRaw(level, value.ToRaw(null, null));
        }
    }
}