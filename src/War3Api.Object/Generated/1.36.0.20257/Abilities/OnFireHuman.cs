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
    public sealed class OnFireHuman : Ability
    {
        public OnFireHuman(): base(1751737921)
        {
        }

        public OnFireHuman(int newId): base(1751737921, newId)
        {
        }

        public OnFireHuman(string newRawcode): base(1751737921, newRawcode)
        {
        }

        public OnFireHuman(ObjectDatabaseBase db): base(1751737921, db)
        {
        }

        public OnFireHuman(int newId, ObjectDatabaseBase db): base(1751737921, newId, db)
        {
        }

        public OnFireHuman(string newRawcode, ObjectDatabaseBase db): base(1751737921, newRawcode, db)
        {
        }
    }
}