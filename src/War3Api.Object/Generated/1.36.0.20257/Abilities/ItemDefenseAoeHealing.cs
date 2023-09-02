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
    public sealed class ItemDefenseAoeHealing : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDefenseBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDefenseBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointsGainedModified;
        private readonly Lazy<ObjectProperty<int>> _dataManaPointsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaPointsGainedModified;
        public ItemDefenseAoeHealing(): base(1650739521)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ItemDefenseAoeHealing(int newId): base(1650739521, newId)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ItemDefenseAoeHealing(string newRawcode): base(1650739521, newRawcode)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ItemDefenseAoeHealing(ObjectDatabaseBase db): base(1650739521, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ItemDefenseAoeHealing(int newId, ObjectDatabaseBase db): base(1650739521, newId, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ItemDefenseAoeHealing(string newRawcode, ObjectDatabaseBase db): base(1650739521, newRawcode, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataManaPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
        }

        public ObjectProperty<int> DataDefenseBonus => _dataDefenseBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDefenseBonusModified => _isDataDefenseBonusModified.Value;
        public ObjectProperty<int> DataHitPointsGained => _dataHitPointsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataHitPointsGainedModified => _isDataHitPointsGainedModified.Value;
        public ObjectProperty<int> DataManaPointsGained => _dataManaPointsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaPointsGainedModified => _isDataManaPointsGainedModified.Value;
        private int GetDataDefenseBonus(int level)
        {
            return _modifications.GetModification(1717920841, level).ValueAsInt;
        }

        private void SetDataDefenseBonus(int level, int value)
        {
            _modifications[1717920841, level] = new LevelObjectDataModification{Id = 1717920841, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDefenseBonusModified(int level)
        {
            return _modifications.ContainsKey(1717920841, level);
        }

        private int GetDataHitPointsGained(int level)
        {
            return _modifications.GetModification(846227529, level).ValueAsInt;
        }

        private void SetDataHitPointsGained(int level, int value)
        {
            _modifications[846227529, level] = new LevelObjectDataModification{Id = 846227529, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataHitPointsGainedModified(int level)
        {
            return _modifications.ContainsKey(846227529, level);
        }

        private int GetDataManaPointsGained(int level)
        {
            return _modifications.GetModification(846228809, level).ValueAsInt;
        }

        private void SetDataManaPointsGained(int level, int value)
        {
            _modifications[846228809, level] = new LevelObjectDataModification{Id = 846228809, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataManaPointsGainedModified(int level)
        {
            return _modifications.ContainsKey(846228809, level);
        }
    }
}