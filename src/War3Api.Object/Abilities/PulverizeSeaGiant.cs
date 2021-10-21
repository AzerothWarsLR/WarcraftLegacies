using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PulverizeSeaGiant : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToStomp;
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealt;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageRadius;
        private readonly Lazy<ObjectProperty<float>> _dataHalfDamageRadius;
        public PulverizeSeaGiant(): base(1987068737)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public PulverizeSeaGiant(int newId): base(1987068737, newId)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public PulverizeSeaGiant(string newRawcode): base(1987068737, newRawcode)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public PulverizeSeaGiant(ObjectDatabase db): base(1987068737, db)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public PulverizeSeaGiant(int newId, ObjectDatabase db): base(1987068737, newId, db)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public PulverizeSeaGiant(string newRawcode, ObjectDatabase db): base(1987068737, newRawcode, db)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
        }

        public ObjectProperty<float> DataChanceToStomp => _dataChanceToStomp.Value;
        public ObjectProperty<float> DataDamageDealt => _dataDamageDealt.Value;
        public ObjectProperty<float> DataFullDamageRadius => _dataFullDamageRadius.Value;
        public ObjectProperty<float> DataHalfDamageRadius => _dataHalfDamageRadius.Value;
        private float GetDataChanceToStomp(int level)
        {
            return _modifications[829579607, level].ValueAsFloat;
        }

        private void SetDataChanceToStomp(int level, float value)
        {
            _modifications[829579607, level] = new LevelObjectDataModification{Id = 829579607, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageDealt(int level)
        {
            return _modifications[846356823, level].ValueAsFloat;
        }

        private void SetDataDamageDealt(int level, float value)
        {
            _modifications[846356823, level] = new LevelObjectDataModification{Id = 846356823, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataFullDamageRadius(int level)
        {
            return _modifications[863134039, level].ValueAsFloat;
        }

        private void SetDataFullDamageRadius(int level, float value)
        {
            _modifications[863134039, level] = new LevelObjectDataModification{Id = 863134039, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataHalfDamageRadius(int level)
        {
            return _modifications[879911255, level].ValueAsFloat;
        }

        private void SetDataHalfDamageRadius(int level, float value)
        {
            _modifications[879911255, level] = new LevelObjectDataModification{Id = 879911255, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }
    }
}