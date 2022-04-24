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
    public sealed class RexxarSummonQuilbeast : Ability
    {
        public RexxarSummonQuilbeast(): base(1903391297)
        {
        }

        public RexxarSummonQuilbeast(int newId): base(1903391297, newId)
        {
        }

        public RexxarSummonQuilbeast(string newRawcode): base(1903391297, newRawcode)
        {
        }

        public RexxarSummonQuilbeast(ObjectDatabaseBase db): base(1903391297, db)
        {
        }

        public RexxarSummonQuilbeast(int newId, ObjectDatabaseBase db): base(1903391297, newId, db)
        {
        }

        public RexxarSummonQuilbeast(string newRawcode, ObjectDatabaseBase db): base(1903391297, newRawcode, db)
        {
        }
    }
}