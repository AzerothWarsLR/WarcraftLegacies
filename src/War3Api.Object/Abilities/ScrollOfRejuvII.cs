using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ScrollOfRejuvII : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLifeRegenerated;
        private readonly Lazy<ObjectProperty<float>> _dataManaRegenerated;
        private readonly Lazy<ObjectProperty<int>> _dataAllowWhenFullRaw;
        private readonly Lazy<ObjectProperty<FullFlags>> _dataAllowWhenFull;
        private readonly Lazy<ObjectProperty<bool>> _dataNoTargetRequired;
        private readonly Lazy<ObjectProperty<bool>> _dataDispelOnAttack;
        public ScrollOfRejuvII(): base(913328449)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ScrollOfRejuvII(int newId): base(913328449, newId)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ScrollOfRejuvII(string newRawcode): base(913328449, newRawcode)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ScrollOfRejuvII(ObjectDatabase db): base(913328449, db)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ScrollOfRejuvII(int newId, ObjectDatabase db): base(913328449, newId, db)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ScrollOfRejuvII(string newRawcode, ObjectDatabase db): base(913328449, newRawcode, db)
        {
            _dataLifeRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerated, SetDataLifeRegenerated));
            _dataManaRegenerated = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerated, SetDataManaRegenerated));
            _dataAllowWhenFullRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowWhenFullRaw, SetDataAllowWhenFullRaw));
            _dataAllowWhenFull = new Lazy<ObjectProperty<FullFlags>>(() => new ObjectProperty<FullFlags>(GetDataAllowWhenFull, SetDataAllowWhenFull));
            _dataNoTargetRequired = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNoTargetRequired, SetDataNoTargetRequired));
            _dataDispelOnAttack = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDispelOnAttack, SetDataDispelOnAttack));
        }

        public ObjectProperty<float> DataLifeRegenerated => _dataLifeRegenerated.Value;
        public ObjectProperty<float> DataManaRegenerated => _dataManaRegenerated.Value;
        public ObjectProperty<int> DataAllowWhenFullRaw => _dataAllowWhenFullRaw.Value;
        public ObjectProperty<FullFlags> DataAllowWhenFull => _dataAllowWhenFull.Value;
        public ObjectProperty<bool> DataNoTargetRequired => _dataNoTargetRequired.Value;
        public ObjectProperty<bool> DataDispelOnAttack => _dataDispelOnAttack.Value;
        private float GetDataLifeRegenerated(int level)
        {
            return _modifications[829190761, level].ValueAsFloat;
        }

        private void SetDataLifeRegenerated(int level, float value)
        {
            _modifications[829190761, level] = new LevelObjectDataModification{Id = 829190761, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataManaRegenerated(int level)
        {
            return _modifications[845967977, level].ValueAsFloat;
        }

        private void SetDataManaRegenerated(int level, float value)
        {
            _modifications[845967977, level] = new LevelObjectDataModification{Id = 845967977, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataAllowWhenFullRaw(int level)
        {
            return _modifications[862745193, level].ValueAsInt;
        }

        private void SetDataAllowWhenFullRaw(int level, int value)
        {
            _modifications[862745193, level] = new LevelObjectDataModification{Id = 862745193, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
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

        private bool GetDataDispelOnAttack(int level)
        {
            return _modifications[896299625, level].ValueAsBool;
        }

        private void SetDataDispelOnAttack(int level, bool value)
        {
            _modifications[896299625, level] = new LevelObjectDataModification{Id = 896299625, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }
    }
}