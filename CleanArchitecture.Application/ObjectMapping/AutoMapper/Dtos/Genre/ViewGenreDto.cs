using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Genre
{
    public class ViewGenreDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
