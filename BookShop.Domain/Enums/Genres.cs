using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Enums
{
    public enum Genres
    {
        [Description("Не указан")]
        NoGenre,
        [Description("Художественная литература")]
        Fiction,
        [Description("Компьютеры")]
        Cyber,
        [Description("Деловая литература")]
        Bussines,
        [Description("Наука, образование")]
        Educ,
        [Description("Детская литература")]
        Child,
        [Description("Семья, дом, дача")]
        Personal,
        [Description("Техника и технология")]
        Moto,
        [Description("Медицина, спорт, здоровье")]
        Health,
        [Description("Общество, политика, религия")]
        Politics,
        [Description("Специальная и справочная литература")]
        Ref,
        [Description("Искусство, культура")]
        Culture,
        [Description("Хобби, коллекционирование")]
        Hobby,
        [Description("Мистика, эзотерика, непознанное")]
        Mistiq,
        [Description("Разное")]
        Other
    }
}
