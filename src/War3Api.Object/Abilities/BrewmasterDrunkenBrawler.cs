using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BrewmasterDrunkenBrawler : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToCriticalStrike;
        private readonly Lazy<ObjectProperty<float>> _dataDamageMultiplier;
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToEvade;
        private readonly Lazy<ObjectProperty<bool>> _dataNeverMiss;
        private readonly Lazy<ObjectProperty<bool>> _dataExcludeItemDamage;
        public BrewmasterDrunkenBrawler(): base(1650740801)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public BrewmasterDrunkenBrawler(int newId): base(1650740801, newId)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public BrewmasterDrunkenBrawler(string newRawcode): base(1650740801, newRawcode)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public BrewmasterDrunkenBrawler(ObjectDatabase db): base(1650740801, db)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public BrewmasterDrunkenBrawler(int newId, ObjectDatabase db): base(1650740801, newId, db)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public BrewmasterDrunkenBrawler(string newRawcode, ObjectDatabase db): base(1650740801, newRawcode, db)
        {
            _dataChanceToCriticalStrike = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToCriticalStrike, SetDataChanceToCriticalStrike));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _dataExcludeItemDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExcludeItemDamage, SetDataExcludeItemDamage));
        }

        public ObjectProperty<float> DataChanceToCriticalStrike => _dataChanceToCriticalStrike.Value;
        public ObjectProperty<float> DataDamageMultiplier => _dataDamageMultiplier.Value;
        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ObjectProperty<float> DataChanceToEvade => _dataChanceToEvade.Value;
        public ObjectProperty<bool> DataNeverMiss => _dataNeverMiss.Value;
        public ObjectProperty<bool> DataExcludeItemDamage => _dataExcludeItemDamage.Value;
        private float GetDataChanceToCriticalStrike(int level)
        {
            return _modifications[829580111, level].ValueAsFloat;
        }

        private void SetDataChanceToCriticalStrike(int level, float value)
        {
            _modifications[829580111, level] = new LevelObjectDataModification{Id = 829580111, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageMultiplier(int level)
        {
            return _modifications[846357327, level].ValueAsFloat;
        }

        private void SetDataDamageMultiplier(int level, float value)
        {
            _modifications[846357327, level] = new LevelObjectDataModification{Id = 846357327, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDamageBonus(int level)
        {
            return _modifications[863134543, level].ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[863134543, level] = new LevelObjectDataModification{Id = 863134543, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataChanceToEvade(int level)
        {
            return _modifications[879911759, level].ValueAsFloat;
        }

        private void SetDataChanceToEvade(int level, float value)
        {
            _modifications[879911759, level] = new LevelObjectDataModification{Id = 879911759, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetDataNeverMiss(int level)
        {
            return _modifications[896688975, level].ValueAsBool;
        }

        private void SetDataNeverMiss(int level, bool value)
        {
            _modifications[896688975, level] = new LevelObjectDataModification{Id = 896688975, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private bool GetDataExcludeItemDamage(int level)
        {
            return _modifications[913466191, level].ValueAsBool;
        }

        private void SetDataExcludeItemDamage(int level, bool value)
        {
            _modifications[913466191, level] = new LevelObjectDataModification{Id = 913466191, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 6};
        }
    }
}