using System;
using System.Collections.Generic;
using System.Text;

namespace SQliteLappolainen
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
