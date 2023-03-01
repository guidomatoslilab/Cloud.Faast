namespace Cloud.Faast.HangFire.Interface.Repository
{
    public interface IGenerateIdentity<T>
    {
        Func<T> GetKey();
    }
}
