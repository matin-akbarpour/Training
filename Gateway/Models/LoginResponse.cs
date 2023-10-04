using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gateway.Models
{
    public class LoginResponse
    {
        public Token tokens { get; set; }
        public List<Role> roles { get; set; }
        public User user { get; set; }
    }

    public class Token
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public DateTime? refreshTokenExpirationDate { get; set; }
    }

    public class Role
    {
        public string name { get; set; }
        public string pName { get; set; }
        public int priority { get; set; }
        public string description { get; set; }
        public bool isAdmin { get; set; }
        public Guid id { get; set; }
        public long id2 { get; set; }
    }

    //public class BaseWithDate : BaseEntity<Guid>
    //{
    //    public DateTime? createAt { get; set; } = DateTime.Now;
    //}

    public class User/* : BaseWithDate*/
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string phoneNo { get; set; }
        public Guid? parentId { get; set; } = null;
        public UserSex? sex { get; set; } = UserSex.Unknown;
        public string referrer { get; set; }
        public string image { get; set; }
        public string nationalCode { get; set; }
        public DateTime? birthDate { get; set; }
        public string email { get; set; }
        public Guid? city { get; set; }
        //public string iban { get; set; }
        public UserStatus? status { get; set; } = UserStatus.Active;
        public string address { get; set; }
        public SimSwapSuspention suspention { get; set; } = 0;
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public long? id2 { get; set; }
        //public string Password { get; set; }
        //public string Salt { get; set; }
        //public bool IsBlocked { get; set; } = false;
        //public DateTime? BlockedUntilDateTime { get; set; }
        public string ldapUserName { get; set; }
        public DateTime? createAt { get; set; } = DateTime.Now;
        public Guid id { get; set; }
    }

    public enum UserSex
    {
        [Display(Name = "نامشخص")]
        Unknown = 0,

        [Display(Name = "مرد")]
        Male = 1,

        [Display(Name = "زن")]
        Female = 2,
    }

    public enum UserStatus
    {
        [Display(Name = "فعال")]
        Active = 1,

        [Display(Name = "غیرفعال")]
        InActive = 0,

        [Display(Name = "مسدود")]
        Blocked = 2,
    }

    public enum SimSwapSuspention
    {
        Unsuspend,
        Suspend
    }
}
