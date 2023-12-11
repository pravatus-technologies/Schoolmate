namespace Schoolmate.Domain.Entities.ApplicantAggregate;

public class Applicant : BaseAuditableEntity
{
    // Related User Id from Authentication Db
    public string ApplicationUserId { get; private set; } = string.Empty;
    
    // LRN from DepEd
    public string? LearnerRefNumber { get; private set; }
    
    // Given names
    public string GivenNames { get; private set; } = string.Empty;

    // Middle name, optional
    public string? MiddleName { get; private set; }

    // Family name
    public string FamilyName { get; private set; } = string.Empty;

    // Gender
    public Gender? Gender { get; private set; }

    // Birthday, optional
    public DateOnly? Birthday { get; private set; }

    // Calculate Age by number of Total days between now and birthday divided by 365.25
    public double Age => Birthday.HasValue ? (DateTime.Now - Birthday.Value.ToDateTime(TimeOnly.MinValue)).TotalDays / 365.25 : 0;

    // Birthplace
    public string? Birthplace { get; private set; }

    // Civil status
    public CivilStatus? CivilStatus { get; private set; }

    // Nationality
    public string? Nationality { get; private set; }

    // Religion
    public string? Religion { get; private set; }

    // DDD Patterns comment
    // Using a private collection field, better for DDD Aggregate's encapsulation
    // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
    // but only through the method Order.AddOrderItem() which includes behavior.
    private readonly List<Address> _addresses = new List<Address>();
    private readonly List<ParentInformation> _parentInfos = new List<ParentInformation>();
    private readonly List<AcademicHistory> _academicHistory = new List<AcademicHistory>();

    // Using List<>.AsReadOnly() 
    // This will create a read only wrapper around the private list so is protected against "external updates".
    // It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
    //https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 
    public IReadOnlyCollection<Address> AddressList => _addresses.AsReadOnly();
    public IReadOnlyCollection<ParentInformation> ParentList => _parentInfos.AsReadOnly();
    public IReadOnlyCollection<AcademicHistory> AcademicHistory => _academicHistory.AsReadOnly();

    #pragma warning disable CS8618 // Required by Entity Framework
    private Applicant() { }

    // Static method that returns a new instance of the Resource class
    public static Applicant Create(
        string givenNames,
        string? middleName,
        string familyName,
        Gender? gender,
        DateOnly? birthday,
        string? birthPlace,
        CivilStatus? civilStatus,
        string? nationality,
        string? religion)
    {
        
        var t = new Applicant();
        t.GivenNames = givenNames;
        t.MiddleName = middleName;
        t.FamilyName = familyName;
        t.Gender = gender;
        t.Birthday = birthday;
        t.Birthplace = birthPlace;
        t.CivilStatus = civilStatus;
        t.Nationality = nationality;
        t.Religion = religion;

        return t;
    }

    /// <summary>
    /// Add an Address record
    /// </summary>
    /// <param name="address"></param>
    public void AddAddress(Address address)
    {
        _addresses.Add(address);
    }

    /// <summary>
    /// Add a new Parent Info record
    /// </summary>
    /// <param name="parent"></param>
    public void AddParent(ParentInformation parent) 
    { 
        _parentInfos.Add(parent);
    }
}
