using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;

public sealed class GuestId : ValueObject
{
    public Guid Value { get; }

    public GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUnique()
    {
        return new GuestId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}