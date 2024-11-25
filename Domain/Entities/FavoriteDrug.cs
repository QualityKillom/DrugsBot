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
    /// <summary>
    /// Идентификатор профиля.
    /// </summary>
    public Guid ExternalUserId { get; private init; }

    /// <summary>
    /// Идентификатор препарата.
    /// </summary>
    public Guid DrugId { get; private set; }

    /// <summary>
    /// Идентификатор аптеки.
    /// </summary>
    public Guid? DrugStoreId { get; private set; }

    // Навигационные свойства
    public Profile Profile { get; private set; }
    public Drug Drug { get; private set; }
    public DrugStore? DrugStore { get; private set; }
    
    /// <summary>
    /// Метод для обновления аптеки
    /// </summary>
    /// <param name="drugStoreId"></param>
    /// <param name="drugStore"></param>
    public void UpdateDrugStore(Guid? drugStoreId, DrugStore? drugStore)
    {
        DrugStoreId = drugStoreId;
        DrugStore = drugStore;
    }
}