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
    public sealed class RexxarStormBolt : Ability
    {
        public RexxarStormBolt(): base(1651723841)
        {
        }

        public RexxarStormBolt(int newId): base(1651723841, newId)
        {
        }

        public RexxarStormBolt(string newRawcode): base(1651723841, newRawcode)
        {
        }

        public RexxarStormBolt(ObjectDatabaseBase db): base(1651723841, db)
        {
        }

        public RexxarStormBolt(int newId, ObjectDatabaseBase db): base(1651723841, newId, db)
        {
        }

        public RexxarStormBolt(string newRawcode, ObjectDatabaseBase db): base(1651723841, newRawcode, db)
        {
        }
    }
}