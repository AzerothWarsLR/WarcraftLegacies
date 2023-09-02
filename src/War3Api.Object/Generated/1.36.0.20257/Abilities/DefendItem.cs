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
    public sealed class DefendItem : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageTaken;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageTakenModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealt;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageDealtModified;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataMagicDamageReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMagicDamageReductionModified;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToDeflect;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToDeflectModified;
        private readonly Lazy<ObjectProperty<float>> _dataDeflectDamageTakenPiercing;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDeflectDamageTakenPiercingModified;
        private readonly Lazy<ObjectProperty<float>> _dataDeflectDamageTakenSpells;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDeflectDamageTakenSpellsModified;
        public DefendItem(): base(1684293953)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _isDataDamageTakenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public DefendItem(int newId): base(1684293953, newId)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _isDataDamageTakenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public DefendItem(string newRawcode): base(1684293953, newRawcode)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _isDataDamageTakenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public DefendItem(ObjectDatabaseBase db): base(1684293953, db)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _isDataDamageTakenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public DefendItem(int newId, ObjectDatabaseBase db): base(1684293953, newId, db)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _isDataDamageTakenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public DefendItem(string newRawcode, ObjectDatabaseBase db): base(1684293953, newRawcode, db)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _isDataDamageTakenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _isDataMovementSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedFactorModified));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _isDataAttackSpeedFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedFactorModified));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _isDataMagicDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMagicDamageReductionModified));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public ObjectProperty<float> DataDamageTaken => _dataDamageTaken.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageTakenModified => _isDataDamageTakenModified.Value;
        public ObjectProperty<float> DataDamageDealt => _dataDamageDealt.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageDealtModified => _isDataDamageDealtModified.Value;
        public ObjectProperty<float> DataMovementSpeedFactor => _dataMovementSpeedFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedFactorModified => _isDataMovementSpeedFactorModified.Value;
        public ObjectProperty<float> DataAttackSpeedFactor => _dataAttackSpeedFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedFactorModified => _isDataAttackSpeedFactorModified.Value;
        public ObjectProperty<float> DataMagicDamageReduction => _dataMagicDamageReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataMagicDamageReductionModified => _isDataMagicDamageReductionModified.Value;
        public ObjectProperty<float> DataChanceToDeflect => _dataChanceToDeflect.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToDeflectModified => _isDataChanceToDeflectModified.Value;
        public ObjectProperty<float> DataDeflectDamageTakenPiercing => _dataDeflectDamageTakenPiercing.Value;
        public ReadOnlyObjectProperty<bool> IsDataDeflectDamageTakenPiercingModified => _isDataDeflectDamageTakenPiercingModified.Value;
        public ObjectProperty<float> DataDeflectDamageTakenSpells => _dataDeflectDamageTakenSpells.Value;
        public ReadOnlyObjectProperty<bool> IsDataDeflectDamageTakenSpellsModified => _isDataDeflectDamageTakenSpellsModified.Value;
        private float GetDataDamageTaken(int level)
        {
            return _modifications.GetModification(828794180, level).ValueAsFloat;
        }

        private void SetDataDamageTaken(int level, float value)
        {
            _modifications[828794180, level] = new LevelObjectDataModification{Id = 828794180, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageTakenModified(int level)
        {
            return _modifications.ContainsKey(828794180, level);
        }

        private float GetDataDamageDealt(int level)
        {
            return _modifications.GetModification(845571396, level).ValueAsFloat;
        }

        private void SetDataDamageDealt(int level, float value)
        {
            _modifications[845571396, level] = new LevelObjectDataModification{Id = 845571396, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageDealtModified(int level)
        {
            return _modifications.ContainsKey(845571396, level);
        }

        private float GetDataMovementSpeedFactor(int level)
        {
            return _modifications.GetModification(862348612, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedFactor(int level, float value)
        {
            _modifications[862348612, level] = new LevelObjectDataModification{Id = 862348612, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMovementSpeedFactorModified(int level)
        {
            return _modifications.ContainsKey(862348612, level);
        }

        private float GetDataAttackSpeedFactor(int level)
        {
            return _modifications.GetModification(879125828, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedFactor(int level, float value)
        {
            _modifications[879125828, level] = new LevelObjectDataModification{Id = 879125828, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataAttackSpeedFactorModified(int level)
        {
            return _modifications.ContainsKey(879125828, level);
        }

        private float GetDataMagicDamageReduction(int level)
        {
            return _modifications.GetModification(895903044, level).ValueAsFloat;
        }

        private void SetDataMagicDamageReduction(int level, float value)
        {
            _modifications[895903044, level] = new LevelObjectDataModification{Id = 895903044, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataMagicDamageReductionModified(int level)
        {
            return _modifications.ContainsKey(895903044, level);
        }

        private float GetDataChanceToDeflect(int level)
        {
            return _modifications.GetModification(912680260, level).ValueAsFloat;
        }

        private void SetDataChanceToDeflect(int level, float value)
        {
            _modifications[912680260, level] = new LevelObjectDataModification{Id = 912680260, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataChanceToDeflectModified(int level)
        {
            return _modifications.ContainsKey(912680260, level);
        }

        private float GetDataDeflectDamageTakenPiercing(int level)
        {
            return _modifications.GetModification(929457476, level).ValueAsFloat;
        }

        private void SetDataDeflectDamageTakenPiercing(int level, float value)
        {
            _modifications[929457476, level] = new LevelObjectDataModification{Id = 929457476, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 7};
        }

        private bool GetIsDataDeflectDamageTakenPiercingModified(int level)
        {
            return _modifications.ContainsKey(929457476, level);
        }

        private float GetDataDeflectDamageTakenSpells(int level)
        {
            return _modifications.GetModification(946234692, level).ValueAsFloat;
        }

        private void SetDataDeflectDamageTakenSpells(int level, float value)
        {
            _modifications[946234692, level] = new LevelObjectDataModification{Id = 946234692, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 8};
        }

        private bool GetIsDataDeflectDamageTakenSpellsModified(int level)
        {
            return _modifications.ContainsKey(946234692, level);
        }
    }
}