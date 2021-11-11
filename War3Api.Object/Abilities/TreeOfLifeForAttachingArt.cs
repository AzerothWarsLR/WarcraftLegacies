using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TreeOfLifeForAttachingArt : Ability
    {
        public TreeOfLifeForAttachingArt(): base(1819243585)
        {
        }

        public TreeOfLifeForAttachingArt(int newId): base(1819243585, newId)
        {
        }

        public TreeOfLifeForAttachingArt(string newRawcode): base(1819243585, newRawcode)
        {
        }

        public TreeOfLifeForAttachingArt(ObjectDatabase db): base(1819243585, db)
        {
        }

        public TreeOfLifeForAttachingArt(int newId, ObjectDatabase db): base(1819243585, newId, db)
        {
        }

        public TreeOfLifeForAttachingArt(string newRawcode, ObjectDatabase db): base(1819243585, newRawcode, db)
        {
        }
    }
}