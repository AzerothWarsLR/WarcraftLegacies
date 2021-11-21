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
    public sealed class PassiveSimple : Ability
    {
        public PassiveSimple(): base(1767985217)
        {
        }

        public PassiveSimple(int newId): base(1767985217, newId)
        {
        }

        public PassiveSimple(string newRawcode): base(1767985217, newRawcode)
        {
        }

        public PassiveSimple(ObjectDatabaseBase db): base(1767985217, db)
        {
        }

        public PassiveSimple(int newId, ObjectDatabaseBase db): base(1767985217, newId, db)
        {
        }

        public PassiveSimple(string newRawcode, ObjectDatabaseBase db): base(1767985217, newRawcode, db)
        {
        }
    }
}