using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FamilyTreeJSGenerateNewNodesIdsFromServerSide.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update([FromBody] JsonElement args)
        {
            System.Threading.Thread.Sleep(1000);
            var addNodesData = args.GetProperty("addNodesData").EnumerateArray();
            //var updateNodesData = args.GetProperty("updateNodesData").EnumerateArray(); 
            //update fid, mid and pids as well

            Random rnd = new Random();

            var oldId_newId = new Dictionary<string, string>();
            foreach (var node in addNodesData)
            {
                int serverId = rnd.Next();//Generate id from the server it could be SQL server
                var clientId = node.GetProperty("id").ToString();
                oldId_newId.Add(clientId, serverId.ToString());
            }

            return Json(oldId_newId);
        }
    }
}