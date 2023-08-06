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
    public sealed class Militia : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataNormalFormUnitRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNormalFormUnitModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataNormalFormUnit;
        private readonly Lazy<ObjectProperty<string>> _dataAlternateFormUnitRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAlternateFormUnitModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataAlternateFormUnit;
        public Militia(): base(1818848577)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public Militia(int newId): base(1818848577, newId)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public Militia(string newRawcode): base(1818848577, newRawcode)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public Militia(ObjectDatabaseBase db): base(1818848577, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public Militia(int newId, ObjectDatabaseBase db): base(1818848577, newId, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public Militia(string newRawcode, ObjectDatabaseBase db): base(1818848577, newRawcode, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public ObjectProperty<string> DataNormalFormUnitRaw => _dataNormalFormUnitRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataNormalFormUnitModified => _isDataNormalFormUnitModified.Value;
        public ObjectProperty<Unit> DataNormalFormUnit => _dataNormalFormUnit.Value;
        public ObjectProperty<string> DataAlternateFormUnitRaw => _dataAlternateFormUnitRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAlternateFormUnitModified => _isDataAlternateFormUnitModified.Value;
        public ObjectProperty<Unit> DataAlternateFormUnit => _dataAlternateFormUnit.Value;
        private string GetDataNormalFormUnitRaw(int level)
        {
            return _modifications.GetModification(829188429, level).ValueAsString;
        }

        private void SetDataNormalFormUnitRaw(int level, string value)
        {
            _modifications[829188429, level] = new LevelObjectDataModification{Id = 829188429, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNormalFormUnitModified(int level)
        {
            return _modifications.ContainsKey(829188429, level);
        }

        private Unit GetDataNormalFormUnit(int level)
        {
            return GetDataNormalFormUnitRaw(level).ToUnit(this);
        }

        private void SetDataNormalFormUnit(int level, Unit value)
        {
            SetDataNormalFormUnitRaw(level, value.ToRaw(null, null));
        }

        private string GetDataAlternateFormUnitRaw(int level)
        {
            return _modifications.GetModification(845965645, level).ValueAsString;
        }

        private void SetDataAlternateFormUnitRaw(int level, string value)
        {
            _modifications[845965645, level] = new LevelObjectDataModification{Id = 845965645, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAlternateFormUnitModified(int level)
        {
            return _modifications.ContainsKey(845965645, level);
        }

        private Unit GetDataAlternateFormUnit(int level)
        {
            return GetDataAlternateFormUnitRaw(level).ToUnit(this);
        }

        private void SetDataAlternateFormUnit(int level, Unit value)
        {
            SetDataAlternateFormUnitRaw(level, value.ToRaw(null, null));
        }
    }
}