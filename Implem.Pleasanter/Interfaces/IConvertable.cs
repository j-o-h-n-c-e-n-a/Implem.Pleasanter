﻿using Implem.Pleasanter.Libraries.Html;
using Implem.Pleasanter.Libraries.Settings;
namespace Implem.Pleasanter.Interfaces
{
    public interface IConvertable
    {
        string ToControl(Column column);
        string ToResponse();
        HtmlBuilder Td(HtmlBuilder hb, Column column);
        string ToExport(Column column);
    }
}