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
    public sealed class ChieftainEnduranceAura : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataData_Oae1;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Oae1Modified;
        private readonly Lazy<ObjectProperty<float>> _dataData_Oae2;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Oae2Modified;
        public ChieftainEnduranceAura(): base(1700876097)
        {
            _dataData_Oae1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae1, SetDataData_Oae1));
            _isDataData_Oae1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae1Modified));
            _dataData_Oae2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae2, SetDataData_Oae2));
            _isDataData_Oae2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae2Modified));
        }

        public ChieftainEnduranceAura(int newId): base(1700876097, newId)
        {
            _dataData_Oae1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae1, SetDataData_Oae1));
            _isDataData_Oae1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae1Modified));
            _dataData_Oae2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae2, SetDataData_Oae2));
            _isDataData_Oae2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae2Modified));
        }

        public ChieftainEnduranceAura(string newRawcode): base(1700876097, newRawcode)
        {
            _dataData_Oae1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae1, SetDataData_Oae1));
            _isDataData_Oae1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae1Modified));
            _dataData_Oae2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae2, SetDataData_Oae2));
            _isDataData_Oae2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae2Modified));
        }

        public ChieftainEnduranceAura(ObjectDatabaseBase db): base(1700876097, db)
        {
            _dataData_Oae1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae1, SetDataData_Oae1));
            _isDataData_Oae1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae1Modified));
            _dataData_Oae2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae2, SetDataData_Oae2));
            _isDataData_Oae2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae2Modified));
        }

        public ChieftainEnduranceAura(int newId, ObjectDatabaseBase db): base(1700876097, newId, db)
        {
            _dataData_Oae1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae1, SetDataData_Oae1));
            _isDataData_Oae1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae1Modified));
            _dataData_Oae2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae2, SetDataData_Oae2));
            _isDataData_Oae2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae2Modified));
        }

        public ChieftainEnduranceAura(string newRawcode, ObjectDatabaseBase db): base(1700876097, newRawcode, db)
        {
            _dataData_Oae1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae1, SetDataData_Oae1));
            _isDataData_Oae1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae1Modified));
            _dataData_Oae2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Oae2, SetDataData_Oae2));
            _isDataData_Oae2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Oae2Modified));
        }

        public ObjectProperty<float> DataData_Oae1 => _dataData_Oae1.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Oae1Modified => _isDataData_Oae1Modified.Value;
        public ObjectProperty<float> DataData_Oae2 => _dataData_Oae2.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Oae2Modified => _isDataData_Oae2Modified.Value;
        private float GetDataData_Oae1(int level)
        {
            return _modifications.GetModification(828727631, level).ValueAsFloat;
        }

        private void SetDataData_Oae1(int level, float value)
        {
            _modifications[828727631, level] = new LevelObjectDataModification{Id = 828727631, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataData_Oae1Modified(int level)
        {
            return _modifications.ContainsKey(828727631, level);
        }

        private float GetDataData_Oae2(int level)
        {
            return _modifications.GetModification(845504847, level).ValueAsFloat;
        }

        private void SetDataData_Oae2(int level, float value)
        {
            _modifications[845504847, level] = new LevelObjectDataModification{Id = 845504847, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataData_Oae2Modified(int level)
        {
            return _modifications.ContainsKey(845504847, level);
        }
    }
}