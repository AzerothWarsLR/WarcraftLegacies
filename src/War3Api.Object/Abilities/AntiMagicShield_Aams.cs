using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AntiMagicShield_Aams : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDamage;
        private readonly Lazy<ObjectProperty<float>> _dataMagicDamageReduction;
        private readonly Lazy<ObjectProperty<int>> _dataShieldLife;
        private readonly Lazy<ObjectProperty<int>> _dataManaLoss;
        public AntiMagicShield_Aams(): base(1936548161)
        {
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public AntiMagicShield_Aams(int newId): base(1936548161, newId)
        {
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public AntiMagicShield_Aams(string newRawcode): base(1936548161, newRawcode)
        {
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public AntiMagicShield_Aams(ObjectDatabase db): base(1936548161, db)
        {
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public AntiMagicShield_Aams(int newId, ObjectDatabase db): base(1936548161, newId, db)
        {
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public AntiMagicShield_Aams(string newRawcode, ObjectDatabase db): base(1936548161, newRawcode, db)
        {
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public ObjectProperty<float> DataSummonedUnitDamage => _dataSummonedUnitDamage.Value;
        public ObjectProperty<float> DataMagicDamageReduction => _dataMagicDamageReduction.Value;
        public ObjectProperty<int> DataShieldLife => _dataShieldLife.Value;
        public ObjectProperty<int> DataManaLoss => _dataManaLoss.Value;
        private float GetDataSummonedUnitDamage(int level)
        {
            return _modifications[829648193, level].ValueAsFloat;
        }

        private void SetDataSummonedUnitDamage(int level, float value)
        {
            _modifications[829648193, level] = new LevelObjectDataModification{Id = 829648193, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMagicDamageReduction(int level)
        {
            return _modifications[846425409, level].ValueAsFloat;
        }

        private void SetDataMagicDamageReduction(int level, float value)
        {
            _modifications[846425409, level] = new LevelObjectDataModification{Id = 846425409, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataShieldLife(int level)
        {
            return _modifications[863202625, level].ValueAsInt;
        }

        private void SetDataShieldLife(int level, int value)
        {
            _modifications[863202625, level] = new LevelObjectDataModification{Id = 863202625, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private int GetDataManaLoss(int level)
        {
            return _modifications[879979841, level].ValueAsInt;
        }

        private void SetDataManaLoss(int level, int value)
        {
            _modifications[879979841, level] = new LevelObjectDataModification{Id = 879979841, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }
    }
}