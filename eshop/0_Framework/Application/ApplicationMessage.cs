using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class ApplicationMessage
    {
        public const string duplicated = "مقدار وارد شده با این نام قبلا در سیستم ثبت شده";
        public const string recordNotFound = "رکوردی با این مشخصات یافت نشد";
        public static string PasswordsNotMatch = "تکرار کلمه عبور نادرست میباشد";

        public static string WrongUserinformation = "اطلاعات وارد شده اشتباه است";
    }
}
