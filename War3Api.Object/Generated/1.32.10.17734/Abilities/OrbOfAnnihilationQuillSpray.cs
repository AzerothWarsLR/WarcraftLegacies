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
    public sealed class OrbOfAnnihilationQuillSpray : Ability
    {
        public OrbOfAnnihilationQuillSpray(): base(1801539137)
        {
        }

        public OrbOfAnnihilationQuillSpray(int newId): base(1801539137, newId)
        {
        }

        public OrbOfAnnihilationQuillSpray(string newRawcode): base(1801539137, newRawcode)
        {
        }

        public OrbOfAnnihilationQuillSpray(ObjectDatabaseBase db): base(1801539137, db)
        {
        }

        public OrbOfAnnihilationQuillSpray(int newId, ObjectDatabaseBase db): base(1801539137, newId, db)
        {
        }

        public OrbOfAnnihilationQuillSpray(string newRawcode, ObjectDatabaseBase db): base(1801539137, newRawcode, db)
        {
        }
    }
}