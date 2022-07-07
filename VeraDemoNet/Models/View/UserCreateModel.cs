using System;

namespace VeraDemoNet.Models.View
{
    public sealed class UserCreateModel
    {
        public UserCreateModel()
        {
            CreatedAt = DateTime.Now;
        }

        public string Password { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string BlabName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}