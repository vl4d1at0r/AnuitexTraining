using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Authors;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
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
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidName});

            await _authorRepository.AddAsync(_authorMapper.Map(item));
        }

        public async Task DeleteAsync(long id)
        {
            if (await _authorRepository.GetAsync(id) is null)
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});

            await _authorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AuthorModel>> GetAllAsync()
        {
            return _authorMapper.Map(await _authorRepository.GetAllAsync());
        }

        public async Task<AuthorModel> GetAsync(long id)
        {
            var author = await _authorRepository.GetAsync(id);
            if (author is null)
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});

            return _authorMapper.Map(author);
        }

        public async Task UpdateAsync(AuthorModel item)
        {
            if (await _authorRepository.GetAsync(item.Id) is null) item.Errors.Add(ExceptionsInfo.InvalidId);

            if (string.IsNullOrEmpty(item.Name)) item.Errors.Add(ExceptionsInfo.InvalidName);

            if (item.Errors.Any()) throw new UserException(HttpStatusCode.BadRequest, item.Errors);

            await _authorRepository.UpdateAsync(_authorMapper.Map(item));
        }
    }
}