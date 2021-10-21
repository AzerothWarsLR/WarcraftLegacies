using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AncestralSpirit : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeRestoredFactor;
        private readonly Lazy<ObjectProperty<float>> _dataManaRestoredFactor;
        public AncestralSpirit(): base(1953718593)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
        }

        public AncestralSpirit(int newId): base(1953718593, newId)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
        }

        public AncestralSpirit(string newRawcode): base(1953718593, newRawcode)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
        }

        public AncestralSpirit(ObjectDatabase db): base(1953718593, db)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
        }

        public AncestralSpirit(int newId, ObjectDatabase db): base(1953718593, newId, db)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
        }

        public AncestralSpirit(string newRawcode, ObjectDatabase db): base(1953718593, newRawcode, db)
        {
            _dataLifeRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRestoredFactor, SetDataLifeRestoredFactor));
            _dataManaRestoredFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRestoredFactor, SetDataManaRestoredFactor));
        }

        public ObjectProperty<float> DataLifeRestoredFactor => _dataLifeRestoredFactor.Value;
        public ObjectProperty<float> DataManaRestoredFactor => _dataManaRestoredFactor.Value;
        private float GetDataLifeRestoredFactor(int level)
        {
            return _modifications[829715297, level].ValueAsFloat;
        }

        private void SetDataLifeRestoredFactor(int level, float value)
        {
            _modifications[829715297, level] = new LevelObjectDataModification{Id = 829715297, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataManaRestoredFactor(int level)
        {
            return _modifications[846492513, level].ValueAsFloat;
        }

        private void SetDataManaRestoredFactor(int level, float value)
        {
            _modifications[846492513, level] = new LevelObjectDataModification{Id = 846492513, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}