#pragma checksum "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Quizes\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a24b9587a8bca4c6f4daf12e7488c860bafdf9cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Quizes_Details), @"mvc.1.0.view", @"/Views/Quizes/Details.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\_ViewImports.cshtml"
using Math;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\_ViewImports.cshtml"
using Math.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a24b9587a8bca4c6f4daf12e7488c860bafdf9cc", @"/Views/Quizes/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51037c4a57b97a33f9a7cb7124b1d362641358d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Quizes_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Quiz>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Quizes\Details.cshtml"
  
    ViewData["Title"] = "Detalhes do Quiz";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row text-center\" style=\"background-color: #F39F0B\">\r\n        <div class=\"col-md-12\" style=\"margin-top: 10px;\">\r\n            <h1>");
#nullable restore
#line 11 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Quizes\Details.cshtml"
           Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        </div>\r\n    </div>\r\n</div>\r\n<table class=\"table table-bordered\">\r\n    <thead class=\"thead-dark\">\r\n        <tr class=\"d-flex\">\r\n            <th scope=\"col\" class=\"col-md-6\">\r\n                ");
#nullable restore
#line 19 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Quizes\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th scope=\"col\" class=\"col-md-5\">\r\n                ");
#nullable restore
#line 22 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Quizes\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Conteudo));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </th>
            <th scope=""col"" class=""col-md-1 text-center"">
                Ações
            </th>
        </tr>
    </thead>
    <tbody>
        <tr scope=""row"" class=""d-flex"">
            <td class=""col-md-6"">
                ");
#nullable restore
#line 32 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Quizes\Details.cshtml"
           Write(Html.DisplayFor(model => model.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td class=\"col-md-5\">\r\n                ");
#nullable restore
#line 35 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Quizes\Details.cshtml"
           Write(Html.DisplayFor(model => model.Conteudo.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td class=\"col-md-1\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-4 text-center\" style=\"padding: 0 20px;\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a24b9587a8bca4c6f4daf12e7488c860bafdf9cc6342", async() => {
                WriteLiteral("<i style=\"font-size: 14pt;\" class=\"fas fa-edit text-warning\" title=\"Editar\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Quizes\Details.cshtml"
                                               WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-md-4 text-center\" style=\"padding: 0 20px;\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a24b9587a8bca4c6f4daf12e7488c860bafdf9cc8728", async() => {
                WriteLiteral("<i style=\"font-size: 14pt;\" class=\"fas fa-arrow-circle-left text-secondary\" title=\"Voltar\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Quiz> Html { get; private set; }
    }
}
#pragma warning restore 1591
