﻿namespace Classroom.TodoWithAuth.Models.Requests
{
    public class ResetPasswordRequest
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
