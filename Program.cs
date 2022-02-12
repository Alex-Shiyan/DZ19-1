//
// Домашнее задание к занятию 19. LINQ
//
// Задача 1. Модель  компьютера  характеризуется
// кодом  и
// названием  марки компьютера,
// типом  процессора,
// частотой  работы  процессора,
// объемом оперативной памяти,
// объемом жесткого диска,
// объемом памяти видеокарты,
// стоимостью компьютера в условных единицах
// и количеством экземпляров, имеющихся в наличии.
// Создать список, содержащий 6-10 записей с различным набором значений характеристик.

//Определить:
//-все компьютеры с указанным процессором. Название процессора запросить у пользователя;
//-все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
//-вывести весь список, отсортированный по увеличению стоимости;
//-вывести весь список, сгруппированный по типу процессора;
//-найти самый дорогой и самый бюджетный компьютер;
//-есть ли хотя бы один компьютер в количестве не менее 30 штук?


using DZ19;


// Создать список, содержащий 6-10 записей с различным набором значений характеристик.
List<Сomputer> comps = new List<Сomputer>()
{
    new Сomputer(){Code = "001", Name ="Apple" , Cpu = "Intel", Freq = 3.2, Ram =8, Hdd = 2, Video=1, Price=2300, Quant=9 },
    new Сomputer(){Code = "002", Name ="Lenovo" , Cpu = "AMD", Freq = 3.5, Ram =4, Hdd = 4, Video=4, Price=1900, Quant=24 },
    new Сomputer(){Code = "002A", Name ="MSI" , Cpu = "Intel", Freq = 4.0, Ram =8, Hdd = 4, Video=6, Price=1750, Quant=12 },
    new Сomputer(){Code = "002F", Name ="Acer" , Cpu = "AMD", Freq = 4.0, Ram =4, Hdd = 2, Video=2, Price=1100, Quant=4 },
    new Сomputer(){Code = "003", Name ="ASUS" , Cpu = "Intel", Freq = 3.5, Ram =2, Hdd = 1, Video=1, Price=1150, Quant=52 },
    new Сomputer(){Code = "004", Name ="HP" , Cpu = "Intel", Freq = 3.2, Ram =4, Hdd = 2, Video=2, Price=950, Quant=27 },
    new Сomputer(){Code = "004-1", Name ="DELL" , Cpu = "AMD", Freq = 3.2, Ram =8, Hdd = 2, Video=1, Price=1650, Quant=31 },
    new Сomputer(){Code = "005", Name ="ASUS" , Cpu = "AMD", Freq = 3.5, Ram =8, Hdd = 1, Video=2, Price=1020, Quant=14 },
    new Сomputer(){Code = "006", Name ="MSI" , Cpu = "Intel", Freq = 3.0, Ram =2, Hdd = 2, Video=1, Price=870, Quant=8 },
    new Сomputer(){Code = "006-S", Name ="Acer" , Cpu = "AMD", Freq = 3.5, Ram =4, Hdd = 1, Video=1, Price=950, Quant=6 }
};

//-все компьютеры с указанным процессором. Название процессора запросить у пользователя;
Console.Write("Введите тип процессора (Intel или AMD): ");
    string cpu = Console.ReadLine();
Console.WriteLine();
List<Сomputer> compsCpu = comps
                .Where(c => c.Cpu == cpu)
                .ToList();
if (compsCpu.Count > 0)
    Print(compsCpu);
else
   Console.WriteLine("Позиции не найдены");
Console.WriteLine();

//-все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
int ram;
Console.Write("Введите минимальный объем ОЗУ, ГБ (диапазон от 2 до 8): ");
while (!int.TryParse(Console.ReadLine(), out ram))
{
    Console.WriteLine("Ошибка ввода");
}
Console.WriteLine(); 
List<Сomputer> compsRam = comps
                .Where(c => c.Ram >= ram)
                .ToList();
if (compsRam.Count == 0)
{
    Console.WriteLine("Позиции не найдены");
    Console.WriteLine();
}
else
    Print(compsRam);
Console.WriteLine();

//-вывести весь список, отсортированный по увеличению стоимости;
Console.WriteLine("Список компьюторов по увеличению стоимости: ");
Console.WriteLine();
List<Сomputer> compsPrice = comps.OrderBy(c => c.Price).ToList();
Print(compsPrice);
Console.WriteLine();

//-вывести весь список, сгруппированный по типу процессора;
Console.WriteLine("Список компьюторов по типу процессора: ");
Console.WriteLine();
List<Сomputer> compsType = comps.OrderBy(c => c.Cpu).ToList();
Print(compsType);
Console.WriteLine();

//-вывести весь список, сгруппированный по типу процессора (2-й вариант);
Console.WriteLine("Список компьюторов по типу процессора (2-й вариант): ");
Console.WriteLine();
IEnumerable<IGrouping<string, Сomputer>> groups = comps.GroupBy(c => c.Cpu);
foreach(IGrouping<string, Сomputer> g in groups)
{
    Console.WriteLine(g.Key);
    foreach(Сomputer c in g)
    {
        Console.WriteLine($"\tКод: { c.Code,-5} Название: { c.Name,-6}  Процессор: { c.Cpu,-6}  Частота: { c.Freq:F1} ГГц   Память: { c.Ram} ГБ   Жесткий диск: { c.Hdd} ТВ   Видеокарта: { c.Video} ГБ   Цена: { c.Price,4} у.е.");
    }
}
Console.WriteLine();

//-найти самый дорогой и самый бюджетный компьютер;
Console.WriteLine("Самый дорогой компьютор: ");
Сomputer maxPrice = comps.OrderByDescending(c=> c.Price).FirstOrDefault();
Console.WriteLine($"Код: { maxPrice.Code,-5} Название: { maxPrice.Name,-6}  Процессор: { maxPrice.Cpu,-6}  Частота: { maxPrice.Freq:F1} ГГц   Память: { maxPrice.Ram} ГБ   Жесткий диск: { maxPrice.Hdd} ТВ   Видеокарта: { maxPrice.Video} ГБ   Цена: { maxPrice.Price,4} у.е.");
Console.WriteLine();
Console.WriteLine("Самый бюджетный компьютор: ");
Сomputer minPrice = comps.OrderBy(c => c.Price).FirstOrDefault();
Console.WriteLine($"Код: { minPrice.Code,-5} Название: { minPrice.Name,-6}  Процессор: { minPrice.Cpu,-6}  Частота: { minPrice.Freq:F1} ГГц   Память: { minPrice.Ram} ГБ   Жесткий диск: { minPrice.Hdd} ТВ   Видеокарта: { minPrice.Video} ГБ   Цена: { minPrice.Price,4} у.е.");
Console.WriteLine();

//-есть ли хотя бы один компьютер в количестве не менее 30 штук?
Console.Write("Есть ли хотя бы один компьютер в количестве не менее 30 штук? ");
comps.Any(c => c.Quant >= 30);
if (comps.Any()==true) Console.WriteLine(" Ответ положительный.");
else Console.WriteLine(" Ответ отрицательный.");

Console.ReadKey();




static void Print (List<Сomputer> comps)
{ 
        foreach(Сomputer c in comps)
    {
        Console.WriteLine($"Код: { c.Code,-5} Название: { c.Name,-6}  Процессор: { c.Cpu,-6}  Частота: { c.Freq:F1} ГГц   Память: { c.Ram} ГБ   Жесткий диск: { c.Hdd} ТВ   Видеокарта: { c.Video} ГБ   Цена: { c.Price,4} у.е.");
    }
    Console.WriteLine();
}





