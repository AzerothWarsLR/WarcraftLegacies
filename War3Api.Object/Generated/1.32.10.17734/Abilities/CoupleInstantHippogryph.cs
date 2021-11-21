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
    public sealed class CoupleInstantHippogryph : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataResultingUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataResultingUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataResultingUnitType;
        private readonly Lazy<ObjectProperty<string>> _dataPartnerUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPartnerUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataPartnerUnitType;
        private readonly Lazy<ObjectProperty<int>> _dataMoveToPartnerRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMoveToPartnerModified;
        private readonly Lazy<ObjectProperty<bool>> _dataMoveToPartner;
        public CoupleInstantHippogryph(): base(862937921)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
            _dataPartnerUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeRaw, SetDataPartnerUnitTypeRaw));
            _isDataPartnerUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeModified));
            _dataPartnerUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitType, SetDataPartnerUnitType));
            _dataMoveToPartnerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMoveToPartnerRaw, SetDataMoveToPartnerRaw));
            _isDataMoveToPartnerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveToPartnerModified));
            _dataMoveToPartner = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMoveToPartner, SetDataMoveToPartner));
        }

        public CoupleInstantHippogryph(int newId): base(862937921, newId)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
            _dataPartnerUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeRaw, SetDataPartnerUnitTypeRaw));
            _isDataPartnerUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeModified));
            _dataPartnerUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitType, SetDataPartnerUnitType));
            _dataMoveToPartnerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMoveToPartnerRaw, SetDataMoveToPartnerRaw));
            _isDataMoveToPartnerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveToPartnerModified));
            _dataMoveToPartner = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMoveToPartner, SetDataMoveToPartner));
        }

        public CoupleInstantHippogryph(string newRawcode): base(862937921, newRawcode)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
            _dataPartnerUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeRaw, SetDataPartnerUnitTypeRaw));
            _isDataPartnerUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeModified));
            _dataPartnerUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitType, SetDataPartnerUnitType));
            _dataMoveToPartnerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMoveToPartnerRaw, SetDataMoveToPartnerRaw));
            _isDataMoveToPartnerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveToPartnerModified));
            _dataMoveToPartner = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMoveToPartner, SetDataMoveToPartner));
        }

        public CoupleInstantHippogryph(ObjectDatabaseBase db): base(862937921, db)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
            _dataPartnerUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeRaw, SetDataPartnerUnitTypeRaw));
            _isDataPartnerUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeModified));
            _dataPartnerUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitType, SetDataPartnerUnitType));
            _dataMoveToPartnerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMoveToPartnerRaw, SetDataMoveToPartnerRaw));
            _isDataMoveToPartnerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveToPartnerModified));
            _dataMoveToPartner = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMoveToPartner, SetDataMoveToPartner));
        }

        public CoupleInstantHippogryph(int newId, ObjectDatabaseBase db): base(862937921, newId, db)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
            _dataPartnerUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeRaw, SetDataPartnerUnitTypeRaw));
            _isDataPartnerUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeModified));
            _dataPartnerUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitType, SetDataPartnerUnitType));
            _dataMoveToPartnerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMoveToPartnerRaw, SetDataMoveToPartnerRaw));
            _isDataMoveToPartnerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveToPartnerModified));
            _dataMoveToPartner = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMoveToPartner, SetDataMoveToPartner));
        }

        public CoupleInstantHippogryph(string newRawcode, ObjectDatabaseBase db): base(862937921, newRawcode, db)
        {
            _dataResultingUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataResultingUnitTypeRaw, SetDataResultingUnitTypeRaw));
            _isDataResultingUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataResultingUnitTypeModified));
            _dataResultingUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataResultingUnitType, SetDataResultingUnitType));
            _dataPartnerUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataPartnerUnitTypeRaw, SetDataPartnerUnitTypeRaw));
            _isDataPartnerUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartnerUnitTypeModified));
            _dataPartnerUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataPartnerUnitType, SetDataPartnerUnitType));
            _dataMoveToPartnerRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMoveToPartnerRaw, SetDataMoveToPartnerRaw));
            _isDataMoveToPartnerModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveToPartnerModified));
            _dataMoveToPartner = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataMoveToPartner, SetDataMoveToPartner));
        }

        public ObjectProperty<string> DataResultingUnitTypeRaw => _dataResultingUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataResultingUnitTypeModified => _isDataResultingUnitTypeModified.Value;
        public ObjectProperty<Unit> DataResultingUnitType => _dataResultingUnitType.Value;
        public ObjectProperty<string> DataPartnerUnitTypeRaw => _dataPartnerUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataPartnerUnitTypeModified => _isDataPartnerUnitTypeModified.Value;
        public ObjectProperty<Unit> DataPartnerUnitType => _dataPartnerUnitType.Value;
        public ObjectProperty<int> DataMoveToPartnerRaw => _dataMoveToPartnerRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataMoveToPartnerModified => _isDataMoveToPartnerModified.Value;
        public ObjectProperty<bool> DataMoveToPartner => _dataMoveToPartner.Value;
        private string GetDataResultingUnitTypeRaw(int level)
        {
            return _modifications.GetModification(1969319779, level).ValueAsString;
        }

        private void SetDataResultingUnitTypeRaw(int level, string value)
        {
            _modifications[1969319779, level] = new LevelObjectDataModification{Id = 1969319779, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataResultingUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(1969319779, level);
        }

        private Unit GetDataResultingUnitType(int level)
        {
            return GetDataResultingUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataResultingUnitType(int level, Unit value)
        {
            SetDataResultingUnitTypeRaw(level, value.ToRaw(null, null));
        }

        private string GetDataPartnerUnitTypeRaw(int level)
        {
            return _modifications.GetModification(828469091, level).ValueAsString;
        }

        private void SetDataPartnerUnitTypeRaw(int level, string value)
        {
            _modifications[828469091, level] = new LevelObjectDataModification{Id = 828469091, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataPartnerUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(828469091, level);
        }

        private Unit GetDataPartnerUnitType(int level)
        {
            return GetDataPartnerUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataPartnerUnitType(int level, Unit value)
        {
            SetDataPartnerUnitTypeRaw(level, value.ToRaw(null, null));
        }

        private int GetDataMoveToPartnerRaw(int level)
        {
            return _modifications.GetModification(845246307, level).ValueAsInt;
        }

        private void SetDataMoveToPartnerRaw(int level, int value)
        {
            _modifications[845246307, level] = new LevelObjectDataModification{Id = 845246307, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMoveToPartnerModified(int level)
        {
            return _modifications.ContainsKey(845246307, level);
        }

        private bool GetDataMoveToPartner(int level)
        {
            return GetDataMoveToPartnerRaw(level).ToBool(this);
        }

        private void SetDataMoveToPartner(int level, bool value)
        {
            SetDataMoveToPartnerRaw(level, value.ToRaw(null, null));
        }
    }
}