using Newtonsoft.Json;
using System.Collections.Generic;

public class CompanyData
{
    [JsonProperty("employees")]
    public List<Employee> Employees { get; set; } = new List<Employee>();
}
