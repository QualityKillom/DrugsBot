using Domain.DomainEvents;
using Domain.Validators;
using Domain.Validators.EntitiesValidator;
using FluentValidation;

namespace Domain.Entities
{
    /// <summary>
    /// Справочник стран
    /// </summary>
    public class Country : BaseEntity<Country>
    {
        public static readonly HashSet<string> CountryCodes = new()
        {
            "RU", "MD", "UA", "US", "CA", "CN", "FR", "DE", "IT", "ES", "GB", "JP",
            "BR", "IN", "MX", "KZ", "BY", "TR", "PL", "SE", "FI", "NO", "DK", "PT",
            "GR", "CZ", "SK", "HU", "RO", "BG", "CH", "AT", "BE", "NL", "IE", "LU",
            "IS", "EE", "LV", "LT", "AM", "GE", "AZ", "UZ", "KG", "TJ", "TM", "AF",
            "EG", "ZA", "AU", "NZ", "AR", "CL", "CO", "PE", "VE", "KR", "SA", "AE",
            "QA", "IL", "TH", "MY", "SG", "VN", "ID", "PH", "NG", "KE", "TZ", "UG",
            "GH", "ET", "DZ", "MA", "SN", "ZM", "ZW", "PK", "BD", "LK", "MM", "KH",
            "LA", "NP", "MN", "CU", "DO", "JM", "HT", "TT", "BZ", "GT", "HN", "SV",
            "NI", "CR", "PA", "PY", "UY"
        };
        /// <summary>
        /// Конструктор для инициализации страны с названием и кодом.
        /// </summary>
        /// <param name="name">Название страны.</param>
        /// <param name="code">Код страны.</param>
        public Country(string name, string code)
        {
            Name = name;
            Code = code;
            Validate();
        }
        private void Validate()
        {
            var validator = new CountryValidator();
            var result = validator.Validate(this);

            if (!result.IsValid)
            {
                var errors = string.Join("  ", result.Errors.Select(x => x.ErrorMessage));
                
                throw new ValidationException(errors);
            }
        }
        public void UpdateName(string name)
        {
            if (Name != name)
            {
                var previousName = Name;
                Name = name;

                ValidateEntity(new CountryValidator());

                AddDomainEvent(new CountryUpdateEvent(this, previousName, name));
            }
        }
        /// <summary>
        /// Обновить код страны.
        /// </summary>
        /// <param name="code">Новый код страны.</param>
        public void UpdateCode(string code)
        {
            if (!CountryCodes.Contains(code))
                throw new ArgumentException("Неверный код страны.", nameof(code));

            if (Code != code)
            {
                var previousCode = Code;
                Code = code;

                ValidateEntity(new CountryValidator());

                AddDomainEvent(new CountryUpdateEvent(this, previousCode, code));
            }
        }

        /// <summary>
        /// Название страны.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Код страны (например, ISO-код).
        /// </summary>
        public string Code { get; private set; }
        
       
        public ICollection<Drug> Drugs { get; private set; }
        
        
    }
}