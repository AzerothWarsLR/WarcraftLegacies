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
    public sealed class MountainKingBash : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToBash;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToBashModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageMultiplier;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageMultiplierModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToMiss;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToMissModified;
        private readonly Lazy<ObjectProperty<int>> _dataNeverMissRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNeverMissModified;
        private readonly Lazy<ObjectProperty<bool>> _dataNeverMiss;
        public MountainKingBash(): base(1751271489)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _isDataChanceToBashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToBashModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public MountainKingBash(int newId): base(1751271489, newId)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _isDataChanceToBashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToBashModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public MountainKingBash(string newRawcode): base(1751271489, newRawcode)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _isDataChanceToBashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToBashModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public MountainKingBash(ObjectDatabaseBase db): base(1751271489, db)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _isDataChanceToBashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToBashModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public MountainKingBash(int newId, ObjectDatabaseBase db): base(1751271489, newId, db)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _isDataChanceToBashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToBashModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public MountainKingBash(string newRawcode, ObjectDatabaseBase db): base(1751271489, newRawcode, db)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _isDataChanceToBashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToBashModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public ObjectProperty<float> DataChanceToBash => _dataChanceToBash.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToBashModified => _isDataChanceToBashModified.Value;
        public ObjectProperty<float> DataDamageMultiplier => _dataDamageMultiplier.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageMultiplierModified => _isDataDamageMultiplierModified.Value;
        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<float> DataChanceToMiss => _dataChanceToMiss.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToMissModified => _isDataChanceToMissModified.Value;
        public ObjectProperty<int> DataNeverMissRaw => _dataNeverMissRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataNeverMissModified => _isDataNeverMissModified.Value;
        public ObjectProperty<bool> DataNeverMiss => _dataNeverMiss.Value;
        private float GetDataChanceToBash(int level)
        {
            return _modifications.GetModification(828924488, level).ValueAsFloat;
        }

        private void SetDataChanceToBash(int level, float value)
        {
            _modifications[828924488, level] = new LevelObjectDataModification{Id = 828924488, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataChanceToBashModified(int level)
        {
            return _modifications.ContainsKey(828924488, level);
        }

        private float GetDataDamageMultiplier(int level)
        {
            return _modifications.GetModification(845701704, level).ValueAsFloat;
        }

        private void SetDataDamageMultiplier(int level, float value)
        {
            _modifications[845701704, level] = new LevelObjectDataModification{Id = 845701704, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageMultiplierModified(int level)
        {
            return _modifications.ContainsKey(845701704, level);
        }

        private float GetDataDamageBonus(int level)
        {
            return _modifications.GetModification(862478920, level).ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[862478920, level] = new LevelObjectDataModification{Id = 862478920, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamageBonusModified(int level)
        {
            return _modifications.ContainsKey(862478920, level);
        }

        private float GetDataChanceToMiss(int level)
        {
            return _modifications.GetModification(879256136, level).ValueAsFloat;
        }

        private void SetDataChanceToMiss(int level, float value)
        {
            _modifications[879256136, level] = new LevelObjectDataModification{Id = 879256136, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataChanceToMissModified(int level)
        {
            return _modifications.ContainsKey(879256136, level);
        }

        private int GetDataNeverMissRaw(int level)
        {
            return _modifications.GetModification(896033352, level).ValueAsInt;
        }

        private void SetDataNeverMissRaw(int level, int value)
        {
            _modifications[896033352, level] = new LevelObjectDataModification{Id = 896033352, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataNeverMissModified(int level)
        {
            return _modifications.ContainsKey(896033352, level);
        }

        private bool GetDataNeverMiss(int level)
        {
            return GetDataNeverMissRaw(level).ToBool(this);
        }

        private void SetDataNeverMiss(int level, bool value)
        {
            SetDataNeverMissRaw(level, value.ToRaw(0, 1));
        }
    }
}