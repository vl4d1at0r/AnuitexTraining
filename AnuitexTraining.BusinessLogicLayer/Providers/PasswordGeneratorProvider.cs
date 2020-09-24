using System;
using System.Collections.Generic;
using System.Linq;
using static AnuitexTraining.Shared.Constants.Constants;
using Microsoft.AspNetCore.Identity;

namespace AnuitexTraining.BusinessLogicLayer.Providers
{
    public class PasswordGeneratorProvider
    {
        public string GeneratePassword(PasswordOptions options)
        {
            if (options == null)
            {
                options = new PasswordOptions()
                {
                    RequiredLength = 8,
                    RequiredUniqueChars = 4,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = true,
                    RequireUppercase = true
                };
            }

            var random = new Random(Environment.TickCount);
            var chars = new List<char>();

            if (options.RequireUppercase)
            {
                chars.Insert(random.Next(0, chars.Count),
                    PasswordGeneratorOptions.UppercaseChars[
                        random.Next(0, PasswordGeneratorOptions.UppercaseChars.Length)]);
            }

            if (options.RequireLowercase)
            {
                chars.Insert(random.Next(0, chars.Count),
                    PasswordGeneratorOptions.LowercaseChars[
                        random.Next(0, PasswordGeneratorOptions.LowercaseChars.Length)]);
            }

            if (options.RequireDigit)
            {
                chars.Insert(random.Next(0, chars.Count),
                    PasswordGeneratorOptions.DigitChars[random.Next(0, PasswordGeneratorOptions.DigitChars.Length)]);
            }

            if (options.RequireNonAlphanumeric)
            {
                chars.Insert(random.Next(0, chars.Count),
                    PasswordGeneratorOptions.SpecialChars[
                        random.Next(0, PasswordGeneratorOptions.SpecialChars.Length)]);
            }

            for (var i = chars.Count;
                i < options.RequiredLength
                || chars.Distinct().Count() < options.RequiredUniqueChars;
                i++)
            {
                var randomChars = new[]
                {
                    PasswordGeneratorOptions.UppercaseChars,
                    PasswordGeneratorOptions.LowercaseChars,
                    PasswordGeneratorOptions.DigitChars,
                    PasswordGeneratorOptions.SpecialChars
                };
                var randomChar = randomChars[random.Next(0, randomChars.Length)];
                chars.Insert(random.Next(0, chars.Count),
                    randomChar[random.Next(0, randomChar.Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}