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
    public sealed class IllidanChannel : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataFollowThroughTime;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFollowThroughTimeModified;
        private readonly Lazy<ObjectProperty<int>> _dataTargetTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTargetTypeModified;
        private readonly Lazy<ObjectProperty<ChannelType>> _dataTargetType;
        private readonly Lazy<ObjectProperty<int>> _dataOptionsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataOptionsModified;
        private readonly Lazy<ObjectProperty<ChannelFlags>> _dataOptions;
        private readonly Lazy<ObjectProperty<float>> _dataArtDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataArtDurationModified;
        private readonly Lazy<ObjectProperty<int>> _dataDisableOtherAbilitiesRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDisableOtherAbilitiesModified;
        private readonly Lazy<ObjectProperty<bool>> _dataDisableOtherAbilities;
        private readonly Lazy<ObjectProperty<string>> _dataBaseOrderIDRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBaseOrderIDModified;
        private readonly Lazy<ObjectProperty<string>> _dataBaseOrderID;
        public IllidanChannel(): base(1818447425)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _isDataFollowThroughTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFollowThroughTimeModified));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _isDataTargetTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetTypeModified));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _isDataOptionsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataOptionsModified));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _isDataArtDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtDurationModified));
            _dataDisableOtherAbilitiesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisableOtherAbilitiesRaw, SetDataDisableOtherAbilitiesRaw));
            _isDataDisableOtherAbilitiesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisableOtherAbilitiesModified));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public IllidanChannel(int newId): base(1818447425, newId)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _isDataFollowThroughTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFollowThroughTimeModified));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _isDataTargetTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetTypeModified));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _isDataOptionsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataOptionsModified));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _isDataArtDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtDurationModified));
            _dataDisableOtherAbilitiesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisableOtherAbilitiesRaw, SetDataDisableOtherAbilitiesRaw));
            _isDataDisableOtherAbilitiesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisableOtherAbilitiesModified));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public IllidanChannel(string newRawcode): base(1818447425, newRawcode)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _isDataFollowThroughTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFollowThroughTimeModified));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _isDataTargetTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetTypeModified));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _isDataOptionsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataOptionsModified));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _isDataArtDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtDurationModified));
            _dataDisableOtherAbilitiesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisableOtherAbilitiesRaw, SetDataDisableOtherAbilitiesRaw));
            _isDataDisableOtherAbilitiesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisableOtherAbilitiesModified));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public IllidanChannel(ObjectDatabaseBase db): base(1818447425, db)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _isDataFollowThroughTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFollowThroughTimeModified));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _isDataTargetTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetTypeModified));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _isDataOptionsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataOptionsModified));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _isDataArtDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtDurationModified));
            _dataDisableOtherAbilitiesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisableOtherAbilitiesRaw, SetDataDisableOtherAbilitiesRaw));
            _isDataDisableOtherAbilitiesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisableOtherAbilitiesModified));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public IllidanChannel(int newId, ObjectDatabaseBase db): base(1818447425, newId, db)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _isDataFollowThroughTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFollowThroughTimeModified));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _isDataTargetTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetTypeModified));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _isDataOptionsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataOptionsModified));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _isDataArtDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtDurationModified));
            _dataDisableOtherAbilitiesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisableOtherAbilitiesRaw, SetDataDisableOtherAbilitiesRaw));
            _isDataDisableOtherAbilitiesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisableOtherAbilitiesModified));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public IllidanChannel(string newRawcode, ObjectDatabaseBase db): base(1818447425, newRawcode, db)
        {
            _dataFollowThroughTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFollowThroughTime, SetDataFollowThroughTime));
            _isDataFollowThroughTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFollowThroughTimeModified));
            _dataTargetTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataTargetTypeRaw, SetDataTargetTypeRaw));
            _isDataTargetTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetTypeModified));
            _dataTargetType = new Lazy<ObjectProperty<ChannelType>>(() => new ObjectProperty<ChannelType>(GetDataTargetType, SetDataTargetType));
            _dataOptionsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataOptionsRaw, SetDataOptionsRaw));
            _isDataOptionsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataOptionsModified));
            _dataOptions = new Lazy<ObjectProperty<ChannelFlags>>(() => new ObjectProperty<ChannelFlags>(GetDataOptions, SetDataOptions));
            _dataArtDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtDuration, SetDataArtDuration));
            _isDataArtDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtDurationModified));
            _dataDisableOtherAbilitiesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisableOtherAbilitiesRaw, SetDataDisableOtherAbilitiesRaw));
            _isDataDisableOtherAbilitiesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisableOtherAbilitiesModified));
            _dataDisableOtherAbilities = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDisableOtherAbilities, SetDataDisableOtherAbilities));
            _dataBaseOrderIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderIDRaw, SetDataBaseOrderIDRaw));
            _isDataBaseOrderIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBaseOrderIDModified));
            _dataBaseOrderID = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataBaseOrderID, SetDataBaseOrderID));
        }

        public ObjectProperty<float> DataFollowThroughTime => _dataFollowThroughTime.Value;
        public ReadOnlyObjectProperty<bool> IsDataFollowThroughTimeModified => _isDataFollowThroughTimeModified.Value;
        public ObjectProperty<int> DataTargetTypeRaw => _dataTargetTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataTargetTypeModified => _isDataTargetTypeModified.Value;
        public ObjectProperty<ChannelType> DataTargetType => _dataTargetType.Value;
        public ObjectProperty<int> DataOptionsRaw => _dataOptionsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataOptionsModified => _isDataOptionsModified.Value;
        public ObjectProperty<ChannelFlags> DataOptions => _dataOptions.Value;
        public ObjectProperty<float> DataArtDuration => _dataArtDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataArtDurationModified => _isDataArtDurationModified.Value;
        public ObjectProperty<int> DataDisableOtherAbilitiesRaw => _dataDisableOtherAbilitiesRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDisableOtherAbilitiesModified => _isDataDisableOtherAbilitiesModified.Value;
        public ObjectProperty<bool> DataDisableOtherAbilities => _dataDisableOtherAbilities.Value;
        public ObjectProperty<string> DataBaseOrderIDRaw => _dataBaseOrderIDRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataBaseOrderIDModified => _isDataBaseOrderIDModified.Value;
        public ObjectProperty<string> DataBaseOrderID => _dataBaseOrderID.Value;
        private float GetDataFollowThroughTime(int level)
        {
            return _modifications.GetModification(829186894, level).ValueAsFloat;
        }

        private void SetDataFollowThroughTime(int level, float value)
        {
            _modifications[829186894, level] = new LevelObjectDataModification{Id = 829186894, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataFollowThroughTimeModified(int level)
        {
            return _modifications.ContainsKey(829186894, level);
        }

        private int GetDataTargetTypeRaw(int level)
        {
            return _modifications.GetModification(845964110, level).ValueAsInt;
        }

        private void SetDataTargetTypeRaw(int level, int value)
        {
            _modifications[845964110, level] = new LevelObjectDataModification{Id = 845964110, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataTargetTypeModified(int level)
        {
            return _modifications.ContainsKey(845964110, level);
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
            return _modifications.GetModification(862741326, level).ValueAsInt;
        }

        private void SetDataOptionsRaw(int level, int value)
        {
            _modifications[862741326, level] = new LevelObjectDataModification{Id = 862741326, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataOptionsModified(int level)
        {
            return _modifications.ContainsKey(862741326, level);
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
            return _modifications.GetModification(879518542, level).ValueAsFloat;
        }

        private void SetDataArtDuration(int level, float value)
        {
            _modifications[879518542, level] = new LevelObjectDataModification{Id = 879518542, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataArtDurationModified(int level)
        {
            return _modifications.ContainsKey(879518542, level);
        }

        private int GetDataDisableOtherAbilitiesRaw(int level)
        {
            return _modifications.GetModification(896295758, level).ValueAsInt;
        }

        private void SetDataDisableOtherAbilitiesRaw(int level, int value)
        {
            _modifications[896295758, level] = new LevelObjectDataModification{Id = 896295758, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataDisableOtherAbilitiesModified(int level)
        {
            return _modifications.ContainsKey(896295758, level);
        }

        private bool GetDataDisableOtherAbilities(int level)
        {
            return GetDataDisableOtherAbilitiesRaw(level).ToBool(this);
        }

        private void SetDataDisableOtherAbilities(int level, bool value)
        {
            SetDataDisableOtherAbilitiesRaw(level, value.ToRaw(null, null));
        }

        private string GetDataBaseOrderIDRaw(int level)
        {
            return _modifications.GetModification(913072974, level).ValueAsString;
        }

        private void SetDataBaseOrderIDRaw(int level, string value)
        {
            _modifications[913072974, level] = new LevelObjectDataModification{Id = 913072974, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataBaseOrderIDModified(int level)
        {
            return _modifications.ContainsKey(913072974, level);
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