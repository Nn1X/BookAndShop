using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndShop.Extentions
{
    public class RuIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = $"Произошла неизвестная ошибка." }; }
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = "Optimistic concurrency failure, object has been modified." }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = "Неверный пароль." }; }
        public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = "Invalid token." }; }
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "Пользователь с этим именем уже существует." }; }
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = $"Имя пользователя '{userName}' должно содержать только буквы и цифры." }; }
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = nameof(InvalidEmail), Description = $"Email '{email}' не верный." }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = $"Имя пользователя '{userName}' уже существует." }; }
        public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = $"Почта '{email}' уже используется." }; }
        public override IdentityError InvalidRoleName(string role) { return new IdentityError { Code = nameof(InvalidRoleName), Description = $"Неправильное имя роли '{role}'." }; }
        public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"Роль с именем '{role}' уже существует." }; }
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "У пользователя уже есть пароль." }; }
        public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = "Lockout is not enabled for this user." }; }
        public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"Пользователь уже принадлежит роли '{role}'." }; }
        public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = nameof(UserNotInRole), Description = $"Пользователь не принадлежит этой роли '{role}'." }; }
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = $"Длина пароля должна быть как минимум {length} символов." }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "Пароль должен содержать хотя бы один спецсимвол." }; }
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "Пароль должен содержать хотя бы одну цифру ('0'-'9')." }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "Пароль должен содержать как минимум одну маленькую букву ('a'-'z'|'а'-'я')." }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "Пароль должен содержать как минимум одну большую букву ('A'-'Z'|'А'-'Я')." }; }
    }
}
