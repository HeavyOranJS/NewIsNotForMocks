// Создаем сервис который будет внедряться.
var service = new Service();
var serviceManager = new ServiceManager(service);
Console.WriteLine($"Вызываем менеджер без мока. Результат: {serviceManager.CallServiceMethod()}");
// Ожидаемый результат: hi, i'm service
// Реальный результат : hi, i'm service

// Создаем сервис в котором методы перезаписаны через new.
var mock = new MockService();
var mockedServiceManager = new ServiceManager(mock);
Console.WriteLine($"Вызываем менеджер с переопределением через new. Результат: {mockedServiceManager.CallServiceMethod()}");
// Ожидаемый результат: hi, i'm mock service
// Реальный результат : hi, i'm service

// Результаты совпадают так как при передаче mock c типом MockService
// его тип приводится к базовому типу Service, который прописан в аргументе.
// new в наследнике на базовый тип никакого эффекта не оказывает.

public class ServiceManager
{
    private readonly Service _service;

    public ServiceManager(Service service) => _service = service ?? throw new ArgumentNullException(nameof(service));

    public string CallServiceMethod() => _service.Method();
}

public class Service
{
    public string Method() => "hi, i'm service";
}

public class MockService : Service
{
    public new string Method() => "hi, i'm mock service";
}