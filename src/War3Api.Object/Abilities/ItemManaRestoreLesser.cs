using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemManaRestoreLesser : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataManaPointsGained;
        public ItemManaRestoreLesser(): base(829245761)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ItemManaRestoreLesser(int newId): base(829245761, newId)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ItemManaRestoreLesser(string newRawcode): base(829245761, newRawcode)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ItemManaRestoreLesser(ObjectDatabase db): base(829245761, db)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ItemManaRestoreLesser(int newId, ObjectDatabase db): base(829245761, newId, db)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ItemManaRestoreLesser(string newRawcode, ObjectDatabase db): base(829245761, newRawcode, db)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ObjectProperty<int> DataManaPointsGained => _dataManaPointsGained.Value;
        private int GetDataManaPointsGained(int level)
        {
            return _modifications[1735421257, level].ValueAsInt;
        }

        private void SetDataManaPointsGained(int level, int value)
        {
            _modifications[1735421257, level] = new LevelObjectDataModification{Id = 1735421257, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}