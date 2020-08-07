using System;
namespace Interfaces
{
    /// <summary>
    /// Obliga a todas la entidades a implementar una propiedad Id, 
    /// que la identifica inequívocamente.
    /// </summary>
    public interface IEntity
    {
        int? Id { get; set; }
    }
}
