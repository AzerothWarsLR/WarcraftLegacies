using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DrainLifeCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeTransferredPerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataManaTransferredPerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataBonusLifeFactor;
        private readonly Lazy<ObjectProperty<float>> _dataBonusLifeDecay;
        private readonly Lazy<ObjectProperty<float>> _dataBonusManaFactor;
        private readonly Lazy<ObjectProperty<float>> _dataBonusManaDecay;
        public DrainLifeCreep(): base(1919173441)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
        }

        public DrainLifeCreep(int newId): base(1919173441, newId)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
        }

        public DrainLifeCreep(string newRawcode): base(1919173441, newRawcode)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
        }

        public DrainLifeCreep(ObjectDatabase db): base(1919173441, db)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
        }

        public DrainLifeCreep(int newId, ObjectDatabase db): base(1919173441, newId, db)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
        }

        public DrainLifeCreep(string newRawcode, ObjectDatabase db): base(1919173441, newRawcode, db)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
        }

        public ObjectProperty<float> DataLifeTransferredPerSecond => _dataLifeTransferredPerSecond.Value;
        public ObjectProperty<float> DataManaTransferredPerSecond => _dataManaTransferredPerSecond.Value;
        public ObjectProperty<float> DataBonusLifeFactor => _dataBonusLifeFactor.Value;
        public ObjectProperty<float> DataBonusLifeDecay => _dataBonusLifeDecay.Value;
        public ObjectProperty<float> DataBonusManaFactor => _dataBonusManaFactor.Value;
        public ObjectProperty<float> DataBonusManaDecay => _dataBonusManaDecay.Value;
        private float GetDataLifeTransferredPerSecond(int level)
        {
            return _modifications[879912014, level].ValueAsFloat;
        }

        private void SetDataLifeTransferredPerSecond(int level, float value)
        {
            _modifications[879912014, level] = new LevelObjectDataModification{Id = 879912014, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataManaTransferredPerSecond(int level)
        {
            return _modifications[896689230, level].ValueAsFloat;
        }

        private void SetDataManaTransferredPerSecond(int level, float value)
        {
            _modifications[896689230, level] = new LevelObjectDataModification{Id = 896689230, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private float GetDataBonusLifeFactor(int level)
        {
            return _modifications[913466446, level].ValueAsFloat;
        }

        private void SetDataBonusLifeFactor(int level, float value)
        {
            _modifications[913466446, level] = new LevelObjectDataModification{Id = 913466446, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }

        private float GetDataBonusLifeDecay(int level)
        {
            return _modifications[930243662, level].ValueAsFloat;
        }

        private void SetDataBonusLifeDecay(int level, float value)
        {
            _modifications[930243662, level] = new LevelObjectDataModification{Id = 930243662, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 7};
        }

        private float GetDataBonusManaFactor(int level)
        {
            return _modifications[947020878, level].ValueAsFloat;
        }

        private void SetDataBonusManaFactor(int level, float value)
        {
            _modifications[947020878, level] = new LevelObjectDataModification{Id = 947020878, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 8};
        }

        private float GetDataBonusManaDecay(int level)
        {
            return _modifications[963798094, level].ValueAsFloat;
        }

        private void SetDataBonusManaDecay(int level, float value)
        {
            _modifications[963798094, level] = new LevelObjectDataModification{Id = 963798094, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 9};
        }
    }
}