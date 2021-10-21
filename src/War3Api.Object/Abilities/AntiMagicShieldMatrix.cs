using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AntiMagicShieldMatrix : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataManaLoss;
        public AntiMagicShieldMatrix(): base(846029121)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public AntiMagicShieldMatrix(int newId): base(846029121, newId)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public AntiMagicShieldMatrix(string newRawcode): base(846029121, newRawcode)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public AntiMagicShieldMatrix(ObjectDatabase db): base(846029121, db)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public AntiMagicShieldMatrix(int newId, ObjectDatabase db): base(846029121, newId, db)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public AntiMagicShieldMatrix(string newRawcode, ObjectDatabase db): base(846029121, newRawcode, db)
        {
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public ObjectProperty<int> DataManaLoss => _dataManaLoss.Value;
        private int GetDataManaLoss(int level)
        {
            return _modifications[879979841, level].ValueAsInt;
        }

        private void SetDataManaLoss(int level, int value)
        {
            _modifications[879979841, level] = new LevelObjectDataModification{Id = 879979841, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }
    }
}