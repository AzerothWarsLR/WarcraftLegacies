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
    public sealed class DevourMagic : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifePerUnit;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifePerUnitModified;
        private readonly Lazy<ObjectProperty<float>> _dataManaPerUnit;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaPerUnitModified;
        private readonly Lazy<ObjectProperty<float>> _dataLifePerBuff;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifePerBuffModified;
        private readonly Lazy<ObjectProperty<float>> _dataManaPerBuff;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaPerBuffModified;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedUnitDamageModified;
        private readonly Lazy<ObjectProperty<int>> _dataIgnoreFriendlyBuffsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIgnoreFriendlyBuffsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataIgnoreFriendlyBuffs;
        public DevourMagic(): base(1836475457)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _isDataLifePerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerUnitModified));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _isDataManaPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerUnitModified));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _isDataLifePerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerBuffModified));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _isDataManaPerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerBuffModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagic(int newId): base(1836475457, newId)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _isDataLifePerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerUnitModified));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _isDataManaPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerUnitModified));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _isDataLifePerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerBuffModified));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _isDataManaPerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerBuffModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagic(string newRawcode): base(1836475457, newRawcode)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _isDataLifePerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerUnitModified));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _isDataManaPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerUnitModified));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _isDataLifePerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerBuffModified));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _isDataManaPerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerBuffModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagic(ObjectDatabaseBase db): base(1836475457, db)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _isDataLifePerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerUnitModified));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _isDataManaPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerUnitModified));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _isDataLifePerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerBuffModified));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _isDataManaPerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerBuffModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagic(int newId, ObjectDatabaseBase db): base(1836475457, newId, db)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _isDataLifePerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerUnitModified));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _isDataManaPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerUnitModified));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _isDataLifePerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerBuffModified));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _isDataManaPerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerBuffModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagic(string newRawcode, ObjectDatabaseBase db): base(1836475457, newRawcode, db)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _isDataLifePerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerUnitModified));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _isDataManaPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerUnitModified));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _isDataLifePerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifePerBuffModified));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _isDataManaPerBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPerBuffModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataIgnoreFriendlyBuffsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIgnoreFriendlyBuffsRaw, SetDataIgnoreFriendlyBuffsRaw));
            _isDataIgnoreFriendlyBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoreFriendlyBuffsModified));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public ObjectProperty<float> DataLifePerUnit => _dataLifePerUnit.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifePerUnitModified => _isDataLifePerUnitModified.Value;
        public ObjectProperty<float> DataManaPerUnit => _dataManaPerUnit.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaPerUnitModified => _isDataManaPerUnitModified.Value;
        public ObjectProperty<float> DataLifePerBuff => _dataLifePerBuff.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifePerBuffModified => _isDataLifePerBuffModified.Value;
        public ObjectProperty<float> DataManaPerBuff => _dataManaPerBuff.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaPerBuffModified => _isDataManaPerBuffModified.Value;
        public ObjectProperty<float> DataSummonedUnitDamage => _dataSummonedUnitDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedUnitDamageModified => _isDataSummonedUnitDamageModified.Value;
        public ObjectProperty<int> DataIgnoreFriendlyBuffsRaw => _dataIgnoreFriendlyBuffsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataIgnoreFriendlyBuffsModified => _isDataIgnoreFriendlyBuffsModified.Value;
        public ObjectProperty<bool> DataIgnoreFriendlyBuffs => _dataIgnoreFriendlyBuffs.Value;
        private float GetDataLifePerUnit(int level)
        {
            return _modifications.GetModification(829257316, level).ValueAsFloat;
        }

        private void SetDataLifePerUnit(int level, float value)
        {
            _modifications[829257316, level] = new LevelObjectDataModification{Id = 829257316, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataLifePerUnitModified(int level)
        {
            return _modifications.ContainsKey(829257316, level);
        }

        private float GetDataManaPerUnit(int level)
        {
            return _modifications.GetModification(846034532, level).ValueAsFloat;
        }

        private void SetDataManaPerUnit(int level, float value)
        {
            _modifications[846034532, level] = new LevelObjectDataModification{Id = 846034532, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataManaPerUnitModified(int level)
        {
            return _modifications.ContainsKey(846034532, level);
        }

        private float GetDataLifePerBuff(int level)
        {
            return _modifications.GetModification(862811748, level).ValueAsFloat;
        }

        private void SetDataLifePerBuff(int level, float value)
        {
            _modifications[862811748, level] = new LevelObjectDataModification{Id = 862811748, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataLifePerBuffModified(int level)
        {
            return _modifications.ContainsKey(862811748, level);
        }

        private float GetDataManaPerBuff(int level)
        {
            return _modifications.GetModification(879588964, level).ValueAsFloat;
        }

        private void SetDataManaPerBuff(int level, float value)
        {
            _modifications[879588964, level] = new LevelObjectDataModification{Id = 879588964, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataManaPerBuffModified(int level)
        {
            return _modifications.ContainsKey(879588964, level);
        }

        private float GetDataSummonedUnitDamage(int level)
        {
            return _modifications.GetModification(896366180, level).ValueAsFloat;
        }

        private void SetDataSummonedUnitDamage(int level, float value)
        {
            _modifications[896366180, level] = new LevelObjectDataModification{Id = 896366180, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataSummonedUnitDamageModified(int level)
        {
            return _modifications.ContainsKey(896366180, level);
        }

        private int GetDataIgnoreFriendlyBuffsRaw(int level)
        {
            return _modifications.GetModification(913143396, level).ValueAsInt;
        }

        private void SetDataIgnoreFriendlyBuffsRaw(int level, int value)
        {
            _modifications[913143396, level] = new LevelObjectDataModification{Id = 913143396, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataIgnoreFriendlyBuffsModified(int level)
        {
            return _modifications.ContainsKey(913143396, level);
        }

        private bool GetDataIgnoreFriendlyBuffs(int level)
        {
            return GetDataIgnoreFriendlyBuffsRaw(level).ToBool(this);
        }

        private void SetDataIgnoreFriendlyBuffs(int level, bool value)
        {
            SetDataIgnoreFriendlyBuffsRaw(level, value.ToRaw(0, 99999));
        }
    }
}