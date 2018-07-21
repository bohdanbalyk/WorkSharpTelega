using System;

namespace WorkSharp.Enum
{
    
    public class test
    {

        public void TestVoid()
        {
            var k = Responses.OK;
            switch (k)
            {
                case Responses.OK:

                    break;

                case Responses.Error:

                    break;

            }
        }
    }
}
