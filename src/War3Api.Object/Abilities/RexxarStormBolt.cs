using System;
using System.Collections.Generic;
using System.Linq;
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

        public RexxarStormBolt(ObjectDatabase db): base(1651723841, db)
        {
        }

        public RexxarStormBolt(int newId, ObjectDatabase db): base(1651723841, newId, db)
        {
        }

        public RexxarStormBolt(string newRawcode, ObjectDatabase db): base(1651723841, newRawcode, db)
        {
        }
    }
}