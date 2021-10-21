using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SpiderAttack : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataSpiderCapacity;
        public SpiderAttack(): base(1634759489)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
        }

        public SpiderAttack(int newId): base(1634759489, newId)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
        }

        public SpiderAttack(string newRawcode): base(1634759489, newRawcode)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
        }

        public SpiderAttack(ObjectDatabase db): base(1634759489, db)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
        }

        public SpiderAttack(int newId, ObjectDatabase db): base(1634759489, newId, db)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
        }

        public SpiderAttack(string newRawcode, ObjectDatabase db): base(1634759489, newRawcode, db)
        {
            _dataSpiderCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSpiderCapacity, SetDataSpiderCapacity));
        }

        public ObjectProperty<int> DataSpiderCapacity => _dataSpiderCapacity.Value;
        private int GetDataSpiderCapacity(int level)
        {
            return _modifications[828469331, level].ValueAsInt;
        }

        private void SetDataSpiderCapacity(int level, int value)
        {
            _modifications[828469331, level] = new LevelObjectDataModification{Id = 828469331, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}