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
    public sealed class RootAncients : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataRootedWeaponsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRootedWeaponsModified;
        private readonly Lazy<ObjectProperty<AttackBits>> _dataRootedWeapons;
        private readonly Lazy<ObjectProperty<int>> _dataUprootedWeaponsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUprootedWeaponsModified;
        private readonly Lazy<ObjectProperty<AttackBits>> _dataUprootedWeapons;
        private readonly Lazy<ObjectProperty<int>> _dataRootedTurningRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRootedTurningModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRootedTurning;
        private readonly Lazy<ObjectProperty<int>> _dataUprootedDefenseTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUprootedDefenseTypeModified;
        private readonly Lazy<ObjectProperty<DefenseTypeInt>> _dataUprootedDefenseType;
        public RootAncients(): base(829387329)
        {
            _dataRootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedWeaponsRaw, SetDataRootedWeaponsRaw));
            _isDataRootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedWeaponsModified));
            _dataRootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataRootedWeapons, SetDataRootedWeapons));
            _dataUprootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedWeaponsRaw, SetDataUprootedWeaponsRaw));
            _isDataUprootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedWeaponsModified));
            _dataUprootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataUprootedWeapons, SetDataUprootedWeapons));
            _dataRootedTurningRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedTurningRaw, SetDataRootedTurningRaw));
            _isDataRootedTurningModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedTurningModified));
            _dataRootedTurning = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRootedTurning, SetDataRootedTurning));
            _dataUprootedDefenseTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedDefenseTypeRaw, SetDataUprootedDefenseTypeRaw));
            _isDataUprootedDefenseTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedDefenseTypeModified));
            _dataUprootedDefenseType = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataUprootedDefenseType, SetDataUprootedDefenseType));
        }

        public RootAncients(int newId): base(829387329, newId)
        {
            _dataRootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedWeaponsRaw, SetDataRootedWeaponsRaw));
            _isDataRootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedWeaponsModified));
            _dataRootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataRootedWeapons, SetDataRootedWeapons));
            _dataUprootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedWeaponsRaw, SetDataUprootedWeaponsRaw));
            _isDataUprootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedWeaponsModified));
            _dataUprootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataUprootedWeapons, SetDataUprootedWeapons));
            _dataRootedTurningRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedTurningRaw, SetDataRootedTurningRaw));
            _isDataRootedTurningModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedTurningModified));
            _dataRootedTurning = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRootedTurning, SetDataRootedTurning));
            _dataUprootedDefenseTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedDefenseTypeRaw, SetDataUprootedDefenseTypeRaw));
            _isDataUprootedDefenseTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedDefenseTypeModified));
            _dataUprootedDefenseType = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataUprootedDefenseType, SetDataUprootedDefenseType));
        }

        public RootAncients(string newRawcode): base(829387329, newRawcode)
        {
            _dataRootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedWeaponsRaw, SetDataRootedWeaponsRaw));
            _isDataRootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedWeaponsModified));
            _dataRootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataRootedWeapons, SetDataRootedWeapons));
            _dataUprootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedWeaponsRaw, SetDataUprootedWeaponsRaw));
            _isDataUprootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedWeaponsModified));
            _dataUprootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataUprootedWeapons, SetDataUprootedWeapons));
            _dataRootedTurningRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedTurningRaw, SetDataRootedTurningRaw));
            _isDataRootedTurningModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedTurningModified));
            _dataRootedTurning = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRootedTurning, SetDataRootedTurning));
            _dataUprootedDefenseTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedDefenseTypeRaw, SetDataUprootedDefenseTypeRaw));
            _isDataUprootedDefenseTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedDefenseTypeModified));
            _dataUprootedDefenseType = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataUprootedDefenseType, SetDataUprootedDefenseType));
        }

        public RootAncients(ObjectDatabaseBase db): base(829387329, db)
        {
            _dataRootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedWeaponsRaw, SetDataRootedWeaponsRaw));
            _isDataRootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedWeaponsModified));
            _dataRootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataRootedWeapons, SetDataRootedWeapons));
            _dataUprootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedWeaponsRaw, SetDataUprootedWeaponsRaw));
            _isDataUprootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedWeaponsModified));
            _dataUprootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataUprootedWeapons, SetDataUprootedWeapons));
            _dataRootedTurningRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedTurningRaw, SetDataRootedTurningRaw));
            _isDataRootedTurningModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedTurningModified));
            _dataRootedTurning = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRootedTurning, SetDataRootedTurning));
            _dataUprootedDefenseTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedDefenseTypeRaw, SetDataUprootedDefenseTypeRaw));
            _isDataUprootedDefenseTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedDefenseTypeModified));
            _dataUprootedDefenseType = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataUprootedDefenseType, SetDataUprootedDefenseType));
        }

        public RootAncients(int newId, ObjectDatabaseBase db): base(829387329, newId, db)
        {
            _dataRootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedWeaponsRaw, SetDataRootedWeaponsRaw));
            _isDataRootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedWeaponsModified));
            _dataRootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataRootedWeapons, SetDataRootedWeapons));
            _dataUprootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedWeaponsRaw, SetDataUprootedWeaponsRaw));
            _isDataUprootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedWeaponsModified));
            _dataUprootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataUprootedWeapons, SetDataUprootedWeapons));
            _dataRootedTurningRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedTurningRaw, SetDataRootedTurningRaw));
            _isDataRootedTurningModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedTurningModified));
            _dataRootedTurning = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRootedTurning, SetDataRootedTurning));
            _dataUprootedDefenseTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedDefenseTypeRaw, SetDataUprootedDefenseTypeRaw));
            _isDataUprootedDefenseTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedDefenseTypeModified));
            _dataUprootedDefenseType = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataUprootedDefenseType, SetDataUprootedDefenseType));
        }

        public RootAncients(string newRawcode, ObjectDatabaseBase db): base(829387329, newRawcode, db)
        {
            _dataRootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedWeaponsRaw, SetDataRootedWeaponsRaw));
            _isDataRootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedWeaponsModified));
            _dataRootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataRootedWeapons, SetDataRootedWeapons));
            _dataUprootedWeaponsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedWeaponsRaw, SetDataUprootedWeaponsRaw));
            _isDataUprootedWeaponsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedWeaponsModified));
            _dataUprootedWeapons = new Lazy<ObjectProperty<AttackBits>>(() => new ObjectProperty<AttackBits>(GetDataUprootedWeapons, SetDataUprootedWeapons));
            _dataRootedTurningRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRootedTurningRaw, SetDataRootedTurningRaw));
            _isDataRootedTurningModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRootedTurningModified));
            _dataRootedTurning = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRootedTurning, SetDataRootedTurning));
            _dataUprootedDefenseTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataUprootedDefenseTypeRaw, SetDataUprootedDefenseTypeRaw));
            _isDataUprootedDefenseTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUprootedDefenseTypeModified));
            _dataUprootedDefenseType = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataUprootedDefenseType, SetDataUprootedDefenseType));
        }

        public ObjectProperty<int> DataRootedWeaponsRaw => _dataRootedWeaponsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataRootedWeaponsModified => _isDataRootedWeaponsModified.Value;
        public ObjectProperty<AttackBits> DataRootedWeapons => _dataRootedWeapons.Value;
        public ObjectProperty<int> DataUprootedWeaponsRaw => _dataUprootedWeaponsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUprootedWeaponsModified => _isDataUprootedWeaponsModified.Value;
        public ObjectProperty<AttackBits> DataUprootedWeapons => _dataUprootedWeapons.Value;
        public ObjectProperty<int> DataRootedTurningRaw => _dataRootedTurningRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataRootedTurningModified => _isDataRootedTurningModified.Value;
        public ObjectProperty<bool> DataRootedTurning => _dataRootedTurning.Value;
        public ObjectProperty<int> DataUprootedDefenseTypeRaw => _dataUprootedDefenseTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUprootedDefenseTypeModified => _isDataUprootedDefenseTypeModified.Value;
        public ObjectProperty<DefenseTypeInt> DataUprootedDefenseType => _dataUprootedDefenseType.Value;
        private int GetDataRootedWeaponsRaw(int level)
        {
            return _modifications.GetModification(829386578, level).ValueAsInt;
        }

        private void SetDataRootedWeaponsRaw(int level, int value)
        {
            _modifications[829386578, level] = new LevelObjectDataModification{Id = 829386578, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataRootedWeaponsModified(int level)
        {
            return _modifications.ContainsKey(829386578, level);
        }

        private AttackBits GetDataRootedWeapons(int level)
        {
            return GetDataRootedWeaponsRaw(level).ToAttackBits(this);
        }

        private void SetDataRootedWeapons(int level, AttackBits value)
        {
            SetDataRootedWeaponsRaw(level, value.ToRaw(0, 2));
        }

        private int GetDataUprootedWeaponsRaw(int level)
        {
            return _modifications.GetModification(846163794, level).ValueAsInt;
        }

        private void SetDataUprootedWeaponsRaw(int level, int value)
        {
            _modifications[846163794, level] = new LevelObjectDataModification{Id = 846163794, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataUprootedWeaponsModified(int level)
        {
            return _modifications.ContainsKey(846163794, level);
        }

        private AttackBits GetDataUprootedWeapons(int level)
        {
            return GetDataUprootedWeaponsRaw(level).ToAttackBits(this);
        }

        private void SetDataUprootedWeapons(int level, AttackBits value)
        {
            SetDataUprootedWeaponsRaw(level, value.ToRaw(0, 2));
        }

        private int GetDataRootedTurningRaw(int level)
        {
            return _modifications.GetModification(862941010, level).ValueAsInt;
        }

        private void SetDataRootedTurningRaw(int level, int value)
        {
            _modifications[862941010, level] = new LevelObjectDataModification{Id = 862941010, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataRootedTurningModified(int level)
        {
            return _modifications.ContainsKey(862941010, level);
        }

        private bool GetDataRootedTurning(int level)
        {
            return GetDataRootedTurningRaw(level).ToBool(this);
        }

        private void SetDataRootedTurning(int level, bool value)
        {
            SetDataRootedTurningRaw(level, value.ToRaw(0, 1));
        }

        private int GetDataUprootedDefenseTypeRaw(int level)
        {
            return _modifications.GetModification(879718226, level).ValueAsInt;
        }

        private void SetDataUprootedDefenseTypeRaw(int level, int value)
        {
            _modifications[879718226, level] = new LevelObjectDataModification{Id = 879718226, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataUprootedDefenseTypeModified(int level)
        {
            return _modifications.ContainsKey(879718226, level);
        }

        private DefenseTypeInt GetDataUprootedDefenseType(int level)
        {
            return GetDataUprootedDefenseTypeRaw(level).ToDefenseTypeInt(this);
        }

        private void SetDataUprootedDefenseType(int level, DefenseTypeInt value)
        {
            SetDataUprootedDefenseTypeRaw(level, value.ToRaw(null, null));
        }
    }
}