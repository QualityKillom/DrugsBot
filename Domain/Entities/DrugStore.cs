using Domain.Validators;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Entities
{
    /// <summary>
    /// Аптека
    /// </summary>
    public class DrugStore : BaseEntity<DrugStore>
    {
        public DrugStore(string drugNetwork, int number, Address address)
        {
            DrugNetwork = drugNetwork;
            Number = number;
            Address = address;
            Validate();
        }
        public void Validate()
        {
            var validator = new DrugStoreValidator();
            var result = validator.Validate(this);

            if (!result.IsValid)
            {
                var errors = string.Join(' ', result.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
        /// <summary>
        /// Сеть аптек, к которой принадлежит аптека.
        /// </summary>
        public string DrugNetwork { get; private set; }
        
        /// <summary>
        /// Номер аптеки в сети.
        /// </summary>
        public int Number { get; private set; }
        
        /// <summary>
        /// Адрес аптеки.
        /// </summary>
        public Address Address { get; private set; }
        
        // Навигационное свойство для связи с DrugItem
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="drugNetwork"></param>
        /// <exception cref="ArgumentException"></exception>
        public void UpdateDrugNetwork(string drugNetwork)
        {
            if (string.IsNullOrWhiteSpace(drugNetwork))
                throw new ArgumentException("Название сети аптек не может быть пустым.", nameof(drugNetwork));

            DrugNetwork = drugNetwork;
            ValidateEntity(new DrugStoreValidator());
        }

        public void UpdateNumber(int number)
        {
            if (number <= 0)
                throw new ArgumentException("Номер аптеки должен быть положительным.", nameof(number));

            Number = number;
            ValidateEntity(new DrugStoreValidator());
        }

        public void UpdateAddress(Address address)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
            ValidateEntity(new DrugStoreValidator());
        }
    }
}