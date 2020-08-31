using AnuitexTraining.BusinessLogicLayer.Mappers.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Authors;
using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.BusinessLogicLayer.Mappers
{
    public class AuthorMapper : BaseMapper<Author, AuthorModel>
    {
        public override Author Map(AuthorModel item)
        {
            return new Author
            {
                Id = item.Id,
                CreationDate = item.CreationDate,
                Name = item.Name
            };
        }

        public override AuthorModel Map(Author item)
        {
            return new AuthorModel
            {
                Id = item.Id,
                CreationDate = item.CreationDate,
                Name = item.Name
            };
        }
    }
}
