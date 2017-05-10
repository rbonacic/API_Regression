
using System;

public class Rootobject
{
    public string OrganizationToken { get; set; }
    public Configuration Ptpexecution { get; set; }

    
}

public class Configuration
{
    public int Id { get; set; }
    public int ExecutionDaysInterval { get; set; }
    public int ConfigurationTypeId { get; set; }
    public Configurationtype ConfigurationType { get; set; }

    public static implicit operator Configuration(Ptpexecution v)
    {
        throw new NotImplementedException();
    }
}

public class Configurationtype
{
    public int Id { get; set; }
    public string Name { get; set; }
}



