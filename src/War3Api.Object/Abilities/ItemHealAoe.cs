using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemHealAoe : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsGained;
        public ItemHealAoe(): base(1634224449)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealAoe(int newId): base(1634224449, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealAoe(string newRawcode): base(1634224449, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealAoe(ObjectDatabase db): base(1634224449, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealAoe(int newId, ObjectDatabase db): base(1634224449, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ItemHealAoe(string newRawcode, ObjectDatabase db): base(1634224449, newRawcode, db)
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