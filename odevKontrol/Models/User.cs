﻿namespace odevKontrol.Models
{
    public class User : BaseEntity
    {
        //public int Id { get; set; } --BaseEntity Öncesi--
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public string? PhotoUrl { get; set; }


    }
}
