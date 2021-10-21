using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ReincarnationCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataReincarnationDelay;
        public ReincarnationCreep(): base(1852982081)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
        }

        public ReincarnationCreep(int newId): base(1852982081, newId)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
        }

        public ReincarnationCreep(string newRawcode): base(1852982081, newRawcode)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
        }

        public ReincarnationCreep(ObjectDatabase db): base(1852982081, db)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
        }

        public ReincarnationCreep(int newId, ObjectDatabase db): base(1852982081, newId, db)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
        }

        public ReincarnationCreep(string newRawcode, ObjectDatabase db): base(1852982081, newRawcode, db)
        {
            _dataReincarnationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataReincarnationDelay, SetDataReincarnationDelay));
        }

        public ObjectProperty<float> DataReincarnationDelay => _dataReincarnationDelay.Value;
        private float GetDataReincarnationDelay(int level)
        {
            return _modifications[828731983, level].ValueAsFloat;
        }

        private void SetDataReincarnationDelay(int level, float value)
        {
            _modifications[828731983, level] = new LevelObjectDataModification{Id = 828731983, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}