namespace Argus.Platform.Contract.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";

        public const string Base = $"{Root}/{Version}";
        public static class User
        {
            public const string GetAll = Base + "/users";
            public const string Get = Base + "/users/{id}";
            public const string Create = Base + "/users";
            public const string Update = Base + "/users";
            public const string Delete = Base + "/users/{id}";
            public const string Login = Base + "/login";
            public const string Register = Base + "/register";
            public const string ChangePassword = Base + "/users/{id}/changepassword";
            public const string GenaratePasswordResetToken = Base + "/users/{id}/genaratepasswordresetToken";
            public const string ResetPasswordWithToken = Base + "/users/{id}/resetpasswordwithtoken";


        }

        public static class Role
        {
            public const string GetAll = Base + "/roles";
            public const string Get = Base + "/roles/{id}";
            public const string Create = Base + "/roles";
            public const string Delete = Base + "/roles/{id}";
        }
    }
}
