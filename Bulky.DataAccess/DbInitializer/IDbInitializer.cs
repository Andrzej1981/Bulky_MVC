namespace Bulky.DataAccess.DbInitializer
{
    public interface IDbInitializer
    {
        void Initialize(string AdminName,string password);
    }
}