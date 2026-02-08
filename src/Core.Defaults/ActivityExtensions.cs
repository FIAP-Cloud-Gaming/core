using System.Diagnostics;

namespace Core.Defaults;

public static class ActivityExtensions
{
    public static void SetExceptionTags(this Activity activity, Exception exception)
    {
        if (activity is null)
            return;

        activity.AddTag("exception.type", exception.GetType().FullName);
        activity.AddTag("exception.message", exception.Message);
        activity.AddTag("exception.stacktrace", exception.ToString());

        if (exception.InnerException is not null)
        {
            activity.AddTag("exception.inner_type", exception.InnerException.GetType().FullName);
            activity.AddTag("exception.inner_message", exception.InnerException.Message);
        }

        activity.SetStatus(ActivityStatusCode.Error, exception.Message);
    }

    public static Activity? AddCustomTags(this Activity? activity, params (string Key, object? Value)[] tags)
    {
        if (activity is null)
            return activity;

        foreach (var (key, value) in tags)
        {
            if (value is not null)
            {
                activity.AddTag(key, value);
            }
        }

        return activity;
    }
}
