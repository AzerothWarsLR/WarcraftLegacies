using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemHealGreater : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsGained;
        public ItemHealGreater(): base(845695297)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealGreater(int newId): base(845695297, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealGreater(string newRawcode): base(845695297, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealGreater(ObjectDatabase db): base(845695297, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealGreater(int newId, ObjectDatabase db): base(845695297, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealGreater(string newRawcode, ObjectDatabase db): base(845695297, newRawcode, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ObjectProperty<int> DataHitPointsGained => _dataHitPointsGained.Value;
        private int GetDataHitPointsGained(int level)
        {
            return _modifications[1735419977, level].ValueAsInt;
        }

        private void SetDataHitPointsGained(int level, int value)
        {
            _modifications[1735419977, level] = new LevelObjectDataModification{Id = 1735419977, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}