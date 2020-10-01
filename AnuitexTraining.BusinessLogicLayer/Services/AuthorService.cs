using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Authors;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using static AnuitexTraining.Shared.Constants.Constants;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AuthorMapper _authorMapper;
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(AuthorMapper authorMapper, IAuthorRepository authorRepository)
        {
            _authorMapper = authorMapper;
            _authorRepository = authorRepository;
        }

        public async Task AddAsync(AuthorModel item)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidName});
            }

            await _authorRepository.AddAsync(_authorMapper.Map(item));
        }

        public async Task DeleteAsync(long id)
        {
            if (await _authorRepository.GetAsync(id) is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            await _authorRepository.DeleteAsync(id);
        }

        public async Task<PageDataModel<AuthorModel>> GetPageAsync(PageModel<AuthorModel> pageModel)
        {
            var authors = await _authorRepository.GetPageAsync(new PageOptions<Author>
            {
                Filter = pageModel.Filter == null ? null : _authorMapper.Map(pageModel.Filter),
                Page = pageModel.Page,
                PageSize = pageModel.PageSize,
                SortField = pageModel.SortField,
                SortOrder = pageModel.SortOrder
            });
            
            return new PageDataModel<AuthorModel>
            {
                Data = _authorMapper.Map(authors),
                Length = authors.TotalItemCount
            };
        }

        public async Task<AuthorModel> GetAsync(long id)
        {
            var author = await _authorRepository.GetAsync(id);
            if (author is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            return _authorMapper.Map(author);
        }

        public async Task UpdateAsync(AuthorModel item)
        {
            var author = await _authorRepository.GetAsync(item.Id);
            if (author is null)
            {
                item.Errors.Add(ExceptionsInfo.InvalidId);
            }

            if (string.IsNullOrEmpty(item.Name))
            {
                item.Errors.Add(ExceptionsInfo.InvalidName);
            }

            if (item.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, item.Errors);
            }

            author.Name = item.Name;

            await _authorRepository.UpdateAsync(author);
        }
    }
}