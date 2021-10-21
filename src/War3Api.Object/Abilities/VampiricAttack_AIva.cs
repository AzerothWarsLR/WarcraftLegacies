using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class VampiricAttack_AIva : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeStolenPerAttack;
        public VampiricAttack_AIva(): base(1635141953)
        {
            _dataLifeStolenPerAttack = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStolenPerAttack, SetDataLifeStolenPerAttack));
        }

        public VampiricAttack_AIva(int newId): base(1635141953, newId)
        {
            _dataLifeStolenPerAttack = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStolenPerAttack, SetDataLifeStolenPerAttack));
        }

        public VampiricAttack_AIva(string newRawcode): base(1635141953, newRawcode)
        {
            _dataLifeStolenPerAttack = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStolenPerAttack, SetDataLifeStolenPerAttack));
        }

        public VampiricAttack_AIva(ObjectDatabase db): base(1635141953, db)
        {
            _dataLifeStolenPerAttack = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStolenPerAttack, SetDataLifeStolenPerAttack));
        }

        public VampiricAttack_AIva(int newId, ObjectDatabase db): base(1635141953, newId, db)
        {
            _dataLifeStolenPerAttack = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStolenPerAttack, SetDataLifeStolenPerAttack));
        }

        public VampiricAttack_AIva(string newRawcode, ObjectDatabase db): base(1635141953, newRawcode, db)
        {
            _dataLifeStolenPerAttack = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeStolenPerAttack, SetDataLifeStolenPerAttack));
        }

        public ObjectProperty<float> DataLifeStolenPerAttack => _dataLifeStolenPerAttack.Value;
        private float GetDataLifeStolenPerAttack(int level)
        {
            return _modifications[1835103817, level].ValueAsFloat;
        }

        private void SetDataLifeStolenPerAttack(int level, float value)
        {
            _modifications[1835103817, level] = new LevelObjectDataModification{Id = 1835103817, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}