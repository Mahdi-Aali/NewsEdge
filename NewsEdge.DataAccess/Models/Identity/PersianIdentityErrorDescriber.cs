using Microsoft.AspNetCore.Identity;

namespace NewsEdge.DataAccess.Models.Identity;

public class PersianIdentityErrorDescriber: IdentityErrorDescriber
{
    public override IdentityError DuplicateEmail(string email)
    {
        return new() { Description = $"ایمیل {email} از قبل وجود دارد." };
    }

    public override IdentityError DuplicateRoleName(string role)
    {
        return new() { Description = $"نقش {role} از قبل وجود دارد." };
    }

    public override IdentityError DuplicateUserName(string userName)
    {
        return new() { Description = $"نام کاربری {userName} از قبل گرفته شده است" };
    }

    public override IdentityError InvalidEmail(string email)
    {
        return new() { Description = $"ایمیل {email} معتبر نمیباشد." };
    }

    public override IdentityError InvalidRoleName(string role)
    {
        return new() { Description = $"نقش {role} معتبر نمیباشد." };
    }

    public override IdentityError InvalidToken()
    {
        return new() { Description = "کد وارد شده معتبر نمیباشد" };
    }

    public override IdentityError InvalidUserName(string userName)
    {
        return new() { Description = "نام کاربری وارد شده معتبر نمیباشد" };
    }

    public override IdentityError PasswordRequiresDigit()
    {
        return new() { Description = "رمز عبور حداقل باید شامل یک عدد باشد" };
    }

    public override IdentityError PasswordRequiresLower()
    {
        return new() { Description = "رمز عبور حداقل باید شامل یک حرف کوچک انگلیسی باشد" };
    }

    public override IdentityError PasswordRequiresNonAlphanumeric()
    {
        return new() { Description = "رمز عبور باید شامل یک نماد مانند !@#$%&* باشد" };
    }

    public override IdentityError PasswordRequiresUpper()
    {
        return new() { Description = "رمز عبور حداقل باید شامل یک حرف بزرگ انگلیسی باشد" };
    }

    public override IdentityError PasswordTooShort(int length)
    {
        return new() { Description = $"رمز عبور باید بیشتر از {length} حرف باشد" };
    }

    public override IdentityError UserAlreadyHasPassword()
    {
        return new() { Description = "کاربر از قبل رمز عبور دارد." };
    }

    public override IdentityError UserAlreadyInRole(string role)
    {
        return new() { Description = $"کاربر از قبل نقش {role} را دارد." };
    }

    public override IdentityError UserNotInRole(string role)
    {
        return new() { Description = $"کاربر شامل نقش {role} نمیشود" };
    }

    public override IdentityError PasswordMismatch()
    {
        return new() { Description = "زمز عبور وارد شده اشتباه میباشد" };
    }
}
