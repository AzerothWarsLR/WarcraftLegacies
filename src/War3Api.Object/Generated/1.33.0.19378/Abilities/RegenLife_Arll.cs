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
    public sealed class RegenLife_Arll : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsRegeneratedPerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointsRegeneratedPerSecondModified;
        public RegenLife_Arll(): base(1819046465)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
            _isDataHitPointsRegeneratedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRegeneratedPerSecondModified));
        }

        public RegenLife_Arll(int newId): base(1819046465, newId)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
            _isDataHitPointsRegeneratedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRegeneratedPerSecondModified));
        }

        public RegenLife_Arll(string newRawcode): base(1819046465, newRawcode)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
            _isDataHitPointsRegeneratedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRegeneratedPerSecondModified));
        }

        public RegenLife_Arll(ObjectDatabaseBase db): base(1819046465, db)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
            _isDataHitPointsRegeneratedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRegeneratedPerSecondModified));
        }

        public RegenLife_Arll(int newId, ObjectDatabaseBase db): base(1819046465, newId, db)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
            _isDataHitPointsRegeneratedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsRegeneratedPerSecondModified));
        }

        public RegenLife_Arll(string newRawcode, ObjectDatabaseBase db): base(1819046465, newRawcode, db)
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