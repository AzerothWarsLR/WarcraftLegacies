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
    public sealed class ScrollOfRejuvI : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeRegenerated;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeRegeneratedModified;
        private readonly Lazy<ObjectProperty<float>> _dataManaRegenerated;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaRegeneratedModified;
        private readonly Lazy<ObjectProperty<int>> _dataAllowWhenFullRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAllowWhenFullModified;
        private readonly Lazy<ObjectProperty<FullFlags>> _dataAllowWhenFull;
        private readonly Lazy<ObjectProperty<int>> _dataNoTargetRequiredRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNoTargetRequiredModified;
        private readonly Lazy<ObjectProperty<bool>> _dataNoTargetRequired;
        private readonly Lazy<ObjectProperty<int>> _dataDispelOnAttackRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDispelOnAttackModified;
        private readonly Lazy<ObjectProperty<bool>> _dataDispelOnAttack;
        public ScrollOfRejuvI(): base(896551233)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttackRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDispelOnAttackRaw, SetDataDispelOnAttackRaw));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ScrollOfRejuvI(int newId): base(896551233, newId)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttackRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDispelOnAttackRaw, SetDataDispelOnAttackRaw));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ScrollOfRejuvI(string newRawcode): base(896551233, newRawcode)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttackRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDispelOnAttackRaw, SetDataDispelOnAttackRaw));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ScrollOfRejuvI(ObjectDatabaseBase db): base(896551233, db)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttackRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDispelOnAttackRaw, SetDataDispelOnAttackRaw));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ScrollOfRejuvI(int newId, ObjectDatabaseBase db): base(896551233, newId, db)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttackRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDispelOnAttackRaw, SetDataDispelOnAttackRaw));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ScrollOfRejuvI(string newRawcode, ObjectDatabaseBase db): base(896551233, newRawcode, db)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequiredRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNoTargetRequiredRaw, SetDataNoTargetRequiredRaw));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttackRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDispelOnAttackRaw, SetDataDispelOnAttackRaw));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ObjectProperty<float> DataLifeRegenerated => _dataLifeRegenerated.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeRegeneratedModified => _isDataLifeRegeneratedModified.Value;
        public ObjectProperty<float> DataManaRegenerated => _dataManaRegenerated.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaRegeneratedModified => _isDataManaRegeneratedModified.Value;
        public ObjectProperty<int> DataAllowWhenFullRaw => _dataAllowWhenFullRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAllowWhenFullModified => _isDataAllowWhenFullModified.Value;
        public ObjectProperty<FullFlags> DataAllowWhenFull => _dataAllowWhenFull.Value;
        public ObjectProperty<int> DataNoTargetRequiredRaw => _dataNoTargetRequiredRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataNoTargetRequiredModified => _isDataNoTargetRequiredModified.Value;
        public ObjectProperty<bool> DataNoTargetRequired => _dataNoTargetRequired.Value;
        public ObjectProperty<int> DataDispelOnAttackRaw => _dataDispelOnAttackRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDispelOnAttackModified => _isDataDispelOnAttackModified.Value;
        public ObjectProperty<bool> DataDispelOnAttack => _dataDispelOnAttack.Value;
        private float GetDataLifeRegenerated(int level)
        {
            return _modifications.GetModification(829190761, level).ValueAsFloat;
        }

        private void SetDataLifeRegenerated(int level, float value)
        {
            _modifications[829190761, level] = new LevelObjectDataModification{Id = 829190761, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataLifeRegeneratedModified(int level)
        {
            return _modifications.ContainsKey(829190761, level);
        }

        private float GetDataManaRegenerated(int level)
        {
            return _modifications.GetModification(845967977, level).ValueAsFloat;
        }

        private void SetDataManaRegenerated(int level, float value)
        {
            _modifications[845967977, level] = new LevelObjectDataModification{Id = 845967977, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataManaRegeneratedModified(int level)
        {
            return _modifications.ContainsKey(845967977, level);
        }

        private int GetDataAllowWhenFullRaw(int level)
        {
            return _modifications.GetModification(862745193, level).ValueAsInt;
        }

        private void SetDataAllowWhenFullRaw(int level, int value)
        {
            _modifications[862745193, level] = new LevelObjectDataModification{Id = 862745193, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataAllowWhenFullModified(int level)
        {
            return _modifications.ContainsKey(862745193, level);
        }

        private FullFlags GetDataAllowWhenFull(int level)
        {
            return GetDataAllowWhenFullRaw(level).ToFullFlags(this);
        }

        private void SetDataAllowWhenFull(int level, FullFlags value)
        {
            SetDataAllowWhenFullRaw(level, value.ToRaw(null, null));
        }

        private int GetDataNoTargetRequiredRaw(int level)
        {
            return _modifications.GetModification(879522409, level).ValueAsInt;
        }

        private void SetDataNoTargetRequiredRaw(int level, int value)
        {
            _modifications[879522409, level] = new LevelObjectDataModification{Id = 879522409, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataNoTargetRequiredModified(int level)
        {
            return _modifications.ContainsKey(879522409, level);
        }

        private bool GetDataNoTargetRequired(int level)
        {
            return GetDataNoTargetRequiredRaw(level).ToBool(this);
        }

        private void SetDataNoTargetRequired(int level, bool value)
        {
            SetDataNoTargetRequiredRaw(level, value.ToRaw(null, null));
        }

        private int GetDataDispelOnAttackRaw(int level)
        {
            return _modifications.GetModification(896299625, level).ValueAsInt;
        }

        private void SetDataDispelOnAttackRaw(int level, int value)
        {
            _modifications[896299625, level] = new LevelObjectDataModification{Id = 896299625, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataDispelOnAttackModified(int level)
        {
            return _modifications.ContainsKey(896299625, level);
        }

        private bool GetDataDispelOnAttack(int level)
        {
            return GetDataDispelOnAttackRaw(level).ToBool(this);
        }

        private void SetDataDispelOnAttack(int level, bool value)
        {
            SetDataDispelOnAttackRaw(level, value.ToRaw(null, null));
        }
    }
}