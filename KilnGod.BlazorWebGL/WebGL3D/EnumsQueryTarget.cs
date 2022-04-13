using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public enum EnumsQueryTarget
    {
        ANY_SAMPLES_PASSED = 0x8C2F,
        ANY_SAMPLES_PASSED_CONSERVATIVE = 0x8D6A,
        TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = 0x8C88
    }

    public enum EnumsQueryResult
    {
      
        QUERY_RESULT = 0x8866,
        QUERY_RESULT_AVAILABLE = 0x8867
    }

    public enum EnumsQuery
    {
        CURRENT_QUERY = 0x8865
    }
}
