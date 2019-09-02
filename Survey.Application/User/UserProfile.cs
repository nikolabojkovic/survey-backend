using AutoMapper;
using Survey.Domain.Survey;
using Survey.Domain.Users;
using System.Linq;

namespace Survey.Application
{
    class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(m => m.UserForms, opt => opt.MapFrom(src => src.UserForms.Select(x => x.Form)));
            CreateMap<Form, UserFormViewModel>();
        }
    }
}
