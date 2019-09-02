using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Domain.Survey
{
    public enum NumberValidationSubType
    {
        GreaterThen,
        GreaterThenOrEqualTo,
        LessThen,
        LessThenOrEqualTo,
        EqualTo,
        NotEqualTo,
        Between,
        NotBetween,
        IsNumber,
        WholeNumber
    }
}
