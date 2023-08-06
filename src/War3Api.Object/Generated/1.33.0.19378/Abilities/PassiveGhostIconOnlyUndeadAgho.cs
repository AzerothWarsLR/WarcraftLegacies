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
    public sealed class PassiveGhostIconOnlyUndeadAgho : Ability
    {
        public PassiveGhostIconOnlyUndeadAgho(): base(1751610689)
        {
        }

        public PassiveGhostIconOnlyUndeadAgho(int newId): base(1751610689, newId)
        {
        }

        public PassiveGhostIconOnlyUndeadAgho(string newRawcode): base(1751610689, newRawcode)
        {
        }

        public PassiveGhostIconOnlyUndeadAgho(ObjectDatabaseBase db): base(1751610689, db)
        {
        }

        public PassiveGhostIconOnlyUndeadAgho(int newId, ObjectDatabaseBase db): base(1751610689, newId, db)
        {
        }

        public PassiveGhostIconOnlyUndeadAgho(string newRawcode, ObjectDatabaseBase db): base(1751610689, newRawcode, db)
        {
        }
    }
}