namespace Cloud.Faast.Integracion.Interface.Repository
{
    public interface IGenerateIdentity<T>
    {
        Func<T> GetKey();
    }
}