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
    public sealed class PulverizeSeaGiant : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToStomp;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToStompModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealt;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageDealtModified;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFullDamageRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataHalfDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHalfDamageRadiusModified;
        public PulverizeSeaGiant(): base(1987068737)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _isDataChanceToStompModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToStompModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public PulverizeSeaGiant(int newId): base(1987068737, newId)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _isDataChanceToStompModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToStompModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public PulverizeSeaGiant(string newRawcode): base(1987068737, newRawcode)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _isDataChanceToStompModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToStompModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public PulverizeSeaGiant(ObjectDatabaseBase db): base(1987068737, db)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _isDataChanceToStompModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToStompModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public PulverizeSeaGiant(int newId, ObjectDatabaseBase db): base(1987068737, newId, db)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _isDataChanceToStompModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToStompModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public PulverizeSeaGiant(string newRawcode, ObjectDatabaseBase db): base(1987068737, newRawcode, db)
        {
            _dataChanceToStomp = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToStomp, SetDataChanceToStomp));
            _isDataChanceToStompModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToStompModified));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _isDataDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtModified));
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataHalfDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageRadius, SetDataHalfDamageRadius));
            _isDataHalfDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageRadiusModified));
        }

        public ObjectProperty<float> DataChanceToStomp => _dataChanceToStomp.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToStompModified => _isDataChanceToStompModified.Value;
        public ObjectProperty<float> DataDamageDealt => _dataDamageDealt.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageDealtModified => _isDataDamageDealtModified.Value;
        public ObjectProperty<float> DataFullDamageRadius => _dataFullDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataFullDamageRadiusModified => _isDataFullDamageRadiusModified.Value;
        public ObjectProperty<float> DataHalfDamageRadius => _dataHalfDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataHalfDamageRadiusModified => _isDataHalfDamageRadiusModified.Value;
        private float GetDataChanceToStomp(int level)
        {
            return _modifications.GetModification(829579607, level).ValueAsFloat;
        }

        private void SetDataChanceToStomp(int level, float value)
        {
            _modifications[829579607, level] = new LevelObjectDataModification{Id = 829579607, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataChanceToStompModified(int level)
        {
            return _modifications.ContainsKey(829579607, level);
        }

        private float GetDataDamageDealt(int level)
        {
            return _modifications.GetModification(846356823, level).ValueAsFloat;
        }

        private void SetDataDamageDealt(int level, float value)
        {
            _modifications[846356823, level] = new LevelObjectDataModification{Id = 846356823, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageDealtModified(int level)
        {
            return _modifications.ContainsKey(846356823, level);
        }

        private float GetDataFullDamageRadius(int level)
        {
            return _modifications.GetModification(863134039, level).ValueAsFloat;
        }

        private void SetDataFullDamageRadius(int level, float value)
        {
            _modifications[863134039, level] = new LevelObjectDataModification{Id = 863134039, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataFullDamageRadiusModified(int level)
        {
            return _modifications.ContainsKey(863134039, level);
        }

        private float GetDataHalfDamageRadius(int level)
        {
            return _modifications.GetModification(879911255, level).ValueAsFloat;
        }

        private void SetDataHalfDamageRadius(int level, float value)
        {
            _modifications[879911255, level] = new LevelObjectDataModification{Id = 879911255, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataHalfDamageRadiusModified(int level)
        {
            return _modifications.ContainsKey(879911255, level);
        }
    }
}