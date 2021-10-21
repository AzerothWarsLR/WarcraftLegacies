using System;
using System.Collections.Generic;
using System.Linq;
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

        public BloodlustCreepHotkeyB(ObjectDatabase db): base(1650606913, db)
        {
        }

        public BloodlustCreepHotkeyB(int newId, ObjectDatabase db): base(1650606913, newId, db)
        {
        }

        public BloodlustCreepHotkeyB(string newRawcode, ObjectDatabase db): base(1650606913, newRawcode, db)
        {
        }
    }
}