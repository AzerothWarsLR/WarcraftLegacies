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
    public sealed class SphereSoVLevel5 : Ability
    {
        public SphereSoVLevel5(): base(896561985)
        {
        }

        public SphereSoVLevel5(int newId): base(896561985, newId)
        {
        }

        public SphereSoVLevel5(string newRawcode): base(896561985, newRawcode)
        {
        }

        public SphereSoVLevel5(ObjectDatabaseBase db): base(896561985, db)
        {
        }

        public SphereSoVLevel5(int newId, ObjectDatabaseBase db): base(896561985, newId, db)
        {
        }

        public SphereSoVLevel5(string newRawcode, ObjectDatabaseBase db): base(896561985, newRawcode, db)
        {
        }
    }
}