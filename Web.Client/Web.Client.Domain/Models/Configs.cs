using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Client.Domain.Models
{
    public class Configs
    {
        public Configs()
        {

        }

        public Configs(string apiURL)
        {
            ApiUrl = apiURL;
        }

        public string ApiUrl { get; set; }
    }
}
