﻿using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualClassroom.Common.Helpers
{
    public static class Settings
    {
        private const string _token = "token";
        private const string _isLogin = "isLogin";
        private const string _meeting = "isLogin";
        private static readonly string _stringDefault = string.Empty;
        private static readonly bool _boolDefault = false;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string Token
        {
            get => AppSettings.GetValueOrDefault(_token, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_token, value);
        }

        public static bool IsLogin
        {
            get => AppSettings.GetValueOrDefault(_isLogin, _boolDefault);
            set => AppSettings.AddOrUpdateValue(_isLogin, value);
        }


        public static string Meeting
        {
            get => AppSettings.GetValueOrDefault(_meeting, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_meeting, value);
        }
    }

}
