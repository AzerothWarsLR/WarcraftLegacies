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
    public sealed class EluneSGrace : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToDeflect;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToDeflectModified;
        private readonly Lazy<ObjectProperty<float>> _dataDeflectDamageTakenPiercing;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDeflectDamageTakenPiercingModified;
        private readonly Lazy<ObjectProperty<float>> _dataDeflectDamageTakenSpells;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDeflectDamageTakenSpellsModified;
        public EluneSGrace(): base(1919378753)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public EluneSGrace(int newId): base(1919378753, newId)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public EluneSGrace(string newRawcode): base(1919378753, newRawcode)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public EluneSGrace(ObjectDatabaseBase db): base(1919378753, db)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public EluneSGrace(int newId, ObjectDatabaseBase db): base(1919378753, newId, db)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public EluneSGrace(string newRawcode, ObjectDatabaseBase db): base(1919378753, newRawcode, db)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _isDataChanceToDeflectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToDeflectModified));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _isDataDeflectDamageTakenPiercingModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenPiercingModified));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
            _isDataDeflectDamageTakenSpellsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeflectDamageTakenSpellsModified));
        }

        public ObjectProperty<float> DataChanceToDeflect => _dataChanceToDeflect.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToDeflectModified => _isDataChanceToDeflectModified.Value;
        public ObjectProperty<float> DataDeflectDamageTakenPiercing => _dataDeflectDamageTakenPiercing.Value;
        public ReadOnlyObjectProperty<bool> IsDataDeflectDamageTakenPiercingModified => _isDataDeflectDamageTakenPiercingModified.Value;
        public ObjectProperty<float> DataDeflectDamageTakenSpells => _dataDeflectDamageTakenSpells.Value;
        public ReadOnlyObjectProperty<bool> IsDataDeflectDamageTakenSpellsModified => _isDataDeflectDamageTakenSpellsModified.Value;
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