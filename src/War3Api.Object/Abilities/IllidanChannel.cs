using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class IllidanChannel : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataFollowThroughTime;
        private readonly Lazy<ObjectProperty<int>> _dataTargetTypeRaw;
        private readonly Lazy<ObjectProperty<ChannelType>> _dataTargetType;
        private readonly Lazy<ObjectProperty<int>> _dataOptionsRaw;
        private readonly Lazy<ObjectProperty<ChannelFlags>> _dataOptions;
        private readonly Lazy<ObjectProperty<float>> _dataArtDuration;
        private readonly Lazy<ObjectProperty<bool>> _dataDisableOtherAbilities;
        private readonly Lazy<ObjectProperty<string>> _dataBaseOrderIDRaw;
        private readonly Lazy<ObjectProperty<string>> _dataBaseOrderID;
        public IllidanChannel(): base(1818447425)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public IllidanChannel(int newId): base(1818447425, newId)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public IllidanChannel(string newRawcode): base(1818447425, newRawcode)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public IllidanChannel(ObjectDatabase db): base(1818447425, db)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public IllidanChannel(int newId, ObjectDatabase db): base(1818447425, newId, db)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public IllidanChannel(string newRawcode, ObjectDatabase db): base(1818447425, newRawcode, db)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public ObjectProperty<float> DataFollowThroughTime => _dataFollowThroughTime.Value;
        public ObjectProperty<int> DataTargetTypeRaw => _dataTargetTypeRaw.Value;
        public ObjectProperty<ChannelType> DataTargetType => _dataTargetType.Value;
        public ObjectProperty<int> DataOptionsRaw => _dataOptionsRaw.Value;
        public ObjectProperty<ChannelFlags> DataOptions => _dataOptions.Value;
        public ObjectProperty<float> DataArtDuration => _dataArtDuration.Value;
        public ObjectProperty<bool> DataDisableOtherAbilities => _dataDisableOtherAbilities.Value;
        public ObjectProperty<string> DataBaseOrderIDRaw => _dataBaseOrderIDRaw.Value;
        public ObjectProperty<string> DataBaseOrderID => _dataBaseOrderID.Value;
        private float GetDataFollowThroughTime(int level)
        {
            return _modifications[829186894, level].ValueAsFloat;
        }

        private void SetDataFollowThroughTime(int level, float value)
        {
            _modifications[829186894, level] = new LevelObjectDataModification{Id = 829186894, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataTargetTypeRaw(int level)
        {
            return _modifications[845964110, level].ValueAsInt;
        }

        private void SetDataTargetTypeRaw(int level, int value)
        {
            _modifications[845964110, level] = new LevelObjectDataModification{Id = 845964110, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private ChannelType GetDataTargetType(int level)
        {
            return GetDataTargetTypeRaw(level).ToChannelType(this);
        }

        private void SetDataTargetType(int level, ChannelType value)
        {
            SetDataTargetTypeRaw(level, value.ToRaw(null, null));
        }

        private int GetDataOptionsRaw(int level)
        {
            return _modifications[862741326, level].ValueAsInt;
        }

        private void SetDataOptionsRaw(int level, int value)
        {
            _modifications[862741326, level] = new LevelObjectDataModification{Id = 862741326, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private ChannelFlags GetDataOptions(int level)
        {
            return GetDataOptionsRaw(level).ToChannelFlags(this);
        }

        private void SetDataOptions(int level, ChannelFlags value)
        {
            SetDataOptionsRaw(level, value.ToRaw(null, null));
        }

        private float GetDataArtDuration(int level)
        {
            return _modifications[879518542, level].ValueAsFloat;
        }

        private void SetDataArtDuration(int level, float value)
        {
            _modifications[879518542, level] = new LevelObjectDataModification{Id = 879518542, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetDataDisableOtherAbilities(int level)
        {
            return _modifications[896295758, level].ValueAsBool;
        }

        private void SetDataDisableOtherAbilities(int level, bool value)
        {
            _modifications[896295758, level] = new LevelObjectDataModification{Id = 896295758, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private string GetDataBaseOrderIDRaw(int level)
        {
            return _modifications[913072974, level].ValueAsString;
        }

        private void SetDataBaseOrderIDRaw(int level, string value)
        {
            _modifications[913072974, level] = new LevelObjectDataModification{Id = 913072974, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 6};
        }

        private string GetDataBaseOrderID(int level)
        {
            return GetDataBaseOrderIDRaw(level).ToString(this);
        }

        private void SetDataBaseOrderID(int level, string value)
        {
            SetDataBaseOrderIDRaw(level, value.ToRaw(null, 32));
        }
    }
}