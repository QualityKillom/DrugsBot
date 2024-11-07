﻿using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Справочник стран
    /// </summary>
    public class Country : BaseEntity
    {
        public static readonly Dictionary<string, string> CountryCodes = new Dictionary<string, string>
        {
            { "RU", "Россия" },
            { "MD", "Молдова" },
            { "UA", "Украина" }, 
            { "US", "США" }, 
            { "CA", "Канада" }, 
            { "CN", "Китай" },
            { "FR", "Франция" },
            { "DE", "Германия" },
            { "IT", "Италия" },
            { "ES", "Испания" },
            { "GB", "Великобритания" },
            { "JP", "Япония" },
            { "BR", "Бразилия" },
            { "IN", "Индия" },
            { "MX", "Мексика" },
            { "KZ", "Казахстан" },
            { "BY", "Беларусь" },
            { "TR", "Турция" },
            { "PL", "Польша" },
            { "SE", "Швеция" },
            { "FI", "Финляндия" },
            { "NO", "Норвегия" },
            { "DK", "Дания" },
            { "PT", "Португалия" },
            { "GR", "Греция" },
            { "CZ", "Чехия" },
            { "SK", "Словакия" },
            { "HU", "Венгрия" },
            { "RO", "Румыния" },
            { "BG", "Болгария" },
            { "CH", "Швейцария" },
            { "AT", "Австрия" },
            { "BE", "Бельгия" },
            { "NL", "Нидерланды" },
            { "IE", "Ирландия" },
            { "LU", "Люксембург" },
            { "IS", "Исландия" },
            { "EE", "Эстония" },
            { "LV", "Латвия" },
            { "LT", "Литва" },
            { "AM", "Армения" },
            { "GE", "Грузия" },
            { "AZ", "Азербайджан" },
            { "UZ", "Узбекистан" },
            { "KG", "Киргизия" },
            { "TJ", "Таджикистан" },
            { "TM", "Туркмения" },
            { "AF", "Афганистан" },
            { "EG", "Египет" },
            { "ZA", "Южная Африка" },
            { "AU", "Австралия" },
            { "NZ", "Новая Зеландия" },
            { "AR", "Аргентина" },
            { "CL", "Чили" },
            { "CO", "Колумбия" },
            { "PE", "Перу" },
            { "VE", "Венесуэла" },
            { "KR", "Южная Корея" },
            { "SA", "Саудовская Аравия" },
            { "AE", "ОАЭ" },
            { "QA", "Катар" },
            { "IL", "Израиль" },
            { "TH", "Таиланд" },
            { "MY", "Малайзия" },
            { "SG", "Сингапур" },
            { "VN", "Вьетнам" },
            { "ID", "Индонезия" }, 
            { "PH", "Филиппины" }, 
            { "NG", "Нигерия" },
            { "KE", "Кения" }, 
            { "TZ", "Танзания" }, 
            { "UG", "Уганда" }, 
            { "GH", "Гана" },
            { "ET", "Эфиопия" },
            { "DZ", "Алжир" },
            { "MA", "Марокко" },
            { "SN", "Сенегал" },
            { "ZM", "Замбия" },
            { "ZW", "Зимбабве" },
            { "PK", "Пакистан" }, 
            { "BD", "Бангладеш" },
            { "LK", "Шри-Ланка" },
            { "MM", "Мьянма" },
            { "KH", "Камбоджа" },
            { "LA", "Лаос" },
            { "NP", "Непал" },
            { "MN", "Монголия" },
            { "CU", "Куба" },
            { "DO", "Доминиканская Республика" },
            { "JM", "Ямайка" },
            { "HT", "Гаити" },
            { "TT", "Тринидад и Тобаго" },
            { "BZ", "Белиз" },
            { "GT", "Гватемала" },
            { "HN", "Гондурас" }, 
            { "SV", "Сальвадор" }, 
            { "NI", "Никарагуа" },
            { "CR", "Коста-Рика" },
            { "PA", "Панама" },
            { "PY", "Парагвай" },
            { "UY", "Уругвай" }
            
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
        }

        /// <summary>
        /// Название страны.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Код страны (например, ISO-код).
        /// </summary>
        public string Code { get; private set; }
        
       
        public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();
        
        
    }
}