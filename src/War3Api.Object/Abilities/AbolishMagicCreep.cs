using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AbolishMagicCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaLoss;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDamage;
        public AbolishMagicCreep(): base(1835287361)
        {
            _dataManaLoss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLoss, SetDataManaLoss));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public AbolishMagicCreep(int newId): base(1835287361, newId)
        {
            _dataManaLoss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLoss, SetDataManaLoss));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public AbolishMagicCreep(string newRawcode): base(1835287361, newRawcode)
        {
            _dataManaLoss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLoss, SetDataManaLoss));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public AbolishMagicCreep(ObjectDatabase db): base(1835287361, db)
        {
            _dataManaLoss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLoss, SetDataManaLoss));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public AbolishMagicCreep(int newId, ObjectDatabase db): base(1835287361, newId, db)
        {
            _dataManaLoss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLoss, SetDataManaLoss));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public AbolishMagicCreep(string newRawcode, ObjectDatabase db): base(1835287361, newRawcode, db)
        {
            _dataManaLoss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLoss, SetDataManaLoss));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public ObjectProperty<float> DataManaLoss => _dataManaLoss.Value;
        public ObjectProperty<float> DataSummonedUnitDamage => _dataSummonedUnitDamage.Value;
        private float GetDataManaLoss(int level)
        {
            return _modifications[829252673, level].ValueAsFloat;
        }

        private void SetDataManaLoss(int level, float value)
        {
            _modifications[829252673, level] = new LevelObjectDataModification{Id = 829252673, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataSummonedUnitDamage(int level)
        {
            return _modifications[846029889, level].ValueAsFloat;
        }

        private void SetDataSummonedUnitDamage(int level, float value)
        {
            _modifications[846029889, level] = new LevelObjectDataModification{Id = 846029889, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}