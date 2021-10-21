using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MagicImmunity_Amim : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMagicDamageFactor;
        public MagicImmunity_Amim(): base(1835625793)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
        }

        public MagicImmunity_Amim(int newId): base(1835625793, newId)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
        }

        public MagicImmunity_Amim(string newRawcode): base(1835625793, newRawcode)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
        }

        public MagicImmunity_Amim(ObjectDatabase db): base(1835625793, db)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
        }

        public MagicImmunity_Amim(int newId, ObjectDatabase db): base(1835625793, newId, db)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
        }

        public MagicImmunity_Amim(string newRawcode, ObjectDatabase db): base(1835625793, newRawcode, db)
        {
            _dataMagicDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMagicDamageFactor, SetDataMagicDamageFactor));
        }

        public ObjectProperty<float> DataMagicDamageFactor => _dataMagicDamageFactor.Value;
        private float GetDataMagicDamageFactor(int level)
        {
            return _modifications[829253997, level].ValueAsFloat;
        }

        private void SetDataMagicDamageFactor(int level, float value)
        {
            _modifications[829253997, level] = new LevelObjectDataModification{Id = 829253997, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}