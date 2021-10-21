using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class LichDarkRitual : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeConvertedToMana;
        private readonly Lazy<ObjectProperty<float>> _dataLifeConvertedToLife;
        private readonly Lazy<ObjectProperty<bool>> _dataManaConversionAsPercent;
        private readonly Lazy<ObjectProperty<bool>> _dataLifeConversionAsPercent;
        private readonly Lazy<ObjectProperty<bool>> _dataLeaveTargetAlive;
        public LichDarkRitual(): base(1919178049)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public LichDarkRitual(int newId): base(1919178049, newId)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public LichDarkRitual(string newRawcode): base(1919178049, newRawcode)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public LichDarkRitual(ObjectDatabase db): base(1919178049, db)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public LichDarkRitual(int newId, ObjectDatabase db): base(1919178049, newId, db)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public LichDarkRitual(string newRawcode, ObjectDatabase db): base(1919178049, newRawcode, db)
        {
            _dataLifeConvertedToMana = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToMana, SetDataLifeConvertedToMana));
            _dataLifeConvertedToLife = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeConvertedToLife, SetDataLifeConvertedToLife));
            _dataManaConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataManaConversionAsPercent, SetDataManaConversionAsPercent));
            _dataLifeConversionAsPercent = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLifeConversionAsPercent, SetDataLifeConversionAsPercent));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
        }

        public ObjectProperty<float> DataLifeConvertedToMana => _dataLifeConvertedToMana.Value;
        public ObjectProperty<float> DataLifeConvertedToLife => _dataLifeConvertedToLife.Value;
        public ObjectProperty<bool> DataManaConversionAsPercent => _dataManaConversionAsPercent.Value;
        public ObjectProperty<bool> DataLifeConversionAsPercent => _dataLifeConversionAsPercent.Value;
        public ObjectProperty<bool> DataLeaveTargetAlive => _dataLeaveTargetAlive.Value;
        private float GetDataLifeConvertedToMana(int level)
        {
            return _modifications[829449301, level].ValueAsFloat;
        }

        private void SetDataLifeConvertedToMana(int level, float value)
        {
            _modifications[829449301, level] = new LevelObjectDataModification{Id = 829449301, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataLifeConvertedToLife(int level)
        {
            return _modifications[846226517, level].ValueAsFloat;
        }

        private void SetDataLifeConvertedToLife(int level, float value)
        {
            _modifications[846226517, level] = new LevelObjectDataModification{Id = 846226517, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetDataManaConversionAsPercent(int level)
        {
            return _modifications[863003733, level].ValueAsBool;
        }

        private void SetDataManaConversionAsPercent(int level, bool value)
        {
            _modifications[863003733, level] = new LevelObjectDataModification{Id = 863003733, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetDataLifeConversionAsPercent(int level)
        {
            return _modifications[879780949, level].ValueAsBool;
        }

        private void SetDataLifeConversionAsPercent(int level, bool value)
        {
            _modifications[879780949, level] = new LevelObjectDataModification{Id = 879780949, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetDataLeaveTargetAlive(int level)
        {
            return _modifications[896558165, level].ValueAsBool;
        }

        private void SetDataLeaveTargetAlive(int level, bool value)
        {
            _modifications[896558165, level] = new LevelObjectDataModification{Id = 896558165, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }
    }
}