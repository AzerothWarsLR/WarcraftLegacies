using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class KeeperThornsAura : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealtToAttackers;
        private readonly Lazy<ObjectProperty<bool>> _dataDamageIsPercentReceived;
        public KeeperThornsAura(): base(1751205185)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public KeeperThornsAura(int newId): base(1751205185, newId)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public KeeperThornsAura(string newRawcode): base(1751205185, newRawcode)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public KeeperThornsAura(ObjectDatabase db): base(1751205185, db)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public KeeperThornsAura(int newId, ObjectDatabase db): base(1751205185, newId, db)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public KeeperThornsAura(string newRawcode, ObjectDatabase db): base(1751205185, newRawcode, db)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public ObjectProperty<float> DataDamageDealtToAttackers => _dataDamageDealtToAttackers.Value;
        public ObjectProperty<bool> DataDamageIsPercentReceived => _dataDamageIsPercentReceived.Value;
        private float GetDataDamageDealtToAttackers(int level)
        {
            return _modifications[828924229, level].ValueAsFloat;
        }

        private void SetDataDamageDealtToAttackers(int level, float value)
        {
            _modifications[828924229, level] = new LevelObjectDataModification{Id = 828924229, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetDataDamageIsPercentReceived(int level)
        {
            return _modifications[845701445, level].ValueAsBool;
        }

        private void SetDataDamageIsPercentReceived(int level, bool value)
        {
            _modifications[845701445, level] = new LevelObjectDataModification{Id = 845701445, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }
    }
}