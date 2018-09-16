using System;
using System.Configuration;

namespace Antpoll.Domain.Core.Configuration
{
    public static class ConfigManager
    {
        private static string _defaultConnection;
        public static string DefaultConnection => _defaultConnection ?? (_defaultConnection = GetConfigurationValue<string>("DefaultConnection"));

        private static string _msgGetError;
        public static string MsgGetError => _msgGetError ?? (_msgGetError = GetConfigurationValue<string>("MsgGetError"));

        private static string _msgAddError;
        public static string MsgAddError => _msgAddError ?? (_msgAddError = GetConfigurationValue<string>("MsgAddError"));

        private static string _msgDelError;
        public static string MsgDelError => _msgDelError ?? (_msgDelError = GetConfigurationValue<string>("MsgDelError"));

        private static string _uriAuthorize;
        public static string UriAuthorize => _uriAuthorize ?? (_uriAuthorize = GetConfigurationValue<string>("UriAuthorize"));

        private static string _msgUnauthenticate;
        public static string MsgUnauthenticate => _msgUnauthenticate ?? (_msgUnauthenticate = GetConfigurationValue<string>("MsgUnauthenticate"));

        private static string _msgUnauthorize;
        public static string MsgUnauthorize => _msgUnauthorize ?? (_msgUnauthorize = GetConfigurationValue<string>("MsgUnauthorize"));

        private static T GetConfigurationValue<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
