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
    public sealed class TornadoWander : Ability
    {
        public TornadoWander(): base(1635218497)
        {
        }

        public TornadoWander(int newId): base(1635218497, newId)
        {
        }

        public TornadoWander(string newRawcode): base(1635218497, newRawcode)
        {
        }

        public TornadoWander(ObjectDatabaseBase db): base(1635218497, db)
        {
        }

        public TornadoWander(int newId, ObjectDatabaseBase db): base(1635218497, newId, db)
        {
        }

        public TornadoWander(string newRawcode, ObjectDatabaseBase db): base(1635218497, newRawcode, db)
        {
        }
    }
}