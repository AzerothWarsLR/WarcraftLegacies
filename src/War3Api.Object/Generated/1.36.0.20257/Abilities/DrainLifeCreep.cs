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
    public sealed class DrainLifeCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeTransferredPerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeTransferredPerSecondModified;
        private readonly Lazy<ObjectProperty<float>> _dataManaTransferredPerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaTransferredPerSecondModified;
        private readonly Lazy<ObjectProperty<float>> _dataBonusLifeFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBonusLifeFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataBonusLifeDecay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBonusLifeDecayModified;
        private readonly Lazy<ObjectProperty<float>> _dataBonusManaFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBonusManaFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataBonusManaDecay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBonusManaDecayModified;
        public DrainLifeCreep(): base(1919173441)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _isDataLifeTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeTransferredPerSecondModified));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _isDataManaTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaTransferredPerSecondModified));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _isDataBonusLifeFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeFactorModified));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _isDataBonusLifeDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeDecayModified));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _isDataBonusManaFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaFactorModified));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
            _isDataBonusManaDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaDecayModified));
        }

        public DrainLifeCreep(int newId): base(1919173441, newId)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _isDataLifeTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeTransferredPerSecondModified));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _isDataManaTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaTransferredPerSecondModified));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _isDataBonusLifeFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeFactorModified));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _isDataBonusLifeDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeDecayModified));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _isDataBonusManaFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaFactorModified));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
            _isDataBonusManaDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaDecayModified));
        }

        public DrainLifeCreep(string newRawcode): base(1919173441, newRawcode)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _isDataLifeTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeTransferredPerSecondModified));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _isDataManaTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaTransferredPerSecondModified));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _isDataBonusLifeFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeFactorModified));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _isDataBonusLifeDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeDecayModified));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _isDataBonusManaFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaFactorModified));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
            _isDataBonusManaDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaDecayModified));
        }

        public DrainLifeCreep(ObjectDatabaseBase db): base(1919173441, db)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _isDataLifeTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeTransferredPerSecondModified));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _isDataManaTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaTransferredPerSecondModified));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _isDataBonusLifeFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeFactorModified));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _isDataBonusLifeDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeDecayModified));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _isDataBonusManaFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaFactorModified));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
            _isDataBonusManaDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaDecayModified));
        }

        public DrainLifeCreep(int newId, ObjectDatabaseBase db): base(1919173441, newId, db)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _isDataLifeTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeTransferredPerSecondModified));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _isDataManaTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaTransferredPerSecondModified));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _isDataBonusLifeFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeFactorModified));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _isDataBonusLifeDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeDecayModified));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _isDataBonusManaFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaFactorModified));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
            _isDataBonusManaDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaDecayModified));
        }

        public DrainLifeCreep(string newRawcode, ObjectDatabaseBase db): base(1919173441, newRawcode, db)
        {
            _dataLifeTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeTransferredPerSecond, SetDataLifeTransferredPerSecond));
            _isDataLifeTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeTransferredPerSecondModified));
            _dataManaTransferredPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaTransferredPerSecond, SetDataManaTransferredPerSecond));
            _isDataManaTransferredPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaTransferredPerSecondModified));
            _dataBonusLifeFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeFactor, SetDataBonusLifeFactor));
            _isDataBonusLifeFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeFactorModified));
            _dataBonusLifeDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusLifeDecay, SetDataBonusLifeDecay));
            _isDataBonusLifeDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusLifeDecayModified));
            _dataBonusManaFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaFactor, SetDataBonusManaFactor));
            _isDataBonusManaFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaFactorModified));
            _dataBonusManaDecay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusManaDecay, SetDataBonusManaDecay));
            _isDataBonusManaDecayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusManaDecayModified));
        }

        public ObjectProperty<float> DataLifeTransferredPerSecond => _dataLifeTransferredPerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeTransferredPerSecondModified => _isDataLifeTransferredPerSecondModified.Value;
        public ObjectProperty<float> DataManaTransferredPerSecond => _dataManaTransferredPerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaTransferredPerSecondModified => _isDataManaTransferredPerSecondModified.Value;
        public ObjectProperty<float> DataBonusLifeFactor => _dataBonusLifeFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataBonusLifeFactorModified => _isDataBonusLifeFactorModified.Value;
        public ObjectProperty<float> DataBonusLifeDecay => _dataBonusLifeDecay.Value;
        public ReadOnlyObjectProperty<bool> IsDataBonusLifeDecayModified => _isDataBonusLifeDecayModified.Value;
        public ObjectProperty<float> DataBonusManaFactor => _dataBonusManaFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataBonusManaFactorModified => _isDataBonusManaFactorModified.Value;
        public ObjectProperty<float> DataBonusManaDecay => _dataBonusManaDecay.Value;
        public ReadOnlyObjectProperty<bool> IsDataBonusManaDecayModified => _isDataBonusManaDecayModified.Value;
        private float GetDataLifeTransferredPerSecond(int level)
        {
            return _modifications.GetModification(879912014, level).ValueAsFloat;
        }

        private void SetDataLifeTransferredPerSecond(int level, float value)
        {
            _modifications[879912014, level] = new LevelObjectDataModification{Id = 879912014, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataLifeTransferredPerSecondModified(int level)
        {
            return _modifications.ContainsKey(879912014, level);
        }

        private float GetDataManaTransferredPerSecond(int level)
        {
            return _modifications.GetModification(896689230, level).ValueAsFloat;
        }

        private void SetDataManaTransferredPerSecond(int level, float value)
        {
            _modifications[896689230, level] = new LevelObjectDataModification{Id = 896689230, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataManaTransferredPerSecondModified(int level)
        {
            return _modifications.ContainsKey(896689230, level);
        }

        private float GetDataBonusLifeFactor(int level)
        {
            return _modifications.GetModification(913466446, level).ValueAsFloat;
        }

        private void SetDataBonusLifeFactor(int level, float value)
        {
            _modifications[913466446, level] = new LevelObjectDataModification{Id = 913466446, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataBonusLifeFactorModified(int level)
        {
            return _modifications.ContainsKey(913466446, level);
        }

        private float GetDataBonusLifeDecay(int level)
        {
            return _modifications.GetModification(930243662, level).ValueAsFloat;
        }

        private void SetDataBonusLifeDecay(int level, float value)
        {
            _modifications[930243662, level] = new LevelObjectDataModification{Id = 930243662, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 7};
        }

        private bool GetIsDataBonusLifeDecayModified(int level)
        {
            return _modifications.ContainsKey(930243662, level);
        }

        private float GetDataBonusManaFactor(int level)
        {
            return _modifications.GetModification(947020878, level).ValueAsFloat;
        }

        private void SetDataBonusManaFactor(int level, float value)
        {
            _modifications[947020878, level] = new LevelObjectDataModification{Id = 947020878, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 8};
        }

        private bool GetIsDataBonusManaFactorModified(int level)
        {
            return _modifications.ContainsKey(947020878, level);
        }

        private float GetDataBonusManaDecay(int level)
        {
            return _modifications.GetModification(963798094, level).ValueAsFloat;
        }

        private void SetDataBonusManaDecay(int level, float value)
        {
            _modifications[963798094, level] = new LevelObjectDataModification{Id = 963798094, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 9};
        }

        private bool GetIsDataBonusManaDecayModified(int level)
        {
            return _modifications.ContainsKey(963798094, level);
        }
    }
}