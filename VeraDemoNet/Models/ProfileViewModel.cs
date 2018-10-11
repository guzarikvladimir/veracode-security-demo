﻿using System.Collections.Generic;

namespace VeraDemoNet.Models
{
    public class ProfileViewModel
    {
        public string Error { get; set; }
        public List<string> Events { get; set; }
        public List<Blabber> Hecklers { get; set; }
        /*
        public List<string> HecklerUsernames { get; set; }
        public List<string> HecklerNames { get; set; }
        public List<string> CreatedTimes { get; set; }
        */
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Image { get; set; }
        public string BlabName { get; set; }
    }
}