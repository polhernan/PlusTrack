using Newtonsoft.Json;
using PlusTrackForms.Models.Entities;
using PlusTrackForms.Models.RequestModels;
using PlusTrackForms.Services;
using PlusTrackForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PlusTrackForms.Model
{
    public class FormsRepository
    {
        private HttpClient httpClient;

        string ip = "http://172.16.24.175:8085";

        public FormsRepository()
        {
            httpClient = new HttpClient();
        }

        public async Task<bool> CreateRoute(CreateRouteRequest request)
        {
            bool aux = await HttpRequestHelper<CreateRouteRequest, bool>.PostAsJsonAsync(ip + "/v1/route/create-route-assign-all/", request);

            return aux;
        }

        public async Task<List<Employee>> GetEmployees(string companyId)
        {
            List<Employee> employees = await HttpRequestHelper<bool, List<Employee>>.GetAsync(ip + $"/v1/employees/by-company/{companyId}");

            return employees;
        }

        public async Task<List<Employee>> GetEmployeesWithoutRoute(string companyId)
        {
            List<Employee> employees = await HttpRequestHelper<bool, List<Employee>>.GetAsync(ip + $"/v1/employees/by-company-available/{companyId}");

            return employees;
        }

        public async Task<List<Enviament>> GetEnviaments()
        {
            List<Enviament> enviaments = await HttpRequestHelper<bool, List<Enviament>>.GetAsync(ip + "/v1/route/create-route-assign-all/");

            return enviaments;
        }

        public async Task<List<Route>> GetRoutes(string companyId)
        {
            List<Route> rutes = await HttpRequestHelper<bool, List<Route>>.GetAsync(ip + $"/v1/route/get-routes/{companyId}");

            return rutes;
        }

        public async Task<String> GetBuisnessId(string email)
        {
            string id = await HttpRequestHelper<bool, string>.GetAsync(ip + $"/v1/companies/{email}/");

            return id;
        }

        public async Task<List<Truck>> GetTrucks(string companyId)
        {
            List<Truck> trucks = await HttpRequestHelper<bool, List<Truck>>.GetAsync(ip + $"/v1/trucks/by-company/{companyId}");

            return trucks;
        }

        public async Task<List<Truck>> GetTrucksAvailable(string companyId)
        {
            List<Truck> trucks = await HttpRequestHelper<bool, List<Truck>>.GetAsync(ip + $"/v1/trucks/by-company-available/{companyId}");

            return trucks;
        }

        public async Task<List<Package>> GetPackages(string companyId)
        {
            List<Package> packages = await HttpRequestHelper<bool, List<Package>>.GetAsync(ip + $"/v1/packages/by-company/{companyId}");

            return packages;
        }

        public async Task<List<Locator>> getLocations(string companyId)
        {
            List<Locator> locator = await HttpRequestHelper<bool, List<Locator>>.GetAsync(ip + $"/v1/locations/by-company/{companyId}");

            return locator;
        }
    }
}
