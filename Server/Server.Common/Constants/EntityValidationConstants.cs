﻿namespace Server.Common.Constants
{
    public static class EntityValidationConstants
    {
        public static class Transport
        {
            public const int FromAddressMinLength = 3;
            public const int FromAddressMaxLength = 100;
            public const int ToAddressMinLength = 3;
            public const int ToAddressMaxLength = 100;
            public const int NumberOfPalletsMinValue = 1;
            public const int NumberOfPalletsMaxValue = 1000;
            public const int TotalWeightMinValue = 1;
            public const int TotalWeightMaxValue = 1000000;
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
            public const int StatusMinLength = 2;
            public const int StatusMaxLength = 30;
            public const string StatusPending = "Waiting for approval";
            public const string StatusApproved = "Approved";
            public const string StatusRejected = "Rejected";
            public const string RequestFor = "request for transport";
        }

        public static class Spedition
        {
            public const int FromAddressMinLength = 3;
            public const int FromAddressMaxLength = 100;
            public const int ToAddressMinLength = 3;
            public const int ToAddressMaxLength = 100;
            public const int NumberOfPalletsMinValue = 1;
            public const int NumberOfPalletsMaxValue = 1000;
            public const int TotalWeightMinValue = 1;
            public const int TotalWeightMaxValue = 1000000;
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
            public const int StatusMinLength = 2;
            public const int StatusMaxLength = 30;
            public const string StatusPending = "Waiting for approval";
            public const string StatusApproved = "Approved";
            public const string StatusRejected = "Rejected";
            public const string RequestFor = "request for spedition";
        }
        
        public static class Contact
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
            public const int CompanyNameMinLength = 2;
            public const int CompanyNameMaxLength = 100;
            public const int DescriptionMinLength = 2;
            public const int DescriptionMaxLength = 1000;
        }
        public static class Login
        {
            public const int EmailMinLength = 6;
            public const int EmailMaxLength = 100;
            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 100;
        }

        public static class Register
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 100;
            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 100;
            public const int EmailMinLength = 6;
            public const int EmailMaxLength = 100;
            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 100;
            public const int ConfirmPasswordMinLength = 5;
            public const int ConfirmPasswordMaxLength = 100;
        }
    }
}

