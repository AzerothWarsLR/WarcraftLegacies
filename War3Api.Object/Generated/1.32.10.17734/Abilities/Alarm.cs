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
    public sealed class Alarm : Ability
    {
        public Alarm(): base(1919705409)
        {
        }

        public Alarm(int newId): base(1919705409, newId)
        {
        }

        public Alarm(string newRawcode): base(1919705409, newRawcode)
        {
        }

        public Alarm(ObjectDatabaseBase db): base(1919705409, db)
        {
        }

        public Alarm(int newId, ObjectDatabaseBase db): base(1919705409, newId, db)
        {
        }

        public Alarm(string newRawcode, ObjectDatabaseBase db): base(1919705409, newRawcode, db)
        {
        }
    }
}