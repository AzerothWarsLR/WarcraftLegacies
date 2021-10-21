using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Detonate : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaLossPerUnit;
        private readonly Lazy<ObjectProperty<float>> _dataDamageToSummonedUnits;
        public Detonate(): base(1853121601)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
        }

        public Detonate(int newId): base(1853121601, newId)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
        }

        public Detonate(string newRawcode): base(1853121601, newRawcode)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
        }

        public Detonate(ObjectDatabase db): base(1853121601, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
        }

        public Detonate(int newId, ObjectDatabase db): base(1853121601, newId, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
        }

        public Detonate(string newRawcode, ObjectDatabase db): base(1853121601, newRawcode, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
        }

        public ObjectProperty<float> DataManaLossPerUnit => _dataManaLossPerUnit.Value;
        public ObjectProperty<float> DataDamageToSummonedUnits => _dataDamageToSummonedUnits.Value;
        private float GetDataManaLossPerUnit(int level)
        {
            return _modifications[829322308, level].ValueAsFloat;
        }

        private void SetDataManaLossPerUnit(int level, float value)
        {
            _modifications[829322308, level] = new LevelObjectDataModification{Id = 829322308, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageToSummonedUnits(int level)
        {
            return _modifications[846099524, level].ValueAsFloat;
        }

        private void SetDataDamageToSummonedUnits(int level, float value)
        {
            _modifications[846099524, level] = new LevelObjectDataModification{Id = 846099524, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}