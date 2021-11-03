using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PotionOfRejuvIV : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeRegenerated;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeRegeneratedModified;
        private readonly Lazy<ObjectProperty<float>> _dataManaRegenerated;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaRegeneratedModified;
        private readonly Lazy<ObjectProperty<int>> _dataAllowWhenFullRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAllowWhenFullModified;
        private readonly Lazy<ObjectProperty<FullFlags>> _dataAllowWhenFull;
        private readonly Lazy<ObjectProperty<bool>> _dataNoTargetRequired;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNoTargetRequiredModified;
        private readonly Lazy<ObjectProperty<bool>> _dataDispelOnAttack;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDispelOnAttackModified;
        public PotionOfRejuvIV(): base(879774017)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
        }

        public PotionOfRejuvIV(int newId): base(879774017, newId)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
        }

        public PotionOfRejuvIV(string newRawcode): base(879774017, newRawcode)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
        }

        public PotionOfRejuvIV(ObjectDatabase db): base(879774017, db)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
        }

        public PotionOfRejuvIV(int newId, ObjectDatabase db): base(879774017, newId, db)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
        }

        public PotionOfRejuvIV(string newRawcode, ObjectDatabase db): base(879774017, newRawcode, db)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _isDataLifeRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegeneratedModified));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _isDataManaRegeneratedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegeneratedModified));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _isDataAllowWhenFullModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowWhenFullModified));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _isDataNoTargetRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNoTargetRequiredModified));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
            _isDataDispelOnAttackModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDispelOnAttackModified));
        }

        public ObjectProperty<float> DataLifeRegenerated => _dataLifeRegenerated.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeRegeneratedModified => _isDataLifeRegeneratedModified.Value;
        public ObjectProperty<float> DataManaRegenerated => _dataManaRegenerated.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaRegeneratedModified => _isDataManaRegeneratedModified.Value;
        public ObjectProperty<int> DataAllowWhenFullRaw => _dataAllowWhenFullRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAllowWhenFullModified => _isDataAllowWhenFullModified.Value;
        public ObjectProperty<FullFlags> DataAllowWhenFull => _dataAllowWhenFull.Value;
        public ObjectProperty<bool> DataNoTargetRequired => _dataNoTargetRequired.Value;
        public ReadOnlyObjectProperty<bool> IsDataNoTargetRequiredModified => _isDataNoTargetRequiredModified.Value;
        public ObjectProperty<bool> DataDispelOnAttack => _dataDispelOnAttack.Value;
        public ReadOnlyObjectProperty<bool> IsDataDispelOnAttackModified => _isDataDispelOnAttackModified.Value;
        private float GetDataLifeRegenerated(int level)
        {
            return _modifications[829190761, level].ValueAsFloat;
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
            return _modifications[845967977, level].ValueAsFloat;
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
            return _modifications[862745193, level].ValueAsInt;
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

        private bool GetDataNoTargetRequired(int level)
        {
            return _modifications[879522409, level].ValueAsBool;
        }

        private void SetDataNoTargetRequired(int level, bool value)
        {
            _modifications[879522409, level] = new LevelObjectDataModification{Id = 879522409, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataNoTargetRequiredModified(int level)
        {
            return _modifications.ContainsKey(879522409, level);
        }

        private bool GetDataDispelOnAttack(int level)
        {
            return _modifications[896299625, level].ValueAsBool;
        }

        private void SetDataDispelOnAttack(int level, bool value)
        {
            _modifications[896299625, level] = new LevelObjectDataModification{Id = 896299625, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataDispelOnAttackModified(int level)
        {
            return _modifications.ContainsKey(896299625, level);
        }
    }
}