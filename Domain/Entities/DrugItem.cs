using Domain.Validators.EntitiesValidator;
using Domain.Events;


namespace Domain.Entities
{
    /// <summary>
    /// Связь между препаратом и аптекой
    /// </summary>
    public class DrugItem : BaseEntity<DrugItem>
    {
        public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, int count, Drug drug, DrugStore drugStore)
        {
            DrugId = drugId;
            DrugStoreId = drugStoreId;
            Cost = cost;
            Count = count;
            Drug = drug;
            DrugStore = drugStore;
            
            ValidateEntity(new DrugItemValidator());
        }

        
        /// <summary>
        /// Идентификатор препарата.
        /// </summary>
        public Guid DrugId { get; private set; }
        
        /// <summary>
        /// Идентификатор аптеки.
        /// </summary>
        public Guid DrugStoreId { get; private set; }
        
        /// <summary>
        /// Стоимость препарата в данной аптеке.
        /// </summary>
        public decimal Cost { get; private set; }
        
        /// <summary>
        /// Количество препарата на складе.
        /// </summary>
        public int Count { get; private set; }
        
        // Навигационные свойства
        public Drug Drug { get; private set; }
        public DrugStore DrugStore { get; private set; }

        /// <summary>
        /// Обновить стоимость препарата.
        /// </summary>
        /// <param name="cost">Новая стоимость</param>
        public void UpdateCost(decimal cost)
        {
            
            Cost = cost;

            ValidateEntity(new DrugItemValidator());

            AddDomainEvent(new DrugItemUpdateEvent());
        }

        /// <summary>
        /// Обновить количество препарата на складе.
        /// </summary>
        /// <param name="count">Новое количество</param>
        public void UpdateCount(int count)
        {
            Count = count;

            ValidateEntity(new DrugItemValidator());

            AddDomainEvent(new DrugItemUpdateEvent());
        }

        /// <summary>
        /// Обновить связь с препаратом.
        /// </summary>
        /// <param name="drug">Новый объект препарата</param>
        public void UpdateDrug(Drug drug)
        {
            Drug = drug ?? throw new ArgumentNullException(nameof(drug));

            ValidateEntity(new DrugItemValidator());

            AddDomainEvent(new DrugItemUpdateEvent());
        }

        /// <summary>
        /// Обновить связь с аптекой.
        /// </summary>
        /// <param name="drugStore">Новый объект аптеки</param>
        public void UpdateDrugStore(DrugStore drugStore)
        {
            DrugStore = drugStore ?? throw new ArgumentNullException(nameof(drugStore));

            ValidateEntity(new DrugItemValidator());

            AddDomainEvent(new DrugItemUpdateEvent());
        }

    }
}