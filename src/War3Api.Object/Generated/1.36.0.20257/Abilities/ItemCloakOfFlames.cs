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
    public sealed class ItemCloakOfFlames : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDamagePerDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerDurationModified;
        private readonly Lazy<ObjectProperty<int>> _dataManaUsedPerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaUsedPerSecondModified;
        private readonly Lazy<ObjectProperty<int>> _dataExtraManaRequired;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataExtraManaRequiredModified;
        public ItemCloakOfFlames(): base(1717782849)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _isDataDamagePerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerDurationModified));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _isDataManaUsedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaUsedPerSecondModified));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
            _isDataExtraManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraManaRequiredModified));
        }

        public ItemCloakOfFlames(int newId): base(1717782849, newId)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _isDataDamagePerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerDurationModified));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _isDataManaUsedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaUsedPerSecondModified));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
            _isDataExtraManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraManaRequiredModified));
        }

        public ItemCloakOfFlames(string newRawcode): base(1717782849, newRawcode)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _isDataDamagePerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerDurationModified));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _isDataManaUsedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaUsedPerSecondModified));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
            _isDataExtraManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraManaRequiredModified));
        }

        public ItemCloakOfFlames(ObjectDatabaseBase db): base(1717782849, db)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _isDataDamagePerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerDurationModified));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _isDataManaUsedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaUsedPerSecondModified));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
            _isDataExtraManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraManaRequiredModified));
        }

        public ItemCloakOfFlames(int newId, ObjectDatabaseBase db): base(1717782849, newId, db)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _isDataDamagePerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerDurationModified));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _isDataManaUsedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaUsedPerSecondModified));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
            _isDataExtraManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraManaRequiredModified));
        }

        public ItemCloakOfFlames(string newRawcode, ObjectDatabaseBase db): base(1717782849, newRawcode, db)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _isDataDamagePerDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerDurationModified));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _isDataManaUsedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaUsedPerSecondModified));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
            _isDataExtraManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExtraManaRequiredModified));
        }

        public ObjectProperty<int> DataDamagePerDuration => _dataDamagePerDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerDurationModified => _isDataDamagePerDurationModified.Value;
        public ObjectProperty<int> DataManaUsedPerSecond => _dataManaUsedPerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaUsedPerSecondModified => _isDataManaUsedPerSecondModified.Value;
        public ObjectProperty<int> DataExtraManaRequired => _dataExtraManaRequired.Value;
        public ReadOnlyObjectProperty<bool> IsDataExtraManaRequiredModified => _isDataExtraManaRequiredModified.Value;
        private int GetDataDamagePerDuration(int level)
        {
            return _modifications.GetModification(1684431689, level).ValueAsInt;
        }

        private void SetDataDamagePerDuration(int level, int value)
        {
            _modifications[1684431689, level] = new LevelObjectDataModification{Id = 1684431689, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamagePerDurationModified(int level)
        {
            return _modifications.ContainsKey(1684431689, level);
        }

        private int GetDataManaUsedPerSecond(int level)
        {
            return _modifications.GetModification(1835426633, level).ValueAsInt;
        }

        private void SetDataManaUsedPerSecond(int level, int value)
        {
            _modifications[1835426633, level] = new LevelObjectDataModification{Id = 1835426633, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataManaUsedPerSecondModified(int level)
        {
            return _modifications.ContainsKey(1835426633, level);
        }

        private int GetDataExtraManaRequired(int level)
        {
            return _modifications.GetModification(2019976009, level).ValueAsInt;
        }

        private void SetDataExtraManaRequired(int level, int value)
        {
            _modifications[2019976009, level] = new LevelObjectDataModification{Id = 2019976009, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataExtraManaRequiredModified(int level)
        {
            return _modifications.ContainsKey(2019976009, level);
        }
    }
}