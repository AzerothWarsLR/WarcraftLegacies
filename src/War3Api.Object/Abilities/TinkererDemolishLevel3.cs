using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TinkererDemolishLevel3 : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToDemolish;
        private readonly Lazy<ObjectProperty<float>> _dataDamageMultiplierBuildings;
        private readonly Lazy<ObjectProperty<float>> _dataDamageMultiplierUnits;
        private readonly Lazy<ObjectProperty<float>> _dataDamageMultiplierHeroes;
        public TinkererDemolishLevel3(): base(862211649)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
        }

        public TinkererDemolishLevel3(int newId): base(862211649, newId)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
        }

        public TinkererDemolishLevel3(string newRawcode): base(862211649, newRawcode)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
        }

        public TinkererDemolishLevel3(ObjectDatabase db): base(862211649, db)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
        }

        public TinkererDemolishLevel3(int newId, ObjectDatabase db): base(862211649, newId, db)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
        }

        public TinkererDemolishLevel3(string newRawcode, ObjectDatabase db): base(862211649, newRawcode, db)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
        }

        public ObjectProperty<float> DataChanceToDemolish => _dataChanceToDemolish.Value;
        public ObjectProperty<float> DataDamageMultiplierBuildings => _dataDamageMultiplierBuildings.Value;
        public ObjectProperty<float> DataDamageMultiplierUnits => _dataDamageMultiplierUnits.Value;
        public ObjectProperty<float> DataDamageMultiplierHeroes => _dataDamageMultiplierHeroes.Value;
        private float GetDataChanceToDemolish(int level)
        {
            return _modifications[828728398, level].ValueAsFloat;
        }

        private void SetDataChanceToDemolish(int level, float value)
        {
            _modifications[828728398, level] = new LevelObjectDataModification{Id = 828728398, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageMultiplierBuildings(int level)
        {
            return _modifications[845505614, level].ValueAsFloat;
        }

        private void SetDataDamageMultiplierBuildings(int level, float value)
        {
            _modifications[845505614, level] = new LevelObjectDataModification{Id = 845505614, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDamageMultiplierUnits(int level)
        {
            return _modifications[862282830, level].ValueAsFloat;
        }

        private void SetDataDamageMultiplierUnits(int level, float value)
        {
            _modifications[862282830, level] = new LevelObjectDataModification{Id = 862282830, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataDamageMultiplierHeroes(int level)
        {
            return _modifications[879060046, level].ValueAsFloat;
        }

        private void SetDataDamageMultiplierHeroes(int level, float value)
        {
            _modifications[879060046, level] = new LevelObjectDataModification{Id = 879060046, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }
    }
}