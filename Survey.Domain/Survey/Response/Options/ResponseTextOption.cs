namespace Survey.Domain.Survey
{
    public class ResponseTextOption : ResponseOption
    {
        public string Text { get; set; }

        public override object GetValue()
        {
            return Text;
        }
    }
}
