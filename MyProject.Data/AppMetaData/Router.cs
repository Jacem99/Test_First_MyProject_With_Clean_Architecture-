namespace MyProject.Data.AppMetaData
{
    public static class Router
    {
        public const string Id = "/{Id}";
        public const string root = "Api";
        public const string Version = "V1";
        public const string Rule = root + "/" + Version + "/";

        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student";
            public const string Paginated = Prefix + "/Paginated";
            public const string List = Prefix + "/List";
            public const string Delete = Prefix + "/Delete";
            public const string GetById = Prefix + Id;
            public const string DeletById = Delete + Id;

        }
        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department";
            public const string Paginated = Prefix + "/Paginated";
            public const string List = Prefix + "/List";
            public const string GetById = Prefix + Id;
            public const string Delete = Prefix + "/Delete";
            public const string DeletById = Delete + Id;

        }
        public static class SubjectRouting
        {
            public const string Prefix = Rule + "Subject";
            public const string Paginated = Prefix + "/Paginated";
            public const string List = Prefix + "/List";
            public const string GetById = Prefix + Id;

            public const string Delete = Prefix + "/Delete";
            public const string DeletById = Delete + Id;

        }

        public static class User
        {
            public const string Prefix = Rule + "User";
            public const string Paginated = Prefix + "/Paginated";
            public const string List = Prefix + "/List";
            public const string SignIn = Prefix + "/SignIn";
            public const string GetById = Prefix + Id;

            public const string Add = Prefix + "/Add";
            public const string Delete = Prefix + "/Delete";
            public const string DeletById = Delete + Id;

        }

        public static class Authentication
        {
            public const string Prefix = Rule + "Authentication";
            public const string SignIn = Prefix + "/SignIn";
        }
        public static class Email
        {
            public const string Prefix = Rule + "Email";
            public const string Send = Prefix + "/Send";
        }

    }
}
