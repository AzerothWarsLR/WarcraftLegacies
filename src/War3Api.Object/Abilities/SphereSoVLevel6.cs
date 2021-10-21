using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SphereSoVLevel6 : Ability
    {
        public SphereSoVLevel6(): base(913339201)
        {
        }

        public SphereSoVLevel6(int newId): base(913339201, newId)
        {
        }

        public SphereSoVLevel6(string newRawcode): base(913339201, newRawcode)
        {
        }

        public SphereSoVLevel6(ObjectDatabase db): base(913339201, db)
        {
        }

        public SphereSoVLevel6(int newId, ObjectDatabase db): base(913339201, newId, db)
        {
        }

        public SphereSoVLevel6(string newRawcode, ObjectDatabase db): base(913339201, newRawcode, db)
        {
        }
    }
}