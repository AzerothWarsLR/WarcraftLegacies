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
    public sealed class NeutralRegenManaOnly : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAmountRegenerated;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAmountRegeneratedModified;
        private readonly Lazy<ObjectProperty<int>> _dataPercentageRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPercentageModified;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentage;
        public NeutralRegenManaOnly(): base(1701989953)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _isDataAmountRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenManaOnly(int newId): base(1701989953, newId)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _isDataAmountRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenManaOnly(string newRawcode): base(1701989953, newRawcode)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _isDataAmountRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenManaOnly(ObjectDatabaseBase db): base(1701989953, db)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _isDataAmountRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenManaOnly(int newId, ObjectDatabaseBase db): base(1701989953, newId, db)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _isDataAmountRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenManaOnly(string newRawcode, ObjectDatabaseBase db): base(1701989953, newRawcode, db)
        {
            _dataAmountRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountRegenerated, SetDataAmountRegenerated));
            _isDataAmountRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public ObjectProperty<float> DataAmountRegenerated => _dataAmountRegenerated.Value;
        public ReadOnlyObjectProperty<bool> IsDataAmountRegeneratedModified => _isDataAmountRegeneratedModified.Value;
        public ObjectProperty<int> DataPercentageRaw => _dataPercentageRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataPercentageModified => _isDataPercentageModified.Value;
        public ObjectProperty<bool> DataPercentage => _dataPercentage.Value;
        private float GetDataAmountRegenerated(int level)
        {
            return _modifications.GetModification(829256257, level).ValueAsFloat;
        }

        private void SetDataAmountRegenerated(int level, float value)
        {
            _modifications[829256257, level] = new LevelObjectDataModification{Id = 829256257, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAmountRegeneratedModified(int level)
        {
            return _modifications.ContainsKey(829256257, level);
        }

        private int GetDataPercentageRaw(int level)
        {
            return _modifications.GetModification(846033473, level).ValueAsInt;
        }

        private void SetDataPercentageRaw(int level, int value)
        {
            _modifications[846033473, level] = new LevelObjectDataModification{Id = 846033473, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataPercentageModified(int level)
        {
            return _modifications.ContainsKey(846033473, level);
        }

        private bool GetDataPercentage(int level)
        {
            return GetDataPercentageRaw(level).ToBool(this);
        }

        private void SetDataPercentage(int level, bool value)
        {
            SetDataPercentageRaw(level, value.ToRaw(0, 1));
        }
    }
}