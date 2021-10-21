using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ShadowMeldAkama : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataFadeDuration;
        private readonly Lazy<ObjectProperty<float>> _dataDayNightDuration;
        private readonly Lazy<ObjectProperty<float>> _dataActionDuration;
        public ShadowMeldAkama(): base(1684629569)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
        }

        public ShadowMeldAkama(int newId): base(1684629569, newId)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
        }

        public ShadowMeldAkama(string newRawcode): base(1684629569, newRawcode)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
        }

        public ShadowMeldAkama(ObjectDatabase db): base(1684629569, db)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
        }

        public ShadowMeldAkama(int newId, ObjectDatabase db): base(1684629569, newId, db)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
        }

        public ShadowMeldAkama(string newRawcode, ObjectDatabase db): base(1684629569, newRawcode, db)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
        }

        public ObjectProperty<float> DataFadeDuration => _dataFadeDuration.Value;
        public ObjectProperty<float> DataDayNightDuration => _dataDayNightDuration.Value;
        public ObjectProperty<float> DataActionDuration => _dataActionDuration.Value;
        private float GetDataFadeDuration(int level)
        {
            return _modifications[829253715, level].ValueAsFloat;
        }

        private void SetDataFadeDuration(int level, float value)
        {
            _modifications[829253715, level] = new LevelObjectDataModification{Id = 829253715, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDayNightDuration(int level)
        {
            return _modifications[846030931, level].ValueAsFloat;
        }

        private void SetDataDayNightDuration(int level, float value)
        {
            _modifications[846030931, level] = new LevelObjectDataModification{Id = 846030931, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataActionDuration(int level)
        {
            return _modifications[862808147, level].ValueAsFloat;
        }

        private void SetDataActionDuration(int level, float value)
        {
            _modifications[862808147, level] = new LevelObjectDataModification{Id = 862808147, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}