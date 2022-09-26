using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Переводчик.Shared;

namespace Переводчик.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            var rng = new Random();


            using (TranslatorDBContext db = new TranslatorDBContext())
            {
                User user1 = new User { UserId = 6, Login = "a@mail.ru", Password = "1314", NickName = "Man" };

                // Добавление
                //db.User.Add(user1);

                db.SaveChanges();
            }

            string resultText = "";

            using (TranslatorDBContext db = new TranslatorDBContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.User.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.UserId}.{u.Login} - {u.Password} - {u.NickName}");
                }
            }


            return resultText;
        }

    }
}
