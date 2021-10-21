using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AntiMagicShield_AIxs : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataShieldLife;
        private readonly Lazy<ObjectProperty<int>> _dataManaLoss;
        private readonly Lazy<ObjectProperty<float>> _dataDamageToSummonedUnits;
        private readonly Lazy<ObjectProperty<float>> _dataMagicDamageReduction;
        public AntiMagicShield_AIxs(): base(1937262913)
        {
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public AntiMagicShield_AIxs(int newId): base(1937262913, newId)
        {
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public AntiMagicShield_AIxs(string newRawcode): base(1937262913, newRawcode)
        {
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public AntiMagicShield_AIxs(ObjectDatabase db): base(1937262913, db)
        {
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public AntiMagicShield_AIxs(int newId, ObjectDatabase db): base(1937262913, newId, db)
        {
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public AntiMagicShield_AIxs(string newRawcode, ObjectDatabase db): base(1937262913, newRawcode, db)
        {
            _dataShieldLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShieldLife, SetDataShieldLife));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
        }

        public ObjectProperty<int> DataShieldLife => _dataShieldLife.Value;
        public ObjectProperty<int> DataManaLoss => _dataManaLoss.Value;
        public ObjectProperty<float> DataDamageToSummonedUnits => _dataDamageToSummonedUnits.Value;
        public ObjectProperty<float> DataMagicDamageReduction => _dataMagicDamageReduction.Value;
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

        private float GetDataDamageToSummonedUnits(int level)
        {
            return _modifications[829651017, level].ValueAsFloat;
        }

        private void SetDataDamageToSummonedUnits(int level, float value)
        {
            _modifications[829651017, level] = new LevelObjectDataModification{Id = 829651017, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMagicDamageReduction(int level)
        {
            return _modifications[846428233, level].ValueAsFloat;
        }

        private void SetDataMagicDamageReduction(int level, float value)
        {
            _modifications[846428233, level] = new LevelObjectDataModification{Id = 846428233, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}