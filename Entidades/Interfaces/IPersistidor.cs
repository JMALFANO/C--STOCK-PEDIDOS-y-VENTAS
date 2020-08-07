using System;
namespace Interfaces
{
    /// <summary>
    /// Es implementada por todos los persistidores, 
    /// para lograr una funcionalidad común, 
    /// básicamente el CRUD (Create, Read, Update and Delete).
    /// </summary>
    /// <typeparam name="I"></typeparam>
    public interface IProductoPersistidor<I>
    {
       void Delete(int idProducto);
       System.Collections.Generic.List<I> GetAll();
       I GetEnPrestamo(int idProducto);
       void Save(I producto);
    }
}
