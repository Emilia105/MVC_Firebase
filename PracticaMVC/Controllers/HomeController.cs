using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using PracticaMVC.Models;
using System.Diagnostics;

namespace PracticaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SubirArchivo(IFormFile archivo)
        {
            Stream archivoASubir = archivo.OpenReadStream();

            string email = "emilia.escobar@catolica.edu.sv";
            string clave = "2021EM65041464";
            string ruta = "mvcfirebase-28845.appspot.com";
            string api_key = "AIzaSyCRj8eReUYzHsNyv86boglT6fZVjRnXCyc";

            var auth = new FirebaseAuthProvider(new FirebaseConfig(api_key));
            var autenticarFireBase = await auth.SignInWithEmailAndPasswordAsync(email, clave);

            var cancellation = new CancellationTokenSource();
            var tokenUser = autenticarFireBase.FirebaseToken;

            var tareaCargarArchivo = new FirebaseStorage(ruta,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(tokenUser),
                    ThrowOnCancel = true
                }
                ).Child("Archivos").Child(archivo.FileName).PutAsync(archivoASubir, cancellation.Token);
            var urlArchivoCargado = await tareaCargarArchivo;

            return RedirectToAction("VerImagen");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
