using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ShadowMeldItem : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataFadeDuration;
        private readonly Lazy<ObjectProperty<float>> _dataDayNightDuration;
        private readonly Lazy<ObjectProperty<float>> _dataActionDuration;
        private readonly Lazy<ObjectProperty<bool>> _dataPermanentCloak;
        public ShadowMeldItem(): base(1835551041)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
            _dataPermanentCloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPermanentCloak, SetDataPermanentCloak));
        }

        public ShadowMeldItem(int newId): base(1835551041, newId)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
            _dataPermanentCloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPermanentCloak, SetDataPermanentCloak));
        }

        public ShadowMeldItem(string newRawcode): base(1835551041, newRawcode)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
            _dataPermanentCloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPermanentCloak, SetDataPermanentCloak));
        }

        public ShadowMeldItem(ObjectDatabase db): base(1835551041, db)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
            _dataPermanentCloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPermanentCloak, SetDataPermanentCloak));
        }

        public ShadowMeldItem(int newId, ObjectDatabase db): base(1835551041, newId, db)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
            _dataPermanentCloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPermanentCloak, SetDataPermanentCloak));
        }

        public ShadowMeldItem(string newRawcode, ObjectDatabase db): base(1835551041, newRawcode, db)
        {
            _dataFadeDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFadeDuration, SetDataFadeDuration));
            _dataDayNightDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDayNightDuration, SetDataDayNightDuration));
            _dataActionDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataActionDuration, SetDataActionDuration));
            _dataPermanentCloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPermanentCloak, SetDataPermanentCloak));
        }

        public ObjectProperty<float> DataFadeDuration => _dataFadeDuration.Value;
        public ObjectProperty<float> DataDayNightDuration => _dataDayNightDuration.Value;
        public ObjectProperty<float> DataActionDuration => _dataActionDuration.Value;
        public ObjectProperty<bool> DataPermanentCloak => _dataPermanentCloak.Value;
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

        private bool GetDataPermanentCloak(int level)
        {
            return _modifications[879585363, level].ValueAsBool;
        }

        private void SetDataPermanentCloak(int level, bool value)
        {
            _modifications[879585363, level] = new LevelObjectDataModification{Id = 879585363, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }
    }
}