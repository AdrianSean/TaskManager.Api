﻿using System.Collections.Generic;

namespace Web.Api.Models
{
    public class User
    {
        private List<Link> _links;

        public long Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value;}

        }


        public void AddLink(Link link)
        {
            Links.Add(link);
        }
    }
}