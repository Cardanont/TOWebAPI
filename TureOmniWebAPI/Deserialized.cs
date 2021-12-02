using Newtonsoft.Json;
using System.Net;
using TureOmniWebAPI.Models;

namespace TureOmniWebAPI
{
    public class Deserialized
    {
        public List<CompanyData> Deserialize()
        {
            List<string> responseObject = new List<string>();
            string url = "https://webservice.trueomni.com/json.aspx?domainid=2248&fn=listings";
            string response = GetHttp(url);
            List<CompanyData> companyData = JsonConvert.DeserializeObject<List<CompanyData>>(response);

            var filtered = companyData.Select(c => new { c.ListingID, c.Company, c.Image_List, c.CategoryID })
                .Distinct().Select(x => new CompanyData { ListingID = x.ListingID, Company = x.Company, Image_List = x.Image_List, CategoryID = x.CategoryID });

            List<CompanyData> filteredCompanies = filtered.ToList();
            List<CompanyData> clonedCompanies = new List<CompanyData>(filteredCompanies);

            filteredCompanies.AddRange(clonedCompanies);


            return filteredCompanies;
        }

        public string GetHttp(string url)
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return sr.ReadToEnd();
        }
    }
}
