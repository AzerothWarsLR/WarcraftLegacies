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
    public sealed class BloodlustCreepHotkeyB : Ability
    {
        public BloodlustCreepHotkeyB(): base(1650606913)
        {
        }

        public BloodlustCreepHotkeyB(int newId): base(1650606913, newId)
        {
        }

        public BloodlustCreepHotkeyB(string newRawcode): base(1650606913, newRawcode)
        {
        }

        public BloodlustCreepHotkeyB(ObjectDatabaseBase db): base(1650606913, db)
        {
        }

        public BloodlustCreepHotkeyB(int newId, ObjectDatabaseBase db): base(1650606913, newId, db)
        {
        }

        public BloodlustCreepHotkeyB(string newRawcode, ObjectDatabaseBase db): base(1650606913, newRawcode, db)
        {
        }
    }
}