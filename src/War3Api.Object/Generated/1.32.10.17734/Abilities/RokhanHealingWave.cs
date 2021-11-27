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
    public sealed class RokhanHealingWave : Ability
    {
        public RokhanHealingWave(): base(2003324481)
        {
        }

        public RokhanHealingWave(int newId): base(2003324481, newId)
        {
        }

        public RokhanHealingWave(string newRawcode): base(2003324481, newRawcode)
        {
        }

        public RokhanHealingWave(ObjectDatabaseBase db): base(2003324481, db)
        {
        }

        public RokhanHealingWave(int newId, ObjectDatabaseBase db): base(2003324481, newId, db)
        {
        }

        public RokhanHealingWave(string newRawcode, ObjectDatabaseBase db): base(2003324481, newRawcode, db)
        {
        }
    }
}