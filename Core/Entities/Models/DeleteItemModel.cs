using Core.Entities.Abstract;

namespace Core.Entities.Models;

public class DeleteItemModel<TId> : IModel
{
    public TId Id { get; set; }
    public bool Permanent { get; set; }
}
