using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class RegenLife_Arel : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsRegeneratedPerSecond;
        public RegenLife_Arel(): base(1818587713)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
        }

        public RegenLife_Arel(int newId): base(1818587713, newId)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
        }

        public RegenLife_Arel(string newRawcode): base(1818587713, newRawcode)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
        }

        public RegenLife_Arel(ObjectDatabase db): base(1818587713, db)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
        }

        public RegenLife_Arel(int newId, ObjectDatabase db): base(1818587713, newId, db)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
        }

        public RegenLife_Arel(string newRawcode, ObjectDatabase db): base(1818587713, newRawcode, db)
        {
            _dataHitPointsRegeneratedPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsRegeneratedPerSecond, SetDataHitPointsRegeneratedPerSecond));
        }

        public ObjectProperty<int> DataHitPointsRegeneratedPerSecond => _dataHitPointsRegeneratedPerSecond.Value;
        private int GetDataHitPointsRegeneratedPerSecond(int level)
        {
            return _modifications[1919969353, level].ValueAsInt;
        }

        private void SetDataHitPointsRegeneratedPerSecond(int level, int value)
        {
            _modifications[1919969353, level] = new LevelObjectDataModification{Id = 1919969353, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}