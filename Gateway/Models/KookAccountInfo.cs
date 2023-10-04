using System;
using System.Collections.Generic;

namespace Gateway.Models
{
    public class KookAccountInfo
    {
        public string accountNumber { get; set; }
        public List<AccountOwner> accountOwnersList { get; set; }
        public string accountStatus { get; set; }
        public EKookAccountStatus KookAccountStatus
        {
            get
            {
                try
                {
                    return (EKookAccountStatus)Enum.Parse(typeof(EKookAccountStatus), accountStatus);
                }
                catch
                {
                    return EKookAccountStatus.OTHER;
                }
            }
        }
        public string accountComment { get; set; }
        public string bank { get; set; }
    }

    public class AccountOwner
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public enum EKookAccountStatus
    {
        ACTIVE = 1,
        MASDOD_BA_GHABELIAT_VARIZ = 2,
        MASDOD_BEDONE_GHABELIAT_VAR = 3,
        KHATA = 4,
        OTHER = 5
    }
}
