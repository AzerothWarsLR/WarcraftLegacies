using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SphereSoVLevel4 : Ability
    {
        public SphereSoVLevel4(): base(879784769)
        {
        }

        public SphereSoVLevel4(int newId): base(879784769, newId)
        {
        }

        public SphereSoVLevel4(string newRawcode): base(879784769, newRawcode)
        {
        }

        public SphereSoVLevel4(ObjectDatabase db): base(879784769, db)
        {
        }

        public SphereSoVLevel4(int newId, ObjectDatabase db): base(879784769, newId, db)
        {
        }

        public SphereSoVLevel4(string newRawcode, ObjectDatabase db): base(879784769, newRawcode, db)
        {
        }
    }
}