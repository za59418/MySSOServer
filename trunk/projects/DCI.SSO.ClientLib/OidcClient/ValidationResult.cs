﻿namespace DCI.SSO.ClientLib
{
    class ValidationResult
    {
        public bool Success { get; set; } = false;
        public string ErrorMessage { get; set; }

        public LoginResult LoginResult { get; set; }
    }
}