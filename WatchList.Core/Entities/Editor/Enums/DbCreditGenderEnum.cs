namespace WatchList.Core.Entities.Editor.Enums
{
    public enum DbCreditGenderEnum
    {
        Unspecified = 0,
        Female = 1,
        Male = 2,
    }

    public static class DbCreditGenderEnumHelper
    {
        public static DbCreditGenderEnum ToEnum(int id)
        {
            return id switch
            {
                0 => DbCreditGenderEnum.Unspecified,
                1 => DbCreditGenderEnum.Female,
                2 => DbCreditGenderEnum.Male,
                _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
            };
        }
    }
}
