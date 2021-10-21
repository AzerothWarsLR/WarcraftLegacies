using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AbsorbMana : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMaximumLifeAbsorbed;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumManaAbsorbed;
        public AbsorbMana(): base(1935827265)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
        }

        public AbsorbMana(int newId): base(1935827265, newId)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
        }

        public AbsorbMana(string newRawcode): base(1935827265, newRawcode)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
        }

        public AbsorbMana(ObjectDatabase db): base(1935827265, db)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
        }

        public AbsorbMana(int newId, ObjectDatabase db): base(1935827265, newId, db)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
        }

        public AbsorbMana(string newRawcode, ObjectDatabase db): base(1935827265, newRawcode, db)
        {
            _dataMaximumLifeAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumLifeAbsorbed, SetDataMaximumLifeAbsorbed));
            _dataMaximumManaAbsorbed = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumManaAbsorbed, SetDataMaximumManaAbsorbed));
        }

        public ObjectProperty<float> DataMaximumLifeAbsorbed => _dataMaximumLifeAbsorbed.Value;
        public ObjectProperty<float> DataMaximumManaAbsorbed => _dataMaximumManaAbsorbed.Value;
        private float GetDataMaximumLifeAbsorbed(int level)
        {
            return _modifications[829645409, level].ValueAsFloat;
        }

        private void SetDataMaximumLifeAbsorbed(int level, float value)
        {
            _modifications[829645409, level] = new LevelObjectDataModification{Id = 829645409, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMaximumManaAbsorbed(int level)
        {
            return _modifications[846422625, level].ValueAsFloat;
        }

        private void SetDataMaximumManaAbsorbed(int level, float value)
        {
            _modifications[846422625, level] = new LevelObjectDataModification{Id = 846422625, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}