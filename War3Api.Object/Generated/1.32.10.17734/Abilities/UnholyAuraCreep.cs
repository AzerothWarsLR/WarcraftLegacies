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
    public sealed class UnholyAuraCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataData_Uau1;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Uau1Modified;
        private readonly Lazy<ObjectProperty<float>> _dataData_Uau2;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Uau2Modified;
        private readonly Lazy<ObjectProperty<int>> _dataPercentBonusRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPercentBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentBonus;
        public UnholyAuraCreep(): base(1635074881)
        {
            _dataData_Uau1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau1, SetDataData_Uau1));
            _isDataData_Uau1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau1Modified));
            _dataData_Uau2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau2, SetDataData_Uau2));
            _isDataData_Uau2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau2Modified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public UnholyAuraCreep(int newId): base(1635074881, newId)
        {
            _dataData_Uau1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau1, SetDataData_Uau1));
            _isDataData_Uau1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau1Modified));
            _dataData_Uau2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau2, SetDataData_Uau2));
            _isDataData_Uau2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau2Modified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public UnholyAuraCreep(string newRawcode): base(1635074881, newRawcode)
        {
            _dataData_Uau1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau1, SetDataData_Uau1));
            _isDataData_Uau1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau1Modified));
            _dataData_Uau2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau2, SetDataData_Uau2));
            _isDataData_Uau2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau2Modified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public UnholyAuraCreep(ObjectDatabaseBase db): base(1635074881, db)
        {
            _dataData_Uau1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau1, SetDataData_Uau1));
            _isDataData_Uau1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau1Modified));
            _dataData_Uau2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau2, SetDataData_Uau2));
            _isDataData_Uau2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau2Modified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public UnholyAuraCreep(int newId, ObjectDatabaseBase db): base(1635074881, newId, db)
        {
            _dataData_Uau1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau1, SetDataData_Uau1));
            _isDataData_Uau1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau1Modified));
            _dataData_Uau2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau2, SetDataData_Uau2));
            _isDataData_Uau2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau2Modified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public UnholyAuraCreep(string newRawcode, ObjectDatabaseBase db): base(1635074881, newRawcode, db)
        {
            _dataData_Uau1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau1, SetDataData_Uau1));
            _isDataData_Uau1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau1Modified));
            _dataData_Uau2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Uau2, SetDataData_Uau2));
            _isDataData_Uau2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Uau2Modified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public ObjectProperty<float> DataData_Uau1 => _dataData_Uau1.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Uau1Modified => _isDataData_Uau1Modified.Value;
        public ObjectProperty<float> DataData_Uau2 => _dataData_Uau2.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Uau2Modified => _isDataData_Uau2Modified.Value;
        public ObjectProperty<int> DataPercentBonusRaw => _dataPercentBonusRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataPercentBonusModified => _isDataPercentBonusModified.Value;
        public ObjectProperty<bool> DataPercentBonus => _dataPercentBonus.Value;
        private float GetDataData_Uau1(int level)
        {
            return _modifications.GetModification(829776213, level).ValueAsFloat;
        }

        private void SetDataData_Uau1(int level, float value)
        {
            _modifications[829776213, level] = new LevelObjectDataModification{Id = 829776213, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataData_Uau1Modified(int level)
        {
            return _modifications.ContainsKey(829776213, level);
        }

        private float GetDataData_Uau2(int level)
        {
            return _modifications.GetModification(846553429, level).ValueAsFloat;
        }

        private void SetDataData_Uau2(int level, float value)
        {
            _modifications[846553429, level] = new LevelObjectDataModification{Id = 846553429, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataData_Uau2Modified(int level)
        {
            return _modifications.ContainsKey(846553429, level);
        }

        private int GetDataPercentBonusRaw(int level)
        {
            return _modifications.GetModification(863330645, level).ValueAsInt;
        }

        private void SetDataPercentBonusRaw(int level, int value)
        {
            _modifications[863330645, level] = new LevelObjectDataModification{Id = 863330645, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataPercentBonusModified(int level)
        {
            return _modifications.ContainsKey(863330645, level);
        }

        private bool GetDataPercentBonus(int level)
        {
            return GetDataPercentBonusRaw(level).ToBool(this);
        }

        private void SetDataPercentBonus(int level, bool value)
        {
            SetDataPercentBonusRaw(level, value.ToRaw(0, 1));
        }
    }
}