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
    public sealed class PassivePhoenixFireAndEgg : Ability
    {
        public PassivePhoenixFireAndEgg(): base(1701865537)
        {
        }

        public PassivePhoenixFireAndEgg(int newId): base(1701865537, newId)
        {
        }

        public PassivePhoenixFireAndEgg(string newRawcode): base(1701865537, newRawcode)
        {
        }

        public PassivePhoenixFireAndEgg(ObjectDatabaseBase db): base(1701865537, db)
        {
        }

        public PassivePhoenixFireAndEgg(int newId, ObjectDatabaseBase db): base(1701865537, newId, db)
        {
        }

        public PassivePhoenixFireAndEgg(string newRawcode, ObjectDatabaseBase db): base(1701865537, newRawcode, db)
        {
        }
    }
}