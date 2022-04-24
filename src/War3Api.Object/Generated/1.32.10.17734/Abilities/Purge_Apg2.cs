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
    public sealed class Purge_Apg2 : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataManaLoss;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaLossModified;
        public Purge_Apg2(): base(845639745)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public Purge_Apg2(int newId): base(845639745, newId)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public Purge_Apg2(string newRawcode): base(845639745, newRawcode)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public Purge_Apg2(ObjectDatabaseBase db): base(845639745, db)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public Purge_Apg2(int newId, ObjectDatabaseBase db): base(845639745, newId, db)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public Purge_Apg2(string newRawcode, ObjectDatabaseBase db): base(845639745, newRawcode, db)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public ObjectProperty<int> DataManaLoss => _dataManaLoss.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaLossModified => _isDataManaLossModified.Value;
        private int GetDataManaLoss(int level)
        {
            return _modifications.GetModification(912749136, level).ValueAsInt;
        }

        private void SetDataManaLoss(int level, int value)
        {
            _modifications[912749136, level] = new LevelObjectDataModification{Id = 912749136, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataManaLossModified(int level)
        {
            return _modifications.ContainsKey(912749136, level);
        }
    }
}