#pragma checksum "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f861f9303f0a7b67ba43d4ad74f205dbb9143e2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Aplikacja_webowa___Football.Pages.Home.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
using Football.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f861f9303f0a7b67ba43d4ad74f205dbb9143e2b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93fa5087191d699091836c69a50df6a43135b285", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Country>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Home Page";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2 class=\"text-white\">Lista drużyn biorących udział w turnieju</h2>\r\n<input class=\"search-bar\" type=\"text\" id=\"myInput\" onkeyup=\"searchCountryByName()\" placeholder=\"Wyszukaj..\">\r\n<a");
            BeginWriteAttribute("href", " href=\"", 275, "\"", 315, 1);
#nullable restore
#line 8 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
WriteAttributeValue("", 282, Url.Action("AddClub", "Country"), 282, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""addCountryButton"" class=""btn btn-primary"">Dodaj drużynę</a>
<table id=""searchTable"" class=""sortable table my-table"">
    <thead>
        <tr>
            <th>Nr.</th>
            <th>Kraj</th>
            <th>Trener</th>
            <th>Grupa</th>
            <th>Akcje</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 20 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
         foreach (var (team, index) in Model.Select((item, index) => (item, index)))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 23 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
                Write(index + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</td>\r\n                <td>");
#nullable restore
#line 24 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
               Write(team.CountryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
               Write(team.Coach.Firstname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 25 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
                                     Write(team.Coach.Lastname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
               Write(team.Grupa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
#nullable restore
#line 28 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
               Write(Html.ActionLink("Szczegóły", "Details", new { countryId = team.CountryID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 29 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
               Write(Html.ActionLink("Edytuj", "EditClub", "Country", new { countryId = team.CountryID }, null));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 30 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
               Write(Html.ActionLink("Usuń", "DeleteClub", "Country", new { countryId = team.CountryID }, new { onclick = "return confirm('Czy na pewno chcesz usunąć drużynę?');" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 33 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Country>> Html { get; private set; }
    }
}
#pragma warning restore 1591
