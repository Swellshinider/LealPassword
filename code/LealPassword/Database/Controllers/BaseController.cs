namespace LealPassword.Database.Controllers
{
    internal abstract class BaseController
    {
        protected readonly string _directory;
        protected readonly string _fileName;

        protected BaseController(string directory, string fileName)
        {
            _directory = directory;
            _fileName = fileName;
        }
    }
}