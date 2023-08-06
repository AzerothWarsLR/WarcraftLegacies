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
    public sealed class CriticalStrikeCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToCriticalStrike;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToCriticalStrikeModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageMultiplier;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageMultiplierModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageBonusModified;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToEvade;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToEvadeModified;
        private readonly Lazy<ObjectProperty<int>> _dataNeverMissRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNeverMissModified;
        private readonly Lazy<ObjectProperty<bool>> _dataNeverMiss;
        private readonly Lazy<ObjectProperty<int>> _dataExcludeItemDamageRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataExcludeItemDamageModified;
        private readonly Lazy<ObjectProperty<bool>> _dataExcludeItemDamage;
        public CriticalStrikeCreep(): base(1952662337)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _isDataChanceToCriticalStrikeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToCriticalStrikeModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExcludeItemDamageRaw, SetDataExcludeItemDamageRaw));
            _isDataExcludeItemDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExcludeItemDamageModified));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public CriticalStrikeCreep(int newId): base(1952662337, newId)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _isDataChanceToCriticalStrikeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToCriticalStrikeModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExcludeItemDamageRaw, SetDataExcludeItemDamageRaw));
            _isDataExcludeItemDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExcludeItemDamageModified));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public CriticalStrikeCreep(string newRawcode): base(1952662337, newRawcode)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _isDataChanceToCriticalStrikeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToCriticalStrikeModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExcludeItemDamageRaw, SetDataExcludeItemDamageRaw));
            _isDataExcludeItemDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExcludeItemDamageModified));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public CriticalStrikeCreep(ObjectDatabaseBase db): base(1952662337, db)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _isDataChanceToCriticalStrikeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToCriticalStrikeModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExcludeItemDamageRaw, SetDataExcludeItemDamageRaw));
            _isDataExcludeItemDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExcludeItemDamageModified));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public CriticalStrikeCreep(int newId, ObjectDatabaseBase db): base(1952662337, newId, db)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _isDataChanceToCriticalStrikeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToCriticalStrikeModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExcludeItemDamageRaw, SetDataExcludeItemDamageRaw));
            _isDataExcludeItemDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExcludeItemDamageModified));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public CriticalStrikeCreep(string newRawcode, ObjectDatabaseBase db): base(1952662337, newRawcode, db)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _isDataChanceToCriticalStrikeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToCriticalStrikeModified));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _isDataDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierModified));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _isDataDamageBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageBonusModified));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExcludeItemDamageRaw, SetDataExcludeItemDamageRaw));
            _isDataExcludeItemDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExcludeItemDamageModified));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public ObjectProperty<float> DataChanceToCriticalStrike => _dataChanceToCriticalStrike.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToCriticalStrikeModified => _isDataChanceToCriticalStrikeModified.Value;
        public ObjectProperty<float> DataDamageMultiplier => _dataDamageMultiplier.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageMultiplierModified => _isDataDamageMultiplierModified.Value;
        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageBonusModified => _isDataDamageBonusModified.Value;
        public ObjectProperty<float> DataChanceToEvade => _dataChanceToEvade.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToEvadeModified => _isDataChanceToEvadeModified.Value;
        public ObjectProperty<int> DataNeverMissRaw => _dataNeverMissRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataNeverMissModified => _isDataNeverMissModified.Value;
        public ObjectProperty<bool> DataNeverMiss => _dataNeverMiss.Value;
        public ObjectProperty<int> DataExcludeItemDamageRaw => _dataExcludeItemDamageRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataExcludeItemDamageModified => _isDataExcludeItemDamageModified.Value;
        public ObjectProperty<bool> DataExcludeItemDamage => _dataExcludeItemDamage.Value;
        private float GetDataChanceToCriticalStrike(int level)
        {
            return _modifications.GetModification(829580111, level).ValueAsFloat;
        }

        private void SetDataChanceToCriticalStrike(int level, float value)
        {
            _modifications[829580111, level] = new LevelObjectDataModification{Id = 829580111, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataChanceToCriticalStrikeModified(int level)
        {
            return _modifications.ContainsKey(829580111, level);
        }

        private float GetDataDamageMultiplier(int level)
        {
            return _modifications.GetModification(846357327, level).ValueAsFloat;
        }

        private void SetDataDamageMultiplier(int level, float value)
        {
            _modifications[846357327, level] = new LevelObjectDataModification{Id = 846357327, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageMultiplierModified(int level)
        {
            return _modifications.ContainsKey(846357327, level);
        }

        private float GetDataDamageBonus(int level)
        {
            return _modifications.GetModification(863134543, level).ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[863134543, level] = new LevelObjectDataModification{Id = 863134543, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamageBonusModified(int level)
        {
            return _modifications.ContainsKey(863134543, level);
        }

        private float GetDataChanceToEvade(int level)
        {
            return _modifications.GetModification(879911759, level).ValueAsFloat;
        }

        private void SetDataChanceToEvade(int level, float value)
        {
            _modifications[879911759, level] = new LevelObjectDataModification{Id = 879911759, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataChanceToEvadeModified(int level)
        {
            return _modifications.ContainsKey(879911759, level);
        }

        private int GetDataNeverMissRaw(int level)
        {
            return _modifications.GetModification(896688975, level).ValueAsInt;
        }

        private void SetDataNeverMissRaw(int level, int value)
        {
            _modifications[896688975, level] = new LevelObjectDataModification{Id = 896688975, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataNeverMissModified(int level)
        {
            return _modifications.ContainsKey(896688975, level);
        }

        private bool GetDataNeverMiss(int level)
        {
            return GetDataNeverMissRaw(level).ToBool(this);
        }

        private void SetDataNeverMiss(int level, bool value)
        {
            SetDataNeverMissRaw(level, value.ToRaw(0, 1));
        }

        private int GetDataExcludeItemDamageRaw(int level)
        {
            return _modifications.GetModification(913466191, level).ValueAsInt;
        }

        private void SetDataExcludeItemDamageRaw(int level, int value)
        {
            _modifications[913466191, level] = new LevelObjectDataModification{Id = 913466191, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataExcludeItemDamageModified(int level)
        {
            return _modifications.ContainsKey(913466191, level);
        }

        private bool GetDataExcludeItemDamage(int level)
        {
            return GetDataExcludeItemDamageRaw(level).ToBool(this);
        }

        private void SetDataExcludeItemDamage(int level, bool value)
        {
            SetDataExcludeItemDamageRaw(level, value.ToRaw(0, 1));
        }
    }
}