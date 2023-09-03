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
    public sealed class ReincarnationGeneric : Ability
    {
        public ReincarnationGeneric(): base(846351937)
        {
        }

        public ReincarnationGeneric(int newId): base(846351937, newId)
        {
        }

        public ReincarnationGeneric(string newRawcode): base(846351937, newRawcode)
        {
        }

        public ReincarnationGeneric(ObjectDatabaseBase db): base(846351937, db)
        {
        }

        public ReincarnationGeneric(int newId, ObjectDatabaseBase db): base(846351937, newId, db)
        {
        }

        public ReincarnationGeneric(string newRawcode, ObjectDatabaseBase db): base(846351937, newRawcode, db)
        {
        }
    }
}