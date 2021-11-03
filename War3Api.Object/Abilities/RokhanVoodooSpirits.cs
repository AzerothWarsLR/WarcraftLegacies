using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class RokhanVoodooSpirits : Ability
    {
        public RokhanVoodooSpirits(): base(1936478017)
        {
        }

        public RokhanVoodooSpirits(int newId): base(1936478017, newId)
        {
        }

        public RokhanVoodooSpirits(string newRawcode): base(1936478017, newRawcode)
        {
        }

        public RokhanVoodooSpirits(ObjectDatabase db): base(1936478017, db)
        {
        }

        public RokhanVoodooSpirits(int newId, ObjectDatabase db): base(1936478017, newId, db)
        {
        }

        public RokhanVoodooSpirits(string newRawcode, ObjectDatabase db): base(1936478017, newRawcode, db)
        {
        }
    }
}