using System;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights;
using System.Reflection;
using System.Threading;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector;
using ProjectBook.Managers.Configuration;

namespace ProjectBook.AppInsight
{
    // Inativo
    public static class AppInsightMetrics
    {
        private static TelemetryClient telemetryClient;
        private static TelemetryConfiguration telemetryConfiguration;

        public static void InicializarInsights()
        {
            if(AppConfigurationManager.configuration.telemetry.UseTelemetry) return;

            telemetryConfiguration = TelemetryConfiguration.CreateDefault();
            telemetryConfiguration.ConnectionString = ApiKeys.TELEMETRY_CONNECTION;

            telemetryClient = new(telemetryConfiguration);
            telemetryClient.Context.Session.Id = Guid.NewGuid().ToString();
            telemetryClient.Context.Device.OperatingSystem = Environment.OSVersion.ToString();
            telemetryClient.Context.Component.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public static void FlushTelemetry()
        {
            if(telemetryClient == null) return;

            telemetryClient.Flush();
            Thread.Sleep(500);
        }

        public static void SendError(Exception exception)
        {
            if(telemetryClient == null) return;

            telemetryClient.TrackException(exception);
            FlushTelemetry();
        }
        public static void SendProcessInfo()
        {
            if(telemetryClient == null) return;

            var perfCollectorModule = new PerformanceCollectorModule();
            perfCollectorModule.Counters.Add(new(
                @"\Process(ProjectBook.exe)\Page Faults/sec", "PageFaultsPerfSec"));

            perfCollectorModule.Initialize(telemetryConfiguration);
        }
        public static void SendMetric(string metricId, int metricValue)
        {
            if(telemetryClient == null) return;

            telemetryClient.GetMetric(metricId).TrackValue(metricValue);
        }
        public static void SendUserInfo(int userId, string userName, string userType)
        {
            if(telemetryClient == null) return;

            telemetryClient.Context.User.Id = userName;
            telemetryClient.Context.User.AccountId = userId.ToString();
            telemetryClient.Context.User.AuthenticatedUserId = userName;
            telemetryClient.Context.User.UserAgent = userType;
        }
        public static void TrackForm(string formName)
        {
            if(telemetryClient == null) return;

            telemetryClient.TrackPageView(formName);
        }
        public static void TrackEvent(string eventName)
        {
            if(telemetryClient == null) return;

            telemetryClient.TrackEvent(eventName);
        }
    }
}
