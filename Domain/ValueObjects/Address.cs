namespace Domain.ValueObjects
{
    /// <summary>
    /// Объект значения, представляющий адрес.
    /// </summary>
    public class Address : BaseValueObject
    {
        /// <summary>
        /// Конструктор для инициализации адреса.
        /// </summary>
        /// <param name="city">Город.</param>
        /// <param name="street">Улица.</param>
        /// <param name="house">Номер дома.</param>
        public Address(string city, string street, string house, int postcode)
        {
            City = city;
            Street = street;
            House = house;
            PostalCode = postcode;
        }
        
        /// <summary>
        /// Город.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Улица.
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// Номер дома.
        /// </summary>
        public string House { get; private set; }

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        /// КАНАДА T0J 0H0
        /// КОЛУМБИЯ 050005
        /// НУ НЕЗЯ СДЕЛАТЬ ЧИСЛОВОЙ 
        public int PostalCode { get; private set; }
        
        /// <summary>
        /// Возвращает строковое представление адреса.
        /// </summary>
        /// <returns>Строка, представляющая адрес.</returns>
        
        public override string ToString()
        {
            return $"{City}, {Street}, {House}, {PostalCode}";
        }
    }
}