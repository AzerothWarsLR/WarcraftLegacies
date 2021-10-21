using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MagicDefense : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageTaken;
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealt;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedFactor;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedFactor;
        private readonly Lazy<ObjectProperty<float>> _dataMagicDamageReduction;
        private readonly Lazy<ObjectProperty<float>> _dataChanceToDeflect;
        private readonly Lazy<ObjectProperty<float>> _dataDeflectDamageTakenPiercing;
        private readonly Lazy<ObjectProperty<float>> _dataDeflectDamageTakenSpells;
        public MagicDefense(): base(1717857601)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public MagicDefense(int newId): base(1717857601, newId)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public MagicDefense(string newRawcode): base(1717857601, newRawcode)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public MagicDefense(ObjectDatabase db): base(1717857601, db)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public MagicDefense(int newId, ObjectDatabase db): base(1717857601, newId, db)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public MagicDefense(string newRawcode, ObjectDatabase db): base(1717857601, newRawcode, db)
        {
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataMovementSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedFactor, SetDataMovementSpeedFactor));
            _dataAttackSpeedFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedFactor, SetDataAttackSpeedFactor));
            _dataMagicDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageReduction, SetDataMagicDamageReduction));
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public ObjectProperty<float> DataDamageTaken => _dataDamageTaken.Value;
        public ObjectProperty<float> DataDamageDealt => _dataDamageDealt.Value;
        public ObjectProperty<float> DataMovementSpeedFactor => _dataMovementSpeedFactor.Value;
        public ObjectProperty<float> DataAttackSpeedFactor => _dataAttackSpeedFactor.Value;
        public ObjectProperty<float> DataMagicDamageReduction => _dataMagicDamageReduction.Value;
        public ObjectProperty<float> DataChanceToDeflect => _dataChanceToDeflect.Value;
        public ObjectProperty<float> DataDeflectDamageTakenPiercing => _dataDeflectDamageTakenPiercing.Value;
        public ObjectProperty<float> DataDeflectDamageTakenSpells => _dataDeflectDamageTakenSpells.Value;
        private float GetDataDamageTaken(int level)
        {
            return _modifications[828794180, level].ValueAsFloat;
        }

        private void SetDataDamageTaken(int level, float value)
        {
            _modifications[828794180, level] = new LevelObjectDataModification{Id = 828794180, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageDealt(int level)
        {
            return _modifications[845571396, level].ValueAsFloat;
        }

        private void SetDataDamageDealt(int level, float value)
        {
            _modifications[845571396, level] = new LevelObjectDataModification{Id = 845571396, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataMovementSpeedFactor(int level)
        {
            return _modifications[862348612, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedFactor(int level, float value)
        {
            _modifications[862348612, level] = new LevelObjectDataModification{Id = 862348612, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataAttackSpeedFactor(int level)
        {
            return _modifications[879125828, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedFactor(int level, float value)
        {
            _modifications[879125828, level] = new LevelObjectDataModification{Id = 879125828, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataMagicDamageReduction(int level)
        {
            return _modifications[895903044, level].ValueAsFloat;
        }

        private void SetDataMagicDamageReduction(int level, float value)
        {
            _modifications[895903044, level] = new LevelObjectDataModification{Id = 895903044, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private float GetDataChanceToDeflect(int level)
        {
            return _modifications[912680260, level].ValueAsFloat;
        }

        private void SetDataChanceToDeflect(int level, float value)
        {
            _modifications[912680260, level] = new LevelObjectDataModification{Id = 912680260, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }

        private float GetDataDeflectDamageTakenPiercing(int level)
        {
            return _modifications[929457476, level].ValueAsFloat;
        }

        private void SetDataDeflectDamageTakenPiercing(int level, float value)
        {
            _modifications[929457476, level] = new LevelObjectDataModification{Id = 929457476, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 7};
        }

        private float GetDataDeflectDamageTakenSpells(int level)
        {
            return _modifications[946234692, level].ValueAsFloat;
        }

        private void SetDataDeflectDamageTakenSpells(int level, float value)
        {
            _modifications[946234692, level] = new LevelObjectDataModification{Id = 946234692, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 8};
        }
    }
}