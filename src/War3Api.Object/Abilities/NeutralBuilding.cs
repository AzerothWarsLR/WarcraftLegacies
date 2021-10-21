using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class NeutralBuilding : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataActivationRadius;
        private readonly Lazy<ObjectProperty<int>> _dataInteractionTypeRaw;
        private readonly Lazy<ObjectProperty<InteractionFlags>> _dataInteractionType;
        private readonly Lazy<ObjectProperty<bool>> _dataShowSelectUnitButton;
        private readonly Lazy<ObjectProperty<bool>> _dataShowUnitIndicator;
        public NeutralBuilding(): base(1969581633)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public NeutralBuilding(int newId): base(1969581633, newId)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public NeutralBuilding(string newRawcode): base(1969581633, newRawcode)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public NeutralBuilding(ObjectDatabase db): base(1969581633, db)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public NeutralBuilding(int newId, ObjectDatabase db): base(1969581633, newId, db)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public NeutralBuilding(string newRawcode, ObjectDatabase db): base(1969581633, newRawcode, db)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public ObjectProperty<float> DataActivationRadius => _dataActivationRadius.Value;
        public ObjectProperty<int> DataInteractionTypeRaw => _dataInteractionTypeRaw.Value;
        public ObjectProperty<InteractionFlags> DataInteractionType => _dataInteractionType.Value;
        public ObjectProperty<bool> DataShowSelectUnitButton => _dataShowSelectUnitButton.Value;
        public ObjectProperty<bool> DataShowUnitIndicator => _dataShowUnitIndicator.Value;
        private float GetDataActivationRadius(int level)
        {
            return _modifications[829777230, level].ValueAsFloat;
        }

        private void SetDataActivationRadius(int level, float value)
        {
            _modifications[829777230, level] = new LevelObjectDataModification{Id = 829777230, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataInteractionTypeRaw(int level)
        {
            return _modifications[846554446, level].ValueAsInt;
        }

        private void SetDataInteractionTypeRaw(int level, int value)
        {
            _modifications[846554446, level] = new LevelObjectDataModification{Id = 846554446, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private InteractionFlags GetDataInteractionType(int level)
        {
            return GetDataInteractionTypeRaw(level).ToInteractionFlags(this);
        }

        private void SetDataInteractionType(int level, InteractionFlags value)
        {
            SetDataInteractionTypeRaw(level, value.ToRaw(null, null));
        }

        private bool GetDataShowSelectUnitButton(int level)
        {
            return _modifications[863331662, level].ValueAsBool;
        }

        private void SetDataShowSelectUnitButton(int level, bool value)
        {
            _modifications[863331662, level] = new LevelObjectDataModification{Id = 863331662, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetDataShowUnitIndicator(int level)
        {
            return _modifications[880108878, level].ValueAsBool;
        }

        private void SetDataShowUnitIndicator(int level, bool value)
        {
            _modifications[880108878, level] = new LevelObjectDataModification{Id = 880108878, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }
    }
}