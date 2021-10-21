using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SightBonus : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataSightRangeBonus;
        public SightBonus(): base(1769163073)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
        }

        public SightBonus(int newId): base(1769163073, newId)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
        }

        public SightBonus(string newRawcode): base(1769163073, newRawcode)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
        }

        public SightBonus(ObjectDatabase db): base(1769163073, db)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
        }

        public SightBonus(int newId, ObjectDatabase db): base(1769163073, newId, db)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
        }

        public SightBonus(string newRawcode, ObjectDatabase db): base(1769163073, newRawcode, db)
        {
            _dataSightRangeBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSightRangeBonus, SetDataSightRangeBonus));
        }

        public ObjectProperty<int> DataSightRangeBonus => _dataSightRangeBonus.Value;
        private int GetDataSightRangeBonus(int level)
        {
            return _modifications[1651077961, level].ValueAsInt;
        }

        private void SetDataSightRangeBonus(int level, int value)
        {
            _modifications[1651077961, level] = new LevelObjectDataModification{Id = 1651077961, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}