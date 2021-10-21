using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemDefenseAoe : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDefenseBonus;
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsGained;
        private readonly Lazy<ObjectProperty<int>> _dataManaPointsGained;
        public ItemDefenseAoe(): base(1633962305)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ItemDefenseAoe(int newId): base(1633962305, newId)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ItemDefenseAoe(string newRawcode): base(1633962305, newRawcode)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ItemDefenseAoe(ObjectDatabase db): base(1633962305, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ItemDefenseAoe(int newId, ObjectDatabase db): base(1633962305, newId, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ItemDefenseAoe(string newRawcode, ObjectDatabase db): base(1633962305, newRawcode, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
        }

        public ObjectProperty<int> DataDefenseBonus => _dataDefenseBonus.Value;
        public ObjectProperty<int> DataHitPointsGained => _dataHitPointsGained.Value;
        public ObjectProperty<int> DataManaPointsGained => _dataManaPointsGained.Value;
        private int GetDataDefenseBonus(int level)
        {
            return _modifications[1717920841, level].ValueAsInt;
        }

        private void SetDataDefenseBonus(int level, int value)
        {
            _modifications[1717920841, level] = new LevelObjectDataModification{Id = 1717920841, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataHitPointsGained(int level)
        {
            return _modifications[846227529, level].ValueAsInt;
        }

        private void SetDataHitPointsGained(int level, int value)
        {
            _modifications[846227529, level] = new LevelObjectDataModification{Id = 846227529, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataManaPointsGained(int level)
        {
            return _modifications[846228809, level].ValueAsInt;
        }

        private void SetDataManaPointsGained(int level, int value)
        {
            _modifications[846228809, level] = new LevelObjectDataModification{Id = 846228809, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }
    }
}