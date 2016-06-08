﻿using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.Charts;
using Implem.Pleasanter.Libraries.Html;
using Implem.Pleasanter.Libraries.Items;
using Implem.Pleasanter.Libraries.Responses;
using Implem.Pleasanter.Libraries.Security;
using Implem.Pleasanter.Libraries.Settings;
using System.Collections.Generic;
using System.Data;
namespace Implem.Pleasanter.Libraries.HtmlParts
{
    public static class HtmlGantts
    {
        public static HtmlBuilder Gantt(
            this HtmlBuilder hb,
            SiteSettings siteSettings,
            Permissions.Types permissionType,
            IEnumerable<DataRow> dataRows,
            string unit)
        {
            var gantt = new Gantt(siteSettings, dataRows);
            return hb
                .Graph(gantt: gantt)
                .MainCommands(
                    siteId: siteSettings.SiteId,
                    permissionType: permissionType,
                    verType: Versions.VerTypes.Latest,
                    backUrl: Navigations.ItemIndex(siteSettings.ParentId),
                    importButton: true,
                    exportButton: true);
        }

        private static HtmlBuilder Graph(this HtmlBuilder hb, Gantt gantt)
        {
            return hb.Div(css: "gantt-graph", action: () => hb
                .Svg(
                    attributes: new HtmlAttributes()
                        .Id_Css("Gantt", "gantt")
                        .Height(gantt.Height.ToInt()))
                .Svg(
                    attributes: new HtmlAttributes()
                        .Id_Css("GanttAxis", "gantt-axis"))
                .Hidden(
                    controlId: "GanttJson",
                    value: gantt.GanttGraphJson()));
        }
    }
}