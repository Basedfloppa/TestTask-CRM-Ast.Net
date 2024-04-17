using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTask.db;
using TestTask_CRM_ASP.Net.Models;
using System.Text.Json;

namespace TestTask_CRM_ASP.Net.Controllers;

public class HomeController : Controller
{
    [BindProperty]
    public string Login { get; set; }
    [BindProperty]
    public string Password { get; set; }
    public List<Client> clients { get; set; } = new List<Client>();
    public HomeController(){}

    public async Task<IActionResult> Index(string login, string password, string clientUuid, string newStatus)
    {
        if (!String.IsNullOrEmpty(clientUuid) && !String.IsNullOrEmpty(newStatus)) 
        {
            using var db = new ClientsContext();
            var client = db.Clients.FirstOrDefault(c => c.Uuid.ToString() == clientUuid);
            if (client != null)
            {
                client.Status = newStatus;
                await db.SaveChangesAsync();
            }
        }
        else if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
        {
                using var db = new ClientsContext();
                var user = db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user != null)
                {
                    var clients = db.Clients.Where(c => c.Responsible == user.Fio).ToList();
                    return View("Privacy", clients);
                }
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
