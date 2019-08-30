using FluentAssertions;
using Survey.Domain.Survey;
using System;
using Xunit;

namespace Survey.UnitTest
{
    public class CreateFormTest
    {
        public CreateFormTest()
        {

        }

        [Theory]
        [InlineData("Test Form", "Test form description")]
        public void CreateForm_WithQuestions_shouldCreateNewForm(string name, string description)
        {
            var form = Form.Create(name, description);

            form.Name.Should().Be(name);
            form.Description.Should().Be(description);
        }
    }
}
