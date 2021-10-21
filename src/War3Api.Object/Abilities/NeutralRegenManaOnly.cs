using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class NeutralRegenManaOnly : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAmountRegenerated;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentage;
        public NeutralRegenManaOnly(): base(1701989953)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenManaOnly(int newId): base(1701989953, newId)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenManaOnly(string newRawcode): base(1701989953, newRawcode)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenManaOnly(ObjectDatabase db): base(1701989953, db)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenManaOnly(int newId, ObjectDatabase db): base(1701989953, newId, db)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenManaOnly(string newRawcode, ObjectDatabase db): base(1701989953, newRawcode, db)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public ObjectProperty<float> DataAmountRegenerated => _dataAmountRegenerated.Value;
        public ObjectProperty<bool> DataPercentage => _dataPercentage.Value;
        private float GetDataAmountRegenerated(int level)
        {
            return _modifications[829256257, level].ValueAsFloat;
        }

        private void SetDataAmountRegenerated(int level, float value)
        {
            _modifications[829256257, level] = new LevelObjectDataModification{Id = 829256257, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetDataPercentage(int level)
        {
            return _modifications[846033473, level].ValueAsBool;
        }

        private void SetDataPercentage(int level, bool value)
        {
            _modifications[846033473, level] = new LevelObjectDataModification{Id = 846033473, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }
    }
}