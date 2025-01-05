using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace SiteCostProApp.Classes
{
    internal static class FirestoreHelper
    {
        static string fireconfig = @"
        {
          ""type"": ""service_account"",
          ""project_id"": ""sitecostpro-firebase"",
          ""private_key_id"": ""61689faff0c062b5aecd6fe356fc9ff1567e3c6c"",
          ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDEjFyxYtGvmyZq\nSoR72TADEjey+whvoMLhJN3NgSYskSQM2xLs1t2unW0R5z5V0GuwOGBj4QIAvqog\nb8jKi5Tvbl8sQWJD+oYts8/uHmW4Nd3QNutgq+WgVb6v6yCQ5DdedOXZ9oNqRiET\nXNMiT00tAcAFCXi5Wp2UsULlWZuxJ1cES4B3aPjBwPHorJedhLG0Woq08C4IdZt1\nuIPRiuRK/Xa6mgVm+ng6ECKnub5GADfIHBp+uMFCwk8kth1FH0fZSpS8hMak2Se3\nzFMiOCnJ+dEefJGV6K7lOgw+UiKGZJWJCsrUtBDOKKPlGHsBh8BqfDBhNlNwBhCC\nlo8lYoVdAgMBAAECggEAEGsTMSQqlOs2bcmUwI23c4I5keNjZIO+07TTLF/98toa\n81H3hj46nWP8IPM6o0t6O2myL5Wzp6FFr9j2omi/g7KqE5XQohIS1E2BcIgsghNJ\n2KNFzTj+wQJ4n9RZz5CoyWSlcKwldSKvj6EA6AxMy5YqVqFgasdVg369MlBmb4lO\nqaF0oUu2QMuISX8sP4PUaX5KkPUUS4wdPQIUrJsu8W+6tt3cPvKv2ywi9H1TyHsb\nyzp6A78Ko815gZ92LKLt9ZhR00P4NDvq9x6sjDnwmKWd1DWKoMk4suBSgDiCzZUd\ne2Tzx+VidaYmPZectyQ25oNMGrA3yyyA0NNFs15xhwKBgQDxUdOpM+LEQkjU6hXu\naP/SS/hHddyDYTNP7AdFlhXF1zJk89r0LBuz+5HNcbz1k9rZqWsU+DUYsGC6RKlD\n48MXE0s3V6Hw6VJ6vD0PRx9cJa0AITY4Xnupb6DIlgHZN4M5l31aVV/xPjxXum8j\n4YBAAW2eD+kMsQqKKzjJhnEf1wKBgQDQgUrF8zGuFFjNVWePVjshy4ig2lIbFljS\nNRueY93jMu0JAQI2cDSnld5+VRgygSTpGt4iw8spzn0cLV+Cy59cKuu6eGs96MlH\ne8B5eTNfX1DWy8hy36j+oKRyOw2UMYpyz1NaPuHpyLXxCgFDK01ixp50HB47/uqA\n+L0edmqt6wKBgQCvdrPT/6oO0bNrPJmdtDLukdaA/y3LSU2p+xB+hFZod8Roqva1\nO60Y/P5SxzSBy3QBd7IomSDiRrzOM0Zv2pfrm1fBcbKKHNyf6WbsSOaAddSIl514\n9xorZMMflhLaAgckRQYcPJ96Japyj1hoWnqKD3/IwgDN/ZyQQkUUIvD2GQKBgAkc\nnVfpONKSsQ7IHK525j6j1mSxJcVpRJhrGbniQ2AaaaFrGd2nKaXpNr/umBAc9K/7\nLJn4VHiPPYhtsy7UFzK/7W1ItecOtT0ae17TnRsd3zqDzU6313rJKmaTjhRb1eEO\njmXzOYwt6UWPWl7FFayrYWFRmUCl8zmPpTQfmKnhAoGAR/0oDJK7FG1jAQaSdYgG\nFKASkOmakB8PQDUL1Vna3jdih6lM+coP7xjXZfWzQDYHEukngzjh/+2WyzJrn92P\ntjuBZp1Yb5xuZT5CVghe3SN3fAe/CjmcbA05F6R0l5Xfw9W3UBbQSQDndG2Pb02z\n8p+kHhAGPKQapxSAt3sncOs=\n-----END PRIVATE KEY-----\n"",
          ""client_email"": ""firebase-adminsdk-xuqtd@sitecostpro-firebase.iam.gserviceaccount.com"",
          ""client_id"": ""114517280582189202624"",
          ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
          ""token_uri"": ""https://oauth2.googleapis.com/token"",
          ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
          ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-xuqtd%40sitecostpro-firebase.iam.gserviceaccount.com"",
          ""universe_domain"": ""googleapis.com""
        }";

        static string filepath = "";
        public static FirestoreDb Database{get; private set;}

        public static void SetEnvironmentVariable()
        {
            filepath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
            File.WriteAllText(filepath, fireconfig);
            File.SetAttributes(filepath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS",filepath);
            Database = FirestoreDb.Create("sitecostpro-firebase");
            File.Delete(filepath);
        }

    }
}
