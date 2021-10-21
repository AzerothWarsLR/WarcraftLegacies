using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DevourMagicCreep : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataIgnoreFriendlyBuffs;
        public DevourMagicCreep(): base(1701069633)
        {
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagicCreep(int newId): base(1701069633, newId)
        {
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagicCreep(string newRawcode): base(1701069633, newRawcode)
        {
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagicCreep(ObjectDatabase db): base(1701069633, db)
        {
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagicCreep(int newId, ObjectDatabase db): base(1701069633, newId, db)
        {
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public DevourMagicCreep(string newRawcode, ObjectDatabase db): base(1701069633, newRawcode, db)
        {
            _dataIgnoreFriendlyBuffs = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIgnoreFriendlyBuffs, SetDataIgnoreFriendlyBuffs));
        }

        public ObjectProperty<bool> DataIgnoreFriendlyBuffs => _dataIgnoreFriendlyBuffs.Value;
        private bool GetDataIgnoreFriendlyBuffs(int level)
        {
            return _modifications[913143396, level].ValueAsBool;
        }

        private void SetDataIgnoreFriendlyBuffs(int level, bool value)
        {
            _modifications[913143396, level] = new LevelObjectDataModification{Id = 913143396, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 6};
        }
    }
}