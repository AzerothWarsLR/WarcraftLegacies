using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ChenDrunkenHaze : Ability
    {
        public ChenDrunkenHaze(): base(1751409473)
        {
        }

        public ChenDrunkenHaze(int newId): base(1751409473, newId)
        {
        }

        public ChenDrunkenHaze(string newRawcode): base(1751409473, newRawcode)
        {
        }

        public ChenDrunkenHaze(ObjectDatabase db): base(1751409473, db)
        {
        }

        public ChenDrunkenHaze(int newId, ObjectDatabase db): base(1751409473, newId, db)
        {
        }

        public ChenDrunkenHaze(string newRawcode, ObjectDatabase db): base(1751409473, newRawcode, db)
        {
        }
    }
}