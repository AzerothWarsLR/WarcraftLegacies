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
    public sealed class SightBonus : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataSightRangeBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSightRangeBonusModified;
        public SightBonus(): base(1769163073)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
            _isDataSightRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSightRangeBonusModified));
        }

        public SightBonus(int newId): base(1769163073, newId)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
            _isDataSightRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSightRangeBonusModified));
        }

        public SightBonus(string newRawcode): base(1769163073, newRawcode)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
            _isDataSightRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSightRangeBonusModified));
        }

        public SightBonus(ObjectDatabaseBase db): base(1769163073, db)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
            _isDataSightRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSightRangeBonusModified));
        }

        public SightBonus(int newId, ObjectDatabaseBase db): base(1769163073, newId, db)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
            _isDataSightRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSightRangeBonusModified));
        }

        public SightBonus(string newRawcode, ObjectDatabaseBase db): base(1769163073, newRawcode, db)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
            _isDataSightRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSightRangeBonusModified));
        }

        public ObjectProperty<int> DataSightRangeBonus => _dataSightRangeBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataSightRangeBonusModified => _isDataSightRangeBonusModified.Value;
        private int GetDataSightRangeBonus(int level)
        {
            return _modifications.GetModification(1651077961, level).ValueAsInt;
        }

        private void SetDataSightRangeBonus(int level, int value)
        {
            _modifications[1651077961, level] = new LevelObjectDataModification{Id = 1651077961, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataSightRangeBonusModified(int level)
        {
            return _modifications.ContainsKey(1651077961, level);
        }
    }
}