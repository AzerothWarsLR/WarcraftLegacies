using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class StandDown : Ability
    {
        public StandDown(): base(1685353281)
        {
        }

        public StandDown(int newId): base(1685353281, newId)
        {
        }

        public StandDown(string newRawcode): base(1685353281, newRawcode)
        {
        }

        public StandDown(ObjectDatabase db): base(1685353281, db)
        {
        }

        public StandDown(int newId, ObjectDatabase db): base(1685353281, newId, db)
        {
        }

        public StandDown(string newRawcode, ObjectDatabase db): base(1685353281, newRawcode, db)
        {
        }
    }
}