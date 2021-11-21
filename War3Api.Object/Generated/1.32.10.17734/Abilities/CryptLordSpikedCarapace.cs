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
    public sealed class CryptLordSpikedCarapace : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataReturnedDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataReturnedDamageFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataReceivedDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataReceivedDamageFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataDefenseBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDefenseBonusModified;
        public CryptLordSpikedCarapace(): base(1937003841)
        {
            _dataReturnedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReturnedDamageFactor, SetDataReturnedDamageFactor));
            _isDataReturnedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReturnedDamageFactorModified));
            _dataReceivedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReceivedDamageFactor, SetDataReceivedDamageFactor));
            _isDataReceivedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReceivedDamageFactorModified));
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public CryptLordSpikedCarapace(int newId): base(1937003841, newId)
        {
            _dataReturnedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReturnedDamageFactor, SetDataReturnedDamageFactor));
            _isDataReturnedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReturnedDamageFactorModified));
            _dataReceivedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReceivedDamageFactor, SetDataReceivedDamageFactor));
            _isDataReceivedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReceivedDamageFactorModified));
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public CryptLordSpikedCarapace(string newRawcode): base(1937003841, newRawcode)
        {
            _dataReturnedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReturnedDamageFactor, SetDataReturnedDamageFactor));
            _isDataReturnedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReturnedDamageFactorModified));
            _dataReceivedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReceivedDamageFactor, SetDataReceivedDamageFactor));
            _isDataReceivedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReceivedDamageFactorModified));
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public CryptLordSpikedCarapace(ObjectDatabaseBase db): base(1937003841, db)
        {
            _dataReturnedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReturnedDamageFactor, SetDataReturnedDamageFactor));
            _isDataReturnedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReturnedDamageFactorModified));
            _dataReceivedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReceivedDamageFactor, SetDataReceivedDamageFactor));
            _isDataReceivedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReceivedDamageFactorModified));
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public CryptLordSpikedCarapace(int newId, ObjectDatabaseBase db): base(1937003841, newId, db)
        {
            _dataReturnedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReturnedDamageFactor, SetDataReturnedDamageFactor));
            _isDataReturnedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReturnedDamageFactorModified));
            _dataReceivedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReceivedDamageFactor, SetDataReceivedDamageFactor));
            _isDataReceivedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReceivedDamageFactorModified));
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public CryptLordSpikedCarapace(string newRawcode, ObjectDatabaseBase db): base(1937003841, newRawcode, db)
        {
            _dataReturnedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReturnedDamageFactor, SetDataReturnedDamageFactor));
            _isDataReturnedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReturnedDamageFactorModified));
            _dataReceivedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReceivedDamageFactor, SetDataReceivedDamageFactor));
            _isDataReceivedDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataReceivedDamageFactorModified));
            _dataDefenseBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public ObjectProperty<float> DataReturnedDamageFactor => _dataReturnedDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataReturnedDamageFactorModified => _isDataReturnedDamageFactorModified.Value;
        public ObjectProperty<float> DataReceivedDamageFactor => _dataReceivedDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataReceivedDamageFactorModified => _isDataReceivedDamageFactorModified.Value;
        public ObjectProperty<float> DataDefenseBonus => _dataDefenseBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDefenseBonusModified => _isDataDefenseBonusModified.Value;
        private float GetDataReturnedDamageFactor(int level)
        {
            return _modifications.GetModification(829650005, level).ValueAsFloat;
        }

        private void SetDataReturnedDamageFactor(int level, float value)
        {
            _modifications[829650005, level] = new LevelObjectDataModification{Id = 829650005, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataReturnedDamageFactorModified(int level)
        {
            return _modifications.ContainsKey(829650005, level);
        }

        private float GetDataReceivedDamageFactor(int level)
        {
            return _modifications.GetModification(846427221, level).ValueAsFloat;
        }

        private void SetDataReceivedDamageFactor(int level, float value)
        {
            _modifications[846427221, level] = new LevelObjectDataModification{Id = 846427221, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataReceivedDamageFactorModified(int level)
        {
            return _modifications.ContainsKey(846427221, level);
        }

        private float GetDataDefenseBonus(int level)
        {
            return _modifications.GetModification(863204437, level).ValueAsFloat;
        }

        private void SetDataDefenseBonus(int level, float value)
        {
            _modifications[863204437, level] = new LevelObjectDataModification{Id = 863204437, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDefenseBonusModified(int level)
        {
            return _modifications.ContainsKey(863204437, level);
        }
    }
}