﻿using System.Threading.Tasks;
using Miki.Bot.Models;
using Miki.Bot.Models.Exceptions;
using Miki.Discord.Common;
using Miki.Services;

namespace Miki
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Creates and returns the User regardless of business errors.
        /// </summary>
        public static async Task<User> GetOrCreateUserAsync(
            this IUserService service, IDiscordUser user)
        {
            try
            {
                return await service.GetUserAsync((long)user.Id);
            }
            catch (EntityNullException<User>)
            {
                return await service.CreateUserAsync((long)user.Id, user.Username);
            }
        }

        /// <summary>
        /// Creates and returns the User regardless of business errors.
        /// </summary>
        public static async Task<BankAccount> GetOrCreateBankAccountAsync(
            this IBankAccountService service, AccountReference accountDetails)
        {
            try
            {
                return await service.GetAccountAsync(accountDetails);
            }
            catch (BankAccountNullException)
            {
                return await service.CreateAccountAsync(accountDetails);
            }
        }
    }
}
