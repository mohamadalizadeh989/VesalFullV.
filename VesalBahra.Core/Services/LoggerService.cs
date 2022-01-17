﻿using NLog;
using VesalBahar.Core.Interfaces;

namespace VesalBahar.Core.Services
{
    public class LoggerService<TController> : ILoggerService<TController>
    {
        private readonly ILogger _logger;
        public LoggerService()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void LogDebug(string message)
        {
            _logger.Debug(MessageBuilder(message));
        }

        public void LogError(string message)
        {
            _logger.Error(MessageBuilder(message));
        }

        public void LogInfo(string message)
        {
            _logger.Info(MessageBuilder(message));
        }

        public void LogWarn(string message)
        {
            _logger.Warn(MessageBuilder(message));
        }

        private string MessageBuilder(string message)
        {
            return typeof(TController).FullName + " | " + message;
        }
    }
}
