using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BashCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToBash;
        private readonly Lazy<ObjectProperty<float>> _dataDamageMultiplier;
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToMiss;
        private readonly Lazy<ObjectProperty<bool>> _dataNeverMiss;
        public BashCreep(): base(1751270209)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashCreep(int newId): base(1751270209, newId)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashCreep(string newRawcode): base(1751270209, newRawcode)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashCreep(ObjectDatabase db): base(1751270209, db)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashCreep(int newId, ObjectDatabase db): base(1751270209, newId, db)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashCreep(string newRawcode, ObjectDatabase db): base(1751270209, newRawcode, db)
        {
            _dataChanceToBash = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToBash, SetDataChanceToBash));
            _dataDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageMultiplier, SetDataDamageMultiplier));
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public ObjectProperty<float> DataChanceToBash => _dataChanceToBash.Value;
        public ObjectProperty<float> DataDamageMultiplier => _dataDamageMultiplier.Value;
        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        public ObjectProperty<float> DataChanceToMiss => _dataChanceToMiss.Value;
        public ObjectProperty<bool> DataNeverMiss => _dataNeverMiss.Value;
        private float GetDataChanceToBash(int level)
        {
            return _modifications[828924488, level].ValueAsFloat;
        }

        private void SetDataChanceToBash(int level, float value)
        {
            _modifications[828924488, level] = new LevelObjectDataModification{Id = 828924488, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageMultiplier(int level)
        {
            return _modifications[845701704, level].ValueAsFloat;
        }

        private void SetDataDamageMultiplier(int level, float value)
        {
            _modifications[845701704, level] = new LevelObjectDataModification{Id = 845701704, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDamageBonus(int level)
        {
            return _modifications[862478920, level].ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[862478920, level] = new LevelObjectDataModification{Id = 862478920, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataChanceToMiss(int level)
        {
            return _modifications[879256136, level].ValueAsFloat;
        }

        private void SetDataChanceToMiss(int level, float value)
        {
            _modifications[879256136, level] = new LevelObjectDataModification{Id = 879256136, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetDataNeverMiss(int level)
        {
            return _modifications[896033352, level].ValueAsBool;
        }

        private void SetDataNeverMiss(int level, bool value)
        {
            _modifications[896033352, level] = new LevelObjectDataModification{Id = 896033352, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }
    }
}