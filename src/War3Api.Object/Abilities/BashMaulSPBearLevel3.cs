using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BashMaulSPBearLevel3 : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataNeverMiss;
        public BashMaulSPBearLevel3(): base(845303361)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashMaulSPBearLevel3(int newId): base(845303361, newId)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashMaulSPBearLevel3(string newRawcode): base(845303361, newRawcode)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashMaulSPBearLevel3(ObjectDatabase db): base(845303361, db)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashMaulSPBearLevel3(int newId, ObjectDatabase db): base(845303361, newId, db)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashMaulSPBearLevel3(string newRawcode, ObjectDatabase db): base(845303361, newRawcode, db)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public ObjectProperty<bool> DataNeverMiss => _dataNeverMiss.Value;
        private bool GetDataNeverMiss(int level)
        {
            return _modifications[896033352, level].ValueAsBool;
        }

        private void SetDataNeverMiss(int level, bool value)
        {
            _modifications[896033352, level] = new LevelObjectDataModification{Id = 896033352, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }
    }
}