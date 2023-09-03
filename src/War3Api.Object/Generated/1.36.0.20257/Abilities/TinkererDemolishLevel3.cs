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
    public sealed class TinkererDemolishLevel3 : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToDemolish;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToDemolishModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageMultiplierBuildings;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageMultiplierBuildingsModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageMultiplierUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageMultiplierUnitsModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageMultiplierHeroes;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageMultiplierHeroesModified;
        public TinkererDemolishLevel3(): base(862211649)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _isDataChanceToDemolishModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDemolishModified));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _isDataDamageMultiplierBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierBuildingsModified));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _isDataDamageMultiplierUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierUnitsModified));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
            _isDataDamageMultiplierHeroesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierHeroesModified));
        }

        public TinkererDemolishLevel3(int newId): base(862211649, newId)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _isDataChanceToDemolishModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDemolishModified));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _isDataDamageMultiplierBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierBuildingsModified));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _isDataDamageMultiplierUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierUnitsModified));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
            _isDataDamageMultiplierHeroesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierHeroesModified));
        }

        public TinkererDemolishLevel3(string newRawcode): base(862211649, newRawcode)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _isDataChanceToDemolishModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDemolishModified));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _isDataDamageMultiplierBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierBuildingsModified));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _isDataDamageMultiplierUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierUnitsModified));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
            _isDataDamageMultiplierHeroesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierHeroesModified));
        }

        public TinkererDemolishLevel3(ObjectDatabaseBase db): base(862211649, db)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _isDataChanceToDemolishModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDemolishModified));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _isDataDamageMultiplierBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierBuildingsModified));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _isDataDamageMultiplierUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierUnitsModified));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
            _isDataDamageMultiplierHeroesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierHeroesModified));
        }

        public TinkererDemolishLevel3(int newId, ObjectDatabaseBase db): base(862211649, newId, db)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _isDataChanceToDemolishModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDemolishModified));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _isDataDamageMultiplierBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierBuildingsModified));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _isDataDamageMultiplierUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierUnitsModified));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
            _isDataDamageMultiplierHeroesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierHeroesModified));
        }

        public TinkererDemolishLevel3(string newRawcode, ObjectDatabaseBase db): base(862211649, newRawcode, db)
        {
            _dataChanceToDemolish = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDemolish, SetDataChanceToDemolish));
            _isDataChanceToDemolishModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDemolishModified));
            _dataDamageMultiplierBuildings = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierBuildings, SetDataDamageMultiplierBuildings));
            _isDataDamageMultiplierBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierBuildingsModified));
            _dataDamageMultiplierUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierUnits, SetDataDamageMultiplierUnits));
            _isDataDamageMultiplierUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierUnitsModified));
            _dataDamageMultiplierHeroes = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplierHeroes, SetDataDamageMultiplierHeroes));
            _isDataDamageMultiplierHeroesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageMultiplierHeroesModified));
        }

        public ObjectProperty<float> DataChanceToDemolish => _dataChanceToDemolish.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToDemolishModified => _isDataChanceToDemolishModified.Value;
        public ObjectProperty<float> DataDamageMultiplierBuildings => _dataDamageMultiplierBuildings.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageMultiplierBuildingsModified => _isDataDamageMultiplierBuildingsModified.Value;
        public ObjectProperty<float> DataDamageMultiplierUnits => _dataDamageMultiplierUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageMultiplierUnitsModified => _isDataDamageMultiplierUnitsModified.Value;
        public ObjectProperty<float> DataDamageMultiplierHeroes => _dataDamageMultiplierHeroes.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageMultiplierHeroesModified => _isDataDamageMultiplierHeroesModified.Value;
        private float GetDataChanceToDemolish(int level)
        {
            return _modifications.GetModification(828728398, level).ValueAsFloat;
        }

        private void SetDataChanceToDemolish(int level, float value)
        {
            _modifications[828728398, level] = new LevelObjectDataModification{Id = 828728398, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataChanceToDemolishModified(int level)
        {
            return _modifications.ContainsKey(828728398, level);
        }

        private float GetDataDamageMultiplierBuildings(int level)
        {
            return _modifications.GetModification(845505614, level).ValueAsFloat;
        }

        private void SetDataDamageMultiplierBuildings(int level, float value)
        {
            _modifications[845505614, level] = new LevelObjectDataModification{Id = 845505614, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageMultiplierBuildingsModified(int level)
        {
            return _modifications.ContainsKey(845505614, level);
        }

        private float GetDataDamageMultiplierUnits(int level)
        {
            return _modifications.GetModification(862282830, level).ValueAsFloat;
        }

        private void SetDataDamageMultiplierUnits(int level, float value)
        {
            _modifications[862282830, level] = new LevelObjectDataModification{Id = 862282830, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamageMultiplierUnitsModified(int level)
        {
            return _modifications.ContainsKey(862282830, level);
        }

        private float GetDataDamageMultiplierHeroes(int level)
        {
            return _modifications.GetModification(879060046, level).ValueAsFloat;
        }

        private void SetDataDamageMultiplierHeroes(int level, float value)
        {
            _modifications[879060046, level] = new LevelObjectDataModification{Id = 879060046, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataDamageMultiplierHeroesModified(int level)
        {
            return _modifications.ContainsKey(879060046, level);
        }
    }
}