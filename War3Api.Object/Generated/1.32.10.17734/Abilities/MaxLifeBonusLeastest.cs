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
    public sealed class MaxLifeBonusLeastest : Ability
    {
        public MaxLifeBonusLeastest(): base(2053916993)
        {
        }

        public MaxLifeBonusLeastest(int newId): base(2053916993, newId)
        {
        }

        public MaxLifeBonusLeastest(string newRawcode): base(2053916993, newRawcode)
        {
        }

        public MaxLifeBonusLeastest(ObjectDatabaseBase db): base(2053916993, db)
        {
        }

        public MaxLifeBonusLeastest(int newId, ObjectDatabaseBase db): base(2053916993, newId, db)
        {
        }

        public MaxLifeBonusLeastest(string newRawcode, ObjectDatabaseBase db): base(2053916993, newRawcode, db)
        {
        }
    }
}