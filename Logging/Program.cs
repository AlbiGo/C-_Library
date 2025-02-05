// See https://aka.ms/new-console-template for more information
using DataManagement.DbContext;
using DataManagement.Entities;
using Dependency.Concept;
using Logging.Repositories;
using Logging.Services;

Console.WriteLine("Hello, World!");

//Dependency Injection
DependencyInjectionProvider.Register<DatabaseContext>();
DependencyInjectionProvider.Register<IExceptionLogRepository, ExceptionLogRepository>();
DependencyInjectionProvider.Register<ILogService, LogService>();

var _serviceLog = DependencyInjectionProvider.Resolve<ILogService>();
try
{
    await _serviceLog.Log(new Log()
    {
        LogMessage = "Process Started",
        Type = LogType.Info
    });

    //Check business error
    if (2 == 2)
    {
        //throw (new Exception("An error happened on the app"));
    }

    //Check null
    Log log = null;

    if (log.Type == LogType.Error)
    {
    }
}
catch (Exception ex)
{
    await _serviceLog.Log(new Log()
    {
        LogMessage = ex.Message.ToString(),
        Type = LogType.Error
    });
    throw ex;
}

Console.ReadLine();