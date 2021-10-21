using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BrewmasterStormEarthAndFire : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataSummonedUnitTypesRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataSummonedUnitTypes;
        public BrewmasterStormEarthAndFire(): base(1717915201)
        {
            _dataSummonedUnitTypesRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypesRaw, SetDataSummonedUnitTypesRaw));
            _dataSummonedUnitTypes = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSummonedUnitTypes, SetDataSummonedUnitTypes));
        }

        public BrewmasterStormEarthAndFire(int newId): base(1717915201, newId)
        {
            _dataSummonedUnitTypesRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypesRaw, SetDataSummonedUnitTypesRaw));
            _dataSummonedUnitTypes = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSummonedUnitTypes, SetDataSummonedUnitTypes));
        }

        public BrewmasterStormEarthAndFire(string newRawcode): base(1717915201, newRawcode)
        {
            _dataSummonedUnitTypesRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypesRaw, SetDataSummonedUnitTypesRaw));
            _dataSummonedUnitTypes = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSummonedUnitTypes, SetDataSummonedUnitTypes));
        }

        public BrewmasterStormEarthAndFire(ObjectDatabase db): base(1717915201, db)
        {
            _dataSummonedUnitTypesRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypesRaw, SetDataSummonedUnitTypesRaw));
            _dataSummonedUnitTypes = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSummonedUnitTypes, SetDataSummonedUnitTypes));
        }

        public BrewmasterStormEarthAndFire(int newId, ObjectDatabase db): base(1717915201, newId, db)
        {
            _dataSummonedUnitTypesRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypesRaw, SetDataSummonedUnitTypesRaw));
            _dataSummonedUnitTypes = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSummonedUnitTypes, SetDataSummonedUnitTypes));
        }

        public BrewmasterStormEarthAndFire(string newRawcode, ObjectDatabase db): base(1717915201, newRawcode, db)
        {
            _dataSummonedUnitTypesRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypesRaw, SetDataSummonedUnitTypesRaw));
            _dataSummonedUnitTypes = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSummonedUnitTypes, SetDataSummonedUnitTypes));
        }

        public ObjectProperty<string> DataSummonedUnitTypesRaw => _dataSummonedUnitTypesRaw.Value;
        public ObjectProperty<IEnumerable<Unit>> DataSummonedUnitTypes => _dataSummonedUnitTypes.Value;
        private string GetDataSummonedUnitTypesRaw(int level)
        {
            return _modifications[828794190, level].ValueAsString;
        }

        private void SetDataSummonedUnitTypesRaw(int level, string value)
        {
            _modifications[828794190, level] = new LevelObjectDataModification{Id = 828794190, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 1};
        }

        private IEnumerable<Unit> GetDataSummonedUnitTypes(int level)
        {
            return GetDataSummonedUnitTypesRaw(level).ToIEnumerableUnit(this);
        }

        private void SetDataSummonedUnitTypes(int level, IEnumerable<Unit> value)
        {
            SetDataSummonedUnitTypesRaw(level, value.ToRaw(null, null));
        }
    }
}