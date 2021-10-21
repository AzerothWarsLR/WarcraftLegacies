using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ManaFlare : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataUnitDamagePerManaPoint;
        private readonly Lazy<ObjectProperty<float>> _dataHeroDamagePerManaPoint;
        private readonly Lazy<ObjectProperty<float>> _dataUnitMaximumDamage;
        private readonly Lazy<ObjectProperty<float>> _dataHeroMaximumDamage;
        private readonly Lazy<ObjectProperty<float>> _dataDamageCooldown;
        private readonly Lazy<ObjectProperty<bool>> _dataCasterOnlySplash;
        public ManaFlare(): base(1818651969)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ManaFlare(int newId): base(1818651969, newId)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ManaFlare(string newRawcode): base(1818651969, newRawcode)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ManaFlare(ObjectDatabase db): base(1818651969, db)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ManaFlare(int newId, ObjectDatabase db): base(1818651969, newId, db)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ManaFlare(string newRawcode, ObjectDatabase db): base(1818651969, newRawcode, db)
        {
            _dataUnitDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitDamagePerManaPoint, SetDataUnitDamagePerManaPoint));
            _dataHeroDamagePerManaPoint = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroDamagePerManaPoint, SetDataHeroDamagePerManaPoint));
            _dataUnitMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitMaximumDamage, SetDataUnitMaximumDamage));
            _dataHeroMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroMaximumDamage, SetDataHeroMaximumDamage));
            _dataDamageCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageCooldown, SetDataDamageCooldown));
            _dataCasterOnlySplash = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataCasterOnlySplash, SetDataCasterOnlySplash));
        }

        public ObjectProperty<float> DataUnitDamagePerManaPoint => _dataUnitDamagePerManaPoint.Value;
        public ObjectProperty<float> DataHeroDamagePerManaPoint => _dataHeroDamagePerManaPoint.Value;
        public ObjectProperty<float> DataUnitMaximumDamage => _dataUnitMaximumDamage.Value;
        public ObjectProperty<float> DataHeroMaximumDamage => _dataHeroMaximumDamage.Value;
        public ObjectProperty<float> DataDamageCooldown => _dataDamageCooldown.Value;
        public ObjectProperty<bool> DataCasterOnlySplash => _dataCasterOnlySplash.Value;
        private float GetDataUnitDamagePerManaPoint(int level)
        {
            return _modifications[829187693, level].ValueAsFloat;
        }

        private void SetDataUnitDamagePerManaPoint(int level, float value)
        {
            _modifications[829187693, level] = new LevelObjectDataModification{Id = 829187693, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataHeroDamagePerManaPoint(int level)
        {
            return _modifications[845964909, level].ValueAsFloat;
        }

        private void SetDataHeroDamagePerManaPoint(int level, float value)
        {
            _modifications[845964909, level] = new LevelObjectDataModification{Id = 845964909, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataUnitMaximumDamage(int level)
        {
            return _modifications[862742125, level].ValueAsFloat;
        }

        private void SetDataUnitMaximumDamage(int level, float value)
        {
            _modifications[862742125, level] = new LevelObjectDataModification{Id = 862742125, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataHeroMaximumDamage(int level)
        {
            return _modifications[879519341, level].ValueAsFloat;
        }

        private void SetDataHeroMaximumDamage(int level, float value)
        {
            _modifications[879519341, level] = new LevelObjectDataModification{Id = 879519341, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataDamageCooldown(int level)
        {
            return _modifications[896296557, level].ValueAsFloat;
        }

        private void SetDataDamageCooldown(int level, float value)
        {
            _modifications[896296557, level] = new LevelObjectDataModification{Id = 896296557, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetDataCasterOnlySplash(int level)
        {
            return _modifications[913073773, level].ValueAsBool;
        }

        private void SetDataCasterOnlySplash(int level, bool value)
        {
            _modifications[913073773, level] = new LevelObjectDataModification{Id = 913073773, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 6};
        }
    }
}