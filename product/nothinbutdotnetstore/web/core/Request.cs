using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        InputModel map<InputModel>();
        string request_name { get;  }
        NameValueCollection payload { get;  }
    }
}