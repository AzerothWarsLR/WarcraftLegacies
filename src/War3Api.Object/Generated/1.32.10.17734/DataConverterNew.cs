using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    internal static class DataConverterNew
    {
        internal static AiBuffer ToAiBuffer(this string value, BaseObject baseObject)
        {
             return  ( AiBuffer ) Enum . Parse ( typeof ( AiBuffer ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this AiBuffer value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static ArmorType ToArmorType(this string value, BaseObject baseObject)
        {
             return  ( ArmorType ) Enum . Parse ( typeof ( ArmorType ) ,  value ,  false ) ;
        }

        internal static string ToRaw(this ArmorType value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) ;
        }

        internal static AttackBits ToAttackBits(this int value, BaseObject baseObject)
        {
             return  ( AttackBits ) value ;
        }

        internal static int ToRaw(this AttackBits value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static AttackType ToAttackType(this string value, BaseObject baseObject)
        {
             return  ( AttackType ) Enum . Parse ( typeof ( AttackType ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this AttackType value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static AttributeType ToAttributeType(this string value, BaseObject baseObject)
        {
             return  ( AttributeType ) Enum . Parse ( typeof ( AttributeType ) ,  value ,  false ) ;
        }

        internal static string ToRaw(this AttributeType value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) ;
        }

        internal static ChannelFlags ToChannelFlags(this int value, BaseObject baseObject)
        {
             return  ( ChannelFlags ) value ;
        }

        internal static int ToRaw(this ChannelFlags value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static ChannelType ToChannelType(this int value, BaseObject baseObject)
        {
             return  ( ChannelType ) value ;
        }

        internal static int ToRaw(this ChannelType value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static CombatSound ToCombatSound(this string value, BaseObject baseObject)
        {
             return  ( CombatSound ) Enum . Parse ( typeof ( CombatSound ) ,  value ,  false ) ;
        }

        internal static string ToRaw(this CombatSound value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) ;
        }

        internal static DeathType ToDeathType(this int value, BaseObject baseObject)
        {
             return  ( DeathType ) value ;
        }

        internal static int ToRaw(this DeathType value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static DefenseType ToDefenseType(this string value, BaseObject baseObject)
        {
             return  ( DefenseType ) Enum . Parse ( typeof ( DefenseType ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this DefenseType value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static DefenseTypeInt ToDefenseTypeInt(this int value, BaseObject baseObject)
        {
             return  ( DefenseTypeInt ) value ;
        }

        internal static int ToRaw(this DefenseTypeInt value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static DestructableCategory ToDestructableCategory(this string value, BaseObject baseObject)
        {
             return  ( DestructableCategory ) char . Parse ( value ) ;
        }

        internal static string ToRaw(this DestructableCategory value, int? minValue, int? maxValue)
        {
             return  ( ( char ) value ) . ToString ( ) ;
        }

        internal static DetectionType ToDetectionType(this int value, BaseObject baseObject)
        {
             return  ( DetectionType ) value ;
        }

        internal static int ToRaw(this DetectionType value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static DoodadCategory ToDoodadCategory(this string value, BaseObject baseObject)
        {
             return  ( DoodadCategory ) char . Parse ( value ) ;
        }

        internal static string ToRaw(this DoodadCategory value, int? minValue, int? maxValue)
        {
             return  ( ( char ) value ) . ToString ( ) ;
        }

        internal static FullFlags ToFullFlags(this int value, BaseObject baseObject)
        {
             return  ( FullFlags ) value ;
        }

        internal static int ToRaw(this FullFlags value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static InteractionFlags ToInteractionFlags(this int value, BaseObject baseObject)
        {
             return  ( InteractionFlags ) value ;
        }

        internal static int ToRaw(this InteractionFlags value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static ItemClass ToItemClass(this string value, BaseObject baseObject)
        {
             return  ( ItemClass ) Enum . Parse ( typeof ( ItemClass ) ,  value ,  false ) ;
        }

        internal static string ToRaw(this ItemClass value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) ;
        }

        internal static LightningEffect ToLightningEffect(this string value, BaseObject baseObject)
        {
             return  ( LightningEffect ) Enum . Parse ( typeof ( LightningEffect ) ,  value ,  false ) ;
        }

        internal static string ToRaw(this LightningEffect value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) ;
        }

        internal static MorphFlags ToMorphFlags(this int value, BaseObject baseObject)
        {
             return  ( MorphFlags ) value ;
        }

        internal static int ToRaw(this MorphFlags value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static MoveType ToMoveType(this string value, BaseObject baseObject)
        {
             return  ( MoveType ) Enum . Parse ( typeof ( MoveType ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this MoveType value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static PickFlags ToPickFlags(this int value, BaseObject baseObject)
        {
             return  ( PickFlags ) value ;
        }

        internal static int ToRaw(this PickFlags value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static RegenType ToRegenType(this string value, BaseObject baseObject)
        {
             return  ( RegenType ) Enum . Parse ( typeof ( RegenType ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this RegenType value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static ShadowImage ToShadowImage(this string value, BaseObject baseObject)
        {
             return  ( ShadowImage ) Enum . Parse ( typeof ( ShadowImage ) ,  value ,  false ) ;
        }

        internal static string ToRaw(this ShadowImage value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) ;
        }

        internal static SilenceFlags ToSilenceFlags(this int value, BaseObject baseObject)
        {
             return  ( SilenceFlags ) value ;
        }

        internal static int ToRaw(this SilenceFlags value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static SpellDetail ToSpellDetail(this int value, BaseObject baseObject)
        {
             return  ( SpellDetail ) value ;
        }

        internal static int ToRaw(this SpellDetail value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static StackFlags ToStackFlags(this int value, BaseObject baseObject)
        {
             return  ( StackFlags ) value ;
        }

        internal static int ToRaw(this StackFlags value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static TeamColor ToTeamColor(this int value, BaseObject baseObject)
        {
             return  ( TeamColor ) value ;
        }

        internal static int ToRaw(this TeamColor value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static UnitRace ToUnitRace(this string value, BaseObject baseObject)
        {
             return  ( UnitRace ) Enum . Parse ( typeof ( UnitRace ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this UnitRace value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static UpgradeClass ToUpgradeClass(this string value, BaseObject baseObject)
        {
             return  ( UpgradeClass ) Enum . Parse ( typeof ( UpgradeClass ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this UpgradeClass value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static UpgradeEffect ToUpgradeEffect(this string value, BaseObject baseObject)
        {
             return  ( UpgradeEffect ) Enum . Parse ( typeof ( UpgradeEffect ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this UpgradeEffect value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static VersionFlags ToVersionFlags(this int value, BaseObject baseObject)
        {
             return  ( VersionFlags ) value ;
        }

        internal static int ToRaw(this VersionFlags value, int? minValue, int? maxValue)
        {
             return  ( int ) value ;
        }

        internal static WeaponType ToWeaponType(this string value, BaseObject baseObject)
        {
             return  ( WeaponType ) Enum . Parse ( typeof ( WeaponType ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this WeaponType value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static PathingType ToPathingType(this string value, BaseObject baseObject)
        {
             return  ( PathingType ) Enum . Parse ( typeof ( PathingType ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this PathingType value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static Target ToTarget(this string value, BaseObject baseObject)
        {
             return  ( Target ) Enum . Parse ( typeof ( Target ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this Target value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static Tileset ToTileset(this string value, BaseObject baseObject)
        {
             return  ( Tileset ) char . Parse ( value ) ;
        }

        internal static string ToRaw(this Tileset value, int? minValue, int? maxValue)
        {
             return  ( ( char ) value ) . ToString ( ) ;
        }

        internal static UnitClassification ToUnitClassification(this string value, BaseObject baseObject)
        {
             return  ( UnitClassification ) Enum . Parse ( typeof ( UnitClassification ) ,  value ,  true ) ;
        }

        internal static string ToRaw(this UnitClassification value, int? minValue, int? maxValue)
        {
             return  value . ToString ( ) . ToLowerInvariant ( ) ;
        }

        internal static Ability ToAbility(this string value, BaseObject baseObject)
        {
             return  baseObject . Db . GetAbility ( value . FromRawcode ( ) ) ;
        }

        internal static string ToRaw(this Ability value, int? minValue, int? maxValue)
        {
             return  value . Key . ToRawcode ( ) ;
        }

        internal static Unit ToUnit(this string value, BaseObject baseObject)
        {
             return  baseObject . Db . GetUnit ( value . FromRawcode ( ) ) ;
        }

        internal static string ToRaw(this Unit value, int? minValue, int? maxValue)
        {
             return  value . Key . ToRawcode ( ) ;
        }

        internal static Upgrade ToUpgrade(this string value, BaseObject baseObject)
        {
             return  baseObject . Db . GetUpgrade ( value . FromRawcode ( ) ) ;
        }

        internal static string ToRaw(this Upgrade value, int? minValue, int? maxValue)
        {
             return  value . Key . ToRawcode ( ) ;
        }

        internal static Buff ToBuff(this string value, BaseObject baseObject)
        {
             return  baseObject . Db . GetBuff ( value . FromRawcode ( ) ) ;
        }

        internal static string ToRaw(this Buff value, int? minValue, int? maxValue)
        {
             return  value . Key . ToRawcode ( ) ;
        }

        internal static Item ToItem(this string value, BaseObject baseObject)
        {
             return  baseObject . Db . GetItem ( value . FromRawcode ( ) ) ;
        }

        internal static string ToRaw(this Item value, int? minValue, int? maxValue)
        {
             return  value . Key . ToRawcode ( ) ;
        }

        internal static Tech ToTech(this string value, BaseObject baseObject)
        {
             return  baseObject . Db . GetTech ( value . FromRawcode ( ) ) ;
        }

        internal static string ToRaw(this Tech value, int? minValue, int? maxValue)
        {
             return  value . Key . ToRawcode ( ) ;
        }

        internal static IEnumerable<Ability> ToIEnumerableAbility(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < Ability > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToAbility ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<Ability> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<Buff> ToIEnumerableBuff(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < Buff > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToBuff ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<Buff> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<int> ToIEnumerableInt(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < int > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToInt ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<int> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<Item> ToIEnumerableItem(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < Item > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToItem ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<Item> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<LightningEffect> ToIEnumerableLightningEffect(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < LightningEffect > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToLightningEffect ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<LightningEffect> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<string> ToIEnumerableString(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < string > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToString ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<string> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<PathingType> ToIEnumerablePathingType(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < PathingType > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToPathingType ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<PathingType> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<Target> ToIEnumerableTarget(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < Target > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToTarget ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<Target> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<Tech> ToIEnumerableTech(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < Tech > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToTech ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<Tech> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<Tileset> ToIEnumerableTileset(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < Tileset > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToTileset ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<Tileset> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<UnitClassification> ToIEnumerableUnitClassification(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < UnitClassification > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToUnitClassification ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<UnitClassification> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<Unit> ToIEnumerableUnit(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < Unit > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToUnit ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<Unit> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }

        internal static IEnumerable<Upgrade> ToIEnumerableUpgrade(this string value, BaseObject baseObject)
        {
             return  string . IsNullOrEmpty ( value ) || string . Equals ( value ,  "_" ,  StringComparison . Ordinal ) ? Array . Empty < Upgrade > ( ) :  value . Split ( ',' ) . Select ( x  =>  x . ToUpgrade ( baseObject ) ) . ToArray ( ) ;
        }

        internal static string ToRaw(this IEnumerable<Upgrade> list, int? minValue, int? maxValue)
        {
             return  ( ! maxValue . HasValue || list . Count ( ) <= maxValue . Value ) ? $"{string.Join(',', list.Select(value => value.ToRaw(null, null)))}" :  throw  new  ArgumentOutOfRangeException ( nameof ( list ) ) ;
        }
    }
}