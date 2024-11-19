using Domain.Validators;

namespace Domain.Entities;

public class FavoriteDrug : BaseEntity<FavoriteDrug>
{
    public FavoriteDrug(
        Profile profile,
        Guid externalUserId,
        Guid drugId,
        Drug drug,
        Guid? drugStoreId,
        DrugStore? drugStore)
    {
        Profile = profile;
        ExternalUserId = externalUserId;
        DrugId = drugId;
        Drug = drug;
        DrugStoreId = drugStoreId;
        DrugStore = drugStore;
        ValidateEntity(new FavoriteDrugValidator());
    }
    public DrugStore? DrugStore { get; set; }

    public Guid? DrugStoreId { get;private set; }

    public Drug Drug { get; private set; }

    public Guid DrugId { get; private set; }

    public Guid ExternalUserId { get; private set; }
    
    public Profile Profile { get; private set; }
}