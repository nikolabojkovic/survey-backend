using AutoMapper;
using Survey.Domain.Survey;
using System.Linq;

namespace Survey.Application
{
    public class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<Form, FormViewModel>();
            CreateMap<Section, SectionViewModel>()
                .ForMember(m => m.Questions, opt => opt.MapFrom(src => src.SectionQuestions.Select(x => x.Question)));

            CreateMap<Question, QuestionViewModel>();

            CreateMap<Answer, AnswerViewModel>();

            CreateMap<Answer, AnswerViewModel>()
                .Include<TextAnswer, TextAnswerViewModel>()
                .Include<CheckBoxAnswer, CheckBoxAnswerViewModel>()
                .Include<RadioButtonAnswer, RadioButtonAnswerViewModel>();

            CreateMap<TextAnswer, TextAnswerViewModel>();
            CreateMap<CheckBoxAnswer, CheckBoxAnswerViewModel>();
            CreateMap<RadioButtonAnswer, RadioButtonAnswerViewModel>();
        }
    }
}
