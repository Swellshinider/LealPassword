namespace LealPassword.DataBase.Model
{
    internal sealed class Register
    {
        public int Id { get; set; }
        internal string? Name { get; set; }
        internal string? Description { get; set; }
        internal string? Email { get; set; }
        internal string? Password { get; set; }
    }
}