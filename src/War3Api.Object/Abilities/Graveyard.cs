using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Graveyard : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumNumberOfCorpses;
        private readonly Lazy<ObjectProperty<float>> _dataRadiusOfGravestones;
        private readonly Lazy<ObjectProperty<float>> _dataRadiusOfCorpses;
        private readonly Lazy<ObjectProperty<string>> _dataCorpseUnitTypeRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataCorpseUnitType;
        public Graveyard(): base(1685677889)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataRadiusOfGravestones = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfGravestones, SetDataRadiusOfGravestones));
            _dataRadiusOfCorpses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfCorpses, SetDataRadiusOfCorpses));
            _dataCorpseUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataCorpseUnitTypeRaw, SetDataCorpseUnitTypeRaw));
            _dataCorpseUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataCorpseUnitType, SetDataCorpseUnitType));
        }

        public Graveyard(int newId): base(1685677889, newId)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataRadiusOfGravestones = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfGravestones, SetDataRadiusOfGravestones));
            _dataRadiusOfCorpses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfCorpses, SetDataRadiusOfCorpses));
            _dataCorpseUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataCorpseUnitTypeRaw, SetDataCorpseUnitTypeRaw));
            _dataCorpseUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataCorpseUnitType, SetDataCorpseUnitType));
        }

        public Graveyard(string newRawcode): base(1685677889, newRawcode)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataRadiusOfGravestones = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfGravestones, SetDataRadiusOfGravestones));
            _dataRadiusOfCorpses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfCorpses, SetDataRadiusOfCorpses));
            _dataCorpseUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataCorpseUnitTypeRaw, SetDataCorpseUnitTypeRaw));
            _dataCorpseUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataCorpseUnitType, SetDataCorpseUnitType));
        }

        public Graveyard(ObjectDatabase db): base(1685677889, db)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataRadiusOfGravestones = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfGravestones, SetDataRadiusOfGravestones));
            _dataRadiusOfCorpses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfCorpses, SetDataRadiusOfCorpses));
            _dataCorpseUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataCorpseUnitTypeRaw, SetDataCorpseUnitTypeRaw));
            _dataCorpseUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataCorpseUnitType, SetDataCorpseUnitType));
        }

        public Graveyard(int newId, ObjectDatabase db): base(1685677889, newId, db)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataRadiusOfGravestones = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfGravestones, SetDataRadiusOfGravestones));
            _dataRadiusOfCorpses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfCorpses, SetDataRadiusOfCorpses));
            _dataCorpseUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataCorpseUnitTypeRaw, SetDataCorpseUnitTypeRaw));
            _dataCorpseUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataCorpseUnitType, SetDataCorpseUnitType));
        }

        public Graveyard(string newRawcode, ObjectDatabase db): base(1685677889, newRawcode, db)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataRadiusOfGravestones = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfGravestones, SetDataRadiusOfGravestones));
            _dataRadiusOfCorpses = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRadiusOfCorpses, SetDataRadiusOfCorpses));
            _dataCorpseUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataCorpseUnitTypeRaw, SetDataCorpseUnitTypeRaw));
            _dataCorpseUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataCorpseUnitType, SetDataCorpseUnitType));
        }

        public ObjectProperty<int> DataMaximumNumberOfCorpses => _dataMaximumNumberOfCorpses.Value;
        public ObjectProperty<float> DataRadiusOfGravestones => _dataRadiusOfGravestones.Value;
        public ObjectProperty<float> DataRadiusOfCorpses => _dataRadiusOfCorpses.Value;
        public ObjectProperty<string> DataCorpseUnitTypeRaw => _dataCorpseUnitTypeRaw.Value;
        public ObjectProperty<Unit> DataCorpseUnitType => _dataCorpseUnitType.Value;
        private int GetDataMaximumNumberOfCorpses(int level)
        {
            return _modifications[828668231, level].ValueAsInt;
        }

        private void SetDataMaximumNumberOfCorpses(int level, int value)
        {
            _modifications[828668231, level] = new LevelObjectDataModification{Id = 828668231, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataRadiusOfGravestones(int level)
        {
            return _modifications[845445447, level].ValueAsFloat;
        }

        private void SetDataRadiusOfGravestones(int level, float value)
        {
            _modifications[845445447, level] = new LevelObjectDataModification{Id = 845445447, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataRadiusOfCorpses(int level)
        {
            return _modifications[862222663, level].ValueAsFloat;
        }

        private void SetDataRadiusOfCorpses(int level, float value)
        {
            _modifications[862222663, level] = new LevelObjectDataModification{Id = 862222663, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private string GetDataCorpseUnitTypeRaw(int level)
        {
            return _modifications[1969518919, level].ValueAsString;
        }

        private void SetDataCorpseUnitTypeRaw(int level, string value)
        {
            _modifications[1969518919, level] = new LevelObjectDataModification{Id = 1969518919, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private Unit GetDataCorpseUnitType(int level)
        {
            return GetDataCorpseUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataCorpseUnitType(int level, Unit value)
        {
            SetDataCorpseUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}