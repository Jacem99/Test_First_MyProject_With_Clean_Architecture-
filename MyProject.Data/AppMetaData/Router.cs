using System;
using System.Collections.Generic;


namespace MyProject.Data.AppMetaData
{
    public static class Router
    {
        public const string Id = "/{Id}";
        public const string root = "Api";
        public const string Version = "V1";
        public const string Rule = root +"/"+Version+"/";

        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student";
            public const string Paginated = Prefix+"/Paginated";
            public const string List = Prefix + "/List";
            public const string GetById = Prefix + Id;

        }

    }
}
