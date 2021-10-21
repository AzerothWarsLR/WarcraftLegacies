using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SphereSoVLevel2 : Ability
    {
        public SphereSoVLevel2(): base(846230337)
        {
        }

        public SphereSoVLevel2(int newId): base(846230337, newId)
        {
        }

        public SphereSoVLevel2(string newRawcode): base(846230337, newRawcode)
        {
        }

        public SphereSoVLevel2(ObjectDatabase db): base(846230337, db)
        {
        }

        public SphereSoVLevel2(int newId, ObjectDatabase db): base(846230337, newId, db)
        {
        }

        public SphereSoVLevel2(string newRawcode, ObjectDatabase db): base(846230337, newRawcode, db)
        {
        }
    }
}