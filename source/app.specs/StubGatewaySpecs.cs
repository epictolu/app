using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(StubGateway))]
    public class StubGatewaySpecs
    {
        public abstract class concern
        {
        }

        public class when_asked_for_a_stub_display_engine : concern
        {
            Establish c = () =>
            {
               
            };

            private Because b = () => result = StubGateway.Create<StubDisplayEngine>();

            private It should_return_a_stub_display_engine =
                () => result.GetType().IsInstanceOfType(typeof (StubDisplayEngine));

            private static StubDisplayEngine result;
        }
   }

    public delegate void MyDelegate();
}