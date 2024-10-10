using Microsoft.Extensions.Configuration;

namespace Fl.Azure.Calculator.External.PathFinder.Configuration;

public class PathFinderOptions
{
    [ConfigurationKeyName("PathfinderControlConnectionString")]
    public string ControlConnectionString { get; set; } = string.Empty;
    
    [ConfigurationKeyName("PathfinderConnectionString")]
    public string DataConnectionString {  get; set; } = string.Empty;

    public int RetryMaxCount { get; set; } = 5;
   
    public int RetryMaxDelayInSeconds { get; set; } = 60;
    
    public int RetryInitialDelayInSeconds { get; set; } = 3;
}
