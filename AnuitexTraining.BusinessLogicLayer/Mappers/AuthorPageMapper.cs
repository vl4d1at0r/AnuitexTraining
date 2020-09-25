using AnuitexTraining.BusinessLogicLayer.Mappers.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Authors;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;

namespace AnuitexTraining.BusinessLogicLayer.Mappers
{
    public class AuthorPageMapper : BaseMapper<AuthorPageModel, AuthorPage>
    {
        private AuthorMapper _authorMapper;
        
        public AuthorPageMapper(AuthorMapper authorMapper)
        {
            _authorMapper = authorMapper;
        }
        
        public override AuthorPageModel Map(AuthorPage item)
        {
            return new AuthorPageModel
            {
                Filter = _authorMapper.Map(item.Filter),
                Page = item.Page,
                PageSize = item.PageSize,
                SortField = item.SortField,
                SortOrder = item.SortOrder
            };
        }

        public override AuthorPage Map(AuthorPageModel item)
        {
            throw new System.NotImplementedException();
        }
    }
}