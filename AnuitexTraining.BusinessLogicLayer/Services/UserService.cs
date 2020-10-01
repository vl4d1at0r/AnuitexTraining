using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Providers;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using X.PagedList;
using static AnuitexTraining.Shared.Constants.Constants;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserMapper _userMapper;
        private EmailProvider _emailProvider;

        public UserService(UserManager<ApplicationUser> userManager, UserMapper userMapper, EmailProvider emailProvider)
        {
            _userManager = userManager;
            _userMapper = userMapper;
            _emailProvider = emailProvider;
        }

        public async Task DeleteAsync(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            await _userManager.DeleteAsync(user);
        }

        public async Task UpdateAsync(UserModel user, bool force = false)
        {
            var applicationUser = await _userManager.FindByIdAsync(user.Id.ToString());
            if (applicationUser is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            if (string.IsNullOrEmpty(user.FirstName))
            {
                user.Errors.Add(ExceptionsInfo.InvalidFirstName);
            }

            if (string.IsNullOrEmpty(user.LastName))
            {
                user.Errors.Add(ExceptionsInfo.InvalidLastName);
            }

            if (user.PhoneNumber is null)
            {
                user.Errors.Add(ExceptionsInfo.InvalidPhone);
            }

            if (string.IsNullOrEmpty(user.NickName))
            {
                user.Errors.Add(ExceptionsInfo.InvalidNickname);
            }

            applicationUser.UserName = user.NickName;
            applicationUser.FirstName = user.FirstName;
            applicationUser.LastName = user.LastName;
            applicationUser.PhoneNumber = user.PhoneNumber;
            applicationUser.IsBlocked = user.IsBlocked ?? default;
            if (applicationUser.Email != user.Email)
            {
                if (await _userManager.FindByEmailAsync(user.Email) != null)
                {
                    throw new UserException(HttpStatusCode.BadRequest,
                        new List<string> {ExceptionsInfo.EmailAlreadyTaken});
                }

                string code = await _userManager.GenerateChangeEmailTokenAsync(applicationUser, user.Email);
                if (!force)
                {
                    await _emailProvider.SendEmailChangeMessageAsync(applicationUser.Id, user.Email, code);
                }
                else
                {
                    await _userManager.ChangeEmailAsync(applicationUser, user.Email, code);
                }
            }

            if (!string.IsNullOrEmpty(user.Password))
            {
                string code = await _userManager.GeneratePasswordResetTokenAsync(applicationUser);
                await _userManager.ResetPasswordAsync(applicationUser, code, user.Password);
            }

            if (user.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, user.Errors);
            }

            var result = await _userManager.UpdateAsync(applicationUser);
            var userNameError = result.Errors.FirstOrDefault(item => item.Code == "DuplicateUserName");
            if (userNameError != null)
            {
                userNameError.Description = $"Nickname {user.NickName} is already taken";
            }

            if (!result.Succeeded)
            {
                throw new UserException(HttpStatusCode.BadRequest,
                    result.Errors.Select(error => error.Description).ToList());
            }
        }

        public async Task<UserModel> GetAsync(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            return _userMapper.Map(user);
        }

        public async Task<object> GetPageAsync(PageModel<UserModel> pageModel)
        {
            var users = _userManager.Users;
            users = users.Where(user => user.UserName.ToLower().Contains(pageModel.Filter.NickName.ToLower()) &&
                                        user.Email.ToLower().Contains(pageModel.Filter.Email.ToLower()) &&
                                        user.FirstName.ToLower().Contains(pageModel.Filter.FirstName.ToLower()) &&
                                        user.LastName.ToLower().Contains(pageModel.Filter.LastName.ToLower()) &&
                                        (pageModel.Filter.IsBlocked == null ||
                                         pageModel.Filter.IsBlocked == user.IsBlocked) &&
                                        (pageModel.Filter.CreationDate == null || DateTime.Compare(user.CreationDate,
                                            (DateTime) pageModel.Filter.CreationDate) == 0));
            if (pageModel.SortOrder != SortOrder.Unspecified)
            {
                users = users.OrderBy($"{pageModel.SortField} {pageModel.SortOrder.ToString()}");
            }

            var usersList = await users.ToPagedListAsync(pageModel.Page, pageModel.PageSize);

            return new PageDataModel<UserModel>
            {
                Data = _userMapper.Map(usersList),
                Length = usersList.TotalItemCount
            };
        }

        public async Task BlockAsync(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            user.IsBlocked = true;
            await _userManager.UpdateAsync(user);
        }
    }
}