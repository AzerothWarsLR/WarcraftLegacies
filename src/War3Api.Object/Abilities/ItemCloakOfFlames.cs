using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemCloakOfFlames : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDamagePerDuration;
        private readonly Lazy<ObjectProperty<int>> _dataManaUsedPerSecond;
        private readonly Lazy<ObjectProperty<int>> _dataExtraManaRequired;
        public ItemCloakOfFlames(): base(1717782849)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
        }

        public ItemCloakOfFlames(int newId): base(1717782849, newId)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
        }

        public ItemCloakOfFlames(string newRawcode): base(1717782849, newRawcode)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
        }

        public ItemCloakOfFlames(ObjectDatabase db): base(1717782849, db)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
        }

        public ItemCloakOfFlames(int newId, ObjectDatabase db): base(1717782849, newId, db)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
        }

        public ItemCloakOfFlames(string newRawcode, ObjectDatabase db): base(1717782849, newRawcode, db)
        {
            _dataDamagePerDuration = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamagePerDuration, SetDataDamagePerDuration));
            _dataManaUsedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaUsedPerSecond, SetDataManaUsedPerSecond));
            _dataExtraManaRequired = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExtraManaRequired, SetDataExtraManaRequired));
        }

        public ObjectProperty<int> DataDamagePerDuration => _dataDamagePerDuration.Value;
        public ObjectProperty<int> DataManaUsedPerSecond => _dataManaUsedPerSecond.Value;
        public ObjectProperty<int> DataExtraManaRequired => _dataExtraManaRequired.Value;
        private int GetDataDamagePerDuration(int level)
        {
            return _modifications[1684431689, level].ValueAsInt;
        }

        private void SetDataDamagePerDuration(int level, int value)
        {
            _modifications[1684431689, level] = new LevelObjectDataModification{Id = 1684431689, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataManaUsedPerSecond(int level)
        {
            return _modifications[1835426633, level].ValueAsInt;
        }

        private void SetDataManaUsedPerSecond(int level, int value)
        {
            _modifications[1835426633, level] = new LevelObjectDataModification{Id = 1835426633, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataExtraManaRequired(int level)
        {
            return _modifications[2019976009, level].ValueAsInt;
        }

        private void SetDataExtraManaRequired(int level, int value)
        {
            _modifications[2019976009, level] = new LevelObjectDataModification{Id = 2019976009, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }
    }
}