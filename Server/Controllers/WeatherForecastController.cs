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
      
        [HttpPost]
        public IActionResult Post(User newUser)


        {
            using (TranslatorDBContext db = new TranslatorDBContext()) 
            {
            User user7 = new User { UserId = 7, Login = "ab@mail.ru", Password = "4848", NickName = "LALeu" };
            User user8 = new User { UserId = 8, Login = "be@mail.ru", Password = "255AbC47", NickName = "Manny" };
            User user9 = new User { UserId = 9, Login = "vf658@mail.ru", Password = "1552", NickName = "Vaflya" };
                db.User.Add(user7);
                db.User.Add(user8);
                db.User.Add(user9);

            db.SaveChanges();
            }
            return Ok();
          
        }


        [HttpDelete]
        public IActionResult Delete(int UserId)

        {
            string resultText = "";

            using (TranslatorDBContext db = new TranslatorDBContext())
            {
                // получаем первый объект
                User user = db.User.FirstOrDefault(x => x.UserId == 9);
                if (user != null)
                {
                    //удаляем объект
                    db.User.Remove(user);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после удаления:");
                var users = db.User.ToList();
                foreach (User u in users)
                {
                    resultText += $"{u.UserId}.{u.Login} - {u.Password} - {u.NickName}\n";
                }
            }
            
            return Ok();

            
        }

            [HttpGet]
        public string Get(User currentUser)
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

                    resultText+= $"{u.UserId}.{u.Login} - {u.Password} - {u.NickName}\n";
                }
            }


            return resultText;
        }


        [HttpPut]
        public IActionResult Put(User alterUser)

        {
            string resultText = "";

            using (TranslatorDBContext db = new TranslatorDBContext())
            {
                User user = db.User.FirstOrDefault(x => x.UserId == 7);
                if (user != null)
                {
                    user.NickName = "Lushi";
                    user.Login = "cppp@gmail.com";

                    db.User.Update(user);
                    db.SaveChanges();

                    var users = db.User.ToList();
                    foreach (User u in users)
                    {
                        resultText += $"{u.UserId}.{u.Login} - {u.Password} - {u.NickName}\n";
                    }
                }
            }

            return Ok();
        }


    }
}
