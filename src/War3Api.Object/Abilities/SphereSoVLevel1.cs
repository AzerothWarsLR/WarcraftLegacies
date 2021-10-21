using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SphereSoVLevel1 : Ability
    {
        public SphereSoVLevel1(): base(829453121)
        {
        }

        public SphereSoVLevel1(int newId): base(829453121, newId)
        {
        }

        public SphereSoVLevel1(string newRawcode): base(829453121, newRawcode)
        {
        }

        public SphereSoVLevel1(ObjectDatabase db): base(829453121, db)
        {
        }

        public SphereSoVLevel1(int newId, ObjectDatabase db): base(829453121, newId, db)
        {
        }

        public SphereSoVLevel1(string newRawcode, ObjectDatabase db): base(829453121, newRawcode, db)
        {
        }
    }
}