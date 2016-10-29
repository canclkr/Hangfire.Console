﻿using Hangfire.Dashboard;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire.Console.Dashboard
{
    /// <summary>
    /// Dispatcher for configured styles
    /// </summary>
    internal class DynamicCssDispatcher : IDashboardDispatcher
    {
        private readonly ConsoleOptions _options;

        public DynamicCssDispatcher(ConsoleOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            _options = options;
        }
        
        public Task Dispatch(DashboardContext context)
        {
            var builder = new StringBuilder();
            
            builder.AppendLine(".console {")
                   .Append("    background-color: ").Append(_options.BackgroundColor).AppendLine(";")
                   .Append("    color: ").Append(_options.TextColor).AppendLine(";")
                   .AppendLine("}");
            
            builder.AppendLine(".console .line-buffer .line > span[data-moment-title] {")
                   .Append("    color: ").Append(_options.TimestampColor).AppendLine(";")
                   .AppendLine("}");

            return context.Response.WriteAsync(builder.ToString());
        }
    }
}
