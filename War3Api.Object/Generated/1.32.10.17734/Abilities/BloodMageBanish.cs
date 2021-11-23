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
    public sealed class BloodMageBanish : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataData_Hbn1;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Hbn1Modified;
        private readonly Lazy<ObjectProperty<float>> _dataData_Hbn2;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Hbn2Modified;
        public BloodMageBanish(): base(1851934785)
        {
            _dataData_Hbn1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn1, SetDataData_Hbn1));
            _isDataData_Hbn1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn1Modified));
            _dataData_Hbn2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn2, SetDataData_Hbn2));
            _isDataData_Hbn2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn2Modified));
        }

        public BloodMageBanish(int newId): base(1851934785, newId)
        {
            _dataData_Hbn1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn1, SetDataData_Hbn1));
            _isDataData_Hbn1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn1Modified));
            _dataData_Hbn2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn2, SetDataData_Hbn2));
            _isDataData_Hbn2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn2Modified));
        }

        public BloodMageBanish(string newRawcode): base(1851934785, newRawcode)
        {
            _dataData_Hbn1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn1, SetDataData_Hbn1));
            _isDataData_Hbn1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn1Modified));
            _dataData_Hbn2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn2, SetDataData_Hbn2));
            _isDataData_Hbn2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn2Modified));
        }

        public BloodMageBanish(ObjectDatabaseBase db): base(1851934785, db)
        {
            _dataData_Hbn1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn1, SetDataData_Hbn1));
            _isDataData_Hbn1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn1Modified));
            _dataData_Hbn2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn2, SetDataData_Hbn2));
            _isDataData_Hbn2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn2Modified));
        }

        public BloodMageBanish(int newId, ObjectDatabaseBase db): base(1851934785, newId, db)
        {
            _dataData_Hbn1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn1, SetDataData_Hbn1));
            _isDataData_Hbn1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn1Modified));
            _dataData_Hbn2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn2, SetDataData_Hbn2));
            _isDataData_Hbn2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn2Modified));
        }

        public BloodMageBanish(string newRawcode, ObjectDatabaseBase db): base(1851934785, newRawcode, db)
        {
            _dataData_Hbn1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn1, SetDataData_Hbn1));
            _isDataData_Hbn1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn1Modified));
            _dataData_Hbn2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Hbn2, SetDataData_Hbn2));
            _isDataData_Hbn2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Hbn2Modified));
        }

        public ObjectProperty<float> DataData_Hbn1 => _dataData_Hbn1.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Hbn1Modified => _isDataData_Hbn1Modified.Value;
        public ObjectProperty<float> DataData_Hbn2 => _dataData_Hbn2.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Hbn2Modified => _isDataData_Hbn2Modified.Value;
        private float GetDataData_Hbn1(int level)
        {
            return _modifications.GetModification(829317704, level).ValueAsFloat;
        }

        private void SetDataData_Hbn1(int level, float value)
        {
            _modifications[829317704, level] = new LevelObjectDataModification{Id = 829317704, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataData_Hbn1Modified(int level)
        {
            return _modifications.ContainsKey(829317704, level);
        }

        private float GetDataData_Hbn2(int level)
        {
            return _modifications.GetModification(846094920, level).ValueAsFloat;
        }

        private void SetDataData_Hbn2(int level, float value)
        {
            _modifications[846094920, level] = new LevelObjectDataModification{Id = 846094920, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataData_Hbn2Modified(int level)
        {
            return _modifications.ContainsKey(846094920, level);
        }
    }
}