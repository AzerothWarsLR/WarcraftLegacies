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
    public sealed class FaerieFire_Afae : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDefenseReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDefenseReductionModified;
        private readonly Lazy<ObjectProperty<int>> _dataAlwaysAutocastRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAlwaysAutocastModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAlwaysAutocast;
        public FaerieFire_Afae(): base(1700881985)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _isDataDefenseReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseReductionModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public FaerieFire_Afae(int newId): base(1700881985, newId)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _isDataDefenseReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseReductionModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public FaerieFire_Afae(string newRawcode): base(1700881985, newRawcode)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _isDataDefenseReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseReductionModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public FaerieFire_Afae(ObjectDatabaseBase db): base(1700881985, db)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _isDataDefenseReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseReductionModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public FaerieFire_Afae(int newId, ObjectDatabaseBase db): base(1700881985, newId, db)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _isDataDefenseReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseReductionModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public FaerieFire_Afae(string newRawcode, ObjectDatabaseBase db): base(1700881985, newRawcode, db)
        {
            _dataDefenseReduction = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseReduction, SetDataDefenseReduction));
            _isDataDefenseReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseReductionModified));
            _dataAlwaysAutocastRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAlwaysAutocastRaw, SetDataAlwaysAutocastRaw));
            _isDataAlwaysAutocastModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlwaysAutocastModified));
            _dataAlwaysAutocast = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAlwaysAutocast, SetDataAlwaysAutocast));
        }

        public ObjectProperty<int> DataDefenseReduction => _dataDefenseReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataDefenseReductionModified => _isDataDefenseReductionModified.Value;
        public ObjectProperty<int> DataAlwaysAutocastRaw => _dataAlwaysAutocastRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAlwaysAutocastModified => _isDataAlwaysAutocastModified.Value;
        public ObjectProperty<bool> DataAlwaysAutocast => _dataAlwaysAutocast.Value;
        private int GetDataDefenseReduction(int level)
        {
            return _modifications.GetModification(828727622, level).ValueAsInt;
        }

        private void SetDataDefenseReduction(int level, int value)
        {
            _modifications[828727622, level] = new LevelObjectDataModification{Id = 828727622, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDefenseReductionModified(int level)
        {
            return _modifications.ContainsKey(828727622, level);
        }

        private int GetDataAlwaysAutocastRaw(int level)
        {
            return _modifications.GetModification(845504838, level).ValueAsInt;
        }

        private void SetDataAlwaysAutocastRaw(int level, int value)
        {
            _modifications[845504838, level] = new LevelObjectDataModification{Id = 845504838, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAlwaysAutocastModified(int level)
        {
            return _modifications.ContainsKey(845504838, level);
        }

        private bool GetDataAlwaysAutocast(int level)
        {
            return GetDataAlwaysAutocastRaw(level).ToBool(this);
        }

        private void SetDataAlwaysAutocast(int level, bool value)
        {
            SetDataAlwaysAutocastRaw(level, value.ToRaw(0, 1));
        }
    }
}