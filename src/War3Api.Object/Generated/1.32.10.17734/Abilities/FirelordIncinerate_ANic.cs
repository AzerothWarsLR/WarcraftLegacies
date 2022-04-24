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
    public sealed class FirelordIncinerate_ANic : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataBonusDamageMultiplier;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBonusDamageMultiplierModified;
        private readonly Lazy<ObjectProperty<float>> _dataDeathDamageFullAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDeathDamageFullAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataDeathDamageFullArea;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDeathDamageFullAreaModified;
        private readonly Lazy<ObjectProperty<float>> _dataDeathDamageHalfAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDeathDamageHalfAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataDeathDamageHalfArea;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDeathDamageHalfAreaModified;
        private readonly Lazy<ObjectProperty<float>> _dataDeathDamageDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDeathDamageDelayModified;
        public FirelordIncinerate_ANic(): base(1667845697)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _isDataBonusDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageMultiplierModified));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _isDataDeathDamageFullAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAmountModified));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _isDataDeathDamageFullAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAreaModified));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _isDataDeathDamageHalfAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAmountModified));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _isDataDeathDamageHalfAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAreaModified));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
            _isDataDeathDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageDelayModified));
        }

        public FirelordIncinerate_ANic(int newId): base(1667845697, newId)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _isDataBonusDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageMultiplierModified));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _isDataDeathDamageFullAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAmountModified));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _isDataDeathDamageFullAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAreaModified));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _isDataDeathDamageHalfAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAmountModified));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _isDataDeathDamageHalfAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAreaModified));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
            _isDataDeathDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageDelayModified));
        }

        public FirelordIncinerate_ANic(string newRawcode): base(1667845697, newRawcode)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _isDataBonusDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageMultiplierModified));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _isDataDeathDamageFullAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAmountModified));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _isDataDeathDamageFullAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAreaModified));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _isDataDeathDamageHalfAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAmountModified));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _isDataDeathDamageHalfAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAreaModified));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
            _isDataDeathDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageDelayModified));
        }

        public FirelordIncinerate_ANic(ObjectDatabaseBase db): base(1667845697, db)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _isDataBonusDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageMultiplierModified));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _isDataDeathDamageFullAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAmountModified));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _isDataDeathDamageFullAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAreaModified));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _isDataDeathDamageHalfAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAmountModified));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _isDataDeathDamageHalfAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAreaModified));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
            _isDataDeathDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageDelayModified));
        }

        public FirelordIncinerate_ANic(int newId, ObjectDatabaseBase db): base(1667845697, newId, db)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _isDataBonusDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageMultiplierModified));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _isDataDeathDamageFullAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAmountModified));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _isDataDeathDamageFullAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAreaModified));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _isDataDeathDamageHalfAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAmountModified));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _isDataDeathDamageHalfAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAreaModified));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
            _isDataDeathDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageDelayModified));
        }

        public FirelordIncinerate_ANic(string newRawcode, ObjectDatabaseBase db): base(1667845697, newRawcode, db)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _isDataBonusDamageMultiplierModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageMultiplierModified));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _isDataDeathDamageFullAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAmountModified));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _isDataDeathDamageFullAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageFullAreaModified));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _isDataDeathDamageHalfAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAmountModified));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _isDataDeathDamageHalfAreaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageHalfAreaModified));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
            _isDataDeathDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDeathDamageDelayModified));
        }

        public ObjectProperty<float> DataBonusDamageMultiplier => _dataBonusDamageMultiplier.Value;
        public ReadOnlyObjectProperty<bool> IsDataBonusDamageMultiplierModified => _isDataBonusDamageMultiplierModified.Value;
        public ObjectProperty<float> DataDeathDamageFullAmount => _dataDeathDamageFullAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataDeathDamageFullAmountModified => _isDataDeathDamageFullAmountModified.Value;
        public ObjectProperty<float> DataDeathDamageFullArea => _dataDeathDamageFullArea.Value;
        public ReadOnlyObjectProperty<bool> IsDataDeathDamageFullAreaModified => _isDataDeathDamageFullAreaModified.Value;
        public ObjectProperty<float> DataDeathDamageHalfAmount => _dataDeathDamageHalfAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataDeathDamageHalfAmountModified => _isDataDeathDamageHalfAmountModified.Value;
        public ObjectProperty<float> DataDeathDamageHalfArea => _dataDeathDamageHalfArea.Value;
        public ReadOnlyObjectProperty<bool> IsDataDeathDamageHalfAreaModified => _isDataDeathDamageHalfAreaModified.Value;
        public ObjectProperty<float> DataDeathDamageDelay => _dataDeathDamageDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataDeathDamageDelayModified => _isDataDeathDamageDelayModified.Value;
        private float GetDataBonusDamageMultiplier(int level)
        {
            return _modifications.GetModification(828598606, level).ValueAsFloat;
        }

        private void SetDataBonusDamageMultiplier(int level, float value)
        {
            _modifications[828598606, level] = new LevelObjectDataModification{Id = 828598606, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataBonusDamageMultiplierModified(int level)
        {
            return _modifications.ContainsKey(828598606, level);
        }

        private float GetDataDeathDamageFullAmount(int level)
        {
            return _modifications.GetModification(845375822, level).ValueAsFloat;
        }

        private void SetDataDeathDamageFullAmount(int level, float value)
        {
            _modifications[845375822, level] = new LevelObjectDataModification{Id = 845375822, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDeathDamageFullAmountModified(int level)
        {
            return _modifications.ContainsKey(845375822, level);
        }

        private float GetDataDeathDamageFullArea(int level)
        {
            return _modifications.GetModification(862153038, level).ValueAsFloat;
        }

        private void SetDataDeathDamageFullArea(int level, float value)
        {
            _modifications[862153038, level] = new LevelObjectDataModification{Id = 862153038, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDeathDamageFullAreaModified(int level)
        {
            return _modifications.ContainsKey(862153038, level);
        }

        private float GetDataDeathDamageHalfAmount(int level)
        {
            return _modifications.GetModification(878930254, level).ValueAsFloat;
        }

        private void SetDataDeathDamageHalfAmount(int level, float value)
        {
            _modifications[878930254, level] = new LevelObjectDataModification{Id = 878930254, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataDeathDamageHalfAmountModified(int level)
        {
            return _modifications.ContainsKey(878930254, level);
        }

        private float GetDataDeathDamageHalfArea(int level)
        {
            return _modifications.GetModification(895707470, level).ValueAsFloat;
        }

        private void SetDataDeathDamageHalfArea(int level, float value)
        {
            _modifications[895707470, level] = new LevelObjectDataModification{Id = 895707470, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataDeathDamageHalfAreaModified(int level)
        {
            return _modifications.ContainsKey(895707470, level);
        }

        private float GetDataDeathDamageDelay(int level)
        {
            return _modifications.GetModification(912484686, level).ValueAsFloat;
        }

        private void SetDataDeathDamageDelay(int level, float value)
        {
            _modifications[912484686, level] = new LevelObjectDataModification{Id = 912484686, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataDeathDamageDelayModified(int level)
        {
            return _modifications.ContainsKey(912484686, level);
        }
    }
}