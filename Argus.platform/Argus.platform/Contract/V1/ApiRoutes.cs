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

        public static class Document
        {
            public const string GetAll = Base + "/documents";
            public const string Get = Base + "/documents/{id}";
            public const string Create = Base + "/documents";
            public const string Delete = Base + "/documents/{id}";
            public const string Renew = Base + "/documents/{id}/renew";
            public const string Review = Base + "/documents/{id}/review";
        }

        public static class Audits
        {
            public const string GetAll = Base + "/audits";
            public const string Get = Base + "/audits/{id}";
            public const string Create = Base + "/audits";
            public const string Delete = Base + "/audits/{id}";
            public const string Update = Base + "/audits/{id}";
            public const string AddDocument = Base + "/audits/{id}/addocument";
            public const string RemoveDocument = Base + "/audits/{id}/remove";

        }

        public static class Role
        {
            public const string GetAll = Base + "/roles";
            public const string Get = Base + "/roles/{id}";
            public const string Create = Base + "/roles";
            public const string Delete = Base + "/roles/{id}";
        }

        public static class DocumentType
        {
            public const string GetAll = Base + "/documenttypes";
            public const string Get = Base + "/documenttypes/{id}";
            public const string Create = Base + "/documenttypes";
            public const string Update = Base + "/documenttypes/{id}";

            // Add more routes as needed
        }

        public static class Project
        {
            public const string GetAll = Base + "/projects";
            public const string Get = Base + "/projects/{id}";
            public const string Create = Base + "/projects";
            public const string Update = Base + "/projects/{id}";
            // Additional routes as needed, for example, delete:
            public const string Delete = Base + "/projects/{id}";

            public const string AddTask = Base + "/projects/{id}/tasks";
            public const string GetTasks = Base + "/projects/{id}/tasks";
            public const string DeleteTask = Base + "/projects/{id}/tasks/{id}";
            public const string UpdateTask = Base + "/projects/{id}/tasks/{id}";

        }

        public static class Files
        {
            public const string GetAll = Base + "/files";
            public const string Get = Base + "/buckets/{bucketName}/files/{key}";
            public const string Create = Base + "/upload";
            public const string Update = Base + "/files/{key}";

            // Add more routes as needed
        }

        public static class Buyers
        {
            public const string GetAll = Base + "/buyers";
            public const string Get = Base + "/buyers/{id}";
            public const string Create = Base + "/buyers";
            public const string Update = Base + "/buyers/{id}";
            public const string Delete = Base + "/buyers/{id}";

            // Add more routes as needed
        }

        public static class Company 
        {
            public const string GetAll = Base + "/company";
            public const string Get = Base + "/company/{id}";
            public const string Create = Base + "/company";
            public const string Delete = Base + "/company/{id}";
            public const string Update = Base + "/company/{id}";
          

        }

        public static class Branch
        {
            public const string GetAll = Base + "/branch";
            public const string Get = Base + "/branch/{id}";
            public const string Create = Base + "/branch";
            public const string Delete = Base + "/branch/{id}";
            public const string Update = Base + "/branch/{id}";

        }

        public static class Customer
        {
            public const string GetAll = Base + "/customer";
            public const string Get = Base + "/customer/{id}";
            public const string Create = Base + "/customer";
            public const string Delete = Base + "/customer/{id}";
            public const string Update = Base + "/customer/{id}";

        }

        public static class Workflow
        {
            public const string GetAll = Base + "/workflow";
            public const string Get = Base + "/workflow/{id}";
            public const string Create = Base + "/workflow";
            public const string Delete = Base + "/workflow/{id}";
            public const string Update = Base + "/workflow/{id}";

        }

        public static class Package
        {
            public const string GetAll = Base + "/package";
            public const string Get = Base + "/package/{id}";
            public const string Create = Base + "/package";
            public const string Delete = Base + "/package/{id}";
            public const string Update = Base + "/package/{id}";

        }
    }
}
