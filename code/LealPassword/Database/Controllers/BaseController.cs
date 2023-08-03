namespace LealPassword.Database.Controllers
{
    internal abstract class BaseController
    {
        protected readonly string _directory;
        protected readonly string _fileName;
        protected readonly string _unhashedPassword;

        protected BaseController(string directory, string fileName, string unhashedPassword)
        {
            _directory = directory;
            _fileName = fileName;
            _unhashedPassword = unhashedPassword;
        }
    }
}