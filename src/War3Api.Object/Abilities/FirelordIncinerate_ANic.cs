using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FirelordIncinerate_ANic : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataBonusDamageMultiplier;
        private readonly Lazy<ObjectProperty<float>> _dataDeathDamageFullAmount;
        private readonly Lazy<ObjectProperty<float>> _dataDeathDamageFullArea;
        private readonly Lazy<ObjectProperty<float>> _dataDeathDamageHalfAmount;
        private readonly Lazy<ObjectProperty<float>> _dataDeathDamageHalfArea;
        private readonly Lazy<ObjectProperty<float>> _dataDeathDamageDelay;
        public FirelordIncinerate_ANic(): base(1667845697)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
        }

        public FirelordIncinerate_ANic(int newId): base(1667845697, newId)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
        }

        public FirelordIncinerate_ANic(string newRawcode): base(1667845697, newRawcode)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
        }

        public FirelordIncinerate_ANic(ObjectDatabase db): base(1667845697, db)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
        }

        public FirelordIncinerate_ANic(int newId, ObjectDatabase db): base(1667845697, newId, db)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
        }

        public FirelordIncinerate_ANic(string newRawcode, ObjectDatabase db): base(1667845697, newRawcode, db)
        {
            _dataBonusDamageMultiplier = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageMultiplier, SetDataBonusDamageMultiplier));
            _dataDeathDamageFullAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullAmount, SetDataDeathDamageFullAmount));
            _dataDeathDamageFullArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageFullArea, SetDataDeathDamageFullArea));
            _dataDeathDamageHalfAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfAmount, SetDataDeathDamageHalfAmount));
            _dataDeathDamageHalfArea = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageHalfArea, SetDataDeathDamageHalfArea));
            _dataDeathDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDeathDamageDelay, SetDataDeathDamageDelay));
        }

        public ObjectProperty<float> DataBonusDamageMultiplier => _dataBonusDamageMultiplier.Value;
        public ObjectProperty<float> DataDeathDamageFullAmount => _dataDeathDamageFullAmount.Value;
        public ObjectProperty<float> DataDeathDamageFullArea => _dataDeathDamageFullArea.Value;
        public ObjectProperty<float> DataDeathDamageHalfAmount => _dataDeathDamageHalfAmount.Value;
        public ObjectProperty<float> DataDeathDamageHalfArea => _dataDeathDamageHalfArea.Value;
        public ObjectProperty<float> DataDeathDamageDelay => _dataDeathDamageDelay.Value;
        private float GetDataBonusDamageMultiplier(int level)
        {
            return _modifications[828598606, level].ValueAsFloat;
        }

        private void SetDataBonusDamageMultiplier(int level, float value)
        {
            _modifications[828598606, level] = new LevelObjectDataModification{Id = 828598606, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDeathDamageFullAmount(int level)
        {
            return _modifications[845375822, level].ValueAsFloat;
        }

        private void SetDataDeathDamageFullAmount(int level, float value)
        {
            _modifications[845375822, level] = new LevelObjectDataModification{Id = 845375822, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDeathDamageFullArea(int level)
        {
            return _modifications[862153038, level].ValueAsFloat;
        }

        private void SetDataDeathDamageFullArea(int level, float value)
        {
            _modifications[862153038, level] = new LevelObjectDataModification{Id = 862153038, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataDeathDamageHalfAmount(int level)
        {
            return _modifications[878930254, level].ValueAsFloat;
        }

        private void SetDataDeathDamageHalfAmount(int level, float value)
        {
            _modifications[878930254, level] = new LevelObjectDataModification{Id = 878930254, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataDeathDamageHalfArea(int level)
        {
            return _modifications[895707470, level].ValueAsFloat;
        }

        private void SetDataDeathDamageHalfArea(int level, float value)
        {
            _modifications[895707470, level] = new LevelObjectDataModification{Id = 895707470, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private float GetDataDeathDamageDelay(int level)
        {
            return _modifications[912484686, level].ValueAsFloat;
        }

        private void SetDataDeathDamageDelay(int level, float value)
        {
            _modifications[912484686, level] = new LevelObjectDataModification{Id = 912484686, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }
    }
}