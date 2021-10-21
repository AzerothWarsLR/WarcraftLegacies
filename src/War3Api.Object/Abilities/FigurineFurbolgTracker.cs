using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FigurineFurbolgTracker : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataSummon1Amount;
        private readonly Lazy<ObjectProperty<string>> _dataSummon1UnitTypeRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataSummon1UnitType;
        private readonly Lazy<ObjectProperty<int>> _dataSummon2Amount;
        private readonly Lazy<ObjectProperty<string>> _dataSummon2UnitTypeRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataSummon2UnitType;
        public FigurineFurbolgTracker(): base(1953843521)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public FigurineFurbolgTracker(int newId): base(1953843521, newId)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public FigurineFurbolgTracker(string newRawcode): base(1953843521, newRawcode)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public FigurineFurbolgTracker(ObjectDatabase db): base(1953843521, db)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public FigurineFurbolgTracker(int newId, ObjectDatabase db): base(1953843521, newId, db)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public FigurineFurbolgTracker(string newRawcode, ObjectDatabase db): base(1953843521, newRawcode, db)
        {
            _dataSummon1Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon1Amount, SetDataSummon1Amount));
            _dataSummon1UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon1UnitTypeRaw, SetDataSummon1UnitTypeRaw));
            _dataSummon1UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon1UnitType, SetDataSummon1UnitType));
            _dataSummon2Amount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummon2Amount, SetDataSummon2Amount));
            _dataSummon2UnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummon2UnitTypeRaw, SetDataSummon2UnitTypeRaw));
            _dataSummon2UnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummon2UnitType, SetDataSummon2UnitType));
        }

        public ObjectProperty<int> DataSummon1Amount => _dataSummon1Amount.Value;
        public ObjectProperty<string> DataSummon1UnitTypeRaw => _dataSummon1UnitTypeRaw.Value;
        public ObjectProperty<Unit> DataSummon1UnitType => _dataSummon1UnitType.Value;
        public ObjectProperty<int> DataSummon2Amount => _dataSummon2Amount.Value;
        public ObjectProperty<string> DataSummon2UnitTypeRaw => _dataSummon2UnitTypeRaw.Value;
        public ObjectProperty<Unit> DataSummon2UnitType => _dataSummon2UnitType.Value;
        private int GetDataSummon1Amount(int level)
        {
            return _modifications[829322057, level].ValueAsInt;
        }

        private void SetDataSummon1Amount(int level, int value)
        {
            _modifications[829322057, level] = new LevelObjectDataModification{Id = 829322057, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private string GetDataSummon1UnitTypeRaw(int level)
        {
            return _modifications[829715273, level].ValueAsString;
        }

        private void SetDataSummon1UnitTypeRaw(int level, string value)
        {
            _modifications[829715273, level] = new LevelObjectDataModification{Id = 829715273, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 3};
        }

        private Unit GetDataSummon1UnitType(int level)
        {
            return GetDataSummon1UnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataSummon1UnitType(int level, Unit value)
        {
            SetDataSummon1UnitTypeRaw(level, value.ToRaw(null, null));
        }

        private int GetDataSummon2Amount(int level)
        {
            return _modifications[846099273, level].ValueAsInt;
        }

        private void SetDataSummon2Amount(int level, int value)
        {
            _modifications[846099273, level] = new LevelObjectDataModification{Id = 846099273, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private string GetDataSummon2UnitTypeRaw(int level)
        {
            return _modifications[846492489, level].ValueAsString;
        }

        private void SetDataSummon2UnitTypeRaw(int level, string value)
        {
            _modifications[846492489, level] = new LevelObjectDataModification{Id = 846492489, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 4};
        }

        private Unit GetDataSummon2UnitType(int level)
        {
            return GetDataSummon2UnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataSummon2UnitType(int level, Unit value)
        {
            SetDataSummon2UnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}