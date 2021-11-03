using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ManaSteal : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeConvertedToMana;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeConvertedToManaModified;
        private readonly Lazy<ObjectProperty<float>> _dataLifeConvertedToLife;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeConvertedToLifeModified;
        private readonly Lazy<ObjectProperty<bool>> _dataManaConversionAsPercent;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaConversionAsPercentModified;
        private readonly Lazy<ObjectProperty<bool>> _dataLifeConversionAsPercent;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeConversionAsPercentModified;
        private readonly Lazy<ObjectProperty<bool>> _dataLeaveTargetAlive;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLeaveTargetAliveModified;
        public ManaSteal(): base(1702130497)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
        }

        public ManaSteal(int newId): base(1702130497, newId)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
        }

        public ManaSteal(string newRawcode): base(1702130497, newRawcode)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
        }

        public ManaSteal(ObjectDatabase db): base(1702130497, db)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
        }

        public ManaSteal(int newId, ObjectDatabase db): base(1702130497, newId, db)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
        }

        public ManaSteal(string newRawcode, ObjectDatabase db): base(1702130497, newRawcode, db)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _isDataLifeConvertedToManaModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToManaModified));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _isDataLifeConvertedToLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConvertedToLifeModified));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _isDataManaConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaConversionAsPercentModified));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _isDataLifeConversionAsPercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeConversionAsPercentModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
        }

        public ObjectProperty<float> DataLifeConvertedToMana => _dataLifeConvertedToMana.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeConvertedToManaModified => _isDataLifeConvertedToManaModified.Value;
        public ObjectProperty<float> DataLifeConvertedToLife => _dataLifeConvertedToLife.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeConvertedToLifeModified => _isDataLifeConvertedToLifeModified.Value;
        public ObjectProperty<bool> DataManaConversionAsPercent => _dataManaConversionAsPercent.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaConversionAsPercentModified => _isDataManaConversionAsPercentModified.Value;
        public ObjectProperty<bool> DataLifeConversionAsPercent => _dataLifeConversionAsPercent.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeConversionAsPercentModified => _isDataLifeConversionAsPercentModified.Value;
        public ObjectProperty<bool> DataLeaveTargetAlive => _dataLeaveTargetAlive.Value;
        public ReadOnlyObjectProperty<bool> IsDataLeaveTargetAliveModified => _isDataLeaveTargetAliveModified.Value;
        private float GetDataLifeConvertedToMana(int level)
        {
            return _modifications[829449301, level].ValueAsFloat;
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
            return _modifications[846226517, level].ValueAsFloat;
        }

        private void SetDataLifeConvertedToLife(int level, float value)
        {
            _modifications[846226517, level] = new LevelObjectDataModification{Id = 846226517, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataLifeConvertedToLifeModified(int level)
        {
            return _modifications.ContainsKey(846226517, level);
        }

        private bool GetDataManaConversionAsPercent(int level)
        {
            return _modifications[863003733, level].ValueAsBool;
        }

        private void SetDataManaConversionAsPercent(int level, bool value)
        {
            _modifications[863003733, level] = new LevelObjectDataModification{Id = 863003733, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataManaConversionAsPercentModified(int level)
        {
            return _modifications.ContainsKey(863003733, level);
        }

        private bool GetDataLifeConversionAsPercent(int level)
        {
            return _modifications[879780949, level].ValueAsBool;
        }

        private void SetDataLifeConversionAsPercent(int level, bool value)
        {
            _modifications[879780949, level] = new LevelObjectDataModification{Id = 879780949, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataLifeConversionAsPercentModified(int level)
        {
            return _modifications.ContainsKey(879780949, level);
        }

        private bool GetDataLeaveTargetAlive(int level)
        {
            return _modifications[896558165, level].ValueAsBool;
        }

        private void SetDataLeaveTargetAlive(int level, bool value)
        {
            _modifications[896558165, level] = new LevelObjectDataModification{Id = 896558165, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataLeaveTargetAliveModified(int level)
        {
            return _modifications.ContainsKey(896558165, level);
        }
    }
}