#pragma checksum "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa61843965823cb60be0c291924af36de5df933a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Aplikacja_webowa___Football.Pages.Home.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
namespace Aplikacja_webowa___Football.Pages.Home
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\_ViewImports.cshtml"
using Aplikacja_webowa___Football;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa61843965823cb60be0c291924af36de5df933a", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93fa5087191d699091836c69a50df6a43135b285", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Football.Entities.Player>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2 class=\"text-white\">");
#nullable restore
#line 3 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
                  Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<button type=\"button\" class=\"btn btn-secondary\" onclick=\"goBack()\">Wstecz</button>\r\n<a");
            BeginWriteAttribute("href", " href=\"", 169, "\"", 253, 1);
#nullable restore
#line 5 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
WriteAttributeValue("", 176, Url.Action("AddPlayer", "Player", new { countryId = ViewData["CountryId"] }), 176, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"addPlayerButton\" class=\"btn btn-primary\">Dodaj zawodnika</a>\r\n\r\n\r\n");
#nullable restore
#line 8 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
 if (ViewData["Players"] != null && ((List<Football.Entities.Player>)ViewData["Players"]).Any())
{
    var number = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table id=""countryTable"" class=""sortable table my-table"">
        <thead>
            <tr>
                <th>Nr.</th>
                <th>Zawodnik</th>
                <th>Pozycja</th>
                <th>Wiek</th>
                <th>Klub</th>
                <th>Akcje</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 23 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
             foreach (var player in (List<Football.Entities.Player>)ViewData["Players"])
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 26 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
                    Write(number);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</td>\r\n                    <td>");
#nullable restore
#line 27 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
                   Write(player.PlayerFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
                   Write(player.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 29 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
                   Write(player.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
                   Write(player.Club);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 32 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
                   Write(Html.ActionLink("Edytuj", "EditPlayer", "Player", new { playerId = player.PlayerID }, null));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 33 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
                   Write(Html.ActionLink("Usuń", "DeletePlayer", "Player", new { playerId = player.PlayerID }, new { onclick = "return confirm('Czy na pewno chcesz usunąć zawodnika?');" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 36 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
                number++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 41 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"text-white\">Brak zawodników dla tego kraju. Dodaj pierwszego zawodnika.</p>\r\n");
#nullable restore
#line 45 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Details.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Football.Entities.Player> Html { get; private set; }
    }
}
#pragma warning restore 1591
