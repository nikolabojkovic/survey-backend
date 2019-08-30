using AutoMapper;
using Survey.Domain.Survey;
using System.Linq;

namespace Survey.Application
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<Form, FormViewModel>();
            CreateMap<Section, SectionViewModel>()
                .ForMember(m => m.Questions, opt => opt.MapFrom(src => src.SectionQuestions.Select(x => x.Question)));

            CreateMap<Question, QuestionViewModel>();
            CreateMap<CheckBoxesQuestion, QuestionViewModel>();
            CreateMap<RadioButtonsQuestion, QuestionViewModel>();
            CreateMap<ShortQuestion, QuestionViewModel>();

            CreateMap<Answer, AnswerViewModel>();

            CreateMap<Option, OptionViewModel>();
            CreateMap<TextOption, OptionViewModel>();
            CreateMap<CheckBoxOption, OptionViewModel>();
            CreateMap<RadioButtonOption, OptionViewModel>();
        }
    }
}
