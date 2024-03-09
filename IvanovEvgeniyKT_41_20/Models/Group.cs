﻿using System.Text.RegularExpressions;

namespace IvanovEvgeniyKT_41_20.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public bool IsValidGroupName()
        {
            return Regex.Match(GroupName, @"\D\D*-\d\d*-\d\d").Success;
        }
    }
}
