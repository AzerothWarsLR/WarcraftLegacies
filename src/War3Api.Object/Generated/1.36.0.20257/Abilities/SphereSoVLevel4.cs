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

        public SphereSoVLevel4(ObjectDatabaseBase db): base(879784769, db)
        {
        }

        public SphereSoVLevel4(int newId, ObjectDatabaseBase db): base(879784769, newId, db)
        {
        }

        public SphereSoVLevel4(string newRawcode, ObjectDatabaseBase db): base(879784769, newRawcode, db)
        {
        }
    }
}