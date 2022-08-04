namespace LealPassword.DataBase.Model
{
    internal sealed class Account
    {
        internal string? Name { get; set; }
        internal string? Key { get; set; }
        internal List<Register>? Registers { get; set; }
    }
}