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
    public sealed class KeeperThornsAura : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealtToAttackers;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageDealtToAttackersModified;
        private readonly Lazy<ObjectProperty<int>> _dataDamageIsPercentReceivedRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageIsPercentReceivedModified;
        private readonly Lazy<ObjectProperty<bool>> _dataDamageIsPercentReceived;
        public KeeperThornsAura(): base(1751205185)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _isDataDamageDealtToAttackersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtToAttackersModified));
            _dataDamageIsPercentReceivedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageIsPercentReceivedRaw, SetDataDamageIsPercentReceivedRaw));
            _isDataDamageIsPercentReceivedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIsPercentReceivedModified));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public KeeperThornsAura(int newId): base(1751205185, newId)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _isDataDamageDealtToAttackersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtToAttackersModified));
            _dataDamageIsPercentReceivedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageIsPercentReceivedRaw, SetDataDamageIsPercentReceivedRaw));
            _isDataDamageIsPercentReceivedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIsPercentReceivedModified));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public KeeperThornsAura(string newRawcode): base(1751205185, newRawcode)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _isDataDamageDealtToAttackersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtToAttackersModified));
            _dataDamageIsPercentReceivedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageIsPercentReceivedRaw, SetDataDamageIsPercentReceivedRaw));
            _isDataDamageIsPercentReceivedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIsPercentReceivedModified));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public KeeperThornsAura(ObjectDatabaseBase db): base(1751205185, db)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _isDataDamageDealtToAttackersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtToAttackersModified));
            _dataDamageIsPercentReceivedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageIsPercentReceivedRaw, SetDataDamageIsPercentReceivedRaw));
            _isDataDamageIsPercentReceivedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIsPercentReceivedModified));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public KeeperThornsAura(int newId, ObjectDatabaseBase db): base(1751205185, newId, db)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _isDataDamageDealtToAttackersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtToAttackersModified));
            _dataDamageIsPercentReceivedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageIsPercentReceivedRaw, SetDataDamageIsPercentReceivedRaw));
            _isDataDamageIsPercentReceivedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIsPercentReceivedModified));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public KeeperThornsAura(string newRawcode, ObjectDatabaseBase db): base(1751205185, newRawcode, db)
        {
            _dataDamageDealtToAttackers = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealtToAttackers, SetDataDamageDealtToAttackers));
            _isDataDamageDealtToAttackersModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDealtToAttackersModified));
            _dataDamageIsPercentReceivedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageIsPercentReceivedRaw, SetDataDamageIsPercentReceivedRaw));
            _isDataDamageIsPercentReceivedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageIsPercentReceivedModified));
            _dataDamageIsPercentReceived = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDamageIsPercentReceived, SetDataDamageIsPercentReceived));
        }

        public ObjectProperty<float> DataDamageDealtToAttackers => _dataDamageDealtToAttackers.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageDealtToAttackersModified => _isDataDamageDealtToAttackersModified.Value;
        public ObjectProperty<int> DataDamageIsPercentReceivedRaw => _dataDamageIsPercentReceivedRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageIsPercentReceivedModified => _isDataDamageIsPercentReceivedModified.Value;
        public ObjectProperty<bool> DataDamageIsPercentReceived => _dataDamageIsPercentReceived.Value;
        private float GetDataDamageDealtToAttackers(int level)
        {
            return _modifications.GetModification(828924229, level).ValueAsFloat;
        }

        private void SetDataDamageDealtToAttackers(int level, float value)
        {
            _modifications[828924229, level] = new LevelObjectDataModification{Id = 828924229, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamageDealtToAttackersModified(int level)
        {
            return _modifications.ContainsKey(828924229, level);
        }

        private int GetDataDamageIsPercentReceivedRaw(int level)
        {
            return _modifications.GetModification(845701445, level).ValueAsInt;
        }

        private void SetDataDamageIsPercentReceivedRaw(int level, int value)
        {
            _modifications[845701445, level] = new LevelObjectDataModification{Id = 845701445, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageIsPercentReceivedModified(int level)
        {
            return _modifications.ContainsKey(845701445, level);
        }

        private bool GetDataDamageIsPercentReceived(int level)
        {
            return GetDataDamageIsPercentReceivedRaw(level).ToBool(this);
        }

        private void SetDataDamageIsPercentReceived(int level, bool value)
        {
            SetDataDamageIsPercentReceivedRaw(level, value.ToRaw(0, 1));
        }
    }
}