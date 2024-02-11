using System.ComponentModel.DataAnnotations;

namespace WatchList.Core.Utils
{
    public static class Validations
    {
        public static bool IsValidEmailAddress(string? address)
        {
            return address != null && new EmailAddressAttribute().IsValid(address);
        }
    }
}
