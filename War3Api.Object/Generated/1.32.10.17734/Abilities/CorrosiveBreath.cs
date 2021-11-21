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
    public sealed class CorrosiveBreath : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerSecondModified;
        public CorrosiveBreath(): base(1919902529)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public CorrosiveBreath(int newId): base(1919902529, newId)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public CorrosiveBreath(string newRawcode): base(1919902529, newRawcode)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public CorrosiveBreath(ObjectDatabaseBase db): base(1919902529, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public CorrosiveBreath(int newId, ObjectDatabaseBase db): base(1919902529, newId, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public CorrosiveBreath(string newRawcode, ObjectDatabaseBase db): base(1919902529, newRawcode, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerSecondModified => _isDataDamagePerSecondModified.Value;
        private float GetDataDamagePerSecond(int level)
        {
            return _modifications.GetModification(829583171, level).ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[829583171, level] = new LevelObjectDataModification{Id = 829583171, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamagePerSecondModified(int level)
        {
            return _modifications.ContainsKey(829583171, level);
        }
    }
}