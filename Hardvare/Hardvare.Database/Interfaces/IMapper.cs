namespace Hardvare.Database.Interfaces
{
    public interface IMapper<TDomain, TModel>
    {
        TDomain Map(TModel value);
        TModel Map(TDomain value);
    }
}
