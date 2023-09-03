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
    public sealed class StormHammers : Ability
    {
        public StormHammers(): base(1752462145)
        {
        }

        public StormHammers(int newId): base(1752462145, newId)
        {
        }

        public StormHammers(string newRawcode): base(1752462145, newRawcode)
        {
        }

        public StormHammers(ObjectDatabaseBase db): base(1752462145, db)
        {
        }

        public StormHammers(int newId, ObjectDatabaseBase db): base(1752462145, newId, db)
        {
        }

        public StormHammers(string newRawcode, ObjectDatabaseBase db): base(1752462145, newRawcode, db)
        {
        }
    }
}