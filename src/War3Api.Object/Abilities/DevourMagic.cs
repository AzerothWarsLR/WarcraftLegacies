using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DevourMagic : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifePerUnit;
        private readonly Lazy<ObjectProperty<float>> _dataManaPerUnit;
        private readonly Lazy<ObjectProperty<float>> _dataLifePerBuff;
        private readonly Lazy<ObjectProperty<float>> _dataManaPerBuff;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDamage;
        private readonly Lazy<ObjectProperty<bool>> _dataIgnoreFriendlyBuffs;
        public DevourMagic(): base(1836475457)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagic(int newId): base(1836475457, newId)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagic(string newRawcode): base(1836475457, newRawcode)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagic(ObjectDatabase db): base(1836475457, db)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagic(int newId, ObjectDatabase db): base(1836475457, newId, db)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagic(string newRawcode, ObjectDatabase db): base(1836475457, newRawcode, db)
        {
            _dataLifePerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerUnit, SetDataLifePerUnit));
            _dataManaPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerUnit, SetDataManaPerUnit));
            _dataLifePerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifePerBuff, SetDataLifePerBuff));
            _dataManaPerBuff = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPerBuff, SetDataManaPerBuff));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public ObjectProperty<float> DataLifePerUnit => _dataLifePerUnit.Value;
        public ObjectProperty<float> DataManaPerUnit => _dataManaPerUnit.Value;
        public ObjectProperty<float> DataLifePerBuff => _dataLifePerBuff.Value;
        public ObjectProperty<float> DataManaPerBuff => _dataManaPerBuff.Value;
        public ObjectProperty<float> DataSummonedUnitDamage => _dataSummonedUnitDamage.Value;
        public ObjectProperty<bool> DataIgnoreFriendlyBuffs => _dataIgnoreFriendlyBuffs.Value;
        private float GetDataLifePerUnit(int level)
        {
            return _modifications[829257316, level].ValueAsFloat;
        }

        private void SetDataLifePerUnit(int level, float value)
        {
            _modifications[829257316, level] = new LevelObjectDataModification{Id = 829257316, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataManaPerUnit(int level)
        {
            return _modifications[846034532, level].ValueAsFloat;
        }

        private void SetDataManaPerUnit(int level, float value)
        {
            _modifications[846034532, level] = new LevelObjectDataModification{Id = 846034532, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataLifePerBuff(int level)
        {
            return _modifications[862811748, level].ValueAsFloat;
        }

        private void SetDataLifePerBuff(int level, float value)
        {
            _modifications[862811748, level] = new LevelObjectDataModification{Id = 862811748, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataManaPerBuff(int level)
        {
            return _modifications[879588964, level].ValueAsFloat;
        }

        private void SetDataManaPerBuff(int level, float value)
        {
            _modifications[879588964, level] = new LevelObjectDataModification{Id = 879588964, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataSummonedUnitDamage(int level)
        {
            return _modifications[896366180, level].ValueAsFloat;
        }

        private void SetDataSummonedUnitDamage(int level, float value)
        {
            _modifications[896366180, level] = new LevelObjectDataModification{Id = 896366180, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetDataIgnoreFriendlyBuffs(int level)
        {
            return _modifications[913143396, level].ValueAsBool;
        }

        private void SetDataIgnoreFriendlyBuffs(int level, bool value)
        {
            _modifications[913143396, level] = new LevelObjectDataModification{Id = 913143396, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 6};
        }
    }
}