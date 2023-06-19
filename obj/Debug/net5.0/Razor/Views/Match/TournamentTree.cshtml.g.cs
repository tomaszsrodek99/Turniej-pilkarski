#pragma checksum "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecc3135751a8fe439d1961ec1e4e13659da0670b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Aplikacja_webowa___Football.Pages.Match.Views_Match_TournamentTree), @"mvc.1.0.view", @"/Views/Match/TournamentTree.cshtml")]
namespace Aplikacja_webowa___Football.Pages.Match
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
#line 3 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
using Football.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecc3135751a8fe439d1961ec1e4e13659da0670b", @"/Views/Match/TournamentTree.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93fa5087191d699091836c69a50df6a43135b285", @"/Views/_ViewImports.cshtml")]
    public class Views_Match_TournamentTree : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TournamentTreeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"tournament-tree\">\r\n    <div class=\"column\">\r\n");
#nullable restore
#line 6 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
          
            int availableMatchesInQuarterFinal = Model.QuarterFinalMatches.Count;

            for (int i = 0; i < 4; i++)
            {
                if (i < availableMatchesInQuarterFinal)
                {
                    var match = Model.QuarterFinalMatches[i];

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"level\">\r\n                        <div class=\"match\">\r\n                            <div class=\"team-container\">\r\n                                <div class=\"team\">");
#nullable restore
#line 17 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                             Write(match.HomeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            </div>\r\n                            <div class=\"score\">");
#nullable restore
#line 19 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                          Write(match.HomeGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 19 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                                             Write(match.VisitorGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"team-container\">\r\n                                <div class=\"team\">");
#nullable restore
#line 21 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                             Write(match.VisitorId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 25 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""level"">
                        <div class=""match"">
                            <div class=""team-container"">
                                <div class=""team"">Drużyna A</div>
                            </div>
                            <div class=""score"">WYNIK</div>
                            <div class=""team-container"">
                                <div class=""team"">Drużyna B</div>
                            </div>
                        </div>
                    </div>
");
#nullable restore
#line 39 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                }
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n\r\n    <div class=\"column\">\r\n");
#nullable restore
#line 46 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
          
            int totalMatchesInSemiFinal = 2;
            int availableMatchesInSemiFinal = Model.SemiFinalMatches.Count;

            for (int i = 0; i < totalMatchesInSemiFinal; i++)
            {
                if (i < availableMatchesInSemiFinal)
                {
                    var match = Model.SemiFinalMatches[i];

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"level\">\r\n                        <div class=\"match\">\r\n                            <div class=\"team\">");
#nullable restore
#line 57 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                         Write(match.HomeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"score\">");
#nullable restore
#line 58 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                          Write(match.HomeGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 58 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                                             Write(match.VisitorGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"team\">");
#nullable restore
#line 59 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                         Write(match.VisitorId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 62 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""level"">
                        <div class=""match"">
                            <div class=""team"">Drużyna A</div>
                            <div class=""score"">WYNIK</div>
                            <div class=""team"">Drużyna B</div>
                        </div>
                    </div>
");
#nullable restore
#line 72 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                }
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n\r\n    <div class=\"column\">\r\n");
#nullable restore
#line 79 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
         if (Model.FinalMatch == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""level"">
                <div class=""match"">
                    <div class=""team"">Mecz 5</div>
                    <div class=""result"">WYNIK</div>
                    <div class=""team"">Mecz 6</div>
                </div>
            </div>
");
#nullable restore
#line 88 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"level\">\r\n                <div class=\"match\">\r\n                    <div class=\"team\">");
#nullable restore
#line 93 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                 Write(Model.FinalMatch.HomeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"result\">");
#nullable restore
#line 94 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                   Write(Model.FinalMatch.HomeGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 94 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                                                 Write(Model.FinalMatch.VisitorGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"team\">");
#nullable restore
#line 95 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
                                 Write(Model.FinalMatch.VisitorId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 98 "F:\Programowanie\Aplikacja webowa - Football\Aplikacja webowa - Football\Views\Match\TournamentTree.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TournamentTreeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
