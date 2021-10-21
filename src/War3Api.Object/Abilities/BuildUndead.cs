using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BuildUndead : Ability
    {
        public BuildUndead(): base(1969378625)
        {
        }

        public BuildUndead(int newId): base(1969378625, newId)
        {
        }

        public BuildUndead(string newRawcode): base(1969378625, newRawcode)
        {
        }

        public BuildUndead(ObjectDatabase db): base(1969378625, db)
        {
        }

        public BuildUndead(int newId, ObjectDatabase db): base(1969378625, newId, db)
        {
        }

        public BuildUndead(string newRawcode, ObjectDatabase db): base(1969378625, newRawcode, db)
        {
        }
    }
}