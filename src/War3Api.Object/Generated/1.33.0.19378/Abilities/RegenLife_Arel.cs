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
    public sealed class RegenLife_Arel : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsRegeneratedPerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointsRegeneratedPerSecondModified;
        public RegenLife_Arel(): base(1818587713)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
            _isDataHitPointsRegeneratedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRegeneratedPerSecondModified));
        }

        public RegenLife_Arel(int newId): base(1818587713, newId)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
            _isDataHitPointsRegeneratedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRegeneratedPerSecondModified));
        }

        public RegenLife_Arel(string newRawcode): base(1818587713, newRawcode)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
            _isDataHitPointsRegeneratedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRegeneratedPerSecondModified));
        }

        public RegenLife_Arel(ObjectDatabaseBase db): base(1818587713, db)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
            _isDataHitPointsRegeneratedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRegeneratedPerSecondModified));
        }

        public RegenLife_Arel(int newId, ObjectDatabaseBase db): base(1818587713, newId, db)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
            _isDataHitPointsRegeneratedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRegeneratedPerSecondModified));
        }

        public RegenLife_Arel(string newRawcode, ObjectDatabaseBase db): base(1818587713, newRawcode, db)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
            _isDataHitPointsRegeneratedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRegeneratedPerSecondModified));
        }

        public ObjectProperty<int> DataHitPointsRegeneratedPerSecond => _dataHitPointsRegeneratedPerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataHitPointsRegeneratedPerSecondModified => _isDataHitPointsRegeneratedPerSecondModified.Value;
        private int GetDataHitPointsRegeneratedPerSecond(int level)
        {
            return _modifications.GetModification(1919969353, level).ValueAsInt;
        }

        private void SetDataHitPointsRegeneratedPerSecond(int level, int value)
        {
            _modifications[1919969353, level] = new LevelObjectDataModification{Id = 1919969353, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataHitPointsRegeneratedPerSecondModified(int level)
        {
            return _modifications.ContainsKey(1919969353, level);
        }
    }
}