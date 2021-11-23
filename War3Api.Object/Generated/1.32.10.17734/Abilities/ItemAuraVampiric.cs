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
    public sealed class ItemAuraVampiric : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataData;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDataModified;
        public ItemAuraVampiric(): base(1986087233)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
        }

        public ItemAuraVampiric(int newId): base(1986087233, newId)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
        }

        public ItemAuraVampiric(string newRawcode): base(1986087233, newRawcode)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
        }

        public ItemAuraVampiric(ObjectDatabaseBase db): base(1986087233, db)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
        }

        public ItemAuraVampiric(int newId, ObjectDatabaseBase db): base(1986087233, newId, db)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
        }

        public ItemAuraVampiric(string newRawcode, ObjectDatabaseBase db): base(1986087233, newRawcode, db)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
        }

        public ObjectProperty<float> DataData => _dataData.Value;
        public ReadOnlyObjectProperty<bool> IsDataDataModified => _isDataDataModified.Value;
        private float GetDataData(int level)
        {
            return _modifications.GetModification(829841749, level).ValueAsFloat;
        }

        private void SetDataData(int level, float value)
        {
            _modifications[829841749, level] = new LevelObjectDataModification{Id = 829841749, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDataModified(int level)
        {
            return _modifications.ContainsKey(829841749, level);
        }
    }
}