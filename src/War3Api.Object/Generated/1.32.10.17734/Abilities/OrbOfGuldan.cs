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
    public sealed class OrbOfGuldan : Ability
    {
        public OrbOfGuldan(): base(1684490561)
        {
        }

        public OrbOfGuldan(int newId): base(1684490561, newId)
        {
        }

        public OrbOfGuldan(string newRawcode): base(1684490561, newRawcode)
        {
        }

        public OrbOfGuldan(ObjectDatabaseBase db): base(1684490561, db)
        {
        }

        public OrbOfGuldan(int newId, ObjectDatabaseBase db): base(1684490561, newId, db)
        {
        }

        public OrbOfGuldan(string newRawcode, ObjectDatabaseBase db): base(1684490561, newRawcode, db)
        {
        }
    }
}