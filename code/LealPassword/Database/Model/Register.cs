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

        internal bool CheckEqual(Register other)
        {
            return Id == other.Id && 
                    Name == other.Name && 
                    Tag == other.Tag && 
                    Description == other.Description && 
                    Email == other.Email && 
                    ImageKey == other.ImageKey && 
                    Password == other.Password;
        }
    }
}