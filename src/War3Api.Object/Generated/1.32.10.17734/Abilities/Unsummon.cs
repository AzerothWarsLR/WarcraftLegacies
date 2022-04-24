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
    public sealed class Unsummon : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataSalvageCostRatio;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSalvageCostRatioModified;
        private readonly Lazy<ObjectProperty<int>> _dataAccumulationStep;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAccumulationStepModified;
        public Unsummon(): base(1936618817)
        {
            _dataSalvageCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSalvageCostRatio, SetDataSalvageCostRatio));
            _isDataSalvageCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSalvageCostRatioModified));
            _dataAccumulationStep = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAccumulationStep, SetDataAccumulationStep));
            _isDataAccumulationStepModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAccumulationStepModified));
        }

        public Unsummon(int newId): base(1936618817, newId)
        {
            _dataSalvageCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSalvageCostRatio, SetDataSalvageCostRatio));
            _isDataSalvageCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSalvageCostRatioModified));
            _dataAccumulationStep = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAccumulationStep, SetDataAccumulationStep));
            _isDataAccumulationStepModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAccumulationStepModified));
        }

        public Unsummon(string newRawcode): base(1936618817, newRawcode)
        {
            _dataSalvageCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSalvageCostRatio, SetDataSalvageCostRatio));
            _isDataSalvageCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSalvageCostRatioModified));
            _dataAccumulationStep = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAccumulationStep, SetDataAccumulationStep));
            _isDataAccumulationStepModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAccumulationStepModified));
        }

        public Unsummon(ObjectDatabaseBase db): base(1936618817, db)
        {
            _dataSalvageCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSalvageCostRatio, SetDataSalvageCostRatio));
            _isDataSalvageCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSalvageCostRatioModified));
            _dataAccumulationStep = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAccumulationStep, SetDataAccumulationStep));
            _isDataAccumulationStepModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAccumulationStepModified));
        }

        public Unsummon(int newId, ObjectDatabaseBase db): base(1936618817, newId, db)
        {
            _dataSalvageCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSalvageCostRatio, SetDataSalvageCostRatio));
            _isDataSalvageCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSalvageCostRatioModified));
            _dataAccumulationStep = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAccumulationStep, SetDataAccumulationStep));
            _isDataAccumulationStepModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAccumulationStepModified));
        }

        public Unsummon(string newRawcode, ObjectDatabaseBase db): base(1936618817, newRawcode, db)
        {
            _dataSalvageCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSalvageCostRatio, SetDataSalvageCostRatio));
            _isDataSalvageCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSalvageCostRatioModified));
            _dataAccumulationStep = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAccumulationStep, SetDataAccumulationStep));
            _isDataAccumulationStepModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAccumulationStepModified));
        }

        public ObjectProperty<float> DataSalvageCostRatio => _dataSalvageCostRatio.Value;
        public ReadOnlyObjectProperty<bool> IsDataSalvageCostRatioModified => _isDataSalvageCostRatioModified.Value;
        public ObjectProperty<int> DataAccumulationStep => _dataAccumulationStep.Value;
        public ReadOnlyObjectProperty<bool> IsDataAccumulationStepModified => _isDataAccumulationStepModified.Value;
        private float GetDataSalvageCostRatio(int level)
        {
            return _modifications.GetModification(829186387, level).ValueAsFloat;
        }

        private void SetDataSalvageCostRatio(int level, float value)
        {
            _modifications[829186387, level] = new LevelObjectDataModification{Id = 829186387, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataSalvageCostRatioModified(int level)
        {
            return _modifications.ContainsKey(829186387, level);
        }

        private int GetDataAccumulationStep(int level)
        {
            return _modifications.GetModification(845963603, level).ValueAsInt;
        }

        private void SetDataAccumulationStep(int level, int value)
        {
            _modifications[845963603, level] = new LevelObjectDataModification{Id = 845963603, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAccumulationStepModified(int level)
        {
            return _modifications.ContainsKey(845963603, level);
        }
    }
}