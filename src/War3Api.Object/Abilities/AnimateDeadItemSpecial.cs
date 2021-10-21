using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AnimateDeadItemSpecial : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataInheritUpgrades;
        public AnimateDeadItemSpecial(): base(1684949313)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public AnimateDeadItemSpecial(int newId): base(1684949313, newId)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public AnimateDeadItemSpecial(string newRawcode): base(1684949313, newRawcode)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public AnimateDeadItemSpecial(ObjectDatabase db): base(1684949313, db)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public AnimateDeadItemSpecial(int newId, ObjectDatabase db): base(1684949313, newId, db)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public AnimateDeadItemSpecial(string newRawcode, ObjectDatabase db): base(1684949313, newRawcode, db)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public ObjectProperty<bool> DataInheritUpgrades => _dataInheritUpgrades.Value;
        private bool GetDataInheritUpgrades(int level)
        {
            return _modifications[862871893, level].ValueAsBool;
        }

        private void SetDataInheritUpgrades(int level, bool value)
        {
            _modifications[862871893, level] = new LevelObjectDataModification{Id = 862871893, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }
    }
}