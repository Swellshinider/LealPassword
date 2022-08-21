namespace LealPassword.Database.Model
{
    internal sealed class Register
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal string Tag { get; set; }
        internal string Description { get; set; }
        internal string Email { get; set; }
        internal string ImageKey { get; set; }
        internal string Password { get; set; }
    }
}