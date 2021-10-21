using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class EluneSGrace : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToDeflect;
        private readonly Lazy<ObjectProperty<float>> _dataDeflectDamageTakenPiercing;
        private readonly Lazy<ObjectProperty<float>> _dataDeflectDamageTakenSpells;
        public EluneSGrace(): base(1919378753)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public EluneSGrace(int newId): base(1919378753, newId)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public EluneSGrace(string newRawcode): base(1919378753, newRawcode)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public EluneSGrace(ObjectDatabase db): base(1919378753, db)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public EluneSGrace(int newId, ObjectDatabase db): base(1919378753, newId, db)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public EluneSGrace(string newRawcode, ObjectDatabase db): base(1919378753, newRawcode, db)
        {
            _dataChanceToDeflect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToDeflect, SetDataChanceToDeflect));
            _dataDeflectDamageTakenPiercing = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenPiercing, SetDataDeflectDamageTakenPiercing));
            _dataDeflectDamageTakenSpells = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeflectDamageTakenSpells, SetDataDeflectDamageTakenSpells));
        }

        public ObjectProperty<float> DataChanceToDeflect => _dataChanceToDeflect.Value;
        public ObjectProperty<float> DataDeflectDamageTakenPiercing => _dataDeflectDamageTakenPiercing.Value;
        public ObjectProperty<float> DataDeflectDamageTakenSpells => _dataDeflectDamageTakenSpells.Value;
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