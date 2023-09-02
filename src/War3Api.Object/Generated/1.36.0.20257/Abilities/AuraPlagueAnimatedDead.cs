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
    public sealed class AuraPlagueAnimatedDead : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAuraDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAuraDurationModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerSecondModified;
        private readonly Lazy<ObjectProperty<float>> _dataDurationOfPlagueWard;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDurationOfPlagueWardModified;
        private readonly Lazy<ObjectProperty<string>> _dataPlagueWardUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPlagueWardUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataPlagueWardUnitType;
        public AuraPlagueAnimatedDead(): base(896557377)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _isDataAuraDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAuraDurationModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _isDataDurationOfPlagueWardModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfPlagueWardModified));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _isDataPlagueWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlagueWardUnitTypeModified));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public AuraPlagueAnimatedDead(int newId): base(896557377, newId)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _isDataAuraDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAuraDurationModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _isDataDurationOfPlagueWardModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfPlagueWardModified));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _isDataPlagueWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlagueWardUnitTypeModified));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public AuraPlagueAnimatedDead(string newRawcode): base(896557377, newRawcode)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _isDataAuraDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAuraDurationModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _isDataDurationOfPlagueWardModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfPlagueWardModified));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _isDataPlagueWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlagueWardUnitTypeModified));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public AuraPlagueAnimatedDead(ObjectDatabaseBase db): base(896557377, db)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _isDataAuraDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAuraDurationModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _isDataDurationOfPlagueWardModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfPlagueWardModified));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _isDataPlagueWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlagueWardUnitTypeModified));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public AuraPlagueAnimatedDead(int newId, ObjectDatabaseBase db): base(896557377, newId, db)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _isDataAuraDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAuraDurationModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _isDataDurationOfPlagueWardModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfPlagueWardModified));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _isDataPlagueWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlagueWardUnitTypeModified));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public AuraPlagueAnimatedDead(string newRawcode, ObjectDatabaseBase db): base(896557377, newRawcode, db)
        {
            _dataAuraDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAuraDuration, SetDataAuraDuration));
            _isDataAuraDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAuraDurationModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataDurationOfPlagueWard = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDurationOfPlagueWard, SetDataDurationOfPlagueWard));
            _isDataDurationOfPlagueWardModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDurationOfPlagueWardModified));
            _dataPlagueWardUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPlagueWardUnitTypeRaw, SetDataPlagueWardUnitTypeRaw));
            _isDataPlagueWardUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPlagueWardUnitTypeModified));
            _dataPlagueWardUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPlagueWardUnitType, SetDataPlagueWardUnitType));
        }

        public ObjectProperty<float> DataAuraDuration => _dataAuraDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataAuraDurationModified => _isDataAuraDurationModified.Value;
        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerSecondModified => _isDataDamagePerSecondModified.Value;
        public ObjectProperty<float> DataDurationOfPlagueWard => _dataDurationOfPlagueWard.Value;
        public ReadOnlyObjectProperty<bool> IsDataDurationOfPlagueWardModified => _isDataDurationOfPlagueWardModified.Value;
        public ObjectProperty<string> DataPlagueWardUnitTypeRaw => _dataPlagueWardUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataPlagueWardUnitTypeModified => _isDataPlagueWardUnitTypeModified.Value;
        public ObjectProperty<Unit> DataPlagueWardUnitType => _dataPlagueWardUnitType.Value;
        private float GetDataAuraDuration(int level)
        {
            return _modifications.GetModification(829190209, level).ValueAsFloat;
        }

        private void SetDataAuraDuration(int level, float value)
        {
            _modifications[829190209, level] = new LevelObjectDataModification{Id = 829190209, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAuraDurationModified(int level)
        {
            return _modifications.ContainsKey(829190209, level);
        }

        private float GetDataDamagePerSecond(int level)
        {
            return _modifications.GetModification(845967425, level).ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[845967425, level] = new LevelObjectDataModification{Id = 845967425, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamagePerSecondModified(int level)
        {
            return _modifications.ContainsKey(845967425, level);
        }

        private float GetDataDurationOfPlagueWard(int level)
        {
            return _modifications.GetModification(862744641, level).ValueAsFloat;
        }

        private void SetDataDurationOfPlagueWard(int level, float value)
        {
            _modifications[862744641, level] = new LevelObjectDataModification{Id = 862744641, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDurationOfPlagueWardModified(int level)
        {
            return _modifications.ContainsKey(862744641, level);
        }

        private string GetDataPlagueWardUnitTypeRaw(int level)
        {
            return _modifications.GetModification(1970040897, level).ValueAsString;
        }

        private void SetDataPlagueWardUnitTypeRaw(int level, string value)
        {
            _modifications[1970040897, level] = new LevelObjectDataModification{Id = 1970040897, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataPlagueWardUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(1970040897, level);
        }

        private Unit GetDataPlagueWardUnitType(int level)
        {
            return GetDataPlagueWardUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataPlagueWardUnitType(int level, Unit value)
        {
            SetDataPlagueWardUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}