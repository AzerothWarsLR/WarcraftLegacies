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
    public sealed class NeutralRegenHealthOnly : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAmountOfHitPointsRegenerated;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAmountOfHitPointsRegeneratedModified;
        private readonly Lazy<ObjectProperty<int>> _dataPercentageRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPercentageModified;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentage;
        public NeutralRegenHealthOnly(): base(1919828801)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _isDataAmountOfHitPointsRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountOfHitPointsRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenHealthOnly(int newId): base(1919828801, newId)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _isDataAmountOfHitPointsRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountOfHitPointsRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenHealthOnly(string newRawcode): base(1919828801, newRawcode)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _isDataAmountOfHitPointsRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountOfHitPointsRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenHealthOnly(ObjectDatabaseBase db): base(1919828801, db)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _isDataAmountOfHitPointsRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountOfHitPointsRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenHealthOnly(int newId, ObjectDatabaseBase db): base(1919828801, newId, db)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _isDataAmountOfHitPointsRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountOfHitPointsRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public NeutralRegenHealthOnly(string newRawcode, ObjectDatabaseBase db): base(1919828801, newRawcode, db)
        {
            _dataAmountOfHitPointsRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountOfHitPointsRegenerated, SetDataAmountOfHitPointsRegenerated));
            _isDataAmountOfHitPointsRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAmountOfHitPointsRegeneratedModified));
            _dataPercentageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentageRaw, SetDataPercentageRaw));
            _isDataPercentageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentageModified));
            _dataPercentage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentage, SetDataPercentage));
        }

        public ObjectProperty<float> DataAmountOfHitPointsRegenerated => _dataAmountOfHitPointsRegenerated.Value;
        public ReadOnlyObjectProperty<bool> IsDataAmountOfHitPointsRegeneratedModified => _isDataAmountOfHitPointsRegeneratedModified.Value;
        public ObjectProperty<int> DataPercentageRaw => _dataPercentageRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataPercentageModified => _isDataPercentageModified.Value;
        public ObjectProperty<bool> DataPercentage => _dataPercentage.Value;
        private float GetDataAmountOfHitPointsRegenerated(int level)
        {
            return _modifications.GetModification(829579599, level).ValueAsFloat;
        }

        private void SetDataAmountOfHitPointsRegenerated(int level, float value)
        {
            _modifications[829579599, level] = new LevelObjectDataModification{Id = 829579599, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAmountOfHitPointsRegeneratedModified(int level)
        {
            return _modifications.ContainsKey(829579599, level);
        }

        private int GetDataPercentageRaw(int level)
        {
            return _modifications.GetModification(846356815, level).ValueAsInt;
        }

        private void SetDataPercentageRaw(int level, int value)
        {
            _modifications[846356815, level] = new LevelObjectDataModification{Id = 846356815, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataPercentageModified(int level)
        {
            return _modifications.ContainsKey(846356815, level);
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