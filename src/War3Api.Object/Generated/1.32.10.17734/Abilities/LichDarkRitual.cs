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
    public sealed class LichDarkRitual : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeConvertedToMana;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeConvertedToManaModified;
        private readonly Lazy<ObjectProperty<float>> _dataLifeConvertedToLife;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeConvertedToLifeModified;
        private readonly Lazy<ObjectProperty<int>> _dataManaConversionAsPercentRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaConversionAsPercentModified;
        private readonly Lazy<ObjectProperty<bool>> _dataManaConversionAsPercent;
        private readonly Lazy<ObjectProperty<int>> _dataLifeConversionAsPercentRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeConversionAsPercentModified;
        private readonly Lazy<ObjectProperty<bool>> _dataLifeConversionAsPercent;
        private readonly Lazy<ObjectProperty<int>> _dataLeaveTargetAliveRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLeaveTargetAliveModified;
        private readonly Lazy<ObjectProperty<bool>> _dataLeaveTargetAlive;
        public LichDarkRitual(): base(1919178049)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaConversionAsPercentRaw, SetDataManaConversionAsPercentRaw));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLifeConversionAsPercentRaw, SetDataLifeConversionAsPercentRaw));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public LichDarkRitual(int newId): base(1919178049, newId)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaConversionAsPercentRaw, SetDataManaConversionAsPercentRaw));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLifeConversionAsPercentRaw, SetDataLifeConversionAsPercentRaw));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public LichDarkRitual(string newRawcode): base(1919178049, newRawcode)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaConversionAsPercentRaw, SetDataManaConversionAsPercentRaw));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLifeConversionAsPercentRaw, SetDataLifeConversionAsPercentRaw));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public LichDarkRitual(ObjectDatabaseBase db): base(1919178049, db)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaConversionAsPercentRaw, SetDataManaConversionAsPercentRaw));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLifeConversionAsPercentRaw, SetDataLifeConversionAsPercentRaw));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public LichDarkRitual(int newId, ObjectDatabaseBase db): base(1919178049, newId, db)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaConversionAsPercentRaw, SetDataManaConversionAsPercentRaw));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLifeConversionAsPercentRaw, SetDataLifeConversionAsPercentRaw));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public LichDarkRitual(string newRawcode, ObjectDatabaseBase db): base(1919178049, newRawcode, db)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaConversionAsPercentRaw, SetDataManaConversionAsPercentRaw));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercentRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLifeConversionAsPercentRaw, SetDataLifeConversionAsPercentRaw));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public ObjectProperty<float> DataLifeConvertedToMana => _dataLifeConvertedToMana.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeConvertedToManaModified => _isDataLifeConvertedToManaModified.Value;
        public ObjectProperty<float> DataLifeConvertedToLife => _dataLifeConvertedToLife.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeConvertedToLifeModified => _isDataLifeConvertedToLifeModified.Value;
        public ObjectProperty<int> DataManaConversionAsPercentRaw => _dataManaConversionAsPercentRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaConversionAsPercentModified => _isDataManaConversionAsPercentModified.Value;
        public ObjectProperty<bool> DataManaConversionAsPercent => _dataManaConversionAsPercent.Value;
        public ObjectProperty<int> DataLifeConversionAsPercentRaw => _dataLifeConversionAsPercentRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeConversionAsPercentModified => _isDataLifeConversionAsPercentModified.Value;
        public ObjectProperty<bool> DataLifeConversionAsPercent => _dataLifeConversionAsPercent.Value;
        public ObjectProperty<int> DataLeaveTargetAliveRaw => _dataLeaveTargetAliveRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataLeaveTargetAliveModified => _isDataLeaveTargetAliveModified.Value;
        public ObjectProperty<bool> DataLeaveTargetAlive => _dataLeaveTargetAlive.Value;
        private float GetDataLifeConvertedToMana(int level)
        {
            return _modifications.GetModification(829449301, level).ValueAsFloat;
        }

        private void SetDataLifeConvertedToMana(int level, float value)
        {
            _modifications[829449301, level] = new LevelObjectDataModification{Id = 829449301, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataLifeConvertedToManaModified(int level)
        {
            return _modifications.ContainsKey(829449301, level);
        }

        private float GetDataLifeConvertedToLife(int level)
        {
            return _modifications.GetModification(846226517, level).ValueAsFloat;
        }

        private void SetDataLifeConvertedToLife(int level, float value)
        {
            _modifications[846226517, level] = new LevelObjectDataModification{Id = 846226517, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataLifeConvertedToLifeModified(int level)
        {
            return _modifications.ContainsKey(846226517, level);
        }

        private int GetDataManaConversionAsPercentRaw(int level)
        {
            return _modifications.GetModification(863003733, level).ValueAsInt;
        }

        private void SetDataManaConversionAsPercentRaw(int level, int value)
        {
            _modifications[863003733, level] = new LevelObjectDataModification{Id = 863003733, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataManaConversionAsPercentModified(int level)
        {
            return _modifications.ContainsKey(863003733, level);
        }

        private bool GetDataManaConversionAsPercent(int level)
        {
            return GetDataManaConversionAsPercentRaw(level).ToBool(this);
        }

        private void SetDataManaConversionAsPercent(int level, bool value)
        {
            SetDataManaConversionAsPercentRaw(level, value.ToRaw(null, null));
        }

        private int GetDataLifeConversionAsPercentRaw(int level)
        {
            return _modifications.GetModification(879780949, level).ValueAsInt;
        }

        private void SetDataLifeConversionAsPercentRaw(int level, int value)
        {
            _modifications[879780949, level] = new LevelObjectDataModification{Id = 879780949, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataLifeConversionAsPercentModified(int level)
        {
            return _modifications.ContainsKey(879780949, level);
        }

        private bool GetDataLifeConversionAsPercent(int level)
        {
            return GetDataLifeConversionAsPercentRaw(level).ToBool(this);
        }

        private void SetDataLifeConversionAsPercent(int level, bool value)
        {
            SetDataLifeConversionAsPercentRaw(level, value.ToRaw(null, null));
        }

        private int GetDataLeaveTargetAliveRaw(int level)
        {
            return _modifications.GetModification(896558165, level).ValueAsInt;
        }

        private void SetDataLeaveTargetAliveRaw(int level, int value)
        {
            _modifications[896558165, level] = new LevelObjectDataModification{Id = 896558165, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataLeaveTargetAliveModified(int level)
        {
            return _modifications.ContainsKey(896558165, level);
        }

        private bool GetDataLeaveTargetAlive(int level)
        {
            return GetDataLeaveTargetAliveRaw(level).ToBool(this);
        }

        private void SetDataLeaveTargetAlive(int level, bool value)
        {
            SetDataLeaveTargetAliveRaw(level, value.ToRaw(null, null));
        }
    }
}