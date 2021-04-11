﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ExameEscolarOnline.Web
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, String key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }


        public static T Get<T>(this ISession session, String key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
