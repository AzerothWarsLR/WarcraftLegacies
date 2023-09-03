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
    public sealed class ManaFlare : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataUnitDamagePerManaPoint;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitDamagePerManaPointModified;
        private readonly Lazy<ObjectProperty<float>> _dataHeroDamagePerManaPoint;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHeroDamagePerManaPointModified;
        private readonly Lazy<ObjectProperty<float>> _dataUnitMaximumDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitMaximumDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataHeroMaximumDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHeroMaximumDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageCooldown;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageCooldownModified;
        private readonly Lazy<ObjectProperty<int>> _dataCasterOnlySplashRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCasterOnlySplashModified;
        private readonly Lazy<ObjectProperty<bool>> _dataCasterOnlySplash;
        public ManaFlare(): base(1818651969)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _isDataUnitDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitDamagePerManaPointModified));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _isDataHeroDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroDamagePerManaPointModified));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _isDataUnitMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitMaximumDamageModified));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _isDataHeroMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroMaximumDamageModified));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _isDataDamageCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageCooldownModified));
            _dataCasterOnlySplashRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCasterOnlySplashRaw, SetDataCasterOnlySplashRaw));
            _isDataCasterOnlySplashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCasterOnlySplashModified));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ManaFlare(int newId): base(1818651969, newId)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _isDataUnitDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitDamagePerManaPointModified));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _isDataHeroDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroDamagePerManaPointModified));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _isDataUnitMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitMaximumDamageModified));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _isDataHeroMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroMaximumDamageModified));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _isDataDamageCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageCooldownModified));
            _dataCasterOnlySplashRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCasterOnlySplashRaw, SetDataCasterOnlySplashRaw));
            _isDataCasterOnlySplashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCasterOnlySplashModified));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ManaFlare(string newRawcode): base(1818651969, newRawcode)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _isDataUnitDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitDamagePerManaPointModified));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _isDataHeroDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroDamagePerManaPointModified));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _isDataUnitMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitMaximumDamageModified));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _isDataHeroMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroMaximumDamageModified));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _isDataDamageCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageCooldownModified));
            _dataCasterOnlySplashRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCasterOnlySplashRaw, SetDataCasterOnlySplashRaw));
            _isDataCasterOnlySplashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCasterOnlySplashModified));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ManaFlare(ObjectDatabaseBase db): base(1818651969, db)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _isDataUnitDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitDamagePerManaPointModified));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _isDataHeroDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroDamagePerManaPointModified));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _isDataUnitMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitMaximumDamageModified));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _isDataHeroMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroMaximumDamageModified));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _isDataDamageCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageCooldownModified));
            _dataCasterOnlySplashRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCasterOnlySplashRaw, SetDataCasterOnlySplashRaw));
            _isDataCasterOnlySplashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCasterOnlySplashModified));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ManaFlare(int newId, ObjectDatabaseBase db): base(1818651969, newId, db)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _isDataUnitDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitDamagePerManaPointModified));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _isDataHeroDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroDamagePerManaPointModified));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _isDataUnitMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitMaximumDamageModified));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _isDataHeroMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroMaximumDamageModified));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _isDataDamageCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageCooldownModified));
            _dataCasterOnlySplashRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCasterOnlySplashRaw, SetDataCasterOnlySplashRaw));
            _isDataCasterOnlySplashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCasterOnlySplashModified));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ManaFlare(string newRawcode, ObjectDatabaseBase db): base(1818651969, newRawcode, db)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _isDataUnitDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitDamagePerManaPointModified));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _isDataHeroDamagePerManaPointModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroDamagePerManaPointModified));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _isDataUnitMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitMaximumDamageModified));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _isDataHeroMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroMaximumDamageModified));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _isDataDamageCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageCooldownModified));
            _dataCasterOnlySplashRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCasterOnlySplashRaw, SetDataCasterOnlySplashRaw));
            _isDataCasterOnlySplashModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCasterOnlySplashModified));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ObjectProperty<float> DataUnitDamagePerManaPoint => _dataUnitDamagePerManaPoint.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitDamagePerManaPointModified => _isDataUnitDamagePerManaPointModified.Value;
        public ObjectProperty<float> DataHeroDamagePerManaPoint => _dataHeroDamagePerManaPoint.Value;
        public ReadOnlyObjectProperty<bool> IsDataHeroDamagePerManaPointModified => _isDataHeroDamagePerManaPointModified.Value;
        public ObjectProperty<float> DataUnitMaximumDamage => _dataUnitMaximumDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitMaximumDamageModified => _isDataUnitMaximumDamageModified.Value;
        public ObjectProperty<float> DataHeroMaximumDamage => _dataHeroMaximumDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataHeroMaximumDamageModified => _isDataHeroMaximumDamageModified.Value;
        public ObjectProperty<float> DataDamageCooldown => _dataDamageCooldown.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageCooldownModified => _isDataDamageCooldownModified.Value;
        public ObjectProperty<int> DataCasterOnlySplashRaw => _dataCasterOnlySplashRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataCasterOnlySplashModified => _isDataCasterOnlySplashModified.Value;
        public ObjectProperty<bool> DataCasterOnlySplash => _dataCasterOnlySplash.Value;
        private float GetDataUnitDamagePerManaPoint(int level)
        {
            return _modifications.GetModification(829187693, level).ValueAsFloat;
        }

        private void SetDataUnitDamagePerManaPoint(int level, float value)
        {
            _modifications[829187693, level] = new LevelObjectDataModification{Id = 829187693, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataUnitDamagePerManaPointModified(int level)
        {
            return _modifications.ContainsKey(829187693, level);
        }

        private float GetDataHeroDamagePerManaPoint(int level)
        {
            return _modifications.GetModification(845964909, level).ValueAsFloat;
        }

        private void SetDataHeroDamagePerManaPoint(int level, float value)
        {
            _modifications[845964909, level] = new LevelObjectDataModification{Id = 845964909, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataHeroDamagePerManaPointModified(int level)
        {
            return _modifications.ContainsKey(845964909, level);
        }

        private float GetDataUnitMaximumDamage(int level)
        {
            return _modifications.GetModification(862742125, level).ValueAsFloat;
        }

        private void SetDataUnitMaximumDamage(int level, float value)
        {
            _modifications[862742125, level] = new LevelObjectDataModification{Id = 862742125, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataUnitMaximumDamageModified(int level)
        {
            return _modifications.ContainsKey(862742125, level);
        }

        private float GetDataHeroMaximumDamage(int level)
        {
            return _modifications.GetModification(879519341, level).ValueAsFloat;
        }

        private void SetDataHeroMaximumDamage(int level, float value)
        {
            _modifications[879519341, level] = new LevelObjectDataModification{Id = 879519341, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataHeroMaximumDamageModified(int level)
        {
            return _modifications.ContainsKey(879519341, level);
        }

        private float GetDataDamageCooldown(int level)
        {
            return _modifications.GetModification(896296557, level).ValueAsFloat;
        }

        private void SetDataDamageCooldown(int level, float value)
        {
            _modifications[896296557, level] = new LevelObjectDataModification{Id = 896296557, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataDamageCooldownModified(int level)
        {
            return _modifications.ContainsKey(896296557, level);
        }

        private int GetDataCasterOnlySplashRaw(int level)
        {
            return _modifications.GetModification(913073773, level).ValueAsInt;
        }

        private void SetDataCasterOnlySplashRaw(int level, int value)
        {
            _modifications[913073773, level] = new LevelObjectDataModification{Id = 913073773, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataCasterOnlySplashModified(int level)
        {
            return _modifications.ContainsKey(913073773, level);
        }

        private bool GetDataCasterOnlySplash(int level)
        {
            return GetDataCasterOnlySplashRaw(level).ToBool(this);
        }

        private void SetDataCasterOnlySplash(int level, bool value)
        {
            SetDataCasterOnlySplashRaw(level, value.ToRaw(0, 1));
        }
    }
}