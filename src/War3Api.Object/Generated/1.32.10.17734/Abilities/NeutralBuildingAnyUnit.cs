using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class NeutralBuildingAnyUnit : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataActivationRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataActivationRadiusModified;
        private readonly Lazy<ObjectProperty<int>> _dataInteractionTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataInteractionTypeModified;
        private readonly Lazy<ObjectProperty<InteractionFlags>> _dataInteractionType;
        private readonly Lazy<ObjectProperty<int>> _dataShowSelectUnitButtonRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataShowSelectUnitButtonModified;
        private readonly Lazy<ObjectProperty<bool>> _dataShowSelectUnitButton;
        private readonly Lazy<ObjectProperty<int>> _dataShowUnitIndicatorRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataShowUnitIndicatorModified;
        private readonly Lazy<ObjectProperty<bool>> _dataShowUnitIndicator;
        public NeutralBuildingAnyUnit(): base(845508161)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _isDataActivationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationRadiusModified));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _isDataInteractionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInteractionTypeModified));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowSelectUnitButtonRaw, SetDataShowSelectUnitButtonRaw));
            _isDataShowSelectUnitButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowSelectUnitButtonModified));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicatorRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowUnitIndicatorRaw, SetDataShowUnitIndicatorRaw));
            _isDataShowUnitIndicatorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowUnitIndicatorModified));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public NeutralBuildingAnyUnit(int newId): base(845508161, newId)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _isDataActivationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationRadiusModified));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _isDataInteractionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInteractionTypeModified));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowSelectUnitButtonRaw, SetDataShowSelectUnitButtonRaw));
            _isDataShowSelectUnitButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowSelectUnitButtonModified));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicatorRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowUnitIndicatorRaw, SetDataShowUnitIndicatorRaw));
            _isDataShowUnitIndicatorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowUnitIndicatorModified));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public NeutralBuildingAnyUnit(string newRawcode): base(845508161, newRawcode)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _isDataActivationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationRadiusModified));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _isDataInteractionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInteractionTypeModified));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowSelectUnitButtonRaw, SetDataShowSelectUnitButtonRaw));
            _isDataShowSelectUnitButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowSelectUnitButtonModified));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicatorRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowUnitIndicatorRaw, SetDataShowUnitIndicatorRaw));
            _isDataShowUnitIndicatorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowUnitIndicatorModified));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public NeutralBuildingAnyUnit(ObjectDatabaseBase db): base(845508161, db)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _isDataActivationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationRadiusModified));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _isDataInteractionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInteractionTypeModified));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowSelectUnitButtonRaw, SetDataShowSelectUnitButtonRaw));
            _isDataShowSelectUnitButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowSelectUnitButtonModified));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicatorRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowUnitIndicatorRaw, SetDataShowUnitIndicatorRaw));
            _isDataShowUnitIndicatorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowUnitIndicatorModified));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public NeutralBuildingAnyUnit(int newId, ObjectDatabaseBase db): base(845508161, newId, db)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _isDataActivationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationRadiusModified));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _isDataInteractionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInteractionTypeModified));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowSelectUnitButtonRaw, SetDataShowSelectUnitButtonRaw));
            _isDataShowSelectUnitButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowSelectUnitButtonModified));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicatorRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowUnitIndicatorRaw, SetDataShowUnitIndicatorRaw));
            _isDataShowUnitIndicatorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowUnitIndicatorModified));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public NeutralBuildingAnyUnit(string newRawcode, ObjectDatabaseBase db): base(845508161, newRawcode, db)
        {
            _dataActivationRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActivationRadius, SetDataActivationRadius));
            _isDataActivationRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataActivationRadiusModified));
            _dataInteractionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInteractionTypeRaw, SetDataInteractionTypeRaw));
            _isDataInteractionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInteractionTypeModified));
            _dataInteractionType = new Lazy<ObjectProperty<InteractionFlags>>(() => new ObjectProperty<InteractionFlags>(GetDataInteractionType, SetDataInteractionType));
            _dataShowSelectUnitButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowSelectUnitButtonRaw, SetDataShowSelectUnitButtonRaw));
            _isDataShowSelectUnitButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowSelectUnitButtonModified));
            _dataShowSelectUnitButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowSelectUnitButton, SetDataShowSelectUnitButton));
            _dataShowUnitIndicatorRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataShowUnitIndicatorRaw, SetDataShowUnitIndicatorRaw));
            _isDataShowUnitIndicatorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataShowUnitIndicatorModified));
            _dataShowUnitIndicator = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataShowUnitIndicator, SetDataShowUnitIndicator));
        }

        public ObjectProperty<float> DataActivationRadius => _dataActivationRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataActivationRadiusModified => _isDataActivationRadiusModified.Value;
        public ObjectProperty<int> DataInteractionTypeRaw => _dataInteractionTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataInteractionTypeModified => _isDataInteractionTypeModified.Value;
        public ObjectProperty<InteractionFlags> DataInteractionType => _dataInteractionType.Value;
        public ObjectProperty<int> DataShowSelectUnitButtonRaw => _dataShowSelectUnitButtonRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataShowSelectUnitButtonModified => _isDataShowSelectUnitButtonModified.Value;
        public ObjectProperty<bool> DataShowSelectUnitButton => _dataShowSelectUnitButton.Value;
        public ObjectProperty<int> DataShowUnitIndicatorRaw => _dataShowUnitIndicatorRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataShowUnitIndicatorModified => _isDataShowUnitIndicatorModified.Value;
        public ObjectProperty<bool> DataShowUnitIndicator => _dataShowUnitIndicator.Value;
        private float GetDataActivationRadius(int level)
        {
            return _modifications.GetModification(829777230, level).ValueAsFloat;
        }

        private void SetDataActivationRadius(int level, float value)
        {
            _modifications[829777230, level] = new LevelObjectDataModification{Id = 829777230, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataActivationRadiusModified(int level)
        {
            return _modifications.ContainsKey(829777230, level);
        }

        private int GetDataInteractionTypeRaw(int level)
        {
            return _modifications.GetModification(846554446, level).ValueAsInt;
        }

        private void SetDataInteractionTypeRaw(int level, int value)
        {
            _modifications[846554446, level] = new LevelObjectDataModification{Id = 846554446, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataInteractionTypeModified(int level)
        {
            return _modifications.ContainsKey(846554446, level);
        }

        private InteractionFlags GetDataInteractionType(int level)
        {
            return GetDataInteractionTypeRaw(level).ToInteractionFlags(this);
        }

        private void SetDataInteractionType(int level, InteractionFlags value)
        {
            SetDataInteractionTypeRaw(level, value.ToRaw(null, null));
        }

        private int GetDataShowSelectUnitButtonRaw(int level)
        {
            return _modifications.GetModification(863331662, level).ValueAsInt;
        }

        private void SetDataShowSelectUnitButtonRaw(int level, int value)
        {
            _modifications[863331662, level] = new LevelObjectDataModification{Id = 863331662, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataShowSelectUnitButtonModified(int level)
        {
            return _modifications.ContainsKey(863331662, level);
        }

        private bool GetDataShowSelectUnitButton(int level)
        {
            return GetDataShowSelectUnitButtonRaw(level).ToBool(this);
        }

        private void SetDataShowSelectUnitButton(int level, bool value)
        {
            SetDataShowSelectUnitButtonRaw(level, value.ToRaw(null, null));
        }

        private int GetDataShowUnitIndicatorRaw(int level)
        {
            return _modifications.GetModification(880108878, level).ValueAsInt;
        }

        private void SetDataShowUnitIndicatorRaw(int level, int value)
        {
            _modifications[880108878, level] = new LevelObjectDataModification{Id = 880108878, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataShowUnitIndicatorModified(int level)
        {
            return _modifications.ContainsKey(880108878, level);
        }

        private bool GetDataShowUnitIndicator(int level)
        {
            return GetDataShowUnitIndicatorRaw(level).ToBool(this);
        }

        private void SetDataShowUnitIndicator(int level, bool value)
        {
            SetDataShowUnitIndicatorRaw(level, value.ToRaw(null, null));
        }
    }
}