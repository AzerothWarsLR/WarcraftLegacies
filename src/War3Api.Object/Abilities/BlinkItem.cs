using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BlinkItem : Ability
    {
        public BlinkItem(): base(1801603393)
        {
        }

        public BlinkItem(int newId): base(1801603393, newId)
        {
        }

        public BlinkItem(string newRawcode): base(1801603393, newRawcode)
        {
        }

        public BlinkItem(ObjectDatabase db): base(1801603393, db)
        {
        }

        public BlinkItem(int newId, ObjectDatabase db): base(1801603393, newId, db)
        {
        }

        public BlinkItem(string newRawcode, ObjectDatabase db): base(1801603393, newRawcode, db)
        {
        }
    }
}