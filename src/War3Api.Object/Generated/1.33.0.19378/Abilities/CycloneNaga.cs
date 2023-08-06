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
    public sealed class CycloneNaga : Ability
    {
        public CycloneNaga(): base(2037277505)
        {
        }

        public CycloneNaga(int newId): base(2037277505, newId)
        {
        }

        public CycloneNaga(string newRawcode): base(2037277505, newRawcode)
        {
        }

        public CycloneNaga(ObjectDatabaseBase db): base(2037277505, db)
        {
        }

        public CycloneNaga(int newId, ObjectDatabaseBase db): base(2037277505, newId, db)
        {
        }

        public CycloneNaga(string newRawcode, ObjectDatabaseBase db): base(2037277505, newRawcode, db)
        {
        }
    }
}