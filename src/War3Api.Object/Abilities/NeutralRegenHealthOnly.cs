using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class NeutralRegenHealthOnly : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAmountOfHitPointsRegenerated;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentage;
        public NeutralRegenHealthOnly(): base(1919828801)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenHealthOnly(int newId): base(1919828801, newId)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenHealthOnly(string newRawcode): base(1919828801, newRawcode)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenHealthOnly(ObjectDatabase db): base(1919828801, db)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenHealthOnly(int newId, ObjectDatabase db): base(1919828801, newId, db)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenHealthOnly(string newRawcode, ObjectDatabase db): base(1919828801, newRawcode, db)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public ObjectProperty<float> DataAmountOfHitPointsRegenerated => _dataAmountOfHitPointsRegenerated.Value;
        public ObjectProperty<bool> DataPercentage => _dataPercentage.Value;
        private float GetDataAmountOfHitPointsRegenerated(int level)
        {
            return _modifications[829579599, level].ValueAsFloat;
        }

        private void SetDataAmountOfHitPointsRegenerated(int level, float value)
        {
            _modifications[829579599, level] = new LevelObjectDataModification{Id = 829579599, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetDataPercentage(int level)
        {
            return _modifications[846356815, level].ValueAsBool;
        }

        private void SetDataPercentage(int level, bool value)
        {
            _modifications[846356815, level] = new LevelObjectDataModification{Id = 846356815, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }
    }
}