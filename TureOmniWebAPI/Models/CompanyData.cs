using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
//using System.Text.Json;

namespace TureOmniWebAPI.Models
{
    public class CompanyData
    {
        public int ListingID { get; set; }
        public string? Company { get; set; }

        public string? Image_List { get; set; }
        public int CategoryID { get; set; }
    }
}