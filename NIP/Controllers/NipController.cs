using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NIP.Helpers;
using NIP.Models;
using NIP.Repositories;
using NIP.ViewModels;

namespace NIP.Controllers
{
    public class NipController : Controller
    {
        private readonly AppDbContext _context;

        public NipController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> GetSubjectInfo(NipModel data)
        {
            if (!NipHelper.ValidateNip(data.nip) || string.IsNullOrEmpty(data.nip))
                return "{\"message\": \"Niepoprawny NIP.\"}";

            var subjectJsonString = "";
            try
            {
                subjectJsonString = await ZwrocNIp(data.nip);
            }
            catch (Exception)
            {
                return "{\"message\": \"Błąd podczas pobierania danych.\"}";
            }

            JObject subjectJson = JObject.Parse(subjectJsonString);
            if (!subjectJson.ContainsKey("result"))
                return subjectJson.ToString(); ;

            SubjectViewModel subjectViewModel = subjectJson.SelectToken("result.subject").ToObject<SubjectViewModel>();
            subjectViewModel.requestdatetime = subjectJson.SelectToken("result.requestDateTime").ToString();
            subjectViewModel.requestid = subjectJson.SelectToken("result.requestId").ToString();

            if (!_context.subject.Any(x => x.nip == data.nip))
            {
                SubjectRepository repo = new SubjectRepository(_context);
                try
                {
                    await repo.SaveToDb(subjectViewModel);
                }
                catch (Exception)
                {
                    return "{\"message\": \"Błąd podczas zapisywania danych do bazy.\"}";
                }
            }
            return subjectJsonString;
        }

        private async Task<string> ZwrocNIp(string nip)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var url = $"https://19988f09-ed3c-41c6-8cdb-086e693ae9d0.mock.pstmn.io/test1";
            //var url = $"https://wl-api.mf.gov.pl/api/search/nip/{nip}?date={date}";
            try
            {
                using HttpClient client = new HttpClient();
                using HttpResponseMessage res = await client.GetAsync(url);
                using HttpContent content = res.Content;
                var data = await content.ReadAsStringAsync();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}